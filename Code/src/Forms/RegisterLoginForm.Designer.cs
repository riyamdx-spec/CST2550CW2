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
            backButton = new PictureBox();
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
            appLbl2 = new Label();
            lnkToSignUp = new LinkLabel();
            lblPrompt = new Label();
            lblReady = new Label();
            piclogoLogin = new PictureBox();
            lblWelcomeBack = new Label();
            pnlSignupLeft = new Panel();
            appLbl = new Label();
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
            pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backButton).BeginInit();
            pnlSignUpRight.SuspendLayout();
            pnlLoginRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)piclogoLogin).BeginInit();
            pnlSignupLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoSignup).BeginInit();
            pnlLoginLeft.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.Transparent;
            pnlContainer.Controls.Add(backButton);
            pnlContainer.Controls.Add(pnlSignUpRight);
            pnlContainer.Controls.Add(pnlLoginRight);
            pnlContainer.Controls.Add(pnlSignupLeft);
            pnlContainer.Controls.Add(pnlLoginLeft);
            pnlContainer.Location = new Point(36, 31);
            pnlContainer.Margin = new Padding(3, 2, 3, 2);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(962, 465);
            pnlContainer.TabIndex = 0;
            // 
            // backButton
            // 
            backButton.BackColor = Color.Transparent;
            backButton.Cursor = Cursors.Hand;
            backButton.Image = Resources.backBtn;
            backButton.Location = new Point(14, 9);
            backButton.Margin = new Padding(3, 2, 3, 2);
            backButton.Name = "backButton";
            backButton.Size = new Size(42, 36);
            backButton.SizeMode = PictureBoxSizeMode.Zoom;
            backButton.TabIndex = 5;
            backButton.TabStop = false;
            backButton.Click += backButton_Click;
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
            pnlSignUpRight.Location = new Point(481, 0);
            pnlSignUpRight.Margin = new Padding(3, 2, 3, 2);
            pnlSignUpRight.Name = "pnlSignUpRight";
            pnlSignUpRight.Size = new Size(481, 465);
            pnlSignUpRight.TabIndex = 0;
            pnlSignUpRight.Visible = false;
            // 
            // dtpDOB
            // 
            dtpDOB.CalendarFont = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            dtpDOB.CalendarMonthBackground = Color.Transparent;
            dtpDOB.Font = new Font("Times New Roman", 10.8F);
            dtpDOB.Location = new Point(101, 166);
            dtpDOB.Margin = new Padding(3, 2, 3, 2);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(280, 24);
            dtpDOB.TabIndex = 17;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.FromArgb(93, 185, 64);
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSignUp.ForeColor = Color.FromArgb(241, 241, 241);
            btnSignUp.Location = new Point(151, 422);
            btnSignUp.Margin = new Padding(3, 2, 3, 2);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(158, 34);
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
            chk18.Location = new Point(101, 391);
            chk18.Margin = new Padding(3, 2, 3, 2);
            chk18.Name = "chk18";
            chk18.Size = new Size(263, 21);
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
            lblCritSpec.Location = new Point(100, 362);
            lblCritSpec.Name = "lblCritSpec";
            lblCritSpec.Size = new Size(155, 15);
            lblCritSpec.TabIndex = 14;
            lblCritSpec.Text = "* At least 1 special character";
            // 
            // lblCritUpper
            // 
            lblCritUpper.AutoSize = true;
            lblCritUpper.BackColor = Color.Transparent;
            lblCritUpper.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            lblCritUpper.ForeColor = Color.FromArgb(241, 241, 241);
            lblCritUpper.Location = new Point(101, 344);
            lblCritUpper.Name = "lblCritUpper";
            lblCritUpper.Size = new Size(154, 15);
            lblCritUpper.TabIndex = 13;
            lblCritUpper.Text = "* At least 1 upper case letter";
            // 
            // lblCritNum
            // 
            lblCritNum.AutoSize = true;
            lblCritNum.BackColor = Color.Transparent;
            lblCritNum.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            lblCritNum.ForeColor = Color.FromArgb(241, 241, 241);
            lblCritNum.Location = new Point(101, 327);
            lblCritNum.Name = "lblCritNum";
            lblCritNum.Size = new Size(108, 15);
            lblCritNum.TabIndex = 12;
            lblCritNum.Text = "* At least 1 number";
            // 
            // lblCritLen
            // 
            lblCritLen.AutoSize = true;
            lblCritLen.BackColor = Color.Transparent;
            lblCritLen.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            lblCritLen.ForeColor = Color.FromArgb(241, 241, 241);
            lblCritLen.Location = new Point(101, 310);
            lblCritLen.Name = "lblCritLen";
            lblCritLen.Size = new Size(121, 15);
            lblCritLen.TabIndex = 11;
            lblCritLen.Text = "* At least 8 characters";
            // 
            // lblPasswordInfo
            // 
            lblPasswordInfo.AutoSize = true;
            lblPasswordInfo.BackColor = Color.Transparent;
            lblPasswordInfo.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblPasswordInfo.ForeColor = Color.FromArgb(241, 241, 241);
            lblPasswordInfo.Location = new Point(101, 292);
            lblPasswordInfo.Name = "lblPasswordInfo";
            lblPasswordInfo.Size = new Size(162, 17);
            lblPasswordInfo.TabIndex = 10;
            lblPasswordInfo.Text = "Password must contain:";
            // 
            // txtSignUpPassword
            // 
            txtSignUpPassword.BackColor = Color.FromArgb(48, 48, 48);
            txtSignUpPassword.BorderStyle = BorderStyle.None;
            txtSignUpPassword.Font = new Font("Times New Roman", 10.8F);
            txtSignUpPassword.ForeColor = Color.White;
            txtSignUpPassword.Location = new Point(101, 267);
            txtSignUpPassword.Margin = new Padding(3, 2, 3, 2);
            txtSignUpPassword.Name = "txtSignUpPassword";
            txtSignUpPassword.PasswordChar = '*';
            txtSignUpPassword.Size = new Size(280, 17);
            txtSignUpPassword.TabIndex = 9;
            // 
            // txtSignUpEmail
            // 
            txtSignUpEmail.BackColor = Color.FromArgb(48, 48, 48);
            txtSignUpEmail.BorderStyle = BorderStyle.None;
            txtSignUpEmail.Font = new Font("Times New Roman", 10.8F);
            txtSignUpEmail.ForeColor = Color.White;
            txtSignUpEmail.Location = new Point(101, 219);
            txtSignUpEmail.Margin = new Padding(3, 2, 3, 2);
            txtSignUpEmail.Name = "txtSignUpEmail";
            txtSignUpEmail.Size = new Size(280, 17);
            txtSignUpEmail.TabIndex = 8;
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.FromArgb(48, 48, 48);
            txtLastName.BorderStyle = BorderStyle.None;
            txtLastName.Font = new Font("Times New Roman", 10.8F);
            txtLastName.ForeColor = Color.White;
            txtLastName.Location = new Point(101, 119);
            txtLastName.Margin = new Padding(3, 2, 3, 2);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(280, 17);
            txtLastName.TabIndex = 7;
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = Color.FromArgb(48, 48, 48);
            txtFirstName.BorderStyle = BorderStyle.None;
            txtFirstName.Font = new Font("Times New Roman", 10.8F);
            txtFirstName.ForeColor = Color.White;
            txtFirstName.Location = new Point(101, 75);
            txtFirstName.Margin = new Padding(3, 2, 3, 2);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(280, 17);
            txtFirstName.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(241, 241, 241);
            lblPassword.Location = new Point(101, 248);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(72, 19);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            // 
            // lblSignUpEmail
            // 
            lblSignUpEmail.AutoSize = true;
            lblSignUpEmail.BackColor = Color.Transparent;
            lblSignUpEmail.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblSignUpEmail.ForeColor = Color.FromArgb(241, 241, 241);
            lblSignUpEmail.Location = new Point(101, 200);
            lblSignUpEmail.Name = "lblSignUpEmail";
            lblSignUpEmail.Size = new Size(47, 19);
            lblSignUpEmail.TabIndex = 4;
            lblSignUpEmail.Text = "Email";
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.BackColor = Color.Transparent;
            lblDOB.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblDOB.ForeColor = Color.FromArgb(241, 241, 241);
            lblDOB.Location = new Point(101, 146);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(97, 19);
            lblDOB.TabIndex = 3;
            lblDOB.Text = "Date of Birth";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.BackColor = Color.Transparent;
            lblLastName.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(241, 241, 241);
            lblLastName.Location = new Point(101, 100);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(83, 19);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.BackColor = Color.Transparent;
            lblFirstName.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(241, 241, 241);
            lblFirstName.Location = new Point(100, 56);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(84, 19);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "First Name";
            // 
            // lblCreate
            // 
            lblCreate.AutoSize = true;
            lblCreate.BackColor = Color.Transparent;
            lblCreate.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreate.ForeColor = Color.FromArgb(93, 185, 64);
            lblCreate.Location = new Point(143, 9);
            lblCreate.Name = "lblCreate";
            lblCreate.Size = new Size(184, 31);
            lblCreate.TabIndex = 0;
            lblCreate.Text = "Create Account";
            // 
            // pnlLoginRight
            // 
            pnlLoginRight.BackColor = Color.FromArgb(84, 139, 66);
            pnlLoginRight.Controls.Add(appLbl2);
            pnlLoginRight.Controls.Add(lnkToSignUp);
            pnlLoginRight.Controls.Add(lblPrompt);
            pnlLoginRight.Controls.Add(lblReady);
            pnlLoginRight.Controls.Add(piclogoLogin);
            pnlLoginRight.Controls.Add(lblWelcomeBack);
            pnlLoginRight.Location = new Point(481, 0);
            pnlLoginRight.Margin = new Padding(3, 2, 3, 2);
            pnlLoginRight.Name = "pnlLoginRight";
            pnlLoginRight.Size = new Size(481, 465);
            pnlLoginRight.TabIndex = 1;
            // 
            // appLbl2
            // 
            appLbl2.AutoSize = true;
            appLbl2.BackColor = Color.Transparent;
            appLbl2.Font = new Font("Times New Roman", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appLbl2.ForeColor = Color.FromArgb(27, 42, 58);
            appLbl2.Location = new Point(152, 292);
            appLbl2.Name = "appLbl2";
            appLbl2.Size = new Size(176, 45);
            appLbl2.TabIndex = 7;
            appLbl2.Text = "Pitch Bet";
            // 
            // lnkToSignUp
            // 
            lnkToSignUp.ActiveLinkColor = Color.FromArgb(43, 86, 52);
            lnkToSignUp.AutoSize = true;
            lnkToSignUp.BackColor = Color.Transparent;
            lnkToSignUp.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkToSignUp.ForeColor = Color.FromArgb(241, 241, 241);
            lnkToSignUp.LinkColor = Color.FromArgb(27, 42, 58);
            lnkToSignUp.Location = new Point(285, 428);
            lnkToSignUp.Name = "lnkToSignUp";
            lnkToSignUp.Size = new Size(73, 22);
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
            lblPrompt.Location = new Point(84, 428);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(191, 22);
            lblPrompt.TabIndex = 4;
            lblPrompt.Text = "Don't have an account?";
            // 
            // lblReady
            // 
            lblReady.AutoSize = true;
            lblReady.BackColor = Color.Transparent;
            lblReady.Font = new Font("Times New Roman", 15F);
            lblReady.ForeColor = Color.FromArgb(241, 241, 241);
            lblReady.Location = new Point(82, 373);
            lblReady.Name = "lblReady";
            lblReady.Size = new Size(311, 22);
            lblReady.TabIndex = 3;
            lblReady.Text = "Ready to place your next winning bet?";
            // 
            // piclogoLogin
            // 
            piclogoLogin.BackColor = Color.Transparent;
            piclogoLogin.Image = Resources.logo;
            piclogoLogin.Location = new Point(145, 91);
            piclogoLogin.Margin = new Padding(3, 2, 3, 2);
            piclogoLogin.Name = "piclogoLogin";
            piclogoLogin.Size = new Size(214, 184);
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
            lblWelcomeBack.Location = new Point(92, 20);
            lblWelcomeBack.Name = "lblWelcomeBack";
            lblWelcomeBack.Size = new Size(306, 46);
            lblWelcomeBack.TabIndex = 1;
            lblWelcomeBack.Text = "Welcome Back To";
            // 
            // pnlSignupLeft
            // 
            pnlSignupLeft.BackColor = Color.FromArgb(84, 139, 66);
            pnlSignupLeft.Controls.Add(appLbl);
            pnlSignupLeft.Controls.Add(lnkToLogin);
            pnlSignupLeft.Controls.Add(lblAccount);
            pnlSignupLeft.Controls.Add(lblSignupJoin);
            pnlSignupLeft.Controls.Add(picLogoSignup);
            pnlSignupLeft.Controls.Add(lblSignupWelcome);
            pnlSignupLeft.Location = new Point(0, 0);
            pnlSignupLeft.Margin = new Padding(3, 2, 3, 2);
            pnlSignupLeft.Name = "pnlSignupLeft";
            pnlSignupLeft.Size = new Size(481, 465);
            pnlSignupLeft.TabIndex = 0;
            // 
            // appLbl
            // 
            appLbl.AutoSize = true;
            appLbl.BackColor = Color.Transparent;
            appLbl.Font = new Font("Times New Roman", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appLbl.ForeColor = Color.FromArgb(27, 42, 58);
            appLbl.Location = new Point(152, 292);
            appLbl.Name = "appLbl";
            appLbl.Size = new Size(176, 45);
            appLbl.TabIndex = 6;
            appLbl.Text = "Pitch Bet";
            // 
            // lnkToLogin
            // 
            lnkToLogin.ActiveLinkColor = Color.FromArgb(43, 86, 52);
            lnkToLogin.AutoSize = true;
            lnkToLogin.BackColor = Color.Transparent;
            lnkToLogin.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkToLogin.ForeColor = Color.FromArgb(241, 241, 241);
            lnkToLogin.LinkColor = Color.FromArgb(27, 42, 58);
            lnkToLogin.Location = new Point(303, 428);
            lnkToLogin.Name = "lnkToLogin";
            lnkToLogin.Size = new Size(60, 22);
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
            lblAccount.Location = new Point(84, 428);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(213, 22);
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
            lblSignupJoin.Location = new Point(113, 373);
            lblSignupJoin.Name = "lblSignupJoin";
            lblSignupJoin.Size = new Size(254, 22);
            lblSignupJoin.TabIndex = 2;
            lblSignupJoin.Text = "Join and start placing bets now";
            // 
            // picLogoSignup
            // 
            picLogoSignup.BackColor = Color.Transparent;
            picLogoSignup.Image = Resources.logo;
            picLogoSignup.Location = new Point(134, 91);
            picLogoSignup.Margin = new Padding(3, 2, 3, 2);
            picLogoSignup.Name = "picLogoSignup";
            picLogoSignup.Size = new Size(214, 184);
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
            lblSignupWelcome.Location = new Point(133, 20);
            lblSignupWelcome.Name = "lblSignupWelcome";
            lblSignupWelcome.Size = new Size(215, 46);
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
            pnlLoginLeft.Margin = new Padding(3, 2, 3, 2);
            pnlLoginLeft.Name = "pnlLoginLeft";
            pnlLoginLeft.Size = new Size(481, 465);
            pnlLoginLeft.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(93, 185, 64);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.FromArgb(241, 241, 241);
            btnLogin.Location = new Point(162, 352);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(158, 34);
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
            txtLoginPassword.Location = new Point(102, 249);
            txtLoginPassword.Margin = new Padding(3, 2, 3, 2);
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.PasswordChar = '*';
            txtLoginPassword.Size = new Size(280, 17);
            txtLoginPassword.TabIndex = 11;
            // 
            // lblLoginPassword
            // 
            lblLoginPassword.AutoSize = true;
            lblLoginPassword.BackColor = Color.Transparent;
            lblLoginPassword.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblLoginPassword.ForeColor = Color.FromArgb(241, 241, 241);
            lblLoginPassword.Location = new Point(100, 230);
            lblLoginPassword.Name = "lblLoginPassword";
            lblLoginPassword.Size = new Size(72, 19);
            lblLoginPassword.TabIndex = 10;
            lblLoginPassword.Text = "Password";
            // 
            // txtLoginEmail
            // 
            txtLoginEmail.BackColor = Color.FromArgb(48, 48, 48);
            txtLoginEmail.BorderStyle = BorderStyle.None;
            txtLoginEmail.Font = new Font("Times New Roman", 11F);
            txtLoginEmail.ForeColor = Color.White;
            txtLoginEmail.Location = new Point(102, 166);
            txtLoginEmail.Margin = new Padding(3, 2, 3, 2);
            txtLoginEmail.Name = "txtLoginEmail";
            txtLoginEmail.Size = new Size(280, 17);
            txtLoginEmail.TabIndex = 9;
            // 
            // lblLoginEmail
            // 
            lblLoginEmail.AutoSize = true;
            lblLoginEmail.BackColor = Color.Transparent;
            lblLoginEmail.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblLoginEmail.ForeColor = Color.FromArgb(241, 241, 241);
            lblLoginEmail.Location = new Point(100, 146);
            lblLoginEmail.Name = "lblLoginEmail";
            lblLoginEmail.Size = new Size(47, 19);
            lblLoginEmail.TabIndex = 5;
            lblLoginEmail.Text = "Email";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.BackColor = Color.Transparent;
            lblLogin.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogin.ForeColor = Color.FromArgb(93, 185, 64);
            lblLogin.Location = new Point(193, 20);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(85, 31);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Log In";
            // 
            // RegisterLoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1036, 533);
            Controls.Add(pnlContainer);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(1052, 572);
            Name = "RegisterLoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterLoginForm";
            pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)backButton).EndInit();
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
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlContainer;
        private Panel pnlLoginLeft;
        private Panel pnlSignupLeft;
        private LinkLabel lnkToLogin;
        private Label lblAccount;
        private Label lblSignupJoin;
        private PictureBox picLogoSignup;
        private Label lblSignupWelcome;
        private Label lblLogin;
        private RoundedButton btnLogin;
        private UnderlineTextBox txtLoginPassword;
        private Label lblLoginPassword;
        private UnderlineTextBox txtLoginEmail;
        private Label lblLoginEmail;
        private PictureBox backButton;
        private Label appLbl;
        private Panel pnlSignUpRight;
        private DateTimePicker dtpDOB;
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
        private UnderlineTextBox txtFirstName;
        private Label lblPassword;
        private Label lblSignUpEmail;
        private Label lblDOB;
        private Label lblLastName;
        private Label lblFirstName;
        private Label lblCreate;
        private Panel pnlLoginRight;
        private LinkLabel lnkToSignUp;
        private Label lblPrompt;
        private Label lblReady;
        private PictureBox piclogoLogin;
        private Label lblWelcomeBack;
        private Label appLbl2;
    }
}