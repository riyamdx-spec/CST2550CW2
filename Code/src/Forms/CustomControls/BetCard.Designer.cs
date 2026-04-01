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
            matchRoundedPanel = new RoundedPanel();
            teamInfoPanel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            dateTimePanel = new Panel();
            matchTimeLbl = new Label();
            matchDateLbl = new Label();
            vsLbl = new Label();
            awayTeamPanel = new Panel();
            awayTeamLbl = new Label();
            betInfoPanel = new Panel();
            tlpBetInfo = new TableLayoutPanel();
            lblBetTypeHdr = new Label();
            lblBetTypeVal = new Label();
            lblSelectionHdr = new Label();
            lblSelectionVal = new Label();
            lblOddsHdr = new Label();
            lblOddsVal = new Label();
            matchLeagueLbl = new Label();
            btnRemove = new Button();
            matchRoundedPanel.SuspendLayout();
            teamInfoPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            dateTimePanel.SuspendLayout();
            awayTeamPanel.SuspendLayout();
            betInfoPanel.SuspendLayout();
            tlpBetInfo.SuspendLayout();
            SuspendLayout();
            // 
            // matchRoundedPanel
            // 
            matchRoundedPanel.BackColor = Color.FromArgb(26, 26, 26);
            matchRoundedPanel.Controls.Add(teamInfoPanel);
            matchRoundedPanel.Controls.Add(matchLeagueLbl);
            matchRoundedPanel.Controls.Add(btnRemove);
            matchRoundedPanel.Dock = DockStyle.Fill;
            matchRoundedPanel.Location = new Point(0, 0);
            matchRoundedPanel.Name = "matchRoundedPanel";
            matchRoundedPanel.Size = new Size(750, 110);
            matchRoundedPanel.TabIndex = 0;
            // 
            // teamInfoPanel
            // 
            teamInfoPanel.Controls.Add(tableLayoutPanel1);
            teamInfoPanel.Dock = DockStyle.Fill;
            teamInfoPanel.Location = new Point(0, 30);
            teamInfoPanel.Name = "teamInfoPanel";
            teamInfoPanel.Size = new Size(710, 80);
            teamInfoPanel.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            tableLayoutPanel1.Controls.Add(dateTimePanel, 0, 0);
            tableLayoutPanel1.Controls.Add(vsLbl, 2, 0);
            tableLayoutPanel1.Controls.Add(awayTeamPanel, 3, 0);
            tableLayoutPanel1.Controls.Add(betInfoPanel, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(710, 80);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dateTimePanel
            // 
            dateTimePanel.Controls.Add(matchTimeLbl);
            dateTimePanel.Controls.Add(matchDateLbl);
            dateTimePanel.Dock = DockStyle.Fill;
            dateTimePanel.Location = new Point(3, 3);
            dateTimePanel.Name = "dateTimePanel";
            dateTimePanel.Size = new Size(86, 74);
            dateTimePanel.TabIndex = 0;
            // 
            // matchTimeLbl
            // 
            matchTimeLbl.Anchor = AnchorStyles.None;
            matchTimeLbl.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            matchTimeLbl.ForeColor = Color.FromArgb(180, 180, 180);
            matchTimeLbl.Location = new Point(0, 37);
            matchTimeLbl.Name = "matchTimeLbl";
            matchTimeLbl.Size = new Size(86, 37);
            matchTimeLbl.TabIndex = 1;
            matchTimeLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // matchDateLbl
            // 
            matchDateLbl.Anchor = AnchorStyles.None;
            matchDateLbl.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            matchDateLbl.ForeColor = Color.FromArgb(241, 241, 241);
            matchDateLbl.Location = new Point(0, 0);
            matchDateLbl.Name = "matchDateLbl";
            matchDateLbl.Size = new Size(86, 37);
            matchDateLbl.TabIndex = 0;
            matchDateLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // vsLbl
            // 
            vsLbl.Dock = DockStyle.Fill;
            vsLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            vsLbl.ForeColor = Color.FromArgb(241, 241, 241);
            vsLbl.Location = new Point(241, 0);
            vsLbl.Name = "vsLbl";
            vsLbl.Size = new Size(40, 80);
            vsLbl.TabIndex = 2;
            vsLbl.Text = "VS";
            vsLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // awayTeamPanel
            // 
            awayTeamPanel.Controls.Add(awayTeamLbl);
            awayTeamPanel.Dock = DockStyle.Fill;
            awayTeamPanel.Location = new Point(287, 3);
            awayTeamPanel.Name = "awayTeamPanel";
            awayTeamPanel.Size = new Size(140, 74);
            awayTeamPanel.TabIndex = 3;
            // 
            // awayTeamLbl
            // 
            awayTeamLbl.Dock = DockStyle.Fill;
            awayTeamLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            awayTeamLbl.ForeColor = Color.FromArgb(241, 241, 241);
            awayTeamLbl.Location = new Point(0, 0);
            awayTeamLbl.Name = "awayTeamLbl";
            awayTeamLbl.Size = new Size(140, 74);
            awayTeamLbl.TabIndex = 0;
            awayTeamLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // betInfoPanel
            // 
            betInfoPanel.Controls.Add(tlpBetInfo);
            betInfoPanel.Dock = DockStyle.Fill;
            betInfoPanel.Location = new Point(433, 3);
            betInfoPanel.Name = "betInfoPanel";
            betInfoPanel.Size = new Size(274, 74);
            betInfoPanel.TabIndex = 4;
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
            tlpBetInfo.Location = new Point(0, 0);
            tlpBetInfo.Name = "tlpBetInfo";
            tlpBetInfo.RowCount = 3;
            tlpBetInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpBetInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpBetInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpBetInfo.Size = new Size(274, 74);
            tlpBetInfo.TabIndex = 0;
            // 
            // lblBetTypeHdr
            // 
            lblBetTypeHdr.Dock = DockStyle.Fill;
            lblBetTypeHdr.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            lblBetTypeHdr.ForeColor = Color.FromArgb(180, 180, 180);
            lblBetTypeHdr.Location = new Point(3, 0);
            lblBetTypeHdr.Name = "lblBetTypeHdr";
            lblBetTypeHdr.Size = new Size(117, 24);
            lblBetTypeHdr.TabIndex = 0;
            lblBetTypeHdr.Text = "Bet Type:";
            lblBetTypeHdr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBetTypeVal
            // 
            lblBetTypeVal.Dock = DockStyle.Fill;
            lblBetTypeVal.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            lblBetTypeVal.ForeColor = Color.FromArgb(241, 241, 241);
            lblBetTypeVal.Location = new Point(126, 0);
            lblBetTypeVal.Name = "lblBetTypeVal";
            lblBetTypeVal.Size = new Size(145, 24);
            lblBetTypeVal.TabIndex = 1;
            lblBetTypeVal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSelectionHdr
            // 
            lblSelectionHdr.Dock = DockStyle.Fill;
            lblSelectionHdr.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            lblSelectionHdr.ForeColor = Color.FromArgb(180, 180, 180);
            lblSelectionHdr.Location = new Point(3, 24);
            lblSelectionHdr.Name = "lblSelectionHdr";
            lblSelectionHdr.Size = new Size(117, 24);
            lblSelectionHdr.TabIndex = 2;
            lblSelectionHdr.Text = "Selection:";
            lblSelectionHdr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSelectionVal
            // 
            lblSelectionVal.Dock = DockStyle.Fill;
            lblSelectionVal.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            lblSelectionVal.ForeColor = Color.FromArgb(241, 241, 241);
            lblSelectionVal.Location = new Point(126, 24);
            lblSelectionVal.Name = "lblSelectionVal";
            lblSelectionVal.Size = new Size(145, 24);
            lblSelectionVal.TabIndex = 3;
            lblSelectionVal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOddsHdr
            // 
            lblOddsHdr.Dock = DockStyle.Fill;
            lblOddsHdr.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            lblOddsHdr.ForeColor = Color.FromArgb(93, 185, 64);
            lblOddsHdr.Location = new Point(3, 48);
            lblOddsHdr.Name = "lblOddsHdr";
            lblOddsHdr.Size = new Size(117, 26);
            lblOddsHdr.TabIndex = 4;
            lblOddsHdr.Text = "Odds:";
            lblOddsHdr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblOddsVal
            // 
            lblOddsVal.Dock = DockStyle.Fill;
            lblOddsVal.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            lblOddsVal.ForeColor = Color.FromArgb(93, 185, 64);
            lblOddsVal.Location = new Point(126, 48);
            lblOddsVal.Name = "lblOddsVal";
            lblOddsVal.Size = new Size(145, 26);
            lblOddsVal.TabIndex = 5;
            lblOddsVal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // matchLeagueLbl
            // 
            matchLeagueLbl.Dock = DockStyle.Top;
            matchLeagueLbl.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            matchLeagueLbl.ForeColor = Color.FromArgb(241, 241, 241);
            matchLeagueLbl.Location = new Point(0, 0);
            matchLeagueLbl.Name = "matchLeagueLbl";
            matchLeagueLbl.Size = new Size(710, 30);
            matchLeagueLbl.TabIndex = 0;
            matchLeagueLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Transparent;
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.Dock = DockStyle.Right;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Times New Roman", 20F, FontStyle.Bold);
            btnRemove.ForeColor = Color.FromArgb(180, 180, 180);
            btnRemove.Location = new Point(710, 0);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(40, 110);
            btnRemove.TabIndex = 1;
            btnRemove.Text = "✕";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // BetCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(matchRoundedPanel);
            Name = "BetCard";
            Size = new Size(750, 110);
            matchRoundedPanel.ResumeLayout(false);
            teamInfoPanel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            dateTimePanel.ResumeLayout(false);
            awayTeamPanel.ResumeLayout(false);
            betInfoPanel.ResumeLayout(false);
            tlpBetInfo.ResumeLayout(false);
            ResumeLayout(false);
        }

        private RoundedPanel matchRoundedPanel;
        private Label matchLeagueLbl;
        private Panel teamInfoPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel dateTimePanel;
        private Label matchDateLbl;
        private Label matchTimeLbl;
        private Label vsLbl;
        private Panel awayTeamPanel;
        private Label awayTeamLbl;
        private Panel betInfoPanel;
        private TableLayoutPanel tlpBetInfo;
        private Label lblBetTypeHdr;
        private Label lblBetTypeVal;
        private Label lblSelectionHdr;
        private Label lblSelectionVal;
        private Label lblOddsHdr;
        private Label lblOddsVal;
        private Button btnRemove;
    }
}