using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ACHEmailConfirm
{
    public partial class Form1 : Form
    {
        private string _currentFilePath;
        private const string ACH_FILES_FOLDER = "ACH Files";

        public Form1()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.Text = "ACH Email Confirmation";

            // Set default file path to Downloads folder
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string defaultFile = Path.Combine(downloadsPath, "PayrollACH.TXT");
            txtFileName.Text = defaultFile;

            // Set default email addresses
            txtSendingEmail.Text = "CantaWells@FBCMandeville.org";
            txtRecipientEmail.Text = "ACH@CBTBanking.com";

            // Try to load and parse the default file
            LoadAndParseFile(defaultFile);
        }

        private void LoadAndParseFile(string filePath)
        {
            _currentFilePath = filePath;

            if (!File.Exists(filePath))
            {
                lblStatus.Text = $"File not found: {Path.GetFileName(filePath)}. Click OPEN to select a file.";
                lblStatus.ForeColor = Color.Red;
                ClearFields();
                return;
            }

            try
            {
                var achData = ParseACHFile(filePath);

                // Populate form fields
                txtCompanyName.Text = achData.CompanyName;
                txtTotalACH.Text = achData.TotalACH.ToString("C");
                txtNumberOfCredits.Text = achData.NumberOfCredits.ToString();
                txtEffectiveDate.Text = achData.EffectiveDate.ToString("MM/dd/yyyy");

                // Update subject line
                txtSubject.Text = $"Confirming ACH Batch '{achData.CompanyName}'";

                // Update body
                txtBody.Text = $"{achData.TotalACH:C}\r\n{achData.NumberOfCredits} credits\r\neffective {achData.EffectiveDate:MM/dd/yyyy}";

                lblStatus.Text = $"File loaded successfully: {Path.GetFileName(filePath)}";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error parsing file: {ex.Message}";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show($"Error parsing ACH file:\r\n{ex.Message}", "Parse Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ACHData ParseACHFile(string filePath)
        {
            var achData = new ACHData();
            int creditCount = 0;

            foreach (string line in File.ReadLines(filePath))
            {
                if (line.Length < 3) continue;

                string recordCode = line.Substring(0, 1);
                string recordType = line.Substring(0, 3);

                // Record Code 5 (Batch Header - position 520)
                if (recordCode == "5" && line.Length >= 75)
                {
                    // Company Name: columns 5-40 (0-based: 4-39)
                    if (line.Length >= 40)
                    {
                        achData.CompanyName = line.Substring(4, 36).Trim();
                    }

                    // Effective Date: columns 70-75 (0-based: 69-74) - YYMMDD format
                    if (line.Length >= 75)
                    {
                        string effectiveDateStr = line.Substring(69, 6);
                        if (int.TryParse(effectiveDateStr, out int yymmdd))
                        {
                            int yy = yymmdd / 10000;
                            int mm = (yymmdd / 100) % 100;
                            int dd = yymmdd % 100;
                            achData.EffectiveDate = new DateTime(2000 + yy, mm, dd);
                        }
                    }
                }

                // Record Code 6 (Entry Detail - 622 for credits)
                if (recordCode == "6" && line.Length >= 3)
                {
                    string transactionCode = line.Substring(1, 2);
                    if (transactionCode == "22") // Credit
                    {
                        creditCount++;
                    }
                }

                // Record Code 9 (File Control - 900)
                if (recordType == "900" && line.Length >= 55)
                {
                    // Total ACH: columns 46-55 (0-based: 45-54) - format 9(8)v99
                    string totalStr = line.Substring(45, 10);
                    if (long.TryParse(totalStr, out long totalCents))
                    {
                        achData.TotalACH = totalCents / 100.0m;
                    }
                }
            }

            achData.NumberOfCredits = creditCount;
            return achData;
        }

        private void ClearFields()
        {
            txtCompanyName.Text = "";
            txtTotalACH.Text = "";
            txtNumberOfCredits.Text = "";
            txtEffectiveDate.Text = "";
            txtSubject.Text = "";
            txtBody.Text = "";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "Select ACH File";
                openFileDialog.InitialDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = openFileDialog.FileName;
                    LoadAndParseFile(openFileDialog.FileName);
                }
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            // Validate file exists
            if (!File.Exists(_currentFilePath))
            {
                MessageBox.Show("The ACH file does not exist. Please select a valid file.",
                    "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate email fields
            if (string.IsNullOrWhiteSpace(txtSendingEmail.Text) ||
                string.IsNullOrWhiteSpace(txtRecipientEmail.Text))
            {
                MessageBox.Show("Please provide both sending and recipient email addresses.",
                    "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Disable send button during operation
            btnSend.Enabled = false;
            lblStatus.Text = "Sending email...";
            lblStatus.ForeColor = Color.Blue;

            try
            {
                // Send email
                bool emailSent = await SendEmailAsync();

                if (emailSent)
                {
                    lblStatus.Text = "Email sent successfully! Moving file...";

                    // Move and rename file
                    MoveAndRenameFile();

                    lblStatus.Text = "Email sent and file archived successfully!";
                    lblStatus.ForeColor = Color.Green;

                    MessageBox.Show("ACH confirmation email sent successfully!\r\nFile has been archived.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear form for next use
                    ClearFields();
                    txtFileName.Text = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                        "Downloads", "PayrollACH.TXT");
                    _currentFilePath = txtFileName.Text;
                }
                else
                {
                    lblStatus.Text = "Email send failed. File not moved.";
                    lblStatus.ForeColor = Color.Red;

                    var result = MessageBox.Show("Failed to send email. Would you like to retry?",
                        "Send Failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (result == DialogResult.Yes)
                    {
                        btnSend.Enabled = true;
                        btnSend_Click(sender, e); // Retry
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error occurred. File not moved.";
                lblStatus.ForeColor = Color.Red;

                var result = MessageBox.Show($"Error: {ex.Message}\r\n\r\nWould you like to retry?",
                    "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (result == DialogResult.Yes)
                {
                    btnSend.Enabled = true;
                    btnSend_Click(sender, e); // Retry
                    return;
                }
            }
            finally
            {
                btnSend.Enabled = true;
            }
        }

        private async Task<bool> SendEmailAsync()
        {
            try
            {
                // Get SMTP settings from App.config
                string smtpHost = ConfigurationManager.AppSettings["SmtpHost"] ?? "smtp.gmail.com";
                int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"] ?? "587");

                // Get email password from App.config.user
                string fromPassword = string.Empty;
                // Note. this basedirectory is in the debug/release folder, so we need to look for App.config.user there
                var userConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.config.user");
                if (File.Exists(userConfigPath))
                {
                    try
                    {
                        var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = userConfigPath };
                        var userConfig = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                        fromPassword = userConfig.AppSettings.Settings["SecureEmailPassword"]?.Value ?? string.Empty;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error reading App.config.user: {ex.Message}",
                            "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (string.IsNullOrEmpty(fromPassword))
                {
                    MessageBox.Show("Email password not configured. Please check App.config.user file.",
                        "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                using var smtpClient = new SmtpClient(smtpHost)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(txtSendingEmail.Text, fromPassword),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(txtSendingEmail.Text, "FBC Payroll"),
                    Subject = txtSubject.Text,
                    Body = txtBody.Text,
                    IsBodyHtml = false
                };

                mailMessage.To.Add(txtRecipientEmail.Text);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Email send error:\r\n{ex.Message}", "Email Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void MoveAndRenameFile()
        {
            // Create ACH Files folder in Documents if it doesn't exist
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string achFilesPath = Path.Combine(documentsPath, ACH_FILES_FOLDER);

            if (!Directory.Exists(achFilesPath))
            {
                Directory.CreateDirectory(achFilesPath);
            }

            // Parse values for new filename
            string companyName = txtCompanyName.Text.Trim();
            DateTime effectiveDate = DateTime.Parse(txtEffectiveDate.Text);

            // Create new filename: '<companyName> <effectiveDate> Payroll ACH.txt'
            string newFileName = $"{companyName} {effectiveDate:yyyyMMdd} Payroll ACH.txt";
            string newFilePath = Path.Combine(achFilesPath, newFileName);

            // Check if file already exists
            if (File.Exists(newFilePath))
            {
                var result = MessageBox.Show(
                    $"A file with this name already exists:\r\n{newFileName}\r\n\r\nOverwrite?",
                    "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    // Append timestamp to make unique
                    newFileName = $"{companyName} {effectiveDate:yyyyMMdd} Payroll ACH_{DateTime.Now:HHmmss}.txt";
                    newFilePath = Path.Combine(achFilesPath, newFileName);
                }
            }

            // Move file (this removes from source location)
            File.Move(_currentFilePath, newFilePath, true);

            MessageBox.Show($"File archived to:\r\n{newFilePath}", "File Archived",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            // Auto-load when filename is changed manually
            if (File.Exists(txtFileName.Text))
            {
                LoadAndParseFile(txtFileName.Text);
            }
        }
    }

    public class ACHData
    {
        public string CompanyName { get; set; } = "";
        public decimal TotalACH { get; set; }
        public int NumberOfCredits { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}