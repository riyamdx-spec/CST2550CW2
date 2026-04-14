using BettingSystem.Forms.Properties;

namespace BettingSystem.Forms
{
    partial class AccountPage
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
            components = new System.ComponentModel.Container();
            bgPanel = new Panel();
            scrollablePanel = new Panel();
            ProfileTableLayoutPanel = new TableLayoutPanel();
            accountPageLbl = new Label();
            detailsRoundedPanel = new RoundedPanel();
            DetailsBgtableLayoutPanel = new TableLayoutPanel();
            userIcon = new PictureBox();
            detailsTableLayoutPanel = new TableLayoutPanel();
            dobLbl = new Label();
            EmailLbl = new Label();
            LNameLbl = new Label();
            FNameLbl = new Label();
            editBtnPanel = new Panel();
            editBtn = new PictureBox();
            buttonsPanel = new TableLayoutPanel();
            historyBtn = new RoundedButton();
            changePasswordBtn = new RoundedButton();
            balancePanel = new RoundedPanel();
            balanceBtnPanel = new TableLayoutPanel();
            depositBtn = new RoundedButton();
            WithdrawBtn = new RoundedButton();
            amountLbl = new Label();
            balanceLbl = new Label();
            navBar1 = new NavBar();
            dropdownList = new ContextMenuStrip(components);
            viewProfileToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            bgPanel.SuspendLayout();
            scrollablePanel.SuspendLayout();
            ProfileTableLayoutPanel.SuspendLayout();
            detailsRoundedPanel.SuspendLayout();
            DetailsBgtableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userIcon).BeginInit();
            detailsTableLayoutPanel.SuspendLayout();
            editBtnPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)editBtn).BeginInit();
            buttonsPanel.SuspendLayout();
            balancePanel.SuspendLayout();
            balanceBtnPanel.SuspendLayout();
            dropdownList.SuspendLayout();
            SuspendLayout();
            // 
            // bgPanel
            // 
            bgPanel.BackColor = Color.FromArgb(36, 36, 36);
            bgPanel.Controls.Add(scrollablePanel);
            bgPanel.Controls.Add(navBar1);
            bgPanel.Dock = DockStyle.Fill;
            bgPanel.Location = new Point(0, 0);
            bgPanel.Margin = new Padding(0);
            bgPanel.Name = "bgPanel";
            bgPanel.Size = new Size(1184, 711);
            bgPanel.TabIndex = 0;
            // 
            // scrollablePanel
            // 
            scrollablePanel.AutoScroll = true;
            scrollablePanel.Controls.Add(ProfileTableLayoutPanel);
            scrollablePanel.Dock = DockStyle.Fill;
            scrollablePanel.Location = new Point(0, 85);
            scrollablePanel.Name = "scrollablePanel";
            scrollablePanel.Size = new Size(1184, 626);
            scrollablePanel.TabIndex = 1;
            // 
            // ProfileTableLayoutPanel
            // 
            ProfileTableLayoutPanel.ColumnCount = 1;
            ProfileTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ProfileTableLayoutPanel.Controls.Add(accountPageLbl, 0, 0);
            ProfileTableLayoutPanel.Controls.Add(detailsRoundedPanel, 0, 1);
            ProfileTableLayoutPanel.Controls.Add(buttonsPanel, 0, 2);
            ProfileTableLayoutPanel.Controls.Add(balancePanel, 0, 3);
            ProfileTableLayoutPanel.Dock = DockStyle.Top;
            ProfileTableLayoutPanel.ForeColor = Color.Transparent;
            ProfileTableLayoutPanel.Location = new Point(0, 0);
            ProfileTableLayoutPanel.Name = "ProfileTableLayoutPanel";
            ProfileTableLayoutPanel.RowCount = 5;
            ProfileTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ProfileTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            ProfileTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            ProfileTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            ProfileTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ProfileTableLayoutPanel.Size = new Size(1167, 885);
            ProfileTableLayoutPanel.TabIndex = 2;
            // 
            // accountPageLbl
            // 
            accountPageLbl.Anchor = AnchorStyles.None;
            accountPageLbl.AutoSize = true;
            accountPageLbl.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accountPageLbl.ForeColor = Color.FromArgb(241, 241, 241);
            accountPageLbl.Location = new Point(448, 10);
            accountPageLbl.Name = "accountPageLbl";
            accountPageLbl.Padding = new Padding(0, 10, 0, 0);
            accountPageLbl.Size = new Size(271, 65);
            accountPageLbl.TabIndex = 0;
            accountPageLbl.Text = "My Account";
            accountPageLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // detailsRoundedPanel
            // 
            detailsRoundedPanel.Anchor = AnchorStyles.None;
            detailsRoundedPanel.BackColor = Color.FromArgb(26, 26, 26);
            detailsRoundedPanel.Controls.Add(DetailsBgtableLayoutPanel);
            detailsRoundedPanel.CornerRadius = 25;
            detailsRoundedPanel.Location = new Point(158, 96);
            detailsRoundedPanel.Name = "detailsRoundedPanel";
            detailsRoundedPanel.Size = new Size(850, 325);
            detailsRoundedPanel.TabIndex = 1;
            // 
            // DetailsBgtableLayoutPanel
            // 
            DetailsBgtableLayoutPanel.BackColor = Color.FromArgb(26, 26, 25);
            DetailsBgtableLayoutPanel.ColumnCount = 3;
            DetailsBgtableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.3970375F));
            DetailsBgtableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.11476F));
            DetailsBgtableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.48819733F));
            DetailsBgtableLayoutPanel.Controls.Add(userIcon, 0, 0);
            DetailsBgtableLayoutPanel.Controls.Add(detailsTableLayoutPanel, 1, 0);
            DetailsBgtableLayoutPanel.Controls.Add(editBtnPanel, 2, 0);
            DetailsBgtableLayoutPanel.Dock = DockStyle.Fill;
            DetailsBgtableLayoutPanel.Location = new Point(0, 0);
            DetailsBgtableLayoutPanel.Name = "DetailsBgtableLayoutPanel";
            DetailsBgtableLayoutPanel.RowCount = 1;
            DetailsBgtableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            DetailsBgtableLayoutPanel.Size = new Size(850, 325);
            DetailsBgtableLayoutPanel.TabIndex = 2;
            // 
            // userIcon
            // 
            userIcon.Anchor = AnchorStyles.None;
            userIcon.Image = Resources.userIcon1;
            userIcon.Location = new Point(46, 60);
            userIcon.Name = "userIcon";
            userIcon.Size = new Size(139, 205);
            userIcon.SizeMode = PictureBoxSizeMode.Zoom;
            userIcon.TabIndex = 0;
            userIcon.TabStop = false;
            // 
            // detailsTableLayoutPanel
            // 
            detailsTableLayoutPanel.ColumnCount = 1;
            detailsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            detailsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            detailsTableLayoutPanel.Controls.Add(dobLbl, 0, 3);
            detailsTableLayoutPanel.Controls.Add(EmailLbl, 0, 2);
            detailsTableLayoutPanel.Controls.Add(LNameLbl, 0, 1);
            detailsTableLayoutPanel.Controls.Add(FNameLbl, 0, 0);
            detailsTableLayoutPanel.Dock = DockStyle.Fill;
            detailsTableLayoutPanel.Location = new Point(235, 3);
            detailsTableLayoutPanel.Name = "detailsTableLayoutPanel";
            detailsTableLayoutPanel.RowCount = 4;
            detailsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            detailsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            detailsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            detailsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            detailsTableLayoutPanel.Size = new Size(547, 319);
            detailsTableLayoutPanel.TabIndex = 1;
            // 
            // dobLbl
            // 
            dobLbl.Dock = DockStyle.Fill;
            dobLbl.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dobLbl.ForeColor = Color.FromArgb(241, 241, 241);
            dobLbl.Location = new Point(3, 237);
            dobLbl.Name = "dobLbl";
            dobLbl.Padding = new Padding(30, 0, 10, 0);
            dobLbl.Size = new Size(541, 82);
            dobLbl.TabIndex = 3;
            dobLbl.Text = "Date of Birth: 09/10/04";
            dobLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EmailLbl
            // 
            EmailLbl.Dock = DockStyle.Fill;
            EmailLbl.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EmailLbl.ForeColor = Color.FromArgb(241, 241, 241);
            EmailLbl.Location = new Point(3, 158);
            EmailLbl.Name = "EmailLbl";
            EmailLbl.Padding = new Padding(30, 0, 10, 0);
            EmailLbl.Size = new Size(541, 79);
            EmailLbl.TabIndex = 2;
            EmailLbl.Text = "Email: mc@gmail.com";
            EmailLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LNameLbl
            // 
            LNameLbl.Dock = DockStyle.Fill;
            LNameLbl.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LNameLbl.ForeColor = Color.FromArgb(241, 241, 241);
            LNameLbl.Location = new Point(3, 79);
            LNameLbl.Name = "LNameLbl";
            LNameLbl.Padding = new Padding(30, 0, 10, 0);
            LNameLbl.Size = new Size(541, 79);
            LNameLbl.TabIndex = 1;
            LNameLbl.Text = "Last Name: Coret";
            LNameLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FNameLbl
            // 
            FNameLbl.Dock = DockStyle.Fill;
            FNameLbl.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FNameLbl.ForeColor = Color.FromArgb(241, 241, 241);
            FNameLbl.Location = new Point(3, 0);
            FNameLbl.Name = "FNameLbl";
            FNameLbl.Padding = new Padding(30, 0, 10, 0);
            FNameLbl.Size = new Size(541, 79);
            FNameLbl.TabIndex = 0;
            FNameLbl.Text = "First Name: Megane";
            FNameLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // editBtnPanel
            // 
            editBtnPanel.Controls.Add(editBtn);
            editBtnPanel.Dock = DockStyle.Fill;
            editBtnPanel.Location = new Point(788, 3);
            editBtnPanel.Name = "editBtnPanel";
            editBtnPanel.Size = new Size(59, 319);
            editBtnPanel.TabIndex = 2;
            // 
            // editBtn
            // 
            editBtn.Anchor = AnchorStyles.None;
            editBtn.Cursor = Cursors.Hand;
            editBtn.Image = Resources.editBtn;
            editBtn.Location = new Point(8, 265);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(42, 40);
            editBtn.SizeMode = PictureBoxSizeMode.Zoom;
            editBtn.TabIndex = 0;
            editBtn.TabStop = false;
            editBtn.Click += editBtn_Click;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Anchor = AnchorStyles.None;
            buttonsPanel.ColumnCount = 2;
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonsPanel.Controls.Add(historyBtn, 1, 0);
            buttonsPanel.Controls.Add(changePasswordBtn, 0, 0);
            buttonsPanel.Location = new Point(173, 452);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.RowCount = 1;
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            buttonsPanel.Size = new Size(820, 88);
            buttonsPanel.TabIndex = 2;
            // 
            // historyBtn
            // 
            historyBtn.Anchor = AnchorStyles.None;
            historyBtn.BackColor = Color.FromArgb(26, 26, 26);
            historyBtn.CornerRadius = 8;
            historyBtn.Cursor = Cursors.Hand;
            historyBtn.FlatAppearance.BorderSize = 0;
            historyBtn.FlatStyle = FlatStyle.Flat;
            historyBtn.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            historyBtn.ForeColor = Color.FromArgb(241, 241, 241);
            historyBtn.Image = Resources.historyIcon;
            historyBtn.ImageAlign = ContentAlignment.MiddleRight;
            historyBtn.Location = new Point(440, 6);
            historyBtn.Name = "historyBtn";
            historyBtn.Size = new Size(350, 75);
            historyBtn.TabIndex = 1;
            historyBtn.TabStop = false;
            historyBtn.Text = "View Bet History";
            historyBtn.UseVisualStyleBackColor = false;
            historyBtn.Click += historyBtn_Click;
            // 
            // changePasswordBtn
            // 
            changePasswordBtn.Anchor = AnchorStyles.None;
            changePasswordBtn.BackColor = Color.FromArgb(26, 26, 26);
            changePasswordBtn.CornerRadius = 8;
            changePasswordBtn.Cursor = Cursors.Hand;
            changePasswordBtn.FlatAppearance.BorderSize = 0;
            changePasswordBtn.FlatStyle = FlatStyle.Flat;
            changePasswordBtn.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changePasswordBtn.ForeColor = Color.FromArgb(241, 241, 241);
            changePasswordBtn.Image = Resources.lockIcon;
            changePasswordBtn.ImageAlign = ContentAlignment.MiddleRight;
            changePasswordBtn.Location = new Point(30, 6);
            changePasswordBtn.Name = "changePasswordBtn";
            changePasswordBtn.Size = new Size(350, 75);
            changePasswordBtn.TabIndex = 0;
            changePasswordBtn.TabStop = false;
            changePasswordBtn.Text = "Change Password";
            changePasswordBtn.UseVisualStyleBackColor = false;
            changePasswordBtn.Click += changePasswordBtn_Click;
            // 
            // balancePanel
            // 
            balancePanel.Anchor = AnchorStyles.None;
            balancePanel.BackColor = Color.FromArgb(26, 26, 26);
            balancePanel.Controls.Add(balanceBtnPanel);
            balancePanel.Controls.Add(amountLbl);
            balancePanel.Controls.Add(balanceLbl);
            balancePanel.Location = new Point(208, 592);
            balancePanel.Name = "balancePanel";
            balancePanel.Size = new Size(750, 240);
            balancePanel.TabIndex = 3;
            // 
            // balanceBtnPanel
            // 
            balanceBtnPanel.ColumnCount = 2;
            balanceBtnPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            balanceBtnPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            balanceBtnPanel.Controls.Add(depositBtn, 1, 0);
            balanceBtnPanel.Controls.Add(WithdrawBtn, 0, 0);
            balanceBtnPanel.Dock = DockStyle.Fill;
            balanceBtnPanel.Location = new Point(0, 126);
            balanceBtnPanel.Name = "balanceBtnPanel";
            balanceBtnPanel.RowCount = 1;
            balanceBtnPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            balanceBtnPanel.Size = new Size(750, 114);
            balanceBtnPanel.TabIndex = 2;
            // 
            // depositBtn
            // 
            depositBtn.Anchor = AnchorStyles.None;
            depositBtn.BackColor = Color.FromArgb(93, 185, 64);
            depositBtn.CornerRadius = 8;
            depositBtn.Cursor = Cursors.Hand;
            depositBtn.FlatAppearance.BorderSize = 0;
            depositBtn.FlatStyle = FlatStyle.Flat;
            depositBtn.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            depositBtn.ForeColor = Color.FromArgb(241, 241, 241);
            depositBtn.ImageAlign = ContentAlignment.MiddleRight;
            depositBtn.Location = new Point(427, 25);
            depositBtn.Name = "depositBtn";
            depositBtn.Size = new Size(271, 63);
            depositBtn.TabIndex = 2;
            depositBtn.TabStop = false;
            depositBtn.Text = "Deposit";
            depositBtn.UseVisualStyleBackColor = false;
            depositBtn.Click += depositBtn_Click;
            // 
            // WithdrawBtn
            // 
            WithdrawBtn.Anchor = AnchorStyles.None;
            WithdrawBtn.BackColor = Color.FromArgb(54, 69, 79);
            WithdrawBtn.CornerRadius = 8;
            WithdrawBtn.Cursor = Cursors.Hand;
            WithdrawBtn.FlatAppearance.BorderSize = 0;
            WithdrawBtn.FlatStyle = FlatStyle.Flat;
            WithdrawBtn.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            WithdrawBtn.ForeColor = Color.FromArgb(241, 241, 241);
            WithdrawBtn.ImageAlign = ContentAlignment.MiddleRight;
            WithdrawBtn.Location = new Point(52, 25);
            WithdrawBtn.Name = "WithdrawBtn";
            WithdrawBtn.Size = new Size(271, 63);
            WithdrawBtn.TabIndex = 1;
            WithdrawBtn.TabStop = false;
            WithdrawBtn.Text = "Withdraw";
            WithdrawBtn.UseVisualStyleBackColor = false;
            WithdrawBtn.Click += withdrawBtn_Click;
            // 
            // amountLbl
            // 
            amountLbl.Dock = DockStyle.Top;
            amountLbl.Font = new Font("Times New Roman", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            amountLbl.ForeColor = Color.FromArgb(241, 241, 241);
            amountLbl.Location = new Point(0, 60);
            amountLbl.Name = "amountLbl";
            amountLbl.Size = new Size(750, 66);
            amountLbl.TabIndex = 1;
            amountLbl.Text = "$ 1020.50";
            amountLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // balanceLbl
            // 
            balanceLbl.Dock = DockStyle.Top;
            balanceLbl.Font = new Font("Times New Roman", 28.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            balanceLbl.ForeColor = Color.FromArgb(241, 241, 241);
            balanceLbl.Location = new Point(0, 0);
            balanceLbl.Name = "balanceLbl";
            balanceLbl.Size = new Size(750, 60);
            balanceLbl.TabIndex = 0;
            balanceLbl.Text = "Current Balance";
            balanceLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // navBar1
            // 
            navBar1.Dock = DockStyle.Top;
            navBar1.Location = new Point(0, 0);
            navBar1.Name = "navBar1";
            navBar1.Size = new Size(1184, 85);
            navBar1.TabIndex = 3;
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
            // AccountPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 711);
            Controls.Add(bgPanel);
            Name = "AccountPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AccountPage";
            bgPanel.ResumeLayout(false);
            scrollablePanel.ResumeLayout(false);
            ProfileTableLayoutPanel.ResumeLayout(false);
            ProfileTableLayoutPanel.PerformLayout();
            detailsRoundedPanel.ResumeLayout(false);
            DetailsBgtableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)userIcon).EndInit();
            detailsTableLayoutPanel.ResumeLayout(false);
            editBtnPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editBtn).EndInit();
            buttonsPanel.ResumeLayout(false);
            balancePanel.ResumeLayout(false);
            balanceBtnPanel.ResumeLayout(false);
            dropdownList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel bgPanel;
        private Label homePageBtn;
        private ContextMenuStrip dropdownList;
        private ToolStripMenuItem viewProfileToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel scrollablePanel;
        private TableLayoutPanel ProfileTableLayoutPanel;
        private Label accountPageLbl;
        private RoundedPanel detailsRoundedPanel;
        private TableLayoutPanel DetailsBgtableLayoutPanel;
        private PictureBox userIcon;
        private TableLayoutPanel detailsTableLayoutPanel;
        private Label dobLbl;
        private Label EmailLbl;
        private Label LNameLbl;
        private Label FNameLbl;
        private Panel editBtnPanel;
        private TableLayoutPanel buttonsPanel;
        private RoundedButton historyBtn;
        private RoundedButton changePasswordBtn;
        private RoundedPanel balancePanel;
        private TableLayoutPanel balanceBtnPanel;
        private RoundedButton WithdrawBtn;
        private Label amountLbl;
        private Label balanceLbl;
        private RoundedButton depositBtn;
        private PictureBox editBtn;
        private NavBar navBar1;
    }
}