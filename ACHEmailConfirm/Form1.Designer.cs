namespace ACHEmailConfirm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.grpFileInfo = new System.Windows.Forms.GroupBox();
            this.txtEffectiveDate = new System.Windows.Forms.TextBox();
            this.lblEffectiveDate = new System.Windows.Forms.Label();
            this.txtNumberOfCredits = new System.Windows.Forms.TextBox();
            this.lblNumberOfCredits = new System.Windows.Forms.Label();
            this.txtTotalACH = new System.Windows.Forms.TextBox();
            this.lblTotalACH = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.grpEmail = new System.Windows.Forms.GroupBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtRecipientEmail = new System.Windows.Forms.TextBox();
            this.lblRecipientEmail = new System.Windows.Forms.Label();
            this.txtSendingEmail = new System.Windows.Forms.TextBox();
            this.lblSendingEmail = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpFileInfo.SuspendLayout();
            this.grpEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 15);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(60, 15);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "File Name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(12, 33);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(460, 23);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(478, 32);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 25);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "OPEN";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // grpFileInfo
            // 
            this.grpFileInfo.Controls.Add(this.txtEffectiveDate);
            this.grpFileInfo.Controls.Add(this.lblEffectiveDate);
            this.grpFileInfo.Controls.Add(this.txtNumberOfCredits);
            this.grpFileInfo.Controls.Add(this.lblNumberOfCredits);
            this.grpFileInfo.Controls.Add(this.txtTotalACH);
            this.grpFileInfo.Controls.Add(this.lblTotalACH);
            this.grpFileInfo.Controls.Add(this.txtCompanyName);
            this.grpFileInfo.Controls.Add(this.lblCompanyName);
            this.grpFileInfo.Location = new System.Drawing.Point(12, 70);
            this.grpFileInfo.Name = "grpFileInfo";
            this.grpFileInfo.Size = new System.Drawing.Size(541, 140);
            this.grpFileInfo.TabIndex = 3;
            this.grpFileInfo.TabStop = false;
            this.grpFileInfo.Text = "ACH File Information";
            // 
            // txtEffectiveDate
            // 
            this.txtEffectiveDate.Location = new System.Drawing.Point(130, 103);
            this.txtEffectiveDate.Name = "txtEffectiveDate";
            this.txtEffectiveDate.Size = new System.Drawing.Size(200, 23);
            this.txtEffectiveDate.TabIndex = 7;
            // 
            // lblEffectiveDate
            // 
            this.lblEffectiveDate.AutoSize = true;
            this.lblEffectiveDate.Location = new System.Drawing.Point(15, 106);
            this.lblEffectiveDate.Name = "lblEffectiveDate";
            this.lblEffectiveDate.Size = new System.Drawing.Size(83, 15);
            this.lblEffectiveDate.TabIndex = 6;
            this.lblEffectiveDate.Text = "Effective Date:";
            // 
            // txtNumberOfCredits
            // 
            this.txtNumberOfCredits.Location = new System.Drawing.Point(130, 74);
            this.txtNumberOfCredits.Name = "txtNumberOfCredits";
            this.txtNumberOfCredits.Size = new System.Drawing.Size(100, 23);
            this.txtNumberOfCredits.TabIndex = 5;
            // 
            // lblNumberOfCredits
            // 
            this.lblNumberOfCredits.AutoSize = true;
            this.lblNumberOfCredits.Location = new System.Drawing.Point(15, 77);
            this.lblNumberOfCredits.Name = "lblNumberOfCredits";
            this.lblNumberOfCredits.Size = new System.Drawing.Size(113, 15);
            this.lblNumberOfCredits.TabIndex = 4;
            this.lblNumberOfCredits.Text = "Number of Credits:";
            // 
            // txtTotalACH
            // 
            this.txtTotalACH.Location = new System.Drawing.Point(130, 45);
            this.txtTotalACH.Name = "txtTotalACH";
            this.txtTotalACH.Size = new System.Drawing.Size(150, 23);
            this.txtTotalACH.TabIndex = 3;
            // 
            // lblTotalACH
            // 
            this.lblTotalACH.AutoSize = true;
            this.lblTotalACH.Location = new System.Drawing.Point(15, 48);
            this.lblTotalACH.Name = "lblTotalACH";
            this.lblTotalACH.Size = new System.Drawing.Size(63, 15);
            this.lblTotalACH.TabIndex = 2;
            this.lblTotalACH.Text = "Total ACH:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(130, 16);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(300, 23);
            this.txtCompanyName.TabIndex = 1;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(15, 19);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(97, 15);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "Company Name:";
            // 
            // grpEmail
            // 
            this.grpEmail.Controls.Add(this.txtBody);
            this.grpEmail.Controls.Add(this.lblBody);
            this.grpEmail.Controls.Add(this.txtSubject);
            this.grpEmail.Controls.Add(this.lblSubject);
            this.grpEmail.Controls.Add(this.txtRecipientEmail);
            this.grpEmail.Controls.Add(this.lblRecipientEmail);
            this.grpEmail.Controls.Add(this.txtSendingEmail);
            this.grpEmail.Controls.Add(this.lblSendingEmail);
            this.grpEmail.Location = new System.Drawing.Point(12, 216);
            this.grpEmail.Name = "grpEmail";
            this.grpEmail.Size = new System.Drawing.Size(541, 240);
            this.grpEmail.TabIndex = 4;
            this.grpEmail.TabStop = false;
            this.grpEmail.Text = "Email Configuration";
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(130, 132);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(390, 90);
            this.txtBody.TabIndex = 7;
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(15, 135);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(38, 15);
            this.lblBody.TabIndex = 6;
            this.lblBody.Text = "Body:";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(130, 103);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(390, 23);
            this.txtSubject.TabIndex = 5;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(15, 106);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(49, 15);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Subject:";
            // 
            // txtRecipientEmail
            // 
            this.txtRecipientEmail.Location = new System.Drawing.Point(130, 45);
            this.txtRecipientEmail.Name = "txtRecipientEmail";
            this.txtRecipientEmail.Size = new System.Drawing.Size(300, 23);
            this.txtRecipientEmail.TabIndex = 3;
            // 
            // lblRecipientEmail
            // 
            this.lblRecipientEmail.AutoSize = true;
            this.lblRecipientEmail.Location = new System.Drawing.Point(15, 48);
            this.lblRecipientEmail.Name = "lblRecipientEmail";
            this.lblRecipientEmail.Size = new System.Drawing.Size(92, 15);
            this.lblRecipientEmail.TabIndex = 2;
            this.lblRecipientEmail.Text = "Recipient Email:";
            // 
            // txtSendingEmail
            // 
            this.txtSendingEmail.Location = new System.Drawing.Point(130, 16);
            this.txtSendingEmail.Name = "txtSendingEmail";
            this.txtSendingEmail.Size = new System.Drawing.Size(300, 23);
            this.txtSendingEmail.TabIndex = 1;
            // 
            // lblSendingEmail
            // 
            this.lblSendingEmail.AutoSize = true;
            this.lblSendingEmail.Location = new System.Drawing.Point(15, 19);
            this.lblSendingEmail.Name = "lblSendingEmail";
            this.lblSendingEmail.Size = new System.Drawing.Size(87, 15);
            this.lblSendingEmail.TabIndex = 0;
            this.lblSendingEmail.Text = "Sending Email:";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(316, 490);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(110, 35);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(443, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.Location = new System.Drawing.Point(12, 462);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 15);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Ready";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 537);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.grpEmail);
            this.Controls.Add(this.grpFileInfo);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACH Email Confirmation";
            this.grpFileInfo.ResumeLayout(false);
            this.grpFileInfo.PerformLayout();
            this.grpEmail.ResumeLayout(false);
            this.grpEmail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.GroupBox grpFileInfo;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtTotalACH;
        private System.Windows.Forms.Label lblTotalACH;
        private System.Windows.Forms.TextBox txtNumberOfCredits;
        private System.Windows.Forms.Label lblNumberOfCredits;
        private System.Windows.Forms.TextBox txtEffectiveDate;
        private System.Windows.Forms.Label lblEffectiveDate;
        private System.Windows.Forms.GroupBox grpEmail;
        private System.Windows.Forms.TextBox txtSendingEmail;
        private System.Windows.Forms.Label lblSendingEmail;
        private System.Windows.Forms.TextBox txtRecipientEmail;
        private System.Windows.Forms.Label lblRecipientEmail;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;
    }
}