namespace BettingSystem.Forms.CustomControls
{
    partial class BetCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            awayTeamLbl = new Label();
            matchDateLbl = new Label();
            dateTimePanel = new Panel();
            matchTimeLbl = new Label();
            vsLbl = new Label();
            tlpBetInfo = new TableLayoutPanel();
            lblBetTypeHdr = new Label();
            lblBetTypeVal = new Label();
            lblSelectionHdr = new Label();
            lblSelectionVal = new Label();
            lblOddsHdr = new Label();
            lblOddsVal = new Label();
            matchLeagueLbl = new Label();
            gameInfoPanel = new Panel();
            teamInfoPanel = new TableLayoutPanel();
            homeTeamLbl = new Label();
            btnRemove = new Button();
            betRoundedPanel = new RoundedPanel();
            betTableLayoutBgPanel = new TableLayoutPanel();
            resultPanel = new Panel();
            dateTimePanel.SuspendLayout();
            tlpBetInfo.SuspendLayout();
            gameInfoPanel.SuspendLayout();
            teamInfoPanel.SuspendLayout();
            betRoundedPanel.SuspendLayout();
            betTableLayoutBgPanel.SuspendLayout();
            resultPanel.SuspendLayout();
            SuspendLayout();
            // 
            // awayTeamLbl
            // 
            awayTeamLbl.Dock = DockStyle.Fill;
            awayTeamLbl.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            awayTeamLbl.ForeColor = Color.FromArgb(241, 241, 241);
            awayTeamLbl.Location = new Point(221, 0);
            awayTeamLbl.Name = "awayTeamLbl";
            awayTeamLbl.Size = new Size(158, 56);
            awayTeamLbl.TabIndex = 5;
            awayTeamLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // matchDateLbl
            // 
            matchDateLbl.Dock = DockStyle.Top;
            matchDateLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            matchDateLbl.ForeColor = Color.FromArgb(241, 241, 241);
            matchDateLbl.Location = new Point(0, 15);
            matchDateLbl.Name = "matchDateLbl";
            matchDateLbl.Size = new Size(86, 37);
            matchDateLbl.TabIndex = 2;
            matchDateLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePanel
            // 
            dateTimePanel.Controls.Add(matchTimeLbl);
            dateTimePanel.Controls.Add(matchDateLbl);
            dateTimePanel.Dock = DockStyle.Fill;
            dateTimePanel.Location = new Point(4, 5);
            dateTimePanel.Margin = new Padding(2, 1, 2, 1);
            dateTimePanel.Name = "dateTimePanel";
            dateTimePanel.Padding = new Padding(0, 15, 0, 0);
            dateTimePanel.Size = new Size(86, 102);
            dateTimePanel.TabIndex = 11;
            // 
            // matchTimeLbl
            // 
            matchTimeLbl.Dock = DockStyle.Top;
            matchTimeLbl.Font = new Font("Times New Roman", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            matchTimeLbl.ForeColor = Color.FromArgb(180, 180, 180);
            matchTimeLbl.Location = new Point(0, 52);
            matchTimeLbl.Name = "matchTimeLbl";
            matchTimeLbl.Size = new Size(86, 37);
            matchTimeLbl.TabIndex = 3;
            matchTimeLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // vsLbl
            // 
            vsLbl.Dock = DockStyle.Fill;
            vsLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            vsLbl.ForeColor = Color.FromArgb(241, 241, 241);
            vsLbl.Location = new Point(167, 0);
            vsLbl.Name = "vsLbl";
            vsLbl.Size = new Size(48, 56);
            vsLbl.TabIndex = 4;
            vsLbl.Text = "VS";
            vsLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlpBetInfo
            // 
            tlpBetInfo.BackColor = Color.Transparent;
            tlpBetInfo.ColumnCount = 2;
            tlpBetInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tlpBetInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tlpBetInfo.Controls.Add(lblBetTypeHdr, 0, 0);
            tlpBetInfo.Controls.Add(lblBetTypeVal, 1, 0);
            tlpBetInfo.Controls.Add(lblSelectionHdr, 0, 1);
            tlpBetInfo.Controls.Add(lblSelectionVal, 1, 1);
            tlpBetInfo.Controls.Add(lblOddsHdr, 0, 2);
            tlpBetInfo.Controls.Add(lblOddsVal, 1, 2);
            tlpBetInfo.Dock = DockStyle.Fill;
            tlpBetInfo.Location = new Point(483, 7);
            tlpBetInfo.Name = "tlpBetInfo";
            tlpBetInfo.RowCount = 3;
            tlpBetInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpBetInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpBetInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpBetInfo.Size = new Size(207, 98);
            tlpBetInfo.TabIndex = 10;
            // 
            // lblBetTypeHdr
            // 
            lblBetTypeHdr.Dock = DockStyle.Fill;
            lblBetTypeHdr.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBetTypeHdr.ForeColor = Color.FromArgb(180, 180, 180);
            lblBetTypeHdr.Location = new Point(3, 0);
            lblBetTypeHdr.Name = "lblBetTypeHdr";
            lblBetTypeHdr.Padding = new Padding(10, 0, 0, 0);
            lblBetTypeHdr.Size = new Size(87, 32);
            lblBetTypeHdr.TabIndex = 0;
            lblBetTypeHdr.Text = "Bet Type:";
            lblBetTypeHdr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBetTypeVal
            // 
            lblBetTypeVal.Dock = DockStyle.Fill;
            lblBetTypeVal.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblBetTypeVal.ForeColor = Color.FromArgb(241, 241, 241);
            lblBetTypeVal.Location = new Point(96, 0);
            lblBetTypeVal.Name = "lblBetTypeVal";
            lblBetTypeVal.Size = new Size(108, 32);
            lblBetTypeVal.TabIndex = 1;
            lblBetTypeVal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSelectionHdr
            // 
            lblSelectionHdr.Dock = DockStyle.Fill;
            lblSelectionHdr.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectionHdr.ForeColor = Color.FromArgb(180, 180, 180);
            lblSelectionHdr.Location = new Point(3, 32);
            lblSelectionHdr.Name = "lblSelectionHdr";
            lblSelectionHdr.Padding = new Padding(10, 0, 0, 0);
            lblSelectionHdr.Size = new Size(87, 32);
            lblSelectionHdr.TabIndex = 2;
            lblSelectionHdr.Text = "Selection:";
            lblSelectionHdr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSelectionVal
            // 
            lblSelectionVal.Dock = DockStyle.Fill;
            lblSelectionVal.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblSelectionVal.ForeColor = Color.FromArgb(241, 241, 241);
            lblSelectionVal.Location = new Point(96, 32);
            lblSelectionVal.Name = "lblSelectionVal";
            lblSelectionVal.Size = new Size(108, 32);
            lblSelectionVal.TabIndex = 3;
            lblSelectionVal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOddsHdr
            // 
            lblOddsHdr.Dock = DockStyle.Fill;
            lblOddsHdr.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOddsHdr.ForeColor = Color.FromArgb(93, 185, 64);
            lblOddsHdr.Location = new Point(3, 64);
            lblOddsHdr.Name = "lblOddsHdr";
            lblOddsHdr.Padding = new Padding(10, 0, 0, 0);
            lblOddsHdr.Size = new Size(87, 34);
            lblOddsHdr.TabIndex = 4;
            lblOddsHdr.Text = "Odds:";
            lblOddsHdr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOddsVal
            // 
            lblOddsVal.Dock = DockStyle.Fill;
            lblOddsVal.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            lblOddsVal.ForeColor = Color.FromArgb(93, 185, 64);
            lblOddsVal.Location = new Point(96, 64);
            lblOddsVal.Name = "lblOddsVal";
            lblOddsVal.Size = new Size(108, 34);
            lblOddsVal.TabIndex = 5;
            lblOddsVal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // matchLeagueLbl
            // 
            matchLeagueLbl.Dock = DockStyle.Top;
            matchLeagueLbl.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            matchLeagueLbl.ForeColor = Color.FromArgb(241, 241, 241);
            matchLeagueLbl.Location = new Point(0, 0);
            matchLeagueLbl.Name = "matchLeagueLbl";
            matchLeagueLbl.Size = new Size(382, 37);
            matchLeagueLbl.TabIndex = 2;
            matchLeagueLbl.Text = "Premiere League";
            matchLeagueLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gameInfoPanel
            // 
            gameInfoPanel.Controls.Add(teamInfoPanel);
            gameInfoPanel.Controls.Add(matchLeagueLbl);
            gameInfoPanel.Dock = DockStyle.Fill;
            gameInfoPanel.Location = new Point(95, 7);
            gameInfoPanel.Name = "gameInfoPanel";
            gameInfoPanel.Size = new Size(382, 98);
            gameInfoPanel.TabIndex = 9;
            // 
            // teamInfoPanel
            // 
            teamInfoPanel.ColumnCount = 3;
            teamInfoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            teamInfoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 54F));
            teamInfoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            teamInfoPanel.Controls.Add(homeTeamLbl, 0, 0);
            teamInfoPanel.Controls.Add(awayTeamLbl, 2, 0);
            teamInfoPanel.Controls.Add(vsLbl, 1, 0);
            teamInfoPanel.Dock = DockStyle.Fill;
            teamInfoPanel.Location = new Point(0, 37);
            teamInfoPanel.Margin = new Padding(2, 1, 2, 1);
            teamInfoPanel.Name = "teamInfoPanel";
            teamInfoPanel.Padding = new Padding(0, 0, 0, 5);
            teamInfoPanel.RowCount = 1;
            teamInfoPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            teamInfoPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            teamInfoPanel.Size = new Size(382, 61);
            teamInfoPanel.TabIndex = 3;
            // 
            // homeTeamLbl
            // 
            homeTeamLbl.Dock = DockStyle.Fill;
            homeTeamLbl.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            homeTeamLbl.ForeColor = Color.FromArgb(241, 241, 241);
            homeTeamLbl.Location = new Point(3, 0);
            homeTeamLbl.Name = "homeTeamLbl";
            homeTeamLbl.Size = new Size(158, 56);
            homeTeamLbl.TabIndex = 6;
            homeTeamLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Transparent;
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Times New Roman", 20F, FontStyle.Bold);
            btnRemove.ForeColor = Color.FromArgb(180, 180, 180);
            btnRemove.Location = new Point(13, 36);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(28, 39);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "✕";
            btnRemove.UseVisualStyleBackColor = false;
            // 
            // betRoundedPanel
            // 
            betRoundedPanel.BackColor = Color.FromArgb(31, 31, 31);
            betRoundedPanel.Controls.Add(betTableLayoutBgPanel);
            betRoundedPanel.Controls.Add(resultPanel);
            betRoundedPanel.Dock = DockStyle.Fill;
            betRoundedPanel.Location = new Point(0, 0);
            betRoundedPanel.Name = "betRoundedPanel";
            betRoundedPanel.Size = new Size(750, 110);
            betRoundedPanel.TabIndex = 5;
            // 
            // betTableLayoutBgPanel
            // 
            betTableLayoutBgPanel.ColumnCount = 3;
            betTableLayoutBgPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.0335665F));
            betTableLayoutBgPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.2723961F));
            betTableLayoutBgPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.6940346F));
            betTableLayoutBgPanel.Controls.Add(dateTimePanel, 0, 0);
            betTableLayoutBgPanel.Controls.Add(tlpBetInfo, 2, 0);
            betTableLayoutBgPanel.Controls.Add(gameInfoPanel, 1, 0);
            betTableLayoutBgPanel.Dock = DockStyle.Fill;
            betTableLayoutBgPanel.Location = new Point(0, 0);
            betTableLayoutBgPanel.Name = "betTableLayoutBgPanel";
            betTableLayoutBgPanel.Padding = new Padding(2, 4, 2, 2);
            betTableLayoutBgPanel.RowCount = 1;
            betTableLayoutBgPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            betTableLayoutBgPanel.Size = new Size(695, 110);
            betTableLayoutBgPanel.TabIndex = 3;
            // 
            // resultPanel
            // 
            resultPanel.Controls.Add(btnRemove);
            resultPanel.Dock = DockStyle.Right;
            resultPanel.Location = new Point(695, 0);
            resultPanel.Name = "resultPanel";
            resultPanel.Size = new Size(55, 110);
            resultPanel.TabIndex = 2;
            // 
            // BetCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(betRoundedPanel);
            Name = "BetCard";
            Size = new Size(750, 110);
            dateTimePanel.ResumeLayout(false);
            tlpBetInfo.ResumeLayout(false);
            gameInfoPanel.ResumeLayout(false);
            teamInfoPanel.ResumeLayout(false);
            betRoundedPanel.ResumeLayout(false);
            betTableLayoutBgPanel.ResumeLayout(false);
            resultPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Panel leagueTeamPanel;
        private Label awayTeamLbl;
        private Label matchDateLbl;
        private Panel dateTimePanel;
        private Label matchTimeLbl;
        private Label vsLbl;
        private TableLayoutPanel tlpBetInfo;
        private Label lblBetTypeHdr;
        private Label lblBetTypeVal;
        private Label lblSelectionHdr;
        private Label lblSelectionVal;
        private Label lblOddsHdr;
        private Label lblOddsVal;
        private Label matchLeagueLbl;
        private Panel gameInfoPanel;
        private TableLayoutPanel teamInfoPanel;
        private Button btnRemove;
        private RoundedPanel betRoundedPanel;
        private TableLayoutPanel betTableLayoutBgPanel;
        private Panel resultPanel;
        private Label homeTeamLbl;
    }
}