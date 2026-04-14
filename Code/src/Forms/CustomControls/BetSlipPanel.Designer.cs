namespace BettingSystem.Forms.CustomControls
{
    partial class BetSlipPanel
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
            slipRoundedPanel = new RoundedPanel();
            slipTableLayoutBgPanel = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            payoutLbl = new Label();
            stakeLbl = new Label();
            statusLbl = new Label();
            slipTableLayoutPanel1 = new TableLayoutPanel();
            totalOddsLbl = new Label();
            totalBetsLbl = new Label();
            slipDateLbl = new Label();
            slipMatchInfoPanel = new Panel();
            previewMatchDateLbl = new Label();
            matchTableLayoutPanel = new TableLayoutPanel();
            vsLbl = new Label();
            homeTeamPanel = new Panel();
            homeTeamLbl = new Label();
            awayTeamPanel = new Panel();
            awayTeamLbl = new Label();
            previewedLeagueLbl = new Label();
            previewLbl = new Label();
            claimBtnPanel = new Panel();
            claimBtn = new RoundedButton();
            slipRoundedPanel.SuspendLayout();
            slipTableLayoutBgPanel.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            slipTableLayoutPanel1.SuspendLayout();
            slipMatchInfoPanel.SuspendLayout();
            matchTableLayoutPanel.SuspendLayout();
            homeTeamPanel.SuspendLayout();
            awayTeamPanel.SuspendLayout();
            claimBtnPanel.SuspendLayout();
            SuspendLayout();
            // 
            // slipRoundedPanel
            // 
            slipRoundedPanel.BackColor = Color.FromArgb(31, 31, 31);
            slipRoundedPanel.Controls.Add(slipTableLayoutBgPanel);
            slipRoundedPanel.Dock = DockStyle.Fill;
            slipRoundedPanel.Location = new Point(0, 0);
            slipRoundedPanel.Name = "slipRoundedPanel";
            slipRoundedPanel.Size = new Size(1119, 161);
            slipRoundedPanel.TabIndex = 1;
            // 
            // slipTableLayoutBgPanel
            // 
            slipTableLayoutBgPanel.ColumnCount = 4;
            slipTableLayoutBgPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.89991F));
            slipTableLayoutBgPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.0008945F));
            slipTableLayoutBgPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.3875561F));
            slipTableLayoutBgPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.6236687F));
            slipTableLayoutBgPanel.Controls.Add(tableLayoutPanel2, 2, 0);
            slipTableLayoutBgPanel.Controls.Add(slipTableLayoutPanel1, 1, 0);
            slipTableLayoutBgPanel.Controls.Add(slipMatchInfoPanel, 0, 0);
            slipTableLayoutBgPanel.Controls.Add(claimBtnPanel, 3, 0);
            slipTableLayoutBgPanel.Dock = DockStyle.Fill;
            slipTableLayoutBgPanel.Location = new Point(0, 0);
            slipTableLayoutBgPanel.Name = "slipTableLayoutBgPanel";
            slipTableLayoutBgPanel.RowCount = 1;
            slipTableLayoutBgPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            slipTableLayoutBgPanel.Size = new Size(1119, 161);
            slipTableLayoutBgPanel.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(payoutLbl, 0, 2);
            tableLayoutPanel2.Controls.Add(stakeLbl, 0, 1);
            tableLayoutPanel2.Controls.Add(statusLbl, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(774, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(10, 20, 10, 10);
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(211, 155);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // payoutLbl
            // 
            payoutLbl.Dock = DockStyle.Top;
            payoutLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            payoutLbl.ForeColor = Color.FromArgb(241, 241, 241);
            payoutLbl.Location = new Point(13, 102);
            payoutLbl.Name = "payoutLbl";
            payoutLbl.Padding = new Padding(5, 0, 0, 0);
            payoutLbl.Size = new Size(185, 24);
            payoutLbl.TabIndex = 4;
            payoutLbl.Text = "Payout: $150.00";
            payoutLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // stakeLbl
            // 
            stakeLbl.Dock = DockStyle.Top;
            stakeLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stakeLbl.ForeColor = Color.FromArgb(241, 241, 241);
            stakeLbl.Location = new Point(13, 61);
            stakeLbl.Name = "stakeLbl";
            stakeLbl.Padding = new Padding(5, 0, 0, 0);
            stakeLbl.Size = new Size(185, 24);
            stakeLbl.TabIndex = 3;
            stakeLbl.Text = "Stake: $100.00";
            stakeLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // statusLbl
            // 
            statusLbl.Dock = DockStyle.Top;
            statusLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            statusLbl.ForeColor = Color.FromArgb(241, 241, 241);
            statusLbl.Location = new Point(13, 20);
            statusLbl.Name = "statusLbl";
            statusLbl.Padding = new Padding(5, 0, 0, 0);
            statusLbl.Size = new Size(185, 24);
            statusLbl.TabIndex = 2;
            statusLbl.Text = "Status: Pending";
            statusLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // slipTableLayoutPanel1
            // 
            slipTableLayoutPanel1.ColumnCount = 1;
            slipTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            slipTableLayoutPanel1.Controls.Add(totalOddsLbl, 0, 2);
            slipTableLayoutPanel1.Controls.Add(totalBetsLbl, 0, 1);
            slipTableLayoutPanel1.Controls.Add(slipDateLbl, 0, 0);
            slipTableLayoutPanel1.Dock = DockStyle.Fill;
            slipTableLayoutPanel1.Location = new Point(539, 3);
            slipTableLayoutPanel1.Name = "slipTableLayoutPanel1";
            slipTableLayoutPanel1.Padding = new Padding(10, 20, 10, 10);
            slipTableLayoutPanel1.RowCount = 3;
            slipTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            slipTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            slipTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            slipTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            slipTableLayoutPanel1.Size = new Size(229, 155);
            slipTableLayoutPanel1.TabIndex = 2;
            // 
            // totalOddsLbl
            // 
            totalOddsLbl.Dock = DockStyle.Top;
            totalOddsLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalOddsLbl.ForeColor = Color.FromArgb(241, 241, 241);
            totalOddsLbl.Location = new Point(13, 102);
            totalOddsLbl.Name = "totalOddsLbl";
            totalOddsLbl.Padding = new Padding(5, 0, 0, 0);
            totalOddsLbl.Size = new Size(203, 24);
            totalOddsLbl.TabIndex = 4;
            totalOddsLbl.Text = "Total Odds: 1.95";
            totalOddsLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // totalBetsLbl
            // 
            totalBetsLbl.Dock = DockStyle.Top;
            totalBetsLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalBetsLbl.ForeColor = Color.FromArgb(241, 241, 241);
            totalBetsLbl.Location = new Point(13, 61);
            totalBetsLbl.Name = "totalBetsLbl";
            totalBetsLbl.Padding = new Padding(5, 0, 0, 0);
            totalBetsLbl.Size = new Size(203, 24);
            totalBetsLbl.TabIndex = 3;
            totalBetsLbl.Text = "Total Bets: 4";
            totalBetsLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // slipDateLbl
            // 
            slipDateLbl.Dock = DockStyle.Top;
            slipDateLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            slipDateLbl.ForeColor = Color.FromArgb(241, 241, 241);
            slipDateLbl.Location = new Point(13, 20);
            slipDateLbl.Name = "slipDateLbl";
            slipDateLbl.Padding = new Padding(5, 0, 0, 0);
            slipDateLbl.Size = new Size(203, 24);
            slipDateLbl.TabIndex = 2;
            slipDateLbl.Text = "Bet Placed: 23/02/26";
            slipDateLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // slipMatchInfoPanel
            // 
            slipMatchInfoPanel.Controls.Add(previewMatchDateLbl);
            slipMatchInfoPanel.Controls.Add(matchTableLayoutPanel);
            slipMatchInfoPanel.Controls.Add(previewedLeagueLbl);
            slipMatchInfoPanel.Controls.Add(previewLbl);
            slipMatchInfoPanel.Dock = DockStyle.Fill;
            slipMatchInfoPanel.Location = new Point(3, 3);
            slipMatchInfoPanel.Name = "slipMatchInfoPanel";
            slipMatchInfoPanel.Size = new Size(530, 155);
            slipMatchInfoPanel.TabIndex = 0;
            // 
            // previewMatchDateLbl
            // 
            previewMatchDateLbl.Dock = DockStyle.Top;
            previewMatchDateLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            previewMatchDateLbl.ForeColor = Color.FromArgb(241, 241, 241);
            previewMatchDateLbl.Location = new Point(0, 61);
            previewMatchDateLbl.Name = "previewMatchDateLbl";
            previewMatchDateLbl.Size = new Size(530, 24);
            previewMatchDateLbl.TabIndex = 4;
            previewMatchDateLbl.Text = "26/02/2028";
            previewMatchDateLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // matchTableLayoutPanel
            // 
            matchTableLayoutPanel.ColumnCount = 3;
            matchTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            matchTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 54F));
            matchTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            matchTableLayoutPanel.Controls.Add(vsLbl, 1, 0);
            matchTableLayoutPanel.Controls.Add(homeTeamPanel, 0, 0);
            matchTableLayoutPanel.Controls.Add(awayTeamPanel, 2, 0);
            matchTableLayoutPanel.Dock = DockStyle.Bottom;
            matchTableLayoutPanel.Location = new Point(0, 86);
            matchTableLayoutPanel.Margin = new Padding(2, 1, 2, 1);
            matchTableLayoutPanel.Name = "matchTableLayoutPanel";
            matchTableLayoutPanel.Padding = new Padding(0, 0, 0, 5);
            matchTableLayoutPanel.RowCount = 1;
            matchTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            matchTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            matchTableLayoutPanel.Size = new Size(530, 69);
            matchTableLayoutPanel.TabIndex = 3;
            // 
            // vsLbl
            // 
            vsLbl.Dock = DockStyle.Fill;
            vsLbl.Font = new Font("Verdana", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vsLbl.ForeColor = Color.FromArgb(241, 241, 241);
            vsLbl.Location = new Point(240, 0);
            vsLbl.Margin = new Padding(2, 0, 2, 0);
            vsLbl.Name = "vsLbl";
            vsLbl.Size = new Size(50, 64);
            vsLbl.TabIndex = 3;
            vsLbl.Text = "VS";
            vsLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // homeTeamPanel
            // 
            homeTeamPanel.Controls.Add(homeTeamLbl);
            homeTeamPanel.Dock = DockStyle.Fill;
            homeTeamPanel.Location = new Point(2, 1);
            homeTeamPanel.Margin = new Padding(2, 1, 2, 1);
            homeTeamPanel.Name = "homeTeamPanel";
            homeTeamPanel.Size = new Size(234, 62);
            homeTeamPanel.TabIndex = 0;
            // 
            // homeTeamLbl
            // 
            homeTeamLbl.Dock = DockStyle.Fill;
            homeTeamLbl.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeTeamLbl.ForeColor = Color.FromArgb(241, 241, 241);
            homeTeamLbl.Location = new Point(0, 0);
            homeTeamLbl.Name = "homeTeamLbl";
            homeTeamLbl.Padding = new Padding(3, 0, 11, 0);
            homeTeamLbl.Size = new Size(234, 62);
            homeTeamLbl.TabIndex = 3;
            homeTeamLbl.Text = "Manchester United";
            homeTeamLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // awayTeamPanel
            // 
            awayTeamPanel.Controls.Add(awayTeamLbl);
            awayTeamPanel.Dock = DockStyle.Fill;
            awayTeamPanel.Location = new Point(294, 1);
            awayTeamPanel.Margin = new Padding(2, 1, 2, 1);
            awayTeamPanel.Name = "awayTeamPanel";
            awayTeamPanel.Size = new Size(234, 62);
            awayTeamPanel.TabIndex = 4;
            // 
            // awayTeamLbl
            // 
            awayTeamLbl.Dock = DockStyle.Fill;
            awayTeamLbl.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            awayTeamLbl.ForeColor = Color.FromArgb(241, 241, 241);
            awayTeamLbl.Location = new Point(0, 0);
            awayTeamLbl.Name = "awayTeamLbl";
            awayTeamLbl.Padding = new Padding(11, 0, 3, 0);
            awayTeamLbl.Size = new Size(234, 62);
            awayTeamLbl.TabIndex = 4;
            awayTeamLbl.Text = "Barcelona";
            awayTeamLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // previewedLeagueLbl
            // 
            previewedLeagueLbl.Dock = DockStyle.Top;
            previewedLeagueLbl.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            previewedLeagueLbl.ForeColor = Color.FromArgb(241, 241, 241);
            previewedLeagueLbl.Location = new Point(0, 24);
            previewedLeagueLbl.Name = "previewedLeagueLbl";
            previewedLeagueLbl.Size = new Size(530, 37);
            previewedLeagueLbl.TabIndex = 2;
            previewedLeagueLbl.Text = "Premiere League";
            previewedLeagueLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // previewLbl
            // 
            previewLbl.Dock = DockStyle.Top;
            previewLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            previewLbl.ForeColor = Color.FromArgb(241, 241, 241);
            previewLbl.Location = new Point(0, 0);
            previewLbl.Name = "previewLbl";
            previewLbl.Size = new Size(530, 24);
            previewLbl.TabIndex = 1;
            previewLbl.Text = "Bet Preview:";
            previewLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // claimBtnPanel
            // 
            claimBtnPanel.Controls.Add(claimBtn);
            claimBtnPanel.Cursor = Cursors.Hand;
            claimBtnPanel.Dock = DockStyle.Fill;
            claimBtnPanel.Location = new Point(991, 3);
            claimBtnPanel.Name = "claimBtnPanel";
            claimBtnPanel.Padding = new Padding(0, 60, 10, 60);
            claimBtnPanel.Size = new Size(125, 155);
            claimBtnPanel.TabIndex = 4;
            // 
            // claimBtn
            // 
            claimBtn.BackColor = Color.FromArgb(93, 185, 64);
            claimBtn.CornerRadius = 12;
            claimBtn.Dock = DockStyle.Fill;
            claimBtn.Font = new Font("Times New Roman", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            claimBtn.ForeColor = Color.FromArgb(241, 241, 241);
            claimBtn.Location = new Point(0, 60);
            claimBtn.Name = "claimBtn";
            claimBtn.Size = new Size(115, 35);
            claimBtn.TabIndex = 0;
            claimBtn.Text = "Claim";
            claimBtn.UseVisualStyleBackColor = false;
            claimBtn.Click += ClaimBtn_Click;
            // 
            // BetSlipPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(slipRoundedPanel);
            Name = "BetSlipPanel";
            Size = new Size(1119, 161);
            slipRoundedPanel.ResumeLayout(false);
            slipTableLayoutBgPanel.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            slipTableLayoutPanel1.ResumeLayout(false);
            slipMatchInfoPanel.ResumeLayout(false);
            matchTableLayoutPanel.ResumeLayout(false);
            homeTeamPanel.ResumeLayout(false);
            awayTeamPanel.ResumeLayout(false);
            claimBtnPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel slipRoundedPanel;
        private TableLayoutPanel slipTableLayoutBgPanel;
        private TableLayoutPanel tableLayoutPanel2;
        private Label payoutLbl;
        private Label stakeLbl;
        private Label statusLbl;
        private TableLayoutPanel slipTableLayoutPanel1;
        private Label totalOddsLbl;
        private Label totalBetsLbl;
        private Label slipDateLbl;
        private Panel slipMatchInfoPanel;
        private TableLayoutPanel matchTableLayoutPanel;
        private Label vsLbl;
        private Panel homeTeamPanel;
        private Label homeTeamLbl;
        private Panel awayTeamPanel;
        private Label awayTeamLbl;
        private Label previewedLeagueLbl;
        private Label previewMatchDateLbl;
        private Panel claimBtnPanel;
        private RoundedButton claimBtn;
        private Label previewLbl;

    }
}
