namespace BettingSystem.Forms
{
    partial class ChangePasswordPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            changePasswordBgPanel = new Panel();
            ConfirmationBtntableLayoutPanel = new TableLayoutPanel();
            confirmChangeBtn = new RoundedButton();
            cancelBtn = new RoundedButton();
            emailPassword = new Panel();
            specialCharLbl = new Label();
            upperCaseLbl = new Label();
            numberLbl = new Label();
            characterNumLbl = new Label();
            passwordRequirementsLbl1 = new Label();
            newPasswordPanel = new Panel();
            errorLbl = new Label();
            newPasswordTextbox = new UnderlineTextBox();
            newPasswordLbl = new Label();
            currentPasswordPanel = new Panel();
            currentPasswordTextbox = new UnderlineTextBox();
            currentPasswordLbl = new Label();
            changePasswordLbl = new Label();
            changePasswordBgPanel.SuspendLayout();
            ConfirmationBtntableLayoutPanel.SuspendLayout();
            emailPassword.SuspendLayout();
            newPasswordPanel.SuspendLayout();
            currentPasswordPanel.SuspendLayout();
            SuspendLayout();
            // 
            // changePasswordBgPanel
            // 
            changePasswordBgPanel.BackColor = Color.FromArgb(36, 36, 36);
            changePasswordBgPanel.Controls.Add(ConfirmationBtntableLayoutPanel);
            changePasswordBgPanel.Controls.Add(emailPassword);
            changePasswordBgPanel.Controls.Add(newPasswordPanel);
            changePasswordBgPanel.Controls.Add(currentPasswordPanel);
            changePasswordBgPanel.Controls.Add(changePasswordLbl);
            changePasswordBgPanel.Dock = DockStyle.Fill;
            changePasswordBgPanel.Location = new Point(0, 0);
            changePasswordBgPanel.Name = "changePasswordBgPanel";
            changePasswordBgPanel.Padding = new Padding(15, 10, 15, 10);
            changePasswordBgPanel.Size = new Size(574, 428);
            changePasswordBgPanel.TabIndex = 1;
            // 
            // ConfirmationBtntableLayoutPanel
            // 
            ConfirmationBtntableLayoutPanel.ColumnCount = 2;
            ConfirmationBtntableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ConfirmationBtntableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ConfirmationBtntableLayoutPanel.Controls.Add(confirmChangeBtn, 1, 0);
            ConfirmationBtntableLayoutPanel.Controls.Add(cancelBtn, 0, 0);
            ConfirmationBtntableLayoutPanel.Dock = DockStyle.Fill;
            ConfirmationBtntableLayoutPanel.Location = new Point(15, 342);
            ConfirmationBtntableLayoutPanel.Name = "ConfirmationBtntableLayoutPanel";
            ConfirmationBtntableLayoutPanel.RowCount = 1;
            ConfirmationBtntableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ConfirmationBtntableLayoutPanel.Size = new Size(544, 76);
            ConfirmationBtntableLayoutPanel.TabIndex = 5;
            // 
            // confirmChangeBtn
            // 
            confirmChangeBtn.Anchor = AnchorStyles.None;
            confirmChangeBtn.BackColor = Color.FromArgb(93, 185, 64);
            confirmChangeBtn.CornerRadius = 12;
            confirmChangeBtn.Cursor = Cursors.Hand;
            confirmChangeBtn.FlatAppearance.BorderSize = 0;
            confirmChangeBtn.FlatStyle = FlatStyle.Flat;
            confirmChangeBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirmChangeBtn.ForeColor = Color.FromArgb(241, 241, 241);
            confirmChangeBtn.Location = new Point(325, 15);
            confirmChangeBtn.Name = "confirmChangeBtn";
            confirmChangeBtn.Size = new Size(165, 45);
            confirmChangeBtn.TabIndex = 1;
            confirmChangeBtn.TabStop = false;
            confirmChangeBtn.Text = "Change Password";
            confirmChangeBtn.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.None;
            cancelBtn.BackColor = Color.FromArgb(241, 241, 241);
            cancelBtn.CornerRadius = 12;
            cancelBtn.Cursor = Cursors.Hand;
            cancelBtn.FlatAppearance.BorderSize = 0;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.FromArgb(26, 26, 26);
            cancelBtn.Location = new Point(53, 15);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(165, 45);
            cancelBtn.TabIndex = 0;
            cancelBtn.TabStop = false;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            // 
            // emailPassword
            // 
            emailPassword.Controls.Add(specialCharLbl);
            emailPassword.Controls.Add(upperCaseLbl);
            emailPassword.Controls.Add(numberLbl);
            emailPassword.Controls.Add(characterNumLbl);
            emailPassword.Controls.Add(passwordRequirementsLbl1);
            emailPassword.Dock = DockStyle.Top;
            emailPassword.Location = new Point(15, 214);
            emailPassword.Name = "emailPassword";
            emailPassword.Padding = new Padding(0, 0, 0, 20);
            emailPassword.Size = new Size(544, 128);
            emailPassword.TabIndex = 4;
            // 
            // specialCharLbl
            // 
            specialCharLbl.Dock = DockStyle.Top;
            specialCharLbl.Font = new Font("Times New Roman", 10.125F);
            specialCharLbl.ForeColor = Color.FromArgb(241, 241, 241);
            specialCharLbl.Location = new Point(0, 96);
            specialCharLbl.Name = "specialCharLbl";
            specialCharLbl.Padding = new Padding(15, 0, 0, 0);
            specialCharLbl.Size = new Size(544, 24);
            specialCharLbl.TabIndex = 4;
            specialCharLbl.Text = "* At least 1 special character";
            specialCharLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // upperCaseLbl
            // 
            upperCaseLbl.Dock = DockStyle.Top;
            upperCaseLbl.Font = new Font("Times New Roman", 10.125F);
            upperCaseLbl.ForeColor = Color.FromArgb(241, 241, 241);
            upperCaseLbl.Location = new Point(0, 72);
            upperCaseLbl.Name = "upperCaseLbl";
            upperCaseLbl.Padding = new Padding(15, 0, 0, 0);
            upperCaseLbl.Size = new Size(544, 24);
            upperCaseLbl.TabIndex = 3;
            upperCaseLbl.Text = "* At least 1 upper case letter";
            upperCaseLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numberLbl
            // 
            numberLbl.Dock = DockStyle.Top;
            numberLbl.Font = new Font("Times New Roman", 10.125F);
            numberLbl.ForeColor = Color.FromArgb(241, 241, 241);
            numberLbl.Location = new Point(0, 48);
            numberLbl.Name = "numberLbl";
            numberLbl.Padding = new Padding(15, 0, 0, 0);
            numberLbl.Size = new Size(544, 24);
            numberLbl.TabIndex = 2;
            numberLbl.Text = "* At least 1 number";
            numberLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // characterNumLbl
            // 
            characterNumLbl.Dock = DockStyle.Top;
            characterNumLbl.Font = new Font("Times New Roman", 10.125F);
            characterNumLbl.ForeColor = Color.FromArgb(241, 241, 241);
            characterNumLbl.Location = new Point(0, 24);
            characterNumLbl.Name = "characterNumLbl";
            characterNumLbl.Padding = new Padding(15, 0, 0, 0);
            characterNumLbl.Size = new Size(544, 24);
            characterNumLbl.TabIndex = 1;
            characterNumLbl.Text = "* At least 8 characters";
            characterNumLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // passwordRequirementsLbl1
            // 
            passwordRequirementsLbl1.Dock = DockStyle.Top;
            passwordRequirementsLbl1.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordRequirementsLbl1.ForeColor = Color.FromArgb(241, 241, 241);
            passwordRequirementsLbl1.Location = new Point(0, 0);
            passwordRequirementsLbl1.Name = "passwordRequirementsLbl1";
            passwordRequirementsLbl1.Size = new Size(544, 24);
            passwordRequirementsLbl1.TabIndex = 0;
            passwordRequirementsLbl1.Text = "Password must contain:";
            passwordRequirementsLbl1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // newPasswordPanel
            // 
            newPasswordPanel.Controls.Add(errorLbl);
            newPasswordPanel.Controls.Add(newPasswordTextbox);
            newPasswordPanel.Controls.Add(newPasswordLbl);
            newPasswordPanel.Dock = DockStyle.Top;
            newPasswordPanel.Location = new Point(15, 145);
            newPasswordPanel.Name = "newPasswordPanel";
            newPasswordPanel.Padding = new Padding(0, 0, 0, 20);
            newPasswordPanel.Size = new Size(544, 69);
            newPasswordPanel.TabIndex = 3;
            // 
            // errorLbl
            // 
            errorLbl.AutoSize = true;
            errorLbl.Font = new Font("Times New Roman", 9F);
            errorLbl.ForeColor = Color.Firebrick;
            errorLbl.Location = new Point(3, 51);
            errorLbl.Name = "errorLbl";
            errorLbl.Size = new Size(35, 15);
            errorLbl.TabIndex = 2;
            errorLbl.Text = "label1";
            errorLbl.Visible = false;
            // 
            // newPasswordTextbox
            // 
            newPasswordTextbox.BackColor = Color.FromArgb(36, 36, 36);
            newPasswordTextbox.BorderStyle = BorderStyle.None;
            newPasswordTextbox.Dock = DockStyle.Bottom;
            newPasswordTextbox.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newPasswordTextbox.ForeColor = Color.White;
            newPasswordTextbox.Location = new Point(0, 32);
            newPasswordTextbox.Name = "newPasswordTextbox";
            newPasswordTextbox.PasswordChar = '*';
            newPasswordTextbox.Size = new Size(544, 17);
            newPasswordTextbox.TabIndex = 1;
            newPasswordTextbox.TextChanged += txtPassword_TextChanged;
            // 
            // newPasswordLbl
            // 
            newPasswordLbl.Dock = DockStyle.Top;
            newPasswordLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            newPasswordLbl.ForeColor = Color.FromArgb(241, 241, 241);
            newPasswordLbl.ImageAlign = ContentAlignment.MiddleLeft;
            newPasswordLbl.Location = new Point(0, 0);
            newPasswordLbl.Name = "newPasswordLbl";
            newPasswordLbl.Size = new Size(544, 23);
            newPasswordLbl.TabIndex = 0;
            newPasswordLbl.Text = "Enter New Password";
            newPasswordLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // currentPasswordPanel
            // 
            currentPasswordPanel.Controls.Add(currentPasswordTextbox);
            currentPasswordPanel.Controls.Add(currentPasswordLbl);
            currentPasswordPanel.Dock = DockStyle.Top;
            currentPasswordPanel.Location = new Point(15, 76);
            currentPasswordPanel.Name = "currentPasswordPanel";
            currentPasswordPanel.Padding = new Padding(0, 0, 0, 20);
            currentPasswordPanel.Size = new Size(544, 69);
            currentPasswordPanel.TabIndex = 2;
            // 
            // currentPasswordTextbox
            // 
            currentPasswordTextbox.BackColor = Color.FromArgb(36, 36, 36);
            currentPasswordTextbox.BorderStyle = BorderStyle.None;
            currentPasswordTextbox.Dock = DockStyle.Bottom;
            currentPasswordTextbox.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentPasswordTextbox.ForeColor = Color.White;
            currentPasswordTextbox.Location = new Point(0, 32);
            currentPasswordTextbox.Name = "currentPasswordTextbox";
            currentPasswordTextbox.PasswordChar = '*';
            currentPasswordTextbox.Size = new Size(544, 17);
            currentPasswordTextbox.TabIndex = 1;
            // 
            // currentPasswordLbl
            // 
            currentPasswordLbl.Dock = DockStyle.Top;
            currentPasswordLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            currentPasswordLbl.ForeColor = Color.FromArgb(241, 241, 241);
            currentPasswordLbl.ImageAlign = ContentAlignment.MiddleLeft;
            currentPasswordLbl.Location = new Point(0, 0);
            currentPasswordLbl.Name = "currentPasswordLbl";
            currentPasswordLbl.Size = new Size(544, 23);
            currentPasswordLbl.TabIndex = 0;
            currentPasswordLbl.Text = "Enter Current Password";
            currentPasswordLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // changePasswordLbl
            // 
            changePasswordLbl.Dock = DockStyle.Top;
            changePasswordLbl.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changePasswordLbl.ForeColor = Color.FromArgb(241, 241, 241);
            changePasswordLbl.Location = new Point(15, 10);
            changePasswordLbl.Name = "changePasswordLbl";
            changePasswordLbl.Size = new Size(544, 66);
            changePasswordLbl.TabIndex = 0;
            changePasswordLbl.Text = "Change Password";
            changePasswordLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ChangePasswordPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 428);
            Controls.Add(changePasswordBgPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ChangePasswordPopup";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ChangePasswordPopup";
            changePasswordBgPanel.ResumeLayout(false);
            ConfirmationBtntableLayoutPanel.ResumeLayout(false);
            emailPassword.ResumeLayout(false);
            newPasswordPanel.ResumeLayout(false);
            newPasswordPanel.PerformLayout();
            currentPasswordPanel.ResumeLayout(false);
            currentPasswordPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel changePasswordBgPanel;
        private TableLayoutPanel ConfirmationBtntableLayoutPanel;
        private RoundedButton confirmChangeBtn;
        private RoundedButton cancelBtn;
        private Panel emailPassword;
        private Panel newPasswordPanel;
        private UnderlineTextBox newPasswordTextbox;
        private Label newPasswordLbl;
        private Panel currentPasswordPanel;
        private UnderlineTextBox currentPasswordTextbox;
        private Label currentPasswordLbl;
        private Label changePasswordLbl;
        private Label passwordRequirementsLbl1;
        private Label specialCharLbl;
        private Label upperCaseLbl;
        private Label numberLbl;
        private Label characterNumLbl;
        private Label errorLbl;
    }
}