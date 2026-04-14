namespace BettingSystem.Forms
{
    partial class MatchResultPopup
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
            panelBg = new Panel();
            resultsPanelBg = new Panel();
            resultsRroundedPanel = new RoundedPanel();
            cornersPanel = new Panel();
            cornersNum = new Label();
            cornersLbl = new Label();
            seperator4 = new Panel();
            redCardsPanel = new Panel();
            redCardsNum = new Label();
            redCardsLbl = new Label();
            seperator3 = new Panel();
            yellowCardsPanel = new Panel();
            yellowCardsNum = new Label();
            yellowCardsLbl = new Label();
            seperator2 = new Panel();
            TopScorerPanel = new Panel();
            scorerNameLbl = new Label();
            scorerLbl = new Label();
            seperatorPanel = new Panel();
            scorePanel = new Panel();
            scoreLbl = new Label();
            awayTeamLbl = new Label();
            homeTeamLbl = new Label();
            resultsLbl = new Label();
            panelBg.SuspendLayout();
            resultsPanelBg.SuspendLayout();
            resultsRroundedPanel.SuspendLayout();
            cornersPanel.SuspendLayout();
            redCardsPanel.SuspendLayout();
            yellowCardsPanel.SuspendLayout();
            TopScorerPanel.SuspendLayout();
            scorePanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelBg
            // 
            panelBg.BackColor = Color.FromArgb(36, 36, 36);
            panelBg.Controls.Add(resultsPanelBg);
            panelBg.Controls.Add(resultsLbl);
            panelBg.Dock = DockStyle.Fill;
            panelBg.Location = new Point(0, 0);
            panelBg.Name = "panelBg";
            panelBg.Size = new Size(402, 427);
            panelBg.TabIndex = 0;
            // 
            // resultsPanelBg
            // 
            resultsPanelBg.Controls.Add(resultsRroundedPanel);
            resultsPanelBg.Dock = DockStyle.Fill;
            resultsPanelBg.Location = new Point(0, 57);
            resultsPanelBg.Name = "resultsPanelBg";
            resultsPanelBg.Padding = new Padding(20, 10, 20, 10);
            resultsPanelBg.Size = new Size(402, 370);
            resultsPanelBg.TabIndex = 5;
            // 
            // resultsRroundedPanel
            // 
            resultsRroundedPanel.BackColor = Color.FromArgb(31, 31, 31);
            resultsRroundedPanel.Controls.Add(cornersPanel);
            resultsRroundedPanel.Controls.Add(seperator4);
            resultsRroundedPanel.Controls.Add(redCardsPanel);
            resultsRroundedPanel.Controls.Add(seperator3);
            resultsRroundedPanel.Controls.Add(yellowCardsPanel);
            resultsRroundedPanel.Controls.Add(seperator2);
            resultsRroundedPanel.Controls.Add(TopScorerPanel);
            resultsRroundedPanel.Controls.Add(seperatorPanel);
            resultsRroundedPanel.Controls.Add(scorePanel);
            resultsRroundedPanel.Dock = DockStyle.Fill;
            resultsRroundedPanel.Location = new Point(20, 10);
            resultsRroundedPanel.Name = "resultsRroundedPanel";
            resultsRroundedPanel.Size = new Size(362, 350);
            resultsRroundedPanel.TabIndex = 0;
            // 
            // cornersPanel
            // 
            cornersPanel.Controls.Add(cornersNum);
            cornersPanel.Controls.Add(cornersLbl);
            cornersPanel.Dock = DockStyle.Top;
            cornersPanel.Location = new Point(0, 281);
            cornersPanel.Name = "cornersPanel";
            cornersPanel.Padding = new Padding(5, 0, 5, 0);
            cornersPanel.Size = new Size(362, 63);
            cornersPanel.TabIndex = 5;
            // 
            // cornersNum
            // 
            cornersNum.Dock = DockStyle.Fill;
            cornersNum.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            cornersNum.ForeColor = Color.FromArgb(241, 241, 241);
            cornersNum.Location = new Point(143, 0);
            cornersNum.Name = "cornersNum";
            cornersNum.Size = new Size(214, 63);
            cornersNum.TabIndex = 2;
            cornersNum.Text = "10";
            cornersNum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cornersLbl
            // 
            cornersLbl.Dock = DockStyle.Left;
            cornersLbl.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            cornersLbl.ForeColor = Color.Gainsboro;
            cornersLbl.Location = new Point(5, 0);
            cornersLbl.Name = "cornersLbl";
            cornersLbl.Size = new Size(138, 63);
            cornersLbl.TabIndex = 1;
            cornersLbl.Text = "Total Corners:";
            cornersLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // seperator4
            // 
            seperator4.BackColor = Color.Black;
            seperator4.Dock = DockStyle.Top;
            seperator4.Location = new Point(0, 279);
            seperator4.Name = "seperator4";
            seperator4.Size = new Size(362, 2);
            seperator4.TabIndex = 8;
            // 
            // redCardsPanel
            // 
            redCardsPanel.Controls.Add(redCardsNum);
            redCardsPanel.Controls.Add(redCardsLbl);
            redCardsPanel.Dock = DockStyle.Top;
            redCardsPanel.Location = new Point(0, 216);
            redCardsPanel.Name = "redCardsPanel";
            redCardsPanel.Padding = new Padding(5, 0, 5, 0);
            redCardsPanel.Size = new Size(362, 63);
            redCardsPanel.TabIndex = 4;
            // 
            // redCardsNum
            // 
            redCardsNum.Dock = DockStyle.Fill;
            redCardsNum.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            redCardsNum.ForeColor = Color.FromArgb(241, 241, 241);
            redCardsNum.Location = new Point(143, 0);
            redCardsNum.Name = "redCardsNum";
            redCardsNum.Size = new Size(214, 63);
            redCardsNum.TabIndex = 2;
            redCardsNum.Text = "2";
            redCardsNum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // redCardsLbl
            // 
            redCardsLbl.Dock = DockStyle.Left;
            redCardsLbl.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            redCardsLbl.ForeColor = Color.Gainsboro;
            redCardsLbl.Location = new Point(5, 0);
            redCardsLbl.Name = "redCardsLbl";
            redCardsLbl.Size = new Size(138, 63);
            redCardsLbl.TabIndex = 1;
            redCardsLbl.Text = "Red Cards:";
            redCardsLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // seperator3
            // 
            seperator3.BackColor = Color.Black;
            seperator3.Dock = DockStyle.Top;
            seperator3.Location = new Point(0, 214);
            seperator3.Name = "seperator3";
            seperator3.Size = new Size(362, 2);
            seperator3.TabIndex = 7;
            // 
            // yellowCardsPanel
            // 
            yellowCardsPanel.Controls.Add(yellowCardsNum);
            yellowCardsPanel.Controls.Add(yellowCardsLbl);
            yellowCardsPanel.Dock = DockStyle.Top;
            yellowCardsPanel.Location = new Point(0, 151);
            yellowCardsPanel.Name = "yellowCardsPanel";
            yellowCardsPanel.Padding = new Padding(5, 0, 5, 0);
            yellowCardsPanel.Size = new Size(362, 63);
            yellowCardsPanel.TabIndex = 3;
            // 
            // yellowCardsNum
            // 
            yellowCardsNum.Dock = DockStyle.Fill;
            yellowCardsNum.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            yellowCardsNum.ForeColor = Color.FromArgb(241, 241, 241);
            yellowCardsNum.Location = new Point(143, 0);
            yellowCardsNum.Name = "yellowCardsNum";
            yellowCardsNum.Size = new Size(214, 63);
            yellowCardsNum.TabIndex = 2;
            yellowCardsNum.Text = "10";
            yellowCardsNum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // yellowCardsLbl
            // 
            yellowCardsLbl.Dock = DockStyle.Left;
            yellowCardsLbl.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            yellowCardsLbl.ForeColor = Color.Gainsboro;
            yellowCardsLbl.Location = new Point(5, 0);
            yellowCardsLbl.Name = "yellowCardsLbl";
            yellowCardsLbl.Size = new Size(138, 63);
            yellowCardsLbl.TabIndex = 1;
            yellowCardsLbl.Text = "Yellow Cards:";
            yellowCardsLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // seperator2
            // 
            seperator2.BackColor = Color.Black;
            seperator2.Dock = DockStyle.Top;
            seperator2.Location = new Point(0, 149);
            seperator2.Name = "seperator2";
            seperator2.Size = new Size(362, 2);
            seperator2.TabIndex = 6;
            // 
            // TopScorerPanel
            // 
            TopScorerPanel.Controls.Add(scorerNameLbl);
            TopScorerPanel.Controls.Add(scorerLbl);
            TopScorerPanel.Dock = DockStyle.Top;
            TopScorerPanel.Location = new Point(0, 86);
            TopScorerPanel.Name = "TopScorerPanel";
            TopScorerPanel.Padding = new Padding(5, 0, 5, 0);
            TopScorerPanel.Size = new Size(362, 63);
            TopScorerPanel.TabIndex = 2;
            // 
            // scorerNameLbl
            // 
            scorerNameLbl.Dock = DockStyle.Fill;
            scorerNameLbl.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            scorerNameLbl.ForeColor = Color.FromArgb(241, 241, 241);
            scorerNameLbl.Location = new Point(143, 0);
            scorerNameLbl.Name = "scorerNameLbl";
            scorerNameLbl.Size = new Size(214, 63);
            scorerNameLbl.TabIndex = 2;
            scorerNameLbl.Text = "Christiano Ronaldo";
            scorerNameLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // scorerLbl
            // 
            scorerLbl.Dock = DockStyle.Left;
            scorerLbl.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            scorerLbl.ForeColor = Color.Gainsboro;
            scorerLbl.Location = new Point(5, 0);
            scorerLbl.Name = "scorerLbl";
            scorerLbl.Size = new Size(138, 63);
            scorerLbl.TabIndex = 1;
            scorerLbl.Text = "First Scorer:";
            scorerLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // seperatorPanel
            // 
            seperatorPanel.BackColor = Color.Black;
            seperatorPanel.Dock = DockStyle.Top;
            seperatorPanel.Location = new Point(0, 84);
            seperatorPanel.Name = "seperatorPanel";
            seperatorPanel.Size = new Size(362, 2);
            seperatorPanel.TabIndex = 1;
            // 
            // scorePanel
            // 
            scorePanel.Controls.Add(scoreLbl);
            scorePanel.Controls.Add(awayTeamLbl);
            scorePanel.Controls.Add(homeTeamLbl);
            scorePanel.Dock = DockStyle.Top;
            scorePanel.Location = new Point(0, 0);
            scorePanel.Name = "scorePanel";
            scorePanel.Size = new Size(362, 84);
            scorePanel.TabIndex = 0;
            // 
            // scoreLbl
            // 
            scoreLbl.Dock = DockStyle.Fill;
            scoreLbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            scoreLbl.ForeColor = Color.FromArgb(241, 241, 241);
            scoreLbl.Location = new Point(138, 0);
            scoreLbl.Name = "scoreLbl";
            scoreLbl.Size = new Size(86, 84);
            scoreLbl.TabIndex = 3;
            scoreLbl.Text = " 2 - 2";
            scoreLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // awayTeamLbl
            // 
            awayTeamLbl.Dock = DockStyle.Right;
            awayTeamLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            awayTeamLbl.ForeColor = Color.FromArgb(76, 175, 80);
            awayTeamLbl.Location = new Point(224, 0);
            awayTeamLbl.Name = "awayTeamLbl";
            awayTeamLbl.Size = new Size(138, 84);
            awayTeamLbl.TabIndex = 2;
            awayTeamLbl.Text = "Real Madrid";
            awayTeamLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // homeTeamLbl
            // 
            homeTeamLbl.Dock = DockStyle.Left;
            homeTeamLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            homeTeamLbl.ForeColor = Color.FromArgb(76, 175, 80);
            homeTeamLbl.Location = new Point(0, 0);
            homeTeamLbl.Name = "homeTeamLbl";
            homeTeamLbl.Size = new Size(138, 84);
            homeTeamLbl.TabIndex = 0;
            homeTeamLbl.Text = "Manchester United";
            homeTeamLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // resultsLbl
            // 
            resultsLbl.BackColor = Color.Transparent;
            resultsLbl.Dock = DockStyle.Top;
            resultsLbl.Font = new Font("Times New Roman", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resultsLbl.ForeColor = Color.FromArgb(241, 241, 241);
            resultsLbl.Location = new Point(0, 0);
            resultsLbl.Name = "resultsLbl";
            resultsLbl.Padding = new Padding(0, 10, 0, 0);
            resultsLbl.Size = new Size(402, 57);
            resultsLbl.TabIndex = 4;
            resultsLbl.Text = "Game Result";
            resultsLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MatchResultPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 427);
            Controls.Add(panelBg);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MatchResultPopup";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MatchResultPopup";
            panelBg.ResumeLayout(false);
            resultsPanelBg.ResumeLayout(false);
            resultsRroundedPanel.ResumeLayout(false);
            cornersPanel.ResumeLayout(false);
            redCardsPanel.ResumeLayout(false);
            yellowCardsPanel.ResumeLayout(false);
            TopScorerPanel.ResumeLayout(false);
            scorePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBg;
        private Label resultsLbl;
        private Panel resultsPanelBg;
        private RoundedPanel resultsRroundedPanel;
        private Panel scorePanel;
        private Label awayTeamLbl;
        private Label homeTeamLbl;
        private Label scoreLbl;
        private Panel seperatorPanel;
        private Panel TopScorerPanel;
        private Label scorerLbl;
        private Label scorerNameLbl;
        private Panel redCardsPanel;
        private Label redCardsNum;
        private Label redCardsLbl;
        private Panel yellowCardsPanel;
        private Label yellowCardsNum;
        private Label yellowCardsLbl;
        private Panel cornersPanel;
        private Label cornersNum;
        private Label cornersLbl;
        private Panel seperator4;
        private Panel seperator3;
        private Panel seperator2;
    }
}