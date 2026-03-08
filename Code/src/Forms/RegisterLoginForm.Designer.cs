using BettingSystem.Forms.Properties;

namespace BettingSystem.Forms
{
    partial class RegisterLoginForm : BaseForm
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
            pnlContainer = new RoundedPanel();
            pnlSignUpRight = new Panel();
            dtpDOB = new DateTimePicker();
            btnSignUp = new RoundedButton();
            chk18 = new CheckBox();
            lblCritSpec = new Label();
            lblCritUpper = new Label();
            lblCritNum = new Label();
            lblCritLen = new Label();
            lblPasswordInfo = new Label();
            txtSignUpPassword = new UnderlineTextBox();
            txtSignUpEmail = new UnderlineTextBox();
            txtLastName = new UnderlineTextBox();
            txtFirstName = new UnderlineTextBox();
            lblPassword = new Label();
            lblSignUpEmail = new Label();
            lblDOB = new Label();
            lblLastName = new Label();
            lblFirstName = new Label();
            lblCreate = new Label();
            pnlLoginRight = new Panel();
            lnkToSignUp = new LinkLabel();
            lblPrompt = new Label();
            lblReady = new Label();
            piclogoLogin = new PictureBox();
            lblWelcomeBack = new Label();
            pnlSignupLeft = new Panel();
            lnkToLogin = new LinkLabel();
            lblAccount = new Label();
            lblSignupJoin = new Label();
            picLogoSignup = new PictureBox();
            lblSignupWelcome = new Label();
            pnlLoginLeft = new Panel();
            btnLogin = new RoundedButton();
            txtLoginPassword = new UnderlineTextBox();
            lblLoginPassword = new Label();
            txtLoginEmail = new UnderlineTextBox();
            lblLoginEmail = new Label();
            lblLogin = new Label();
            backButton = new PictureBox();
            pnlContainer.SuspendLayout();
            pnlSignUpRight.SuspendLayout();
            pnlLoginRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)piclogoLogin).BeginInit();
            pnlSignupLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoSignup).BeginInit();
            pnlLoginLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backButton).BeginInit();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.Transparent;
            pnlContainer.Controls.Add(pnlSignUpRight);
            pnlContainer.Controls.Add(pnlLoginRight);
            pnlContainer.Controls.Add(pnlSignupLeft);
            pnlContainer.Controls.Add(pnlLoginLeft);
            pnlContainer.Location = new Point(41, 41);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1100, 620);
            pnlContainer.TabIndex = 0;
            // 
            // pnlSignUpRight
            // 
            pnlSignUpRight.BackColor = Color.FromArgb(48, 48, 48);
            pnlSignUpRight.Controls.Add(dtpDOB);
            pnlSignUpRight.Controls.Add(btnSignUp);
            pnlSignUpRight.Controls.Add(chk18);
            pnlSignUpRight.Controls.Add(lblCritSpec);
            pnlSignUpRight.Controls.Add(lblCritUpper);
            pnlSignUpRight.Controls.Add(lblCritNum);
            pnlSignUpRight.Controls.Add(lblCritLen);
            pnlSignUpRight.Controls.Add(lblPasswordInfo);
            pnlSignUpRight.Controls.Add(txtSignUpPassword);
            pnlSignUpRight.Controls.Add(txtSignUpEmail);
            pnlSignUpRight.Controls.Add(txtLastName);
            pnlSignUpRight.Controls.Add(txtFirstName);
            pnlSignUpRight.Controls.Add(lblPassword);
            pnlSignUpRight.Controls.Add(lblSignUpEmail);
            pnlSignUpRight.Controls.Add(lblDOB);
            pnlSignUpRight.Controls.Add(lblLastName);
            pnlSignUpRight.Controls.Add(lblFirstName);
            pnlSignUpRight.Controls.Add(lblCreate);
            pnlSignUpRight.Location = new Point(550, 0);
            pnlSignUpRight.Name = "pnlSignUpRight";
            pnlSignUpRight.Size = new Size(550, 620);
            pnlSignUpRight.TabIndex = 0;
            // 
            // dtpDOB
            // 
            dtpDOB.CalendarFont = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            dtpDOB.CalendarMonthBackground = Color.Transparent;
            dtpDOB.Font = new Font("Times New Roman", 10.8F);
            dtpDOB.Location = new Point(115, 221);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(320, 28);
            dtpDOB.TabIndex = 17;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.FromArgb(93, 185, 64);
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSignUp.ForeColor = Color.FromArgb(241, 241, 241);
            btnSignUp.Location = new Point(173, 563);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(180, 45);
            btnSignUp.TabIndex = 16;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // chk18
            // 
            chk18.AutoSize = true;
            chk18.BackColor = Color.Transparent;
            chk18.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            chk18.ForeColor = Color.FromArgb(241, 241, 241);
            chk18.Location = new Point(115, 521);
            chk18.Name = "chk18";
            chk18.Size = new Size(330, 26);
            chk18.TabIndex = 15;
            chk18.Text = "I confirm that I am 18 years or older";
            chk18.UseVisualStyleBackColor = false;
            // 
            // lblCritSpec
            // 
            lblCritSpec.AutoSize = true;
            lblCritSpec.BackColor = Color.Transparent;
            lblCritSpec.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            lblCritSpec.ForeColor = Color.FromArgb(241, 241, 241);
            lblCritSpec.Location = new Point(114, 482);
            lblCritSpec.Name = "lblCritSpec";
            lblCritSpec.Size = new Size(196, 17);
            lblCritSpec.TabIndex = 14;
            lblCritSpec.Text = "* At least 1 special character";
            // 
            // lblCritUpper
            // 
            lblCritUpper.AutoSize = true;
            lblCritUpper.BackColor = Color.Transparent;
            lblCritUpper.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            lblCritUpper.ForeColor = Color.FromArgb(241, 241, 241);
            lblCritUpper.Location = new Point(115, 459);
            lblCritUpper.Name = "lblCritUpper";
            lblCritUpper.Size = new Size(197, 17);
            lblCritUpper.TabIndex = 13;
            lblCritUpper.Text = "* At least 1 upper case letter";
            // 
            // lblCritNum
            // 
            lblCritNum.AutoSize = true;
            lblCritNum.BackColor = Color.Transparent;
            lblCritNum.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            lblCritNum.ForeColor = Color.FromArgb(241, 241, 241);
            lblCritNum.Location = new Point(115, 436);
            lblCritNum.Name = "lblCritNum";
            lblCritNum.Size = new Size(136, 17);
            lblCritNum.TabIndex = 12;
            lblCritNum.Text = "* At least 1 number";
            // 
            // lblCritLen
            // 
            lblCritLen.AutoSize = true;
            lblCritLen.BackColor = Color.Transparent;
            lblCritLen.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            lblCritLen.ForeColor = Color.FromArgb(241, 241, 241);
            lblCritLen.Location = new Point(115, 413);
            lblCritLen.Name = "lblCritLen";
            lblCritLen.Size = new Size(154, 17);
            lblCritLen.TabIndex = 11;
            lblCritLen.Text = "* At least 8 characters";
            // 
            // lblPasswordInfo
            // 
            lblPasswordInfo.AutoSize = true;
            lblPasswordInfo.BackColor = Color.Transparent;
            lblPasswordInfo.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblPasswordInfo.ForeColor = Color.FromArgb(241, 241, 241);
            lblPasswordInfo.Location = new Point(115, 390);
            lblPasswordInfo.Name = "lblPasswordInfo";
            lblPasswordInfo.Size = new Size(204, 22);
            lblPasswordInfo.TabIndex = 10;
            lblPasswordInfo.Text = "Password must contain:";
            // 
            // txtSignUpPassword
            // 
            txtSignUpPassword.BackColor = Color.FromArgb(48, 48, 48);
            txtSignUpPassword.BorderStyle = BorderStyle.None;
            txtSignUpPassword.Font = new Font("Times New Roman", 10.8F);
            txtSignUpPassword.ForeColor = Color.White;
            txtSignUpPassword.Location = new Point(115, 356);
            txtSignUpPassword.Name = "txtSignUpPassword";
            txtSignUpPassword.PasswordChar = '*';
            txtSignUpPassword.Size = new Size(320, 21);
            txtSignUpPassword.TabIndex = 9;
            // 
            // txtSignUpEmail
            // 
            txtSignUpEmail.BackColor = Color.FromArgb(48, 48, 48);
            txtSignUpEmail.BorderStyle = BorderStyle.None;
            txtSignUpEmail.Font = new Font("Times New Roman", 10.8F);
            txtSignUpEmail.ForeColor = Color.White;
            txtSignUpEmail.Location = new Point(115, 292);
            txtSignUpEmail.Name = "txtSignUpEmail";
            txtSignUpEmail.Size = new Size(320, 21);
            txtSignUpEmail.TabIndex = 8;
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.FromArgb(48, 48, 48);
            txtLastName.BorderStyle = BorderStyle.None;
            txtLastName.Font = new Font("Times New Roman", 10.8F);
            txtLastName.ForeColor = Color.White;
            txtLastName.Location = new Point(115, 159);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(320, 21);
            txtLastName.TabIndex = 7;
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = Color.FromArgb(48, 48, 48);
            txtFirstName.BorderStyle = BorderStyle.None;
            txtFirstName.Font = new Font("Times New Roman", 10.8F);
            txtFirstName.ForeColor = Color.White;
            txtFirstName.Location = new Point(115, 100);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(320, 21);
            txtFirstName.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(241, 241, 241);
            lblPassword.Location = new Point(115, 330);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(90, 23);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            // 
            // lblSignUpEmail
            // 
            lblSignUpEmail.AutoSize = true;
            lblSignUpEmail.BackColor = Color.Transparent;
            lblSignUpEmail.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblSignUpEmail.ForeColor = Color.FromArgb(241, 241, 241);
            lblSignUpEmail.Location = new Point(115, 266);
            lblSignUpEmail.Name = "lblSignUpEmail";
            lblSignUpEmail.Size = new Size(58, 23);
            lblSignUpEmail.TabIndex = 4;
            lblSignUpEmail.Text = "Email";
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.BackColor = Color.Transparent;
            lblDOB.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblDOB.ForeColor = Color.FromArgb(241, 241, 241);
            lblDOB.Location = new Point(115, 195);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(121, 23);
            lblDOB.TabIndex = 3;
            lblDOB.Text = "Date of Birth";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.BackColor = Color.Transparent;
            lblLastName.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(241, 241, 241);
            lblLastName.Location = new Point(115, 133);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(102, 23);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.BackColor = Color.Transparent;
            lblFirstName.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(241, 241, 241);
            lblFirstName.Location = new Point(114, 74);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(103, 23);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "First Name";
            // 
            // lblCreate
            // 
            lblCreate.AutoSize = true;
            lblCreate.BackColor = Color.Transparent;
            lblCreate.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreate.ForeColor = Color.FromArgb(93, 185, 64);
            lblCreate.Location = new Point(163, 12);
            lblCreate.Name = "lblCreate";
            lblCreate.Size = new Size(225, 39);
            lblCreate.TabIndex = 0;
            lblCreate.Text = "Create Account";
            // 
            // pnlLoginRight
            // 
            pnlLoginRight.BackColor = Color.FromArgb(84, 139, 66);
            pnlLoginRight.Controls.Add(lnkToSignUp);
            pnlLoginRight.Controls.Add(lblPrompt);
            pnlLoginRight.Controls.Add(lblReady);
            pnlLoginRight.Controls.Add(piclogoLogin);
            pnlLoginRight.Controls.Add(lblWelcomeBack);
            pnlLoginRight.Location = new Point(550, 0);
            pnlLoginRight.Name = "pnlLoginRight";
            pnlLoginRight.Size = new Size(550, 620);
            pnlLoginRight.TabIndex = 1;
            // 
            // lnkToSignUp
            // 
            lnkToSignUp.ActiveLinkColor = Color.FromArgb(43, 86, 52);
            lnkToSignUp.AutoSize = true;
            lnkToSignUp.BackColor = Color.Transparent;
            lnkToSignUp.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkToSignUp.ForeColor = Color.FromArgb(241, 241, 241);
            lnkToSignUp.LinkColor = Color.FromArgb(27, 42, 58);
            lnkToSignUp.Location = new Point(361, 570);
            lnkToSignUp.Name = "lnkToSignUp";
            lnkToSignUp.Size = new Size(94, 29);
            lnkToSignUp.TabIndex = 5;
            lnkToSignUp.TabStop = true;
            lnkToSignUp.Text = "Sign Up";
            lnkToSignUp.LinkClicked += lnkGoToSignUp_LinkClicked;
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.BackColor = Color.Transparent;
            lblPrompt.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrompt.ForeColor = Color.FromArgb(241, 241, 241);
            lblPrompt.Location = new Point(96, 570);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(247, 29);
            lblPrompt.TabIndex = 4;
            lblPrompt.Text = "Don't have an account?";
            // 
            // lblReady
            // 
            lblReady.AutoSize = true;
            lblReady.BackColor = Color.Transparent;
            lblReady.Font = new Font("Times New Roman", 15F);
            lblReady.ForeColor = Color.FromArgb(241, 241, 241);
            lblReady.Location = new Point(94, 401);
            lblReady.Name = "lblReady";
            lblReady.Size = new Size(400, 29);
            lblReady.TabIndex = 3;
            lblReady.Text = "Ready to place your next winning bet?";
            // 
            // piclogoLogin
            // 
            piclogoLogin.BackColor = Color.Transparent;
            piclogoLogin.Image = Resources.logo;
            piclogoLogin.Location = new Point(166, 121);
            piclogoLogin.Name = "piclogoLogin";
            piclogoLogin.Size = new Size(245, 245);
            piclogoLogin.SizeMode = PictureBoxSizeMode.Zoom;
            piclogoLogin.TabIndex = 2;
            piclogoLogin.TabStop = false;
            // 
            // lblWelcomeBack
            // 
            lblWelcomeBack.AutoSize = true;
            lblWelcomeBack.BackColor = Color.Transparent;
            lblWelcomeBack.Font = new Font("Times New Roman", 30F);
            lblWelcomeBack.ForeColor = Color.FromArgb(241, 241, 241);
            lblWelcomeBack.Location = new Point(105, 27);
            lblWelcomeBack.Name = "lblWelcomeBack";
            lblWelcomeBack.Size = new Size(389, 57);
            lblWelcomeBack.TabIndex = 1;
            lblWelcomeBack.Text = "Welcome Back To";
            // 
            // pnlSignupLeft
            // 
            pnlSignupLeft.BackColor = Color.FromArgb(84, 139, 66);
            pnlSignupLeft.Controls.Add(lnkToLogin);
            pnlSignupLeft.Controls.Add(lblAccount);
            pnlSignupLeft.Controls.Add(lblSignupJoin);
            pnlSignupLeft.Controls.Add(picLogoSignup);
            pnlSignupLeft.Controls.Add(lblSignupWelcome);
            pnlSignupLeft.Location = new Point(0, 0);
            pnlSignupLeft.Name = "pnlSignupLeft";
            pnlSignupLeft.Size = new Size(550, 620);
            pnlSignupLeft.TabIndex = 0;
            // 
            // lnkToLogin
            // 
            lnkToLogin.ActiveLinkColor = Color.FromArgb(43, 86, 52);
            lnkToLogin.AutoSize = true;
            lnkToLogin.BackColor = Color.Transparent;
            lnkToLogin.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkToLogin.ForeColor = Color.FromArgb(241, 241, 241);
            lnkToLogin.LinkColor = Color.FromArgb(27, 42, 58);
            lnkToLogin.Location = new Point(374, 570);
            lnkToLogin.Name = "lnkToLogin";
            lnkToLogin.Size = new Size(80, 29);
            lnkToLogin.TabIndex = 4;
            lnkToLogin.TabStop = true;
            lnkToLogin.Text = "Log In";
            lnkToLogin.LinkClicked += lnkGoToLogin_LinkClicked;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.BackColor = Color.Transparent;
            lblAccount.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccount.ForeColor = Color.FromArgb(241, 241, 241);
            lblAccount.Location = new Point(96, 570);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(272, 29);
            lblAccount.TabIndex = 3;
            lblAccount.Text = "Already have an account?";
            // 
            // lblSignupJoin
            // 
            lblSignupJoin.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblSignupJoin.AutoSize = true;
            lblSignupJoin.BackColor = Color.Transparent;
            lblSignupJoin.Font = new Font("Times New Roman", 15F);
            lblSignupJoin.ForeColor = Color.FromArgb(241, 241, 241);
            lblSignupJoin.Location = new Point(114, 401);
            lblSignupJoin.Name = "lblSignupJoin";
            lblSignupJoin.Size = new Size(322, 29);
            lblSignupJoin.TabIndex = 2;
            lblSignupJoin.Text = "Join and start placing bets now";
            // 
            // picLogoSignup
            // 
            picLogoSignup.BackColor = Color.Transparent;
            picLogoSignup.Image = Resources.logo;
            picLogoSignup.Location = new Point(153, 121);
            picLogoSignup.Name = "picLogoSignup";
            picLogoSignup.Size = new Size(245, 245);
            picLogoSignup.SizeMode = PictureBoxSizeMode.Zoom;
            picLogoSignup.TabIndex = 1;
            picLogoSignup.TabStop = false;
            // 
            // lblSignupWelcome
            // 
            lblSignupWelcome.AutoSize = true;
            lblSignupWelcome.BackColor = Color.Transparent;
            lblSignupWelcome.Font = new Font("Times New Roman", 30F);
            lblSignupWelcome.ForeColor = Color.FromArgb(241, 241, 241);
            lblSignupWelcome.Location = new Point(138, 27);
            lblSignupWelcome.Name = "lblSignupWelcome";
            lblSignupWelcome.Size = new Size(274, 57);
            lblSignupWelcome.TabIndex = 0;
            lblSignupWelcome.Text = "Welcome To";
            // 
            // pnlLoginLeft
            // 
            pnlLoginLeft.BackColor = Color.FromArgb(48, 48, 48);
            pnlLoginLeft.Controls.Add(btnLogin);
            pnlLoginLeft.Controls.Add(txtLoginPassword);
            pnlLoginLeft.Controls.Add(lblLoginPassword);
            pnlLoginLeft.Controls.Add(txtLoginEmail);
            pnlLoginLeft.Controls.Add(lblLoginEmail);
            pnlLoginLeft.Controls.Add(lblLogin);
            pnlLoginLeft.Location = new Point(0, 0);
            pnlLoginLeft.Name = "pnlLoginLeft";
            pnlLoginLeft.Size = new Size(550, 620);
            pnlLoginLeft.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(93, 185, 64);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.FromArgb(241, 241, 241);
            btnLogin.Location = new Point(185, 470);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(180, 45);
            btnLogin.TabIndex = 17;
            btnLogin.Text = "Log In";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.BackColor = Color.FromArgb(48, 48, 48);
            txtLoginPassword.BorderStyle = BorderStyle.None;
            txtLoginPassword.Font = new Font("Times New Roman", 11F);
            txtLoginPassword.ForeColor = Color.White;
            txtLoginPassword.Location = new Point(116, 332);
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.PasswordChar = '*';
            txtLoginPassword.Size = new Size(320, 22);
            txtLoginPassword.TabIndex = 11;
            // 
            // lblLoginPassword
            // 
            lblLoginPassword.AutoSize = true;
            lblLoginPassword.BackColor = Color.Transparent;
            lblLoginPassword.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblLoginPassword.ForeColor = Color.FromArgb(241, 241, 241);
            lblLoginPassword.Location = new Point(114, 306);
            lblLoginPassword.Name = "lblLoginPassword";
            lblLoginPassword.Size = new Size(90, 23);
            lblLoginPassword.TabIndex = 10;
            lblLoginPassword.Text = "Password";
            // 
            // txtLoginEmail
            // 
            txtLoginEmail.BackColor = Color.FromArgb(48, 48, 48);
            txtLoginEmail.BorderStyle = BorderStyle.None;
            txtLoginEmail.Font = new Font("Times New Roman", 11F);
            txtLoginEmail.ForeColor = Color.White;
            txtLoginEmail.Location = new Point(116, 221);
            txtLoginEmail.Name = "txtLoginEmail";
            txtLoginEmail.Size = new Size(320, 22);
            txtLoginEmail.TabIndex = 9;
            // 
            // lblLoginEmail
            // 
            lblLoginEmail.AutoSize = true;
            lblLoginEmail.BackColor = Color.Transparent;
            lblLoginEmail.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblLoginEmail.ForeColor = Color.FromArgb(241, 241, 241);
            lblLoginEmail.Location = new Point(114, 195);
            lblLoginEmail.Name = "lblLoginEmail";
            lblLoginEmail.Size = new Size(58, 23);
            lblLoginEmail.TabIndex = 5;
            lblLoginEmail.Text = "Email";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.BackColor = Color.Transparent;
            lblLogin.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogin.ForeColor = Color.FromArgb(93, 185, 64);
            lblLogin.Location = new Point(221, 27);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(108, 39);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Log In";
            // 
            // backButton
            // 
            backButton.BackColor = Color.Transparent;
            backButton.Cursor = Cursors.Hand;
            backButton.Image = Resources.backBtn;
            backButton.Location = new Point(47, 48);
            backButton.Name = "backButton";
            backButton.Size = new Size(48, 48);
            backButton.SizeMode = PictureBoxSizeMode.Zoom;
            backButton.TabIndex = 5;
            backButton.TabStop = false;
            backButton.Click += backButton_Click;
            // 
            // RegisterLoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1182, 703);
            Controls.Add(backButton);
            Controls.Add(pnlContainer);
            MinimumSize = new Size(1200, 750);
            Name = "RegisterLoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterLoginForm";
            pnlContainer.ResumeLayout(false);
            pnlSignUpRight.ResumeLayout(false);
            pnlSignUpRight.PerformLayout();
            pnlLoginRight.ResumeLayout(false);
            pnlLoginRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)piclogoLogin).EndInit();
            pnlSignupLeft.ResumeLayout(false);
            pnlSignupLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoSignup).EndInit();
            pnlLoginLeft.ResumeLayout(false);
            pnlLoginLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)backButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlContainer;
        private Panel pnlLoginLeft;
        private Panel pnlLoginRight;
        private Panel pnlSignUpRight;
        private Panel pnlSignupLeft;
        private LinkLabel lnkToLogin;
        private Label lblAccount;
        private Label lblSignupJoin;
        private PictureBox picLogoSignup;
        private Label lblSignupWelcome;
        private Label lblLastName;
        private Label lblFirstName;
        private Label lblCreate;
        private Label lblPassword;
        private Label lblSignUpEmail;
        private Label lblDOB;
        private UnderlineTextBox txtFirstName;
        private RoundedButton btnSignUp;
        private CheckBox chk18;
        private Label lblCritSpec;
        private Label lblCritUpper;
        private Label lblCritNum;
        private Label lblCritLen;
        private Label lblPasswordInfo;
        private UnderlineTextBox txtSignUpPassword;
        private UnderlineTextBox txtSignUpEmail;
        private UnderlineTextBox txtLastName;
        private DateTimePicker dtpDOB;
        private Label lblLogin;
        private RoundedButton btnLogin;
        private UnderlineTextBox txtLoginPassword;
        private Label lblLoginPassword;
        private UnderlineTextBox txtLoginEmail;
        private Label lblLoginEmail;
        private LinkLabel lnkToSignUp;
        private Label lblPrompt;
        private Label lblReady;
        private PictureBox piclogoLogin;
        private Label lblWelcomeBack;
        private PictureBox backButton;
    }
}