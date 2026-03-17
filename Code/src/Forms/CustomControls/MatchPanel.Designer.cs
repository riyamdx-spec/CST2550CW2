namespace BettingSystem.Forms
{
    partial class MatchPanel
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
            matchRoundedPanel = new RoundedPanel();
            teamInfoPanel = new Panel();
            matchTableLayoutPanel = new TableLayoutPanel();
            vsLbl = new Label();
            homeTeamPanel = new Panel();
            homeTeamLbl = new Label();
            homeTeamImg = new PictureBox();
            awayTeamPanel = new Panel();
            awayTeamLbl = new Label();
            awayTeamImg = new PictureBox();
            matchLeagueLbl = new Label();
            seeBetBtnPanel = new Panel();
            seeBetsBtn = new RoundedButton();
            dateTimePanel = new Panel();
            matchTimeLbl = new Label();
            matchDateLbl = new Label();
            matchRoundedPanel.SuspendLayout();
            teamInfoPanel.SuspendLayout();
            matchTableLayoutPanel.SuspendLayout();
            homeTeamPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)homeTeamImg).BeginInit();
            awayTeamPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)awayTeamImg).BeginInit();
            seeBetBtnPanel.SuspendLayout();
            dateTimePanel.SuspendLayout();
            SuspendLayout();
            // 
            // matchRoundedPanel
            // 
            matchRoundedPanel.AutoSize = true;
            matchRoundedPanel.BackColor = Color.FromArgb(31, 31, 31);
            matchRoundedPanel.Controls.Add(teamInfoPanel);
            matchRoundedPanel.Controls.Add(matchLeagueLbl);
            matchRoundedPanel.Controls.Add(seeBetBtnPanel);
            matchRoundedPanel.Controls.Add(dateTimePanel);
            matchRoundedPanel.Dock = DockStyle.Fill;
            matchRoundedPanel.ForeColor = Color.FromArgb(31, 31, 31);
            matchRoundedPanel.Location = new Point(0, 0);
            matchRoundedPanel.Name = "matchRoundedPanel";
            matchRoundedPanel.Size = new Size(762, 129);
            matchRoundedPanel.TabIndex = 0;
            // 
            // teamInfoPanel
            // 
            teamInfoPanel.Controls.Add(matchTableLayoutPanel);
            teamInfoPanel.Dock = DockStyle.Fill;
            teamInfoPanel.Location = new Point(148, 39);
            teamInfoPanel.Margin = new Padding(2, 1, 2, 1);
            teamInfoPanel.Name = "teamInfoPanel";
            teamInfoPanel.Size = new Size(489, 90);
            teamInfoPanel.TabIndex = 3;
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
            matchTableLayoutPanel.Location = new Point(0, 0);
            matchTableLayoutPanel.Margin = new Padding(2, 1, 2, 1);
            matchTableLayoutPanel.Name = "matchTableLayoutPanel";
            matchTableLayoutPanel.RowCount = 1;
            matchTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            matchTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            matchTableLayoutPanel.Size = new Size(489, 90);
            matchTableLayoutPanel.TabIndex = 0;
            // 
            // vsLbl
            // 
            vsLbl.Dock = DockStyle.Fill;
            vsLbl.Font = new Font("Verdana", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vsLbl.ForeColor = Color.FromArgb(241, 241, 241);
            vsLbl.Location = new Point(219, 0);
            vsLbl.Margin = new Padding(2, 0, 2, 0);
            vsLbl.Name = "vsLbl";
            vsLbl.Size = new Size(50, 90);
            vsLbl.TabIndex = 3;
            vsLbl.Text = "VS";
            vsLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // homeTeamPanel
            // 
            homeTeamPanel.Controls.Add(homeTeamLbl);
            homeTeamPanel.Controls.Add(homeTeamImg);
            homeTeamPanel.Dock = DockStyle.Fill;
            homeTeamPanel.Location = new Point(2, 1);
            homeTeamPanel.Margin = new Padding(2, 1, 2, 1);
            homeTeamPanel.Name = "homeTeamPanel";
            homeTeamPanel.Size = new Size(213, 88);
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
            homeTeamLbl.Size = new Size(148, 88);
            homeTeamLbl.TabIndex = 3;
            homeTeamLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // homeTeamImg
            // 
            homeTeamImg.BackColor = Color.Transparent;
            homeTeamImg.Dock = DockStyle.Right;
            homeTeamImg.Location = new Point(148, 0);
            homeTeamImg.Margin = new Padding(22, 19, 22, 19);
            homeTeamImg.Name = "homeTeamImg";
            homeTeamImg.Size = new Size(65, 88);
            homeTeamImg.SizeMode = PictureBoxSizeMode.Zoom;
            homeTeamImg.TabIndex = 2;
            homeTeamImg.TabStop = false;
            // 
            // awayTeamPanel
            // 
            awayTeamPanel.Controls.Add(awayTeamLbl);
            awayTeamPanel.Controls.Add(awayTeamImg);
            awayTeamPanel.Dock = DockStyle.Fill;
            awayTeamPanel.Location = new Point(273, 1);
            awayTeamPanel.Margin = new Padding(2, 1, 2, 1);
            awayTeamPanel.Name = "awayTeamPanel";
            awayTeamPanel.Size = new Size(214, 88);
            awayTeamPanel.TabIndex = 4;
            // 
            // awayTeamLbl
            // 
            awayTeamLbl.Dock = DockStyle.Fill;
            awayTeamLbl.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            awayTeamLbl.ForeColor = Color.FromArgb(241, 241, 241);
            awayTeamLbl.Location = new Point(65, 0);
            awayTeamLbl.Name = "awayTeamLbl";
            awayTeamLbl.Padding = new Padding(11, 0, 3, 0);
            awayTeamLbl.Size = new Size(149, 88);
            awayTeamLbl.TabIndex = 4;
            awayTeamLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // awayTeamImg
            // 
            awayTeamImg.BackColor = Color.Transparent;
            awayTeamImg.Dock = DockStyle.Left;
            awayTeamImg.Location = new Point(0, 0);
            awayTeamImg.Margin = new Padding(22, 19, 22, 19);
            awayTeamImg.Name = "awayTeamImg";
            awayTeamImg.Size = new Size(65, 88);
            awayTeamImg.SizeMode = PictureBoxSizeMode.Zoom;
            awayTeamImg.TabIndex = 3;
            awayTeamImg.TabStop = false;
            // 
            // matchLeagueLbl
            // 
            matchLeagueLbl.Dock = DockStyle.Top;
            matchLeagueLbl.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            matchLeagueLbl.ForeColor = Color.FromArgb(241, 241, 241);
            matchLeagueLbl.Location = new Point(148, 0);
            matchLeagueLbl.Name = "matchLeagueLbl";
            matchLeagueLbl.Padding = new Padding(0, 2, 0, 0);
            matchLeagueLbl.Size = new Size(489, 39);
            matchLeagueLbl.TabIndex = 2;
            matchLeagueLbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // seeBetBtnPanel
            // 
            seeBetBtnPanel.Controls.Add(seeBetsBtn);
            seeBetBtnPanel.Dock = DockStyle.Right;
            seeBetBtnPanel.Location = new Point(637, 0);
            seeBetBtnPanel.Margin = new Padding(2, 1, 2, 1);
            seeBetBtnPanel.Name = "seeBetBtnPanel";
            seeBetBtnPanel.Size = new Size(125, 129);
            seeBetBtnPanel.TabIndex = 1;
            // 
            // seeBetsBtn
            // 
            seeBetsBtn.BackColor = Color.FromArgb(93, 185, 64);
            seeBetsBtn.CornerRadius = 15;
            seeBetsBtn.Cursor = Cursors.Hand;
            seeBetsBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            seeBetsBtn.ForeColor = Color.FromArgb(241, 241, 241);
            seeBetsBtn.Location = new Point(10, 45);
            seeBetsBtn.Name = "seeBetsBtn";
            seeBetsBtn.Size = new Size(105, 39);
            seeBetsBtn.TabIndex = 0;
            seeBetsBtn.Text = "See Bets";
            seeBetsBtn.UseVisualStyleBackColor = false;
            seeBetsBtn.Click += seeBetsBtn_Click;
            // 
            // dateTimePanel
            // 
            dateTimePanel.Controls.Add(matchTimeLbl);
            dateTimePanel.Controls.Add(matchDateLbl);
            dateTimePanel.Dock = DockStyle.Left;
            dateTimePanel.Location = new Point(0, 0);
            dateTimePanel.Margin = new Padding(2, 1, 2, 1);
            dateTimePanel.Name = "dateTimePanel";
            dateTimePanel.Size = new Size(148, 129);
            dateTimePanel.TabIndex = 0;
            // 
            // matchTimeLbl
            // 
            matchTimeLbl.Font = new Font("Verdana", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            matchTimeLbl.ForeColor = Color.FromArgb(241, 241, 241);
            matchTimeLbl.Location = new Point(2, 61);
            matchTimeLbl.Margin = new Padding(2, 0, 2, 0);
            matchTimeLbl.Name = "matchTimeLbl";
            matchTimeLbl.Size = new Size(144, 16);
            matchTimeLbl.TabIndex = 1;
            matchTimeLbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // matchDateLbl
            // 
            matchDateLbl.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            matchDateLbl.ForeColor = Color.FromArgb(241, 241, 241);
            matchDateLbl.Location = new Point(2, 38);
            matchDateLbl.Margin = new Padding(2, 0, 2, 0);
            matchDateLbl.Name = "matchDateLbl";
            matchDateLbl.Size = new Size(144, 23);
            matchDateLbl.TabIndex = 0;
            matchDateLbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // MatchPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(matchRoundedPanel);
            Name = "MatchPanel";
            Size = new Size(762, 129);
            matchRoundedPanel.ResumeLayout(false);
            teamInfoPanel.ResumeLayout(false);
            matchTableLayoutPanel.ResumeLayout(false);
            homeTeamPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)homeTeamImg).EndInit();
            awayTeamPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)awayTeamImg).EndInit();
            seeBetBtnPanel.ResumeLayout(false);
            dateTimePanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundedPanel matchRoundedPanel;
        private Panel seeBetBtnPanel;
        private RoundedButton seeBetsBtn;
        private Panel dateTimePanel;
        private Label matchTimeLbl;
        private Label matchDateLbl;
        private Panel teamInfoPanel;
        private TableLayoutPanel matchTableLayoutPanel;
        private Label vsLbl;
        private Panel homeTeamPanel;
        private Label homeTeamLbl;
        private PictureBox homeTeamImg;
        private Panel awayTeamPanel;
        private Label awayTeamLbl;
        private PictureBox awayTeamImg;
        private Label matchLeagueLbl;
        private Label label5;
    }
}
