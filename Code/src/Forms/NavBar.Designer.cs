namespace BettingSystem.Forms
{
    partial class NavBar
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
            navPanel = new Panel();
            navCentrePanel = new Panel();
            betSlipsPageBtn = new Button();
            homeBtn = new Button();
            rightNavPanel = new Panel();
            navDropdownBtn = new RoundedButton();
            dropdownList = new ContextMenuStrip(components);
            viewProfileToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            navDepositBtn = new RoundedButton();
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
            // navPanel
            // 
            navPanel.BackColor = Color.FromArgb(31, 31, 31);
            navPanel.Controls.Add(navCentrePanel);
            navPanel.Controls.Add(rightNavPanel);
            navPanel.Controls.Add(leftNavPanel);
            navPanel.Dock = DockStyle.Top;
            navPanel.Location = new Point(0, 0);
            navPanel.Margin = new Padding(0);
            navPanel.Name = "navPanel";
            navPanel.Padding = new Padding(5);
            navPanel.Size = new Size(1200, 85);
            navPanel.TabIndex = 1;
            // 
            // navCentrePanel
            // 
            navCentrePanel.AutoSize = true;
            navCentrePanel.Controls.Add(betSlipsPageBtn);
            navCentrePanel.Controls.Add(homeBtn);
            navCentrePanel.Dock = DockStyle.Fill;
            navCentrePanel.Location = new Point(244, 5);
            navCentrePanel.Name = "navCentrePanel";
            navCentrePanel.Size = new Size(567, 75);
            navCentrePanel.TabIndex = 2;
            // 
            // betSlipsPageBtn
            // 
            betSlipsPageBtn.AutoSize = true;
            betSlipsPageBtn.Cursor = Cursors.Hand;
            betSlipsPageBtn.FlatAppearance.BorderSize = 0;
            betSlipsPageBtn.FlatStyle = FlatStyle.Flat;
            betSlipsPageBtn.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            betSlipsPageBtn.ForeColor = Color.FromArgb(241, 241, 241);
            betSlipsPageBtn.Location = new Point(151, 20);
            betSlipsPageBtn.Name = "betSlipsPageBtn";
            betSlipsPageBtn.Size = new Size(105, 35);
            betSlipsPageBtn.TabIndex = 1;
            betSlipsPageBtn.Text = "Bet Slip";
            betSlipsPageBtn.UseVisualStyleBackColor = true;
            betSlipsPageBtn.Click += betSlipsPageBtn_Click;
            // 
            // homeBtn
            // 
            homeBtn.AutoSize = true;
            homeBtn.Cursor = Cursors.Hand;
            homeBtn.FlatAppearance.BorderSize = 0;
            homeBtn.FlatStyle = FlatStyle.Flat;
            homeBtn.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            homeBtn.ForeColor = Color.FromArgb(241, 241, 241);
            homeBtn.Location = new Point(0, 20);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(105, 35);
            homeBtn.TabIndex = 0;
            homeBtn.Text = "Matches";
            homeBtn.UseVisualStyleBackColor = true;
            homeBtn.Click += homeBtn_Click;
            // 
            // rightNavPanel
            // 
            rightNavPanel.Controls.Add(navDropdownBtn);
            rightNavPanel.Controls.Add(navDepositBtn);
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
            navDropdownBtn.ImageSize = 20;
            navDropdownBtn.Location = new Point(202, 12);
            navDropdownBtn.Name = "navDropdownBtn";
            navDropdownBtn.Padding = new Padding(2, 2, 4, 2);
            navDropdownBtn.Size = new Size(169, 51);
            navDropdownBtn.TabIndex = 3;
            navDropdownBtn.TabStop = false;
            navDropdownBtn.TextAlign = ContentAlignment.MiddleLeft;
            navDropdownBtn.UseVisualStyleBackColor = false;
            navDropdownBtn.Click += navDropdownBtn_Click;
            // 
            // dropdownList
            // 
            dropdownList.AutoSize = false;
            dropdownList.BackColor = Color.FromArgb(45, 45, 45);
            dropdownList.Font = new Font("Times New Roman", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dropdownList.ForeColor = Color.FromArgb(241, 241, 241);
            dropdownList.ImageScalingSize = new Size(32, 32);
            dropdownList.Items.AddRange(new ToolStripItem[] { viewProfileToolStripMenuItem, logOutToolStripMenuItem });
            dropdownList.Margin = new Padding(0, 40, 0, 0);
            dropdownList.Name = "dropdownList";
            dropdownList.RenderMode = ToolStripRenderMode.System;
            dropdownList.Size = new Size(181, 85);
            // 
            // viewProfileToolStripMenuItem
            // 
            viewProfileToolStripMenuItem.AutoSize = false;
            viewProfileToolStripMenuItem.Font = new Font("Times New Roman", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewProfileToolStripMenuItem.Name = "viewProfileToolStripMenuItem";
            viewProfileToolStripMenuItem.Padding = new Padding(0, 10, 0, 1);
            viewProfileToolStripMenuItem.Size = new Size(180, 40);
            viewProfileToolStripMenuItem.Text = "View Profile";
            viewProfileToolStripMenuItem.Click += viewProfileToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.AutoSize = false;
            logOutToolStripMenuItem.Font = new Font("Times New Roman", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logOutToolStripMenuItem.ImageAlign = ContentAlignment.MiddleRight;
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Padding = new Padding(0, 10, 0, 1);
            logOutToolStripMenuItem.Size = new Size(180, 40);
            logOutToolStripMenuItem.Text = "Log Out";
            // 
            // navDepositBtn
            // 
            navDepositBtn.BackColor = Color.FromArgb(93, 185, 64);
            navDepositBtn.CornerRadius = 12;
            navDepositBtn.Cursor = Cursors.Hand;
            navDepositBtn.FlatAppearance.BorderSize = 0;
            navDepositBtn.FlatStyle = FlatStyle.Flat;
            navDepositBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            navDepositBtn.ForeColor = Color.FromArgb(241, 241, 241);
            navDepositBtn.Location = new Point(17, 13);
            navDepositBtn.Name = "navDepositBtn";
            navDepositBtn.Size = new Size(137, 51);
            navDepositBtn.TabIndex = 2;
            navDepositBtn.TabStop = false;
            navDepositBtn.Text = "+ Deposit";
            navDepositBtn.UseVisualStyleBackColor = false;
            navDepositBtn.Click += navDepositBtn_Click;
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
            // NavBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(navPanel);
            Name = "NavBar";
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

        private Panel navPanel;
        private Panel navCentrePanel;
        private Button betSlipsPageBtn;
        private Button homeBtn;
        private Panel rightNavPanel;
        private RoundedButton navDropdownBtn;
        private RoundedButton navDepositBtn;
        private Panel leftNavPanel;
        private Label lblAppName;
        private PictureBox navLogo;
        private ContextMenuStrip dropdownList;
        private ToolStripMenuItem viewProfileToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
    }
}
