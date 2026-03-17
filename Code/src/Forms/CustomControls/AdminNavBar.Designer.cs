namespace BettingSystem.Forms.CustomControls
{
    partial class AdminNavBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            usersPageBtn = new Button();
            navPanel = new Panel();
            navCentrePanel = new Panel();
            financialPageBtn = new Button();
            matchSearchPageBtn = new Button();
            rightNavPanel = new Panel();
            navDropdownBtn = new RoundedButton();
            dropdownList = new ContextMenuStrip(components);
            editProfileToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            leftNavPanel = new Panel();
            lblAppName = new Label();
            navLogo = new PictureBox();
            navPanel.SuspendLayout();
            navCentrePanel.SuspendLayout();
            rightNavPanel.SuspendLayout();
            dropdownList.SuspendLayout();
            leftNavPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)navLogo).BeginInit();
            SuspendLayout();
            // 
            // usersPageBtn
            // 
            usersPageBtn.AutoSize = true;
            usersPageBtn.Cursor = Cursors.Hand;
            usersPageBtn.FlatAppearance.BorderSize = 0;
            usersPageBtn.FlatStyle = FlatStyle.Flat;
            usersPageBtn.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usersPageBtn.ForeColor = Color.FromArgb(241, 241, 241);
            usersPageBtn.Location = new Point(0, 20);
            usersPageBtn.Name = "usersPageBtn";
            usersPageBtn.Size = new Size(127, 35);
            usersPageBtn.TabIndex = 0;
            usersPageBtn.Text = "View Users";
            usersPageBtn.UseVisualStyleBackColor = true;
            usersPageBtn.Click += usersPageBtn_Click;
            // 
            // navPanel
            // 
            navPanel.BackColor = Color.FromArgb(31, 31, 31);
            navPanel.Controls.Add(navCentrePanel);
            navPanel.Controls.Add(rightNavPanel);
            navPanel.Controls.Add(leftNavPanel);
            navPanel.Dock = DockStyle.Fill;
            navPanel.Location = new Point(0, 0);
            navPanel.Margin = new Padding(0);
            navPanel.Name = "navPanel";
            navPanel.Padding = new Padding(5);
            navPanel.Size = new Size(1200, 85);
            navPanel.TabIndex = 2;
            // 
            // navCentrePanel
            // 
            navCentrePanel.AutoSize = true;
            navCentrePanel.Controls.Add(financialPageBtn);
            navCentrePanel.Controls.Add(matchSearchPageBtn);
            navCentrePanel.Controls.Add(usersPageBtn);
            navCentrePanel.Dock = DockStyle.Fill;
            navCentrePanel.Location = new Point(244, 5);
            navCentrePanel.Name = "navCentrePanel";
            navCentrePanel.Size = new Size(567, 75);
            navCentrePanel.TabIndex = 2;
            // 
            // financialPageBtn
            // 
            financialPageBtn.AutoSize = true;
            financialPageBtn.Cursor = Cursors.Hand;
            financialPageBtn.FlatAppearance.BorderSize = 0;
            financialPageBtn.FlatStyle = FlatStyle.Flat;
            financialPageBtn.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            financialPageBtn.ForeColor = Color.FromArgb(241, 241, 241);
            financialPageBtn.Location = new Point(357, 20);
            financialPageBtn.Name = "financialPageBtn";
            financialPageBtn.Size = new Size(128, 35);
            financialPageBtn.TabIndex = 2;
            financialPageBtn.Text = "Profit/Loss";
            financialPageBtn.UseVisualStyleBackColor = true;
            financialPageBtn.Click += financialPageBtn_Click;
            // 
            // matchSearchPageBtn
            // 
            matchSearchPageBtn.AutoSize = true;
            matchSearchPageBtn.Cursor = Cursors.Hand;
            matchSearchPageBtn.FlatAppearance.BorderSize = 0;
            matchSearchPageBtn.FlatStyle = FlatStyle.Flat;
            matchSearchPageBtn.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            matchSearchPageBtn.ForeColor = Color.FromArgb(241, 241, 241);
            matchSearchPageBtn.Location = new Point(151, 20);
            matchSearchPageBtn.Name = "matchSearchPageBtn";
            matchSearchPageBtn.Size = new Size(171, 35);
            matchSearchPageBtn.TabIndex = 1;
            matchSearchPageBtn.Text = "Search Matches";
            matchSearchPageBtn.UseVisualStyleBackColor = true;
            matchSearchPageBtn.Click += matchSearchPageBtn_Click;
            // 
            // rightNavPanel
            // 
            rightNavPanel.Controls.Add(navDropdownBtn);
            rightNavPanel.Dock = DockStyle.Right;
            rightNavPanel.Location = new Point(811, 5);
            rightNavPanel.Name = "rightNavPanel";
            rightNavPanel.Size = new Size(384, 75);
            rightNavPanel.TabIndex = 1;
            // 
            // navDropdownBtn
            // 
            navDropdownBtn.AutoSize = true;
            navDropdownBtn.BackColor = Color.FromArgb(38, 38, 38);
            navDropdownBtn.ContextMenuStrip = dropdownList;
            navDropdownBtn.CornerRadius = 12;
            navDropdownBtn.Cursor = Cursors.Hand;
            navDropdownBtn.FlatAppearance.BorderSize = 0;
            navDropdownBtn.FlatStyle = FlatStyle.Flat;
            navDropdownBtn.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            navDropdownBtn.ForeColor = Color.FromArgb(241, 241, 241);
            navDropdownBtn.Image = Properties.Resources.dropdownArrow;
            navDropdownBtn.ImageAlign = ContentAlignment.MiddleRight;
            navDropdownBtn.Location = new Point(202, 12);
            navDropdownBtn.Name = "navDropdownBtn";
            navDropdownBtn.Padding = new Padding(2, 2, 4, 2);
            navDropdownBtn.Size = new Size(169, 51);
            navDropdownBtn.TabIndex = 3;
            navDropdownBtn.TabStop = false;
            navDropdownBtn.TextAlign = ContentAlignment.MiddleLeft;
            navDropdownBtn.UseVisualStyleBackColor = false;
            // 
            // dropdownList
            // 
            dropdownList.AutoSize = false;
            dropdownList.BackColor = Color.FromArgb(45, 45, 45);
            dropdownList.Font = new Font("Times New Roman", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dropdownList.ForeColor = Color.FromArgb(241, 241, 241);
            dropdownList.ImageScalingSize = new Size(32, 32);
            dropdownList.Items.AddRange(new ToolStripItem[] { editProfileToolStripMenuItem, changePasswordToolStripMenuItem, logOutToolStripMenuItem });
            dropdownList.Margin = new Padding(0, 40, 0, 0);
            dropdownList.Name = "dropdownList";
            dropdownList.RenderMode = ToolStripRenderMode.System;
            dropdownList.Size = new Size(181, 100);
            // 
            // editProfileToolStripMenuItem
            // 
            editProfileToolStripMenuItem.Name = "editProfileToolStripMenuItem";
            editProfileToolStripMenuItem.Size = new Size(183, 22);
            editProfileToolStripMenuItem.Text = "Edit Profile";
            editProfileToolStripMenuItem.Click += EditProfile_Click;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(183, 22);
            changePasswordToolStripMenuItem.Text = "Change Password";
            changePasswordToolStripMenuItem.Click += ChangedPassword_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(183, 22);
            logOutToolStripMenuItem.Text = "Log Out";
            logOutToolStripMenuItem.Click += LogOut_Click;
            // 
            // leftNavPanel
            // 
            leftNavPanel.Controls.Add(lblAppName);
            leftNavPanel.Controls.Add(navLogo);
            leftNavPanel.Dock = DockStyle.Left;
            leftNavPanel.Location = new Point(5, 5);
            leftNavPanel.Name = "leftNavPanel";
            leftNavPanel.Size = new Size(239, 75);
            leftNavPanel.TabIndex = 0;
            // 
            // lblAppName
            // 
            lblAppName.Dock = DockStyle.Fill;
            lblAppName.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.FromArgb(76, 175, 80);
            lblAppName.Location = new Point(61, 0);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(178, 75);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "Pitch Bet";
            lblAppName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // navLogo
            // 
            navLogo.Dock = DockStyle.Left;
            navLogo.Image = Properties.Resources.logo;
            navLogo.Location = new Point(0, 0);
            navLogo.Margin = new Padding(0);
            navLogo.Name = "navLogo";
            navLogo.Size = new Size(61, 75);
            navLogo.SizeMode = PictureBoxSizeMode.Zoom;
            navLogo.TabIndex = 0;
            navLogo.TabStop = false;
            // 
            // AdminNavBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(navPanel);
            Name = "AdminNavBar";
            Size = new Size(1200, 85);
            navPanel.ResumeLayout(false);
            navPanel.PerformLayout();
            navCentrePanel.ResumeLayout(false);
            navCentrePanel.PerformLayout();
            rightNavPanel.ResumeLayout(false);
            rightNavPanel.PerformLayout();
            dropdownList.ResumeLayout(false);
            leftNavPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)navLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button usersPageBtn;
        private Panel navPanel;
        private Panel navCentrePanel;
        private Button matchSearchPageBtn;
        private Panel rightNavPanel;
        private ContextMenuStrip dropdownList;
        private RoundedButton navDepositBtn;
        private Panel leftNavPanel;
        private Label lblAppName;
        private PictureBox navLogo;
        private Button financialPageBtn;
        private RoundedButton navDropdownBtn;
        private ToolStripMenuItem editProfileToolStripMenuItem;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
    }
}
