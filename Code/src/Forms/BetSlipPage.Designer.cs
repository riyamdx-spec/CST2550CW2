namespace BettingSystem.Forms
{
    partial class BetSlipPage : BaseForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            navBar1 = new NavBar();
            betSlipTitleLbl = new Label();
            panelBg = new Panel();
            pnlSlipList = new Panel();
            pnlSummaryContainer = new Panel();
            pnlSummary = new RoundedPanel();
            tlpSummary = new TableLayoutPanel();
            pnlTotalOdds = new Panel();
            lblTotalOdds = new Label();
            lblTotalOddsHdr = new Label();
            pnlStake = new Panel();
            txtStake = new TextBox();
            lblStakeHdr = new Label();
            pnlPayout = new Panel();
            lblPayout = new Label();
            lblPayoutHdr = new Label();
            pnlPlaceBet = new Panel();
            btnPlaceBet = new RoundedButton();
            panelBg.SuspendLayout();
            pnlSummaryContainer.SuspendLayout();
            pnlSummary.SuspendLayout();
            tlpSummary.SuspendLayout();
            pnlTotalOdds.SuspendLayout();
            pnlStake.SuspendLayout();
            pnlPayout.SuspendLayout();
            pnlPlaceBet.SuspendLayout();
            SuspendLayout();
            // 
            // navBar1
            // 
            navBar1.Dock = DockStyle.Top;
            navBar1.Location = new Point(0, 0);
            navBar1.Name = "navBar1";
            navBar1.Size = new Size(1184, 91);
            navBar1.TabIndex = 0;
            // 
            // betSlipTitleLbl
            // 
            betSlipTitleLbl.Dock = DockStyle.Top;
            betSlipTitleLbl.Font = new Font("Times New Roman", 36F, FontStyle.Bold);
            betSlipTitleLbl.ForeColor = Color.FromArgb(241, 241, 241);
            betSlipTitleLbl.Location = new Point(0, 0);
            betSlipTitleLbl.Name = "betSlipTitleLbl";
            betSlipTitleLbl.Size = new Size(1184, 60);
            betSlipTitleLbl.TabIndex = 1;
            betSlipTitleLbl.Text = "Bet Slip";
            betSlipTitleLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelBg
            // 
            panelBg.Controls.Add(pnlSlipList);
            panelBg.Controls.Add(pnlSummaryContainer);
            panelBg.Controls.Add(betSlipTitleLbl);
            panelBg.Dock = DockStyle.Fill;
            panelBg.Location = new Point(0, 91);
            panelBg.Name = "panelBg";
            panelBg.Size = new Size(1184, 620);
            panelBg.TabIndex = 2;
            // 
            // pnlSlipList
            // 
            pnlSlipList.AutoScroll = true;
            pnlSlipList.BackColor = Color.FromArgb(36, 36, 36);
            pnlSlipList.Dock = DockStyle.Fill;
            pnlSlipList.Location = new Point(0, 60);
            pnlSlipList.Name = "pnlSlipList";
            pnlSlipList.Padding = new Padding(200, 10, 200, 10);
            pnlSlipList.Size = new Size(1184, 470);
            pnlSlipList.TabIndex = 6;
            // 
            // pnlSummaryContainer
            // 
            pnlSummaryContainer.BackColor = Color.FromArgb(36, 36, 36);
            pnlSummaryContainer.Controls.Add(pnlSummary);
            pnlSummaryContainer.Dock = DockStyle.Bottom;
            pnlSummaryContainer.Location = new Point(0, 530);
            pnlSummaryContainer.Name = "pnlSummaryContainer";
            pnlSummaryContainer.Padding = new Padding(120, 10, 120, 10);
            pnlSummaryContainer.Size = new Size(1184, 90);
            pnlSummaryContainer.TabIndex = 4;
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.FromArgb(31, 31, 31);
            pnlSummary.Controls.Add(tlpSummary);
            pnlSummary.Dock = DockStyle.Fill;
            pnlSummary.Location = new Point(120, 10);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(944, 70);
            pnlSummary.TabIndex = 0;
            // 
            // tlpSummary
            // 
            tlpSummary.BackColor = Color.Transparent;
            tlpSummary.ColumnCount = 4;
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSummary.Controls.Add(pnlTotalOdds, 0, 0);
            tlpSummary.Controls.Add(pnlStake, 1, 0);
            tlpSummary.Controls.Add(pnlPayout, 2, 0);
            tlpSummary.Controls.Add(pnlPlaceBet, 3, 0);
            tlpSummary.Dock = DockStyle.Fill;
            tlpSummary.Location = new Point(0, 0);
            tlpSummary.Name = "tlpSummary";
            tlpSummary.RowCount = 1;
            tlpSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSummary.Size = new Size(944, 70);
            tlpSummary.TabIndex = 0;
            // 
            // pnlTotalOdds
            // 
            pnlTotalOdds.BackColor = Color.Transparent;
            pnlTotalOdds.Controls.Add(lblTotalOdds);
            pnlTotalOdds.Controls.Add(lblTotalOddsHdr);
            pnlTotalOdds.Dock = DockStyle.Fill;
            pnlTotalOdds.Location = new Point(3, 3);
            pnlTotalOdds.Name = "pnlTotalOdds";
            pnlTotalOdds.Size = new Size(230, 64);
            pnlTotalOdds.TabIndex = 0;
            // 
            // lblTotalOdds
            // 
            lblTotalOdds.Dock = DockStyle.Fill;
            lblTotalOdds.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblTotalOdds.ForeColor = Color.FromArgb(93, 185, 64);
            lblTotalOdds.Location = new Point(100, 0);
            lblTotalOdds.Name = "lblTotalOdds";
            lblTotalOdds.Size = new Size(130, 64);
            lblTotalOdds.TabIndex = 1;
            lblTotalOdds.Text = "1.00";
            lblTotalOdds.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalOddsHdr
            // 
            lblTotalOddsHdr.Dock = DockStyle.Left;
            lblTotalOddsHdr.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblTotalOddsHdr.ForeColor = Color.FromArgb(241, 241, 241);
            lblTotalOddsHdr.Location = new Point(0, 0);
            lblTotalOddsHdr.Name = "lblTotalOddsHdr";
            lblTotalOddsHdr.Size = new Size(100, 64);
            lblTotalOddsHdr.TabIndex = 0;
            lblTotalOddsHdr.Text = "Total Odds:";
            lblTotalOddsHdr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlStake
            // 
            pnlStake.BackColor = Color.Transparent;
            pnlStake.Controls.Add(txtStake);
            pnlStake.Controls.Add(lblStakeHdr);
            pnlStake.Dock = DockStyle.Fill;
            pnlStake.Location = new Point(239, 3);
            pnlStake.Name = "pnlStake";
            pnlStake.Size = new Size(230, 64);
            pnlStake.TabIndex = 1;
            // 
            // txtStake
            // 
            txtStake.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtStake.BackColor = Color.FromArgb(60, 60, 60);
            txtStake.Font = new Font("Times New Roman", 11F);
            txtStake.ForeColor = Color.FromArgb(241, 241, 241);
            txtStake.Location = new Point(66, 20);
            txtStake.Name = "txtStake";
            txtStake.Size = new Size(164, 24);
            txtStake.TabIndex = 1;
            // 
            // lblStakeHdr
            // 
            lblStakeHdr.Dock = DockStyle.Left;
            lblStakeHdr.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblStakeHdr.ForeColor = Color.FromArgb(241, 241, 241);
            lblStakeHdr.Location = new Point(0, 0);
            lblStakeHdr.Name = "lblStakeHdr";
            lblStakeHdr.Size = new Size(60, 64);
            lblStakeHdr.TabIndex = 0;
            lblStakeHdr.Text = "Stake:";
            lblStakeHdr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlPayout
            // 
            pnlPayout.BackColor = Color.Transparent;
            pnlPayout.Controls.Add(lblPayout);
            pnlPayout.Controls.Add(lblPayoutHdr);
            pnlPayout.Dock = DockStyle.Fill;
            pnlPayout.Location = new Point(475, 3);
            pnlPayout.Name = "pnlPayout";
            pnlPayout.Size = new Size(277, 64);
            pnlPayout.TabIndex = 2;
            // 
            // lblPayout
            // 
            lblPayout.Dock = DockStyle.Fill;
            lblPayout.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblPayout.ForeColor = Color.FromArgb(93, 185, 64);
            lblPayout.Location = new Point(140, 0);
            lblPayout.Name = "lblPayout";
            lblPayout.Size = new Size(137, 64);
            lblPayout.TabIndex = 1;
            lblPayout.Text = "$0.00";
            lblPayout.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPayoutHdr
            // 
            lblPayoutHdr.Dock = DockStyle.Left;
            lblPayoutHdr.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblPayoutHdr.ForeColor = Color.FromArgb(241, 241, 241);
            lblPayoutHdr.Location = new Point(0, 0);
            lblPayoutHdr.Name = "lblPayoutHdr";
            lblPayoutHdr.Size = new Size(140, 64);
            lblPayoutHdr.TabIndex = 0;
            lblPayoutHdr.Text = "Potential Payout:";
            lblPayoutHdr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlPlaceBet
            // 
            pnlPlaceBet.BackColor = Color.Transparent;
            pnlPlaceBet.Controls.Add(btnPlaceBet);
            pnlPlaceBet.Dock = DockStyle.Fill;
            pnlPlaceBet.Location = new Point(758, 3);
            pnlPlaceBet.Name = "pnlPlaceBet";
            pnlPlaceBet.Size = new Size(183, 64);
            pnlPlaceBet.TabIndex = 3;
            // 
            // btnPlaceBet
            // 
            btnPlaceBet.Anchor = AnchorStyles.None;
            btnPlaceBet.BackColor = Color.FromArgb(93, 185, 64);
            btnPlaceBet.CornerRadius = 15;
            btnPlaceBet.Cursor = Cursors.Hand;
            btnPlaceBet.FlatAppearance.BorderSize = 0;
            btnPlaceBet.FlatStyle = FlatStyle.Flat;
            btnPlaceBet.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnPlaceBet.ForeColor = Color.FromArgb(241, 241, 241);
            btnPlaceBet.Location = new Point(26, 12);
            btnPlaceBet.Name = "btnPlaceBet";
            btnPlaceBet.Size = new Size(130, 40);
            btnPlaceBet.TabIndex = 0;
            btnPlaceBet.Text = "Place Bet";
            btnPlaceBet.UseVisualStyleBackColor = false;
            // 
            // BetSlipPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 36, 36);
            ClientSize = new Size(1184, 711);
            Controls.Add(panelBg);
            Controls.Add(navBar1);
            MinimumSize = new Size(1200, 750);
            Name = "BetSlipPage";
            Text = "Bet Slip";
            panelBg.ResumeLayout(false);
            pnlSummaryContainer.ResumeLayout(false);
            pnlSummary.ResumeLayout(false);
            tlpSummary.ResumeLayout(false);
            pnlTotalOdds.ResumeLayout(false);
            pnlStake.ResumeLayout(false);
            pnlStake.PerformLayout();
            pnlPayout.ResumeLayout(false);
            pnlPlaceBet.ResumeLayout(false);
            ResumeLayout(false);
        }

        private NavBar navBar1;
        private Label betSlipTitleLbl;
        private Panel panelBg;
        private Panel pnlSlipList;
        private Panel pnlSummaryContainer;
        private RoundedPanel pnlSummary;
        private TableLayoutPanel tlpSummary;
        private Panel pnlTotalOdds;
        private Label lblTotalOdds;
        private Label lblTotalOddsHdr;
        private Panel pnlStake;
        private TextBox txtStake;
        private Label lblStakeHdr;
        private Panel pnlPayout;
        private Label lblPayout;
        private Label lblPayoutHdr;
        private Panel pnlPlaceBet;
        private RoundedButton btnPlaceBet;
    }
}