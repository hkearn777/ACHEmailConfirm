# ACH Email Confirmation Tool

Windows Forms application to send ACH confirmation emails and archive ACH files.

## Setup Instructions

### 1. Install NuGet Package


### 2. Configure Email Password

Create a file named `App.config.user` in the project root:

**IMPORTANT**: This file is ignored by Git and will NOT be committed.

### 3. Google App Password

Generate a Google App Password for `CantaWells@FBCMandeville.org`:
1. Go to: https://myaccount.google.com/apppasswords
2. Create a new app password named "ACH Email Tool"
3. Copy the 16-character password
4. Paste it into `App.config.user`

### 4. Build and Run

## Features

- Automatically parses NACHA format ACH files
- Extracts company name, total amount, credit count, and effective date
- Sends confirmation email to bank
- Archives processed files to `Documents\ACH Files`
- Retry functionality on email send failure
- All fields are editable before sending

## File Processing

1. Default location: `Downloads\PayrollACH.TXT`
2. After successful email: File moved to `Documents\ACH Files\<CompanyName> <EffectiveDate> Payroll ACH.txt`
3. If email fails: File remains in original location

## Security

- Email password stored in `App.config.user` (not tracked in Git)
- Never commit passwords to source control