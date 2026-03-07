namespace BettingSystem
{
    partial class landingPage : BaseForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picBackground = new PictureBox();
            picLogo = new PictureBox();
            lblSlogan = new Label();
            btnCreateAccount = new Button();
            btnLogin = new Button();
            ((System.ComponentModel.ISupportInitialize)picBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picBackground
            // 
            picBackground.BackColor = Color.Transparent;
            picBackground.BackgroundImage = Properties.Resources.football_pitch;
            picBackground.BackgroundImageLayout = ImageLayout.Stretch;
            picBackground.Dock = DockStyle.Fill;
            picBackground.Location = new Point(0, 0);
            picBackground.Name = "picBackground";
            picBackground.Size = new Size(1182, 703);
            picBackground.SizeMode = PictureBoxSizeMode.Zoom;
            picBackground.TabIndex = 0;
            picBackground.TabStop = false;
            // 
            // picLogo
            // 
            picLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picLogo.BackColor = Color.Transparent;
            picLogo.BackgroundImageLayout = ImageLayout.Zoom;
            picLogo.Image = Properties.Resources.app_logo;
            picLogo.Location = new Point(426, 37);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(331, 321);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 1;
            picLogo.TabStop = false;
            // 
            // lblSlogan
            // 
            lblSlogan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSlogan.AutoSize = true;
            lblSlogan.BackColor = Color.Transparent;
            lblSlogan.Font = new Font("Times New Roman", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSlogan.ForeColor = Color.FromArgb(233, 244, 229);
            lblSlogan.Location = new Point(325, 406);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(532, 53);
            lblSlogan.TabIndex = 2;
            lblSlogan.Text = "KICK OFF YOUR BETS";
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.BackColor = Color.Transparent;
            btnCreateAccount.FlatStyle = FlatStyle.Flat;
            btnCreateAccount.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.Location = new Point(176, 531);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(250, 76);
            btnCreateAccount.TabIndex = 4;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = false;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(93, 185, 64);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(757, 531);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(250, 76);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Log In";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // landingPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 703);
            Controls.Add(btnLogin);
            Controls.Add(btnCreateAccount);
            Controls.Add(lblSlogan);
            Controls.Add(picLogo);
            Controls.Add(picBackground);
            MinimumSize = new Size(1200, 750);
            Name = "landingPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Landing Page";
            ((System.ComponentModel.ISupportInitialize)picBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picBackground;
        private PictureBox picLogo;
        private Label lblSlogan;
        private Button btnLogin;
        private Button btnCreateAccount;
    }
}
