namespace BettingSystem.Forms.CustomControls
{
    partial class HistoryBetPanel
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
            betRoundedPanel = new RoundedPanel();
            betTableLayoutBgPanel = new TableLayoutPanel();
            betTableLayoutPanel1 = new TableLayoutPanel();
            betResultLbl = new Label();
            betOddLbl = new Label();
            betSelectionLbl = new Label();
            betTypeLbl = new Label();
            betMatchInfoPanel = new Panel();
            matchTableLayoutPanel = new TableLayoutPanel();
            vsLbl = new Label();
            homeTeamPanel = new Panel();
            betHomeTeamLbl = new Label();
            awayTeamPanel = new Panel();
            betAwayTeamLbl = new Label();
            betMatchLeagueLbl = new Label();
            betMatchDateLbl = new Label();
            resultPanel = new Panel();
            resultRoundedPanel = new RoundedPanel();
            betOutcomeLbl = new Label();
            betRoundedPanel.SuspendLayout();
            betTableLayoutBgPanel.SuspendLayout();
            betTableLayoutPanel1.SuspendLayout();
            betMatchInfoPanel.SuspendLayout();
            matchTableLayoutPanel.SuspendLayout();
            homeTeamPanel.SuspendLayout();
            awayTeamPanel.SuspendLayout();
            resultPanel.SuspendLayout();
            resultRoundedPanel.SuspendLayout();
            SuspendLayout();
            // 
            // betRoundedPanel
            // 
            betRoundedPanel.BackColor = Color.FromArgb(31, 31, 31);
            betRoundedPanel.Controls.Add(betTableLayoutBgPanel);
            betRoundedPanel.Controls.Add(resultPanel);
            betRoundedPanel.Dock = DockStyle.Fill;
            betRoundedPanel.Location = new Point(0, 0);
            betRoundedPanel.Name = "betRoundedPanel";
            betRoundedPanel.Size = new Size(802, 134);
            betRoundedPanel.TabIndex = 3;
            // 
            // betTableLayoutBgPanel
            // 
            betTableLayoutBgPanel.ColumnCount = 2;
            betTableLayoutBgPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.8571434F));
            betTableLayoutBgPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            betTableLayoutBgPanel.Controls.Add(betTableLayoutPanel1, 1, 0);
            betTableLayoutBgPanel.Controls.Add(betMatchInfoPanel, 0, 0);
            betTableLayoutBgPanel.Dock = DockStyle.Fill;
            betTableLayoutBgPanel.Location = new Point(0, 0);
            betTableLayoutBgPanel.Name = "betTableLayoutBgPanel";
            betTableLayoutBgPanel.Padding = new Padding(2, 4, 2, 2);
            betTableLayoutBgPanel.RowCount = 1;
            betTableLayoutBgPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            betTableLayoutBgPanel.Size = new Size(688, 134);
            betTableLayoutBgPanel.TabIndex = 3;
            // 
            // betTableLayoutPanel1
            // 
            betTableLayoutPanel1.ColumnCount = 1;
            betTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            betTableLayoutPanel1.Controls.Add(betResultLbl, 0, 3);
            betTableLayoutPanel1.Controls.Add(betOddLbl, 0, 2);
            betTableLayoutPanel1.Controls.Add(betSelectionLbl, 0, 1);
            betTableLayoutPanel1.Controls.Add(betTypeLbl, 0, 0);
            betTableLayoutPanel1.Dock = DockStyle.Fill;
            betTableLayoutPanel1.Location = new Point(415, 7);
            betTableLayoutPanel1.Name = "betTableLayoutPanel1";
            betTableLayoutPanel1.Padding = new Padding(10);
            betTableLayoutPanel1.RowCount = 4;
            betTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            betTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            betTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            betTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            betTableLayoutPanel1.Size = new Size(268, 122);
            betTableLayoutPanel1.TabIndex = 2;
            // 
            // betResultLbl
            // 
            betResultLbl.Dock = DockStyle.Top;
            betResultLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            betResultLbl.ForeColor = Color.FromArgb(241, 241, 241);
            betResultLbl.Location = new Point(13, 85);
            betResultLbl.Name = "betResultLbl";
            betResultLbl.Padding = new Padding(5, 0, 0, 0);
            betResultLbl.Size = new Size(242, 21);
            betResultLbl.TabIndex = 5;
            betResultLbl.Text = "Result: Home Win";
            betResultLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // betOddLbl
            // 
            betOddLbl.Dock = DockStyle.Top;
            betOddLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            betOddLbl.ForeColor = Color.FromArgb(241, 241, 241);
            betOddLbl.Location = new Point(13, 60);
            betOddLbl.Name = "betOddLbl";
            betOddLbl.Padding = new Padding(5, 0, 0, 0);
            betOddLbl.Size = new Size(242, 24);
            betOddLbl.TabIndex = 4;
            betOddLbl.Text = "Odd: 1.95";
            betOddLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // betSelectionLbl
            // 
            betSelectionLbl.Dock = DockStyle.Top;
            betSelectionLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            betSelectionLbl.ForeColor = Color.FromArgb(241, 241, 241);
            betSelectionLbl.Location = new Point(13, 35);
            betSelectionLbl.Name = "betSelectionLbl";
            betSelectionLbl.Padding = new Padding(5, 0, 0, 0);
            betSelectionLbl.Size = new Size(242, 24);
            betSelectionLbl.TabIndex = 3;
            betSelectionLbl.Text = "Selection: Home Win";
            betSelectionLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // betTypeLbl
            // 
            betTypeLbl.Dock = DockStyle.Top;
            betTypeLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            betTypeLbl.ForeColor = Color.FromArgb(241, 241, 241);
            betTypeLbl.Location = new Point(13, 10);
            betTypeLbl.Name = "betTypeLbl";
            betTypeLbl.Padding = new Padding(5, 0, 0, 0);
            betTypeLbl.Size = new Size(242, 24);
            betTypeLbl.TabIndex = 2;
            betTypeLbl.Text = "Bet Type: Outcome";
            betTypeLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // betMatchInfoPanel
            // 
            betMatchInfoPanel.Controls.Add(matchTableLayoutPanel);
            betMatchInfoPanel.Controls.Add(betMatchLeagueLbl);
            betMatchInfoPanel.Controls.Add(betMatchDateLbl);
            betMatchInfoPanel.Dock = DockStyle.Fill;
            betMatchInfoPanel.Location = new Point(5, 7);
            betMatchInfoPanel.Name = "betMatchInfoPanel";
            betMatchInfoPanel.Size = new Size(404, 122);
            betMatchInfoPanel.TabIndex = 0;
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
            matchTableLayoutPanel.Dock = DockStyle.Fill;
            matchTableLayoutPanel.Location = new Point(0, 61);
            matchTableLayoutPanel.Margin = new Padding(2, 1, 2, 1);
            matchTableLayoutPanel.Name = "matchTableLayoutPanel";
            matchTableLayoutPanel.Padding = new Padding(0, 0, 0, 5);
            matchTableLayoutPanel.RowCount = 1;
            matchTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            matchTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            matchTableLayoutPanel.Size = new Size(404, 61);
            matchTableLayoutPanel.TabIndex = 3;
            // 
            // vsLbl
            // 
            vsLbl.Dock = DockStyle.Fill;
            vsLbl.Font = new Font("Verdana", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vsLbl.ForeColor = Color.FromArgb(241, 241, 241);
            vsLbl.Location = new Point(177, 0);
            vsLbl.Margin = new Padding(2, 0, 2, 0);
            vsLbl.Name = "vsLbl";
            vsLbl.Size = new Size(50, 56);
            vsLbl.TabIndex = 3;
            vsLbl.Text = "VS";
            vsLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // homeTeamPanel
            // 
            homeTeamPanel.Controls.Add(betHomeTeamLbl);
            homeTeamPanel.Dock = DockStyle.Fill;
            homeTeamPanel.Location = new Point(2, 1);
            homeTeamPanel.Margin = new Padding(2, 1, 2, 1);
            homeTeamPanel.Name = "homeTeamPanel";
            homeTeamPanel.Size = new Size(171, 54);
            homeTeamPanel.TabIndex = 0;
            // 
            // betHomeTeamLbl
            // 
            betHomeTeamLbl.Dock = DockStyle.Fill;
            betHomeTeamLbl.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            betHomeTeamLbl.ForeColor = Color.FromArgb(241, 241, 241);
            betHomeTeamLbl.Location = new Point(0, 0);
            betHomeTeamLbl.Name = "betHomeTeamLbl";
            betHomeTeamLbl.Padding = new Padding(3, 0, 11, 0);
            betHomeTeamLbl.Size = new Size(171, 54);
            betHomeTeamLbl.TabIndex = 3;
            betHomeTeamLbl.Text = "Manchester United";
            betHomeTeamLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // awayTeamPanel
            // 
            awayTeamPanel.Controls.Add(betAwayTeamLbl);
            awayTeamPanel.Dock = DockStyle.Fill;
            awayTeamPanel.Location = new Point(231, 1);
            awayTeamPanel.Margin = new Padding(2, 1, 2, 1);
            awayTeamPanel.Name = "awayTeamPanel";
            awayTeamPanel.Size = new Size(171, 54);
            awayTeamPanel.TabIndex = 4;
            // 
            // betAwayTeamLbl
            // 
            betAwayTeamLbl.Dock = DockStyle.Fill;
            betAwayTeamLbl.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            betAwayTeamLbl.ForeColor = Color.FromArgb(241, 241, 241);
            betAwayTeamLbl.Location = new Point(0, 0);
            betAwayTeamLbl.Name = "betAwayTeamLbl";
            betAwayTeamLbl.Padding = new Padding(11, 0, 3, 0);
            betAwayTeamLbl.Size = new Size(171, 54);
            betAwayTeamLbl.TabIndex = 4;
            betAwayTeamLbl.Text = "Barcelona";
            betAwayTeamLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // betMatchLeagueLbl
            // 
            betMatchLeagueLbl.Dock = DockStyle.Top;
            betMatchLeagueLbl.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            betMatchLeagueLbl.ForeColor = Color.FromArgb(241, 241, 241);
            betMatchLeagueLbl.Location = new Point(0, 24);
            betMatchLeagueLbl.Name = "betMatchLeagueLbl";
            betMatchLeagueLbl.Size = new Size(404, 37);
            betMatchLeagueLbl.TabIndex = 2;
            betMatchLeagueLbl.Text = "Premiere League";
            betMatchLeagueLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // betMatchDateLbl
            // 
            betMatchDateLbl.Dock = DockStyle.Top;
            betMatchDateLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            betMatchDateLbl.ForeColor = Color.FromArgb(241, 241, 241);
            betMatchDateLbl.Location = new Point(0, 0);
            betMatchDateLbl.Name = "betMatchDateLbl";
            betMatchDateLbl.Size = new Size(404, 24);
            betMatchDateLbl.TabIndex = 1;
            betMatchDateLbl.Text = "26/02/2028 - 09:30";
            betMatchDateLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // resultPanel
            // 
            resultPanel.Controls.Add(resultRoundedPanel);
            resultPanel.Dock = DockStyle.Right;
            resultPanel.Location = new Point(688, 0);
            resultPanel.Name = "resultPanel";
            resultPanel.Size = new Size(114, 134);
            resultPanel.TabIndex = 2;
            // 
            // resultRoundedPanel
            // 
            resultRoundedPanel.Anchor = AnchorStyles.None;
            resultRoundedPanel.BackColor = Color.FromArgb(93, 185, 64);
            resultRoundedPanel.Controls.Add(betOutcomeLbl);
            resultRoundedPanel.Location = new Point(12, 42);
            resultRoundedPanel.Name = "resultRoundedPanel";
            resultRoundedPanel.Size = new Size(91, 51);
            resultRoundedPanel.TabIndex = 0;
            // 
            // betOutcomeLbl
            // 
            betOutcomeLbl.BackColor = Color.FromArgb(93, 185, 64);
            betOutcomeLbl.Dock = DockStyle.Fill;
            betOutcomeLbl.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            betOutcomeLbl.ForeColor = Color.FromArgb(241, 241, 241);
            betOutcomeLbl.Location = new Point(0, 0);
            betOutcomeLbl.Name = "betOutcomeLbl";
            betOutcomeLbl.Size = new Size(91, 51);
            betOutcomeLbl.TabIndex = 1;
            betOutcomeLbl.Text = "Won";
            betOutcomeLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HistoryBetPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(betRoundedPanel);
            Name = "HistoryBetPanel";
            Size = new Size(802, 134);
            betRoundedPanel.ResumeLayout(false);
            betTableLayoutBgPanel.ResumeLayout(false);
            betTableLayoutPanel1.ResumeLayout(false);
            betMatchInfoPanel.ResumeLayout(false);
            matchTableLayoutPanel.ResumeLayout(false);
            homeTeamPanel.ResumeLayout(false);
            awayTeamPanel.ResumeLayout(false);
            resultPanel.ResumeLayout(false);
            resultRoundedPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel betRoundedPanel;
        private TableLayoutPanel betTableLayoutBgPanel;
        private TableLayoutPanel betTableLayoutPanel1;
        private Label betResultLbl;
        private Label betOddLbl;
        private Label betSelectionLbl;
        private Label betTypeLbl;
        private Panel betMatchInfoPanel;
        private TableLayoutPanel matchTableLayoutPanel;
        private Label vsLbl;
        private Panel homeTeamPanel;
        private Label betHomeTeamLbl;
        private Panel awayTeamPanel;
        private Label betAwayTeamLbl;
        private Label betMatchLeagueLbl;
        private Label betMatchDateLbl;
        private Panel resultPanel;
        private RoundedPanel resultRoundedPanel;
        private Label betOutcomeLbl;
    }
}
