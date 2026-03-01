namespace BettingSystem
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
            accountPageLayout = new TableLayoutPanel();
            lblAccount = new Label();
            userInfoPanel = new Panel();
            userDetailsLayout = new TableLayoutPanel();
            userIcon = new PictureBox();
            userDetailsTbl = new TableLayoutPanel();
            dobPanel = new Panel();
            txtDobLine = new Panel();
            txtDob = new TextBox();
            lblDob = new Label();
            emailPanel = new Panel();
            txtEmailLine = new Panel();
            txtEmail = new TextBox();
            lblEmail = new Label();
            lNamePanel = new Panel();
            txtLNameLine = new Panel();
            txtLName = new TextBox();
            lblLName = new Label();
            lblFName = new Label();
            fNamePanel = new Panel();
            txtLFameLine = new Panel();
            txtFName = new TextBox();
            buttonsPanels = new TableLayoutPanel();
            historyBtn = new Button();
            changePasswordBtn = new Button();
            walletPanel = new Panel();
            balanceLayout = new TableLayoutPanel();
            lblBalanceAmount = new Label();
            lblCurrentBalance = new Label();
            walletBtnLayout = new TableLayoutPanel();
            DepositMoneyBtn = new Button();
            withdrawMoneyBtn = new Button();
            navPanel = new Panel();
            navCentrePanel = new Panel();
            betSlipsPageBtn = new Button();
            homeBtn = new Button();
            rightNavPanel = new Panel();
            navDropdownBtn = new Button();
            walletDepositBtn = new Button();
            leftNavPanel = new Panel();
            lblAppName = new Label();
            navLogo = new PictureBox();
            dropdownList = new ContextMenuStrip(components);
            viewProfileToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            bgPanel.SuspendLayout();
            scrollablePanel.SuspendLayout();
            accountPageLayout.SuspendLayout();
            userInfoPanel.SuspendLayout();
            userDetailsLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userIcon).BeginInit();
            userDetailsTbl.SuspendLayout();
            dobPanel.SuspendLayout();
            emailPanel.SuspendLayout();
            lNamePanel.SuspendLayout();
            fNamePanel.SuspendLayout();
            buttonsPanels.SuspendLayout();
            walletPanel.SuspendLayout();
            balanceLayout.SuspendLayout();
            walletBtnLayout.SuspendLayout();
            navPanel.SuspendLayout();
            navCentrePanel.SuspendLayout();
            rightNavPanel.SuspendLayout();
            leftNavPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)navLogo).BeginInit();
            dropdownList.SuspendLayout();
            SuspendLayout();
            // 
            // bgPanel
            // 
            bgPanel.BackColor = Color.FromArgb(36, 36, 36);
            bgPanel.Controls.Add(scrollablePanel);
            bgPanel.Controls.Add(navPanel);
            bgPanel.Dock = DockStyle.Fill;
            bgPanel.Location = new Point(0, 0);
            bgPanel.Margin = new Padding(0);
            bgPanel.Name = "bgPanel";
            bgPanel.Size = new Size(1115, 738);
            bgPanel.TabIndex = 0;
            // 
            // scrollablePanel
            // 
            scrollablePanel.AutoScroll = true;
            scrollablePanel.Controls.Add(accountPageLayout);
            scrollablePanel.Dock = DockStyle.Fill;
            scrollablePanel.Location = new Point(0, 70);
            scrollablePanel.Name = "scrollablePanel";
            scrollablePanel.Padding = new Padding(5);
            scrollablePanel.Size = new Size(1115, 668);
            scrollablePanel.TabIndex = 2;
            // 
            // accountPageLayout
            // 
            accountPageLayout.ColumnCount = 1;
            accountPageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            accountPageLayout.Controls.Add(lblAccount, 0, 0);
            accountPageLayout.Controls.Add(userInfoPanel, 0, 1);
            accountPageLayout.Controls.Add(buttonsPanels, 0, 2);
            accountPageLayout.Controls.Add(walletPanel, 0, 3);
            accountPageLayout.Dock = DockStyle.Fill;
            accountPageLayout.Location = new Point(5, 5);
            accountPageLayout.Margin = new Padding(0);
            accountPageLayout.Name = "accountPageLayout";
            accountPageLayout.Padding = new Padding(10);
            accountPageLayout.RowCount = 4;
            accountPageLayout.RowStyles.Add(new RowStyle());
            accountPageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            accountPageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            accountPageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            accountPageLayout.Size = new Size(1105, 658);
            accountPageLayout.TabIndex = 1;
            // 
            // lblAccount
            // 
            lblAccount.Dock = DockStyle.Fill;
            lblAccount.Font = new Font("Times New Roman", 31.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAccount.ForeColor = Color.FromArgb(241, 241, 241);
            lblAccount.Location = new Point(10, 10);
            lblAccount.Margin = new Padding(0);
            lblAccount.Name = "lblAccount";
            lblAccount.Padding = new Padding(2, 20, 2, 10);
            lblAccount.Size = new Size(1085, 107);
            lblAccount.TabIndex = 2;
            lblAccount.Text = "My Account";
            lblAccount.TextAlign = ContentAlignment.TopCenter;
            // 
            // userInfoPanel
            // 
            userInfoPanel.Controls.Add(userDetailsLayout);
            userInfoPanel.Dock = DockStyle.Fill;
            userInfoPanel.Location = new Point(13, 120);
            userInfoPanel.Name = "userInfoPanel";
            userInfoPanel.Padding = new Padding(100, 0, 100, 0);
            userInfoPanel.Size = new Size(1079, 232);
            userInfoPanel.TabIndex = 3;
            // 
            // userDetailsLayout
            // 
            userDetailsLayout.BackColor = Color.FromArgb(26, 26, 26);
            userDetailsLayout.ColumnCount = 2;
            userDetailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            userDetailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.66667F));
            userDetailsLayout.Controls.Add(userIcon, 0, 0);
            userDetailsLayout.Controls.Add(userDetailsTbl, 1, 0);
            userDetailsLayout.Dock = DockStyle.Fill;
            userDetailsLayout.Location = new Point(100, 0);
            userDetailsLayout.Margin = new Padding(0);
            userDetailsLayout.Name = "userDetailsLayout";
            userDetailsLayout.Padding = new Padding(0, 40, 0, 40);
            userDetailsLayout.RowCount = 1;
            userDetailsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            userDetailsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            userDetailsLayout.Size = new Size(879, 232);
            userDetailsLayout.TabIndex = 1;
            // 
            // userIcon
            // 
            userIcon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            userIcon.Image = Properties.Resources.userIcon;
            userIcon.Location = new Point(46, 40);
            userIcon.Margin = new Padding(0);
            userIcon.Name = "userIcon";
            userIcon.Size = new Size(200, 152);
            userIcon.SizeMode = PictureBoxSizeMode.Zoom;
            userIcon.TabIndex = 0;
            userIcon.TabStop = false;
            // 
            // userDetailsTbl
            // 
            userDetailsTbl.ColumnCount = 2;
            userDetailsTbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            userDetailsTbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            userDetailsTbl.Controls.Add(dobPanel, 1, 3);
            userDetailsTbl.Controls.Add(lblDob, 0, 3);
            userDetailsTbl.Controls.Add(emailPanel, 1, 2);
            userDetailsTbl.Controls.Add(lblEmail, 0, 2);
            userDetailsTbl.Controls.Add(lNamePanel, 1, 1);
            userDetailsTbl.Controls.Add(lblLName, 0, 1);
            userDetailsTbl.Controls.Add(lblFName, 0, 0);
            userDetailsTbl.Controls.Add(fNamePanel, 1, 0);
            userDetailsTbl.Dock = DockStyle.Fill;
            userDetailsTbl.Location = new Point(295, 43);
            userDetailsTbl.Name = "userDetailsTbl";
            userDetailsTbl.RowCount = 4;
            userDetailsTbl.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            userDetailsTbl.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            userDetailsTbl.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            userDetailsTbl.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            userDetailsTbl.Size = new Size(581, 146);
            userDetailsTbl.TabIndex = 1;
            // 
            // dobPanel
            // 
            dobPanel.Controls.Add(txtDobLine);
            dobPanel.Controls.Add(txtDob);
            dobPanel.Dock = DockStyle.Fill;
            dobPanel.Location = new Point(174, 108);
            dobPanel.Margin = new Padding(0);
            dobPanel.Name = "dobPanel";
            dobPanel.Padding = new Padding(0, 15, 20, 1);
            dobPanel.Size = new Size(407, 38);
            dobPanel.TabIndex = 7;
            dobPanel.Paint += dobPanel_Paint;
            // 
            // txtDobLine
            // 
            txtDobLine.BackColor = Color.FromArgb(241, 241, 241);
            txtDobLine.Dock = DockStyle.Bottom;
            txtDobLine.Location = new Point(0, 35);
            txtDobLine.Name = "txtDobLine";
            txtDobLine.Size = new Size(387, 2);
            txtDobLine.TabIndex = 1;
            // 
            // txtDob
            // 
            txtDob.BackColor = Color.FromArgb(26, 26, 26);
            txtDob.BorderStyle = BorderStyle.None;
            txtDob.Dock = DockStyle.Fill;
            txtDob.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDob.ForeColor = Color.FromArgb(241, 241, 241);
            txtDob.Location = new Point(0, 15);
            txtDob.Name = "txtDob";
            txtDob.Size = new Size(387, 17);
            txtDob.TabIndex = 0;
            // 
            // lblDob
            // 
            lblDob.AutoSize = true;
            lblDob.Dock = DockStyle.Left;
            lblDob.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDob.ForeColor = Color.FromArgb(241, 241, 241);
            lblDob.Location = new Point(3, 108);
            lblDob.Name = "lblDob";
            lblDob.Size = new Size(145, 38);
            lblDob.TabIndex = 6;
            lblDob.Text = "Date of Birth:";
            lblDob.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // emailPanel
            // 
            emailPanel.Controls.Add(txtEmailLine);
            emailPanel.Controls.Add(txtEmail);
            emailPanel.Dock = DockStyle.Fill;
            emailPanel.Location = new Point(174, 72);
            emailPanel.Margin = new Padding(0);
            emailPanel.Name = "emailPanel";
            emailPanel.Padding = new Padding(0, 15, 20, 1);
            emailPanel.Size = new Size(407, 36);
            emailPanel.TabIndex = 5;
            // 
            // txtEmailLine
            // 
            txtEmailLine.BackColor = Color.FromArgb(241, 241, 241);
            txtEmailLine.Dock = DockStyle.Bottom;
            txtEmailLine.Location = new Point(0, 33);
            txtEmailLine.Name = "txtEmailLine";
            txtEmailLine.Size = new Size(387, 2);
            txtEmailLine.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(26, 26, 26);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.FromArgb(241, 241, 241);
            txtEmail.Location = new Point(0, 15);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(387, 17);
            txtEmail.TabIndex = 0;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Dock = DockStyle.Left;
            lblEmail.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(241, 241, 241);
            lblEmail.Location = new Point(3, 72);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(74, 36);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lNamePanel
            // 
            lNamePanel.Controls.Add(txtLNameLine);
            lNamePanel.Controls.Add(txtLName);
            lNamePanel.Dock = DockStyle.Fill;
            lNamePanel.Location = new Point(174, 36);
            lNamePanel.Margin = new Padding(0);
            lNamePanel.Name = "lNamePanel";
            lNamePanel.Padding = new Padding(0, 15, 20, 1);
            lNamePanel.Size = new Size(407, 36);
            lNamePanel.TabIndex = 3;
            // 
            // txtLNameLine
            // 
            txtLNameLine.BackColor = Color.FromArgb(241, 241, 241);
            txtLNameLine.Dock = DockStyle.Bottom;
            txtLNameLine.Location = new Point(0, 33);
            txtLNameLine.Name = "txtLNameLine";
            txtLNameLine.Size = new Size(387, 2);
            txtLNameLine.TabIndex = 1;
            // 
            // txtLName
            // 
            txtLName.BackColor = Color.FromArgb(26, 26, 26);
            txtLName.BorderStyle = BorderStyle.None;
            txtLName.Dock = DockStyle.Fill;
            txtLName.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLName.ForeColor = Color.FromArgb(241, 241, 241);
            txtLName.Location = new Point(0, 15);
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(387, 17);
            txtLName.TabIndex = 0;
            // 
            // lblLName
            // 
            lblLName.AutoSize = true;
            lblLName.Dock = DockStyle.Left;
            lblLName.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLName.ForeColor = Color.FromArgb(241, 241, 241);
            lblLName.Location = new Point(3, 36);
            lblLName.Name = "lblLName";
            lblLName.Size = new Size(123, 36);
            lblLName.TabIndex = 2;
            lblLName.Text = "Last Name:";
            lblLName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFName
            // 
            lblFName.AutoSize = true;
            lblFName.Dock = DockStyle.Left;
            lblFName.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFName.ForeColor = Color.FromArgb(241, 241, 241);
            lblFName.Location = new Point(3, 0);
            lblFName.Name = "lblFName";
            lblFName.Size = new Size(124, 36);
            lblFName.TabIndex = 0;
            lblFName.Text = "First Name:";
            lblFName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fNamePanel
            // 
            fNamePanel.Controls.Add(txtLFameLine);
            fNamePanel.Controls.Add(txtFName);
            fNamePanel.Dock = DockStyle.Fill;
            fNamePanel.Location = new Point(174, 0);
            fNamePanel.Margin = new Padding(0);
            fNamePanel.Name = "fNamePanel";
            fNamePanel.Padding = new Padding(0, 18, 20, 6);
            fNamePanel.Size = new Size(407, 36);
            fNamePanel.TabIndex = 1;
            // 
            // txtLFameLine
            // 
            txtLFameLine.BackColor = Color.FromArgb(241, 241, 241);
            txtLFameLine.Dock = DockStyle.Bottom;
            txtLFameLine.Location = new Point(0, 28);
            txtLFameLine.Name = "txtLFameLine";
            txtLFameLine.Size = new Size(387, 2);
            txtLFameLine.TabIndex = 1;
            // 
            // txtFName
            // 
            txtFName.BackColor = Color.FromArgb(26, 26, 26);
            txtFName.BorderStyle = BorderStyle.None;
            txtFName.Dock = DockStyle.Fill;
            txtFName.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFName.ForeColor = Color.FromArgb(241, 241, 241);
            txtFName.Location = new Point(0, 18);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(387, 17);
            txtFName.TabIndex = 0;
            // 
            // buttonsPanels
            // 
            buttonsPanels.ColumnCount = 2;
            buttonsPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonsPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonsPanels.Controls.Add(historyBtn, 1, 0);
            buttonsPanels.Controls.Add(changePasswordBtn, 0, 0);
            buttonsPanels.Dock = DockStyle.Fill;
            buttonsPanels.Location = new Point(13, 358);
            buttonsPanels.Name = "buttonsPanels";
            buttonsPanels.RowCount = 1;
            buttonsPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            buttonsPanels.Size = new Size(1079, 100);
            buttonsPanels.TabIndex = 4;
            // 
            // historyBtn
            // 
            historyBtn.Anchor = AnchorStyles.None;
            historyBtn.AutoSize = true;
            historyBtn.BackColor = Color.FromArgb(26, 26, 26);
            historyBtn.FlatAppearance.BorderColor = Color.FromArgb(58, 58, 58);
            historyBtn.FlatStyle = FlatStyle.Flat;
            historyBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            historyBtn.ForeColor = Color.FromArgb(241, 241, 241);
            historyBtn.Image = Properties.Resources.historyIcon;
            historyBtn.ImageAlign = ContentAlignment.MiddleRight;
            historyBtn.Location = new Point(684, 20);
            historyBtn.Margin = new Padding(0);
            historyBtn.Name = "historyBtn";
            historyBtn.Padding = new Padding(2, 0, 5, 0);
            historyBtn.Size = new Size(250, 60);
            historyBtn.TabIndex = 2;
            historyBtn.Text = "View Bet History";
            historyBtn.UseVisualStyleBackColor = false;
            // 
            // changePasswordBtn
            // 
            changePasswordBtn.Anchor = AnchorStyles.None;
            changePasswordBtn.AutoSize = true;
            changePasswordBtn.BackColor = Color.FromArgb(26, 26, 26);
            changePasswordBtn.FlatAppearance.BorderColor = Color.FromArgb(58, 58, 58);
            changePasswordBtn.FlatStyle = FlatStyle.Flat;
            changePasswordBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changePasswordBtn.ForeColor = Color.FromArgb(241, 241, 241);
            changePasswordBtn.Image = Properties.Resources.lockIcon;
            changePasswordBtn.ImageAlign = ContentAlignment.MiddleRight;
            changePasswordBtn.Location = new Point(144, 20);
            changePasswordBtn.Margin = new Padding(0);
            changePasswordBtn.Name = "changePasswordBtn";
            changePasswordBtn.Padding = new Padding(2, 0, 5, 0);
            changePasswordBtn.Size = new Size(250, 60);
            changePasswordBtn.TabIndex = 1;
            changePasswordBtn.Text = "Change Password";
            changePasswordBtn.UseVisualStyleBackColor = false;
            // 
            // walletPanel
            // 
            walletPanel.Controls.Add(balanceLayout);
            walletPanel.Dock = DockStyle.Fill;
            walletPanel.Location = new Point(10, 461);
            walletPanel.Margin = new Padding(0);
            walletPanel.Name = "walletPanel";
            walletPanel.Padding = new Padding(250, 0, 250, 0);
            walletPanel.Size = new Size(1085, 187);
            walletPanel.TabIndex = 5;
            // 
            // balanceLayout
            // 
            balanceLayout.BackColor = Color.FromArgb(26, 26, 26);
            balanceLayout.ColumnCount = 1;
            balanceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            balanceLayout.Controls.Add(lblBalanceAmount, 0, 1);
            balanceLayout.Controls.Add(lblCurrentBalance, 0, 0);
            balanceLayout.Controls.Add(walletBtnLayout, 0, 2);
            balanceLayout.Dock = DockStyle.Fill;
            balanceLayout.Location = new Point(250, 0);
            balanceLayout.Name = "balanceLayout";
            balanceLayout.Padding = new Padding(0, 15, 0, 15);
            balanceLayout.RowCount = 3;
            balanceLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            balanceLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            balanceLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            balanceLayout.Size = new Size(585, 187);
            balanceLayout.TabIndex = 0;
            // 
            // lblBalanceAmount
            // 
            lblBalanceAmount.AutoSize = true;
            lblBalanceAmount.Dock = DockStyle.Fill;
            lblBalanceAmount.Font = new Font("Times New Roman", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBalanceAmount.ForeColor = Color.FromArgb(241, 241, 241);
            lblBalanceAmount.Location = new Point(3, 62);
            lblBalanceAmount.Name = "lblBalanceAmount";
            lblBalanceAmount.Size = new Size(579, 47);
            lblBalanceAmount.TabIndex = 1;
            lblBalanceAmount.Text = "$ 1,200.50";
            lblBalanceAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentBalance
            // 
            lblCurrentBalance.AutoSize = true;
            lblCurrentBalance.Dock = DockStyle.Fill;
            lblCurrentBalance.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentBalance.ForeColor = Color.FromArgb(241, 241, 241);
            lblCurrentBalance.Location = new Point(3, 15);
            lblCurrentBalance.Name = "lblCurrentBalance";
            lblCurrentBalance.Size = new Size(579, 47);
            lblCurrentBalance.TabIndex = 0;
            lblCurrentBalance.Text = "Current Balance";
            lblCurrentBalance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // walletBtnLayout
            // 
            walletBtnLayout.AutoSize = true;
            walletBtnLayout.ColumnCount = 2;
            walletBtnLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            walletBtnLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            walletBtnLayout.Controls.Add(DepositMoneyBtn, 1, 0);
            walletBtnLayout.Controls.Add(withdrawMoneyBtn, 0, 0);
            walletBtnLayout.Dock = DockStyle.Fill;
            walletBtnLayout.Location = new Point(3, 112);
            walletBtnLayout.Name = "walletBtnLayout";
            walletBtnLayout.RowCount = 1;
            walletBtnLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            walletBtnLayout.Size = new Size(579, 57);
            walletBtnLayout.TabIndex = 2;
            // 
            // DepositMoneyBtn
            // 
            DepositMoneyBtn.Anchor = AnchorStyles.None;
            DepositMoneyBtn.AutoSize = true;
            DepositMoneyBtn.BackColor = Color.FromArgb(93, 185, 64);
            DepositMoneyBtn.FlatAppearance.BorderColor = Color.FromArgb(58, 58, 58);
            DepositMoneyBtn.FlatStyle = FlatStyle.Flat;
            DepositMoneyBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DepositMoneyBtn.ForeColor = Color.FromArgb(241, 241, 241);
            DepositMoneyBtn.ImageAlign = ContentAlignment.MiddleRight;
            DepositMoneyBtn.Location = new Point(324, 3);
            DepositMoneyBtn.Margin = new Padding(0);
            DepositMoneyBtn.Name = "DepositMoneyBtn";
            DepositMoneyBtn.Padding = new Padding(2, 0, 5, 0);
            DepositMoneyBtn.Size = new Size(220, 50);
            DepositMoneyBtn.TabIndex = 3;
            DepositMoneyBtn.Text = "Deposit";
            DepositMoneyBtn.UseVisualStyleBackColor = false;
            // 
            // withdrawMoneyBtn
            // 
            withdrawMoneyBtn.Anchor = AnchorStyles.None;
            withdrawMoneyBtn.AutoSize = true;
            withdrawMoneyBtn.BackColor = Color.FromArgb(74, 90, 102);
            withdrawMoneyBtn.FlatAppearance.BorderColor = Color.FromArgb(58, 58, 58);
            withdrawMoneyBtn.FlatStyle = FlatStyle.Flat;
            withdrawMoneyBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            withdrawMoneyBtn.ForeColor = Color.FromArgb(241, 241, 241);
            withdrawMoneyBtn.ImageAlign = ContentAlignment.MiddleRight;
            withdrawMoneyBtn.Location = new Point(34, 3);
            withdrawMoneyBtn.Margin = new Padding(0);
            withdrawMoneyBtn.Name = "withdrawMoneyBtn";
            withdrawMoneyBtn.Padding = new Padding(2, 0, 5, 0);
            withdrawMoneyBtn.Size = new Size(220, 50);
            withdrawMoneyBtn.TabIndex = 2;
            withdrawMoneyBtn.Text = "Withdraw";
            withdrawMoneyBtn.UseVisualStyleBackColor = false;
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
            navPanel.Padding = new Padding(2);
            navPanel.Size = new Size(1115, 70);
            navPanel.TabIndex = 0;
            // 
            // navCentrePanel
            // 
            navCentrePanel.AutoSize = true;
            navCentrePanel.Controls.Add(betSlipsPageBtn);
            navCentrePanel.Controls.Add(homeBtn);
            navCentrePanel.Dock = DockStyle.Fill;
            navCentrePanel.Location = new Point(241, 2);
            navCentrePanel.Name = "navCentrePanel";
            navCentrePanel.Size = new Size(482, 66);
            navCentrePanel.TabIndex = 2;
            // 
            // betSlipsPageBtn
            // 
            betSlipsPageBtn.AutoSize = true;
            betSlipsPageBtn.Dock = DockStyle.Left;
            betSlipsPageBtn.FlatAppearance.BorderSize = 0;
            betSlipsPageBtn.FlatStyle = FlatStyle.Flat;
            betSlipsPageBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            betSlipsPageBtn.ForeColor = Color.FromArgb(241, 241, 241);
            betSlipsPageBtn.Location = new Point(93, 0);
            betSlipsPageBtn.Name = "betSlipsPageBtn";
            betSlipsPageBtn.Size = new Size(93, 66);
            betSlipsPageBtn.TabIndex = 1;
            betSlipsPageBtn.Text = "Bet Slips";
            betSlipsPageBtn.UseVisualStyleBackColor = true;
            // 
            // homeBtn
            // 
            homeBtn.AutoSize = true;
            homeBtn.Dock = DockStyle.Left;
            homeBtn.FlatAppearance.BorderSize = 0;
            homeBtn.FlatStyle = FlatStyle.Flat;
            homeBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            homeBtn.ForeColor = Color.FromArgb(241, 241, 241);
            homeBtn.Location = new Point(0, 0);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(93, 66);
            homeBtn.TabIndex = 0;
            homeBtn.Text = "Matches";
            homeBtn.UseVisualStyleBackColor = true;
            // 
            // rightNavPanel
            // 
            rightNavPanel.Controls.Add(navDropdownBtn);
            rightNavPanel.Controls.Add(walletDepositBtn);
            rightNavPanel.Dock = DockStyle.Right;
            rightNavPanel.Location = new Point(723, 2);
            rightNavPanel.Name = "rightNavPanel";
            rightNavPanel.Size = new Size(390, 66);
            rightNavPanel.TabIndex = 1;
            // 
            // navDropdownBtn
            // 
            navDropdownBtn.AutoSize = true;
            navDropdownBtn.BackColor = Color.FromArgb(38, 38, 38);
            navDropdownBtn.FlatAppearance.BorderColor = Color.FromArgb(58, 58, 58);
            navDropdownBtn.FlatStyle = FlatStyle.Flat;
            navDropdownBtn.ForeColor = Color.FromArgb(241, 241, 241);
            navDropdownBtn.Image = Properties.Resources.dropdownArrow;
            navDropdownBtn.ImageAlign = ContentAlignment.MiddleRight;
            navDropdownBtn.Location = new Point(229, 12);
            navDropdownBtn.Margin = new Padding(0);
            navDropdownBtn.Name = "navDropdownBtn";
            navDropdownBtn.Padding = new Padding(2, 2, 4, 2);
            navDropdownBtn.Size = new Size(145, 45);
            navDropdownBtn.TabIndex = 1;
            navDropdownBtn.UseVisualStyleBackColor = false;
            navDropdownBtn.Click += navDropdownBtn_Click;
            // 
            // walletDepositBtn
            // 
            walletDepositBtn.AutoSize = true;
            walletDepositBtn.BackColor = Color.FromArgb(93, 185, 64);
            walletDepositBtn.FlatAppearance.BorderColor = Color.FromArgb(241, 241, 241);
            walletDepositBtn.FlatAppearance.BorderSize = 0;
            walletDepositBtn.FlatStyle = FlatStyle.Popup;
            walletDepositBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            walletDepositBtn.ForeColor = Color.FromArgb(241, 241, 241);
            walletDepositBtn.Location = new Point(46, 13);
            walletDepositBtn.Name = "walletDepositBtn";
            walletDepositBtn.Size = new Size(120, 40);
            walletDepositBtn.TabIndex = 0;
            walletDepositBtn.Text = "+ Deposit";
            walletDepositBtn.UseVisualStyleBackColor = false;
            walletDepositBtn.Click += walletDepositBtn_Click;
            // 
            // leftNavPanel
            // 
            leftNavPanel.Controls.Add(lblAppName);
            leftNavPanel.Controls.Add(navLogo);
            leftNavPanel.Dock = DockStyle.Left;
            leftNavPanel.Location = new Point(2, 2);
            leftNavPanel.Name = "leftNavPanel";
            leftNavPanel.Size = new Size(239, 66);
            leftNavPanel.TabIndex = 0;
            // 
            // lblAppName
            // 
            lblAppName.Dock = DockStyle.Fill;
            lblAppName.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.FromArgb(76, 175, 80);
            lblAppName.Location = new Point(61, 0);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(178, 66);
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
            navLogo.Size = new Size(61, 66);
            navLogo.SizeMode = PictureBoxSizeMode.Zoom;
            navLogo.TabIndex = 0;
            navLogo.TabStop = false;
            // 
            // dropdownList
            // 
            dropdownList.BackColor = Color.FromArgb(38, 38, 38);
            dropdownList.Font = new Font("Times New Roman", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dropdownList.ForeColor = Color.FromArgb(241, 241, 241);
            dropdownList.Items.AddRange(new ToolStripItem[] { viewProfileToolStripMenuItem, logOutToolStripMenuItem });
            dropdownList.Name = "dropdownList";
            dropdownList.RenderMode = ToolStripRenderMode.System;
            dropdownList.Size = new Size(151, 48);
            // 
            // viewProfileToolStripMenuItem
            // 
            viewProfileToolStripMenuItem.Name = "viewProfileToolStripMenuItem";
            viewProfileToolStripMenuItem.Size = new Size(150, 22);
            viewProfileToolStripMenuItem.Text = "View Profile";
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(150, 22);
            logOutToolStripMenuItem.Text = "Log Out";
            // 
            // AccountPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 738);
            Controls.Add(bgPanel);
            Name = "AccountPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AccountPage";
            bgPanel.ResumeLayout(false);
            scrollablePanel.ResumeLayout(false);
            accountPageLayout.ResumeLayout(false);
            userInfoPanel.ResumeLayout(false);
            userDetailsLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)userIcon).EndInit();
            userDetailsTbl.ResumeLayout(false);
            userDetailsTbl.PerformLayout();
            dobPanel.ResumeLayout(false);
            dobPanel.PerformLayout();
            emailPanel.ResumeLayout(false);
            emailPanel.PerformLayout();
            lNamePanel.ResumeLayout(false);
            lNamePanel.PerformLayout();
            fNamePanel.ResumeLayout(false);
            fNamePanel.PerformLayout();
            buttonsPanels.ResumeLayout(false);
            buttonsPanels.PerformLayout();
            walletPanel.ResumeLayout(false);
            balanceLayout.ResumeLayout(false);
            balanceLayout.PerformLayout();
            walletBtnLayout.ResumeLayout(false);
            walletBtnLayout.PerformLayout();
            navPanel.ResumeLayout(false);
            navPanel.PerformLayout();
            navCentrePanel.ResumeLayout(false);
            navCentrePanel.PerformLayout();
            rightNavPanel.ResumeLayout(false);
            rightNavPanel.PerformLayout();
            leftNavPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)navLogo).EndInit();
            dropdownList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel bgPanel;
        private Panel navPanel;
        private Panel rightNavPanel;
        private Panel leftNavPanel;
        private PictureBox navLogo;
        private Label lblAppName;
        private Panel navCentrePanel;
        private Label homePageBtn;
        private Button homeBtn;
        private Button walletDepositBtn;
        private Button betSlipsPageBtn;
        private Button navDropdownBtn;
        private ContextMenuStrip dropdownList;
        private ToolStripMenuItem viewProfileToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private TableLayoutPanel accountPageLayout;
        private Label lblAccount;
        private Panel userInfoPanel;
        private TableLayoutPanel userDetailsLayout;
        private PictureBox userIcon;
        private TableLayoutPanel userDetailsTbl;
        private Label lblFName;
        private Panel fNamePanel;
        private TextBox txtFName;
        private Label lblEmail;
        private Panel lNamePanel;
        private Panel txtLNameLine;
        private TextBox txtLName;
        private Label lblLName;
        private Panel txtLFameLine;
        private Panel dobPanel;
        private Panel txtDobLine;
        private TextBox txtDob;
        private Label lblDob;
        private Panel emailPanel;
        private Panel txtEmailLine;
        private TextBox txtEmail;
        private Panel scrollablePanel;
        private TableLayoutPanel buttonsPanels;
        private Button changePasswordBtn;
        private Button historyBtn;
        private Panel walletPanel;
        private TableLayoutPanel balanceLayout;
        private Label lblBalanceAmount;
        private Label lblCurrentBalance;
        private TableLayoutPanel walletBtnLayout;
        private Button DepositMoneyBtn;
        private Button withdrawMoneyBtn;
    }
}