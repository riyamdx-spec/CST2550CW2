using ScottPlot.WinForms;

namespace BettingSystem.Forms
{
    partial class AdminFinancialPage : BaseForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            adminNavBar1 = new BettingSystem.Forms.CustomControls.AdminNavBar();
            lblTitle = new Label();
            pnlSummaryCards = new Panel();
            cardWithdrawals = new RoundedPanel();
            cardDeposits = new RoundedPanel();
            cardBetsPlaced = new RoundedPanel();
            cardActiveUsers = new RoundedPanel();
            cardRevenue = new RoundedPanel();
            lblRevenueLbl = new Label();
            lblRevenueVal = new Label();
            lblActiveUsersLbl = new Label();
            lblActiveUsersVal = new Label();
            lblBetsPlacedLbl = new Label();
            lblBetsPlacedVal = new Label();
            lblDepositsLbl = new Label();
            lblDepositsVal = new Label();
            lblWithdrawalsLbl = new Label();
            lblWithdrawalsVal = new Label();
            pnlCharts = new Panel();
            pnlBetStatus = new Panel();
            chartBetStatus = new FormsPlot();
            lblBetStatusDesc = new Label();
            lblBetStatusTitle = new Label();
            pnlTransactionVolume = new Panel();
            chartTransactionVolume = new FormsPlot();
            lblTransactionVolumeDesc = new Label();
            lblTransactionVolumeTitle = new Label();
            pnlProfitLoss = new Panel();
            chartProfitLoss = new FormsPlot();
            lblProfitLossDesc = new Label();
            lblProfitLossTitle = new Label();
            pnlAiReport = new RoundedPanel();
            rtbAiReport = new RichTextBox();
            lblAiReportStatus = new Label();
            pnlAiReportHeader = new Panel();
            lblAiReportTitle = new Label();
            btnGenerateReport = new RoundedButton();
            pnlSummaryCards.SuspendLayout();
            pnlCharts.SuspendLayout();
            pnlBetStatus.SuspendLayout();
            pnlTransactionVolume.SuspendLayout();
            pnlProfitLoss.SuspendLayout();
            pnlAiReport.SuspendLayout();
            pnlAiReportHeader.SuspendLayout();
            SuspendLayout();
            // 
            // adminNavBar1
            // 
            adminNavBar1.Dock = DockStyle.Top;
            adminNavBar1.Location = new Point(0, 0);
            adminNavBar1.Name = "adminNavBar1";
            adminNavBar1.Size = new Size(1184, 85);
            adminNavBar1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(241, 241, 241);
            lblTitle.Location = new Point(0, 85);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1184, 73);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Financial Overview";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSummaryCards
            // 
            pnlSummaryCards.BackColor = Color.Transparent;
            pnlSummaryCards.Controls.Add(cardWithdrawals);
            pnlSummaryCards.Controls.Add(cardDeposits);
            pnlSummaryCards.Controls.Add(cardBetsPlaced);
            pnlSummaryCards.Controls.Add(cardActiveUsers);
            pnlSummaryCards.Controls.Add(cardRevenue);
            pnlSummaryCards.Dock = DockStyle.Top;
            pnlSummaryCards.Location = new Point(0, 158);
            pnlSummaryCards.Name = "pnlSummaryCards";
            pnlSummaryCards.Padding = new Padding(20, 10, 20, 10);
            pnlSummaryCards.Size = new Size(1184, 100);
            pnlSummaryCards.TabIndex = 2;
            // 
            // cardWithdrawals
            // 
            cardWithdrawals.Location = new Point(0, 0);
            cardWithdrawals.Name = "cardWithdrawals";
            cardWithdrawals.Size = new Size(200, 100);
            cardWithdrawals.TabIndex = 0;
            // 
            // cardDeposits
            // 
            cardDeposits.Location = new Point(0, 0);
            cardDeposits.Name = "cardDeposits";
            cardDeposits.Size = new Size(200, 100);
            cardDeposits.TabIndex = 1;
            // 
            // cardBetsPlaced
            // 
            cardBetsPlaced.Location = new Point(0, 0);
            cardBetsPlaced.Name = "cardBetsPlaced";
            cardBetsPlaced.Size = new Size(200, 100);
            cardBetsPlaced.TabIndex = 2;
            // 
            // cardActiveUsers
            // 
            cardActiveUsers.Location = new Point(0, 0);
            cardActiveUsers.Name = "cardActiveUsers";
            cardActiveUsers.Size = new Size(200, 100);
            cardActiveUsers.TabIndex = 3;
            // 
            // cardRevenue
            // 
            cardRevenue.Location = new Point(0, 0);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Size = new Size(200, 100);
            cardRevenue.TabIndex = 4;
            // 
            // lblRevenueLbl
            // 
            lblRevenueLbl.Location = new Point(0, 0);
            lblRevenueLbl.Name = "lblRevenueLbl";
            lblRevenueLbl.Size = new Size(100, 23);
            lblRevenueLbl.TabIndex = 0;
            // 
            // lblRevenueVal
            // 
            lblRevenueVal.Location = new Point(0, 0);
            lblRevenueVal.Name = "lblRevenueVal";
            lblRevenueVal.Size = new Size(100, 23);
            lblRevenueVal.TabIndex = 0;
            // 
            // lblActiveUsersLbl
            // 
            lblActiveUsersLbl.Location = new Point(0, 0);
            lblActiveUsersLbl.Name = "lblActiveUsersLbl";
            lblActiveUsersLbl.Size = new Size(100, 23);
            lblActiveUsersLbl.TabIndex = 0;
            // 
            // lblActiveUsersVal
            // 
            lblActiveUsersVal.Location = new Point(0, 0);
            lblActiveUsersVal.Name = "lblActiveUsersVal";
            lblActiveUsersVal.Size = new Size(100, 23);
            lblActiveUsersVal.TabIndex = 0;
            // 
            // lblBetsPlacedLbl
            // 
            lblBetsPlacedLbl.Location = new Point(0, 0);
            lblBetsPlacedLbl.Name = "lblBetsPlacedLbl";
            lblBetsPlacedLbl.Size = new Size(100, 23);
            lblBetsPlacedLbl.TabIndex = 0;
            // 
            // lblBetsPlacedVal
            // 
            lblBetsPlacedVal.Location = new Point(0, 0);
            lblBetsPlacedVal.Name = "lblBetsPlacedVal";
            lblBetsPlacedVal.Size = new Size(100, 23);
            lblBetsPlacedVal.TabIndex = 0;
            // 
            // lblDepositsLbl
            // 
            lblDepositsLbl.Location = new Point(0, 0);
            lblDepositsLbl.Name = "lblDepositsLbl";
            lblDepositsLbl.Size = new Size(100, 23);
            lblDepositsLbl.TabIndex = 0;
            // 
            // lblDepositsVal
            // 
            lblDepositsVal.Location = new Point(0, 0);
            lblDepositsVal.Name = "lblDepositsVal";
            lblDepositsVal.Size = new Size(100, 23);
            lblDepositsVal.TabIndex = 0;
            // 
            // lblWithdrawalsLbl
            // 
            lblWithdrawalsLbl.Location = new Point(0, 0);
            lblWithdrawalsLbl.Name = "lblWithdrawalsLbl";
            lblWithdrawalsLbl.Size = new Size(100, 23);
            lblWithdrawalsLbl.TabIndex = 0;
            // 
            // lblWithdrawalsVal
            // 
            lblWithdrawalsVal.ForeColor = Color.FromArgb(220, 53, 53);
            lblWithdrawalsVal.Location = new Point(0, 0);
            lblWithdrawalsVal.Name = "lblWithdrawalsVal";
            lblWithdrawalsVal.Size = new Size(100, 23);
            lblWithdrawalsVal.TabIndex = 0;
            // 
            // pnlCharts
            // 
            pnlCharts.BackColor = Color.Transparent;
            pnlCharts.Controls.Add(pnlBetStatus);
            pnlCharts.Controls.Add(pnlTransactionVolume);
            pnlCharts.Controls.Add(pnlProfitLoss);
            pnlCharts.Dock = DockStyle.Fill;
            pnlCharts.Location = new Point(0, 258);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Padding = new Padding(20, 10, 20, 20);
            pnlCharts.Size = new Size(1184, 453);
            pnlCharts.TabIndex = 3;
            // 
            // pnlBetStatus
            // 
            pnlBetStatus.BackColor = Color.Transparent;
            pnlBetStatus.Controls.Add(chartBetStatus);
            pnlBetStatus.Controls.Add(lblBetStatusDesc);
            pnlBetStatus.Controls.Add(lblBetStatusTitle);
            pnlBetStatus.Dock = DockStyle.Fill;
            pnlBetStatus.Location = new Point(420, 10);
            pnlBetStatus.Name = "pnlBetStatus";
            pnlBetStatus.Padding = new Padding(10, 0, 0, 0);
            pnlBetStatus.Size = new Size(744, 423);
            pnlBetStatus.TabIndex = 2;
            // 
            // chartBetStatus
            // 
            chartBetStatus.Dock = DockStyle.Fill;
            chartBetStatus.Location = new Point(10, 30);
            chartBetStatus.Name = "chartBetStatus";
            chartBetStatus.Size = new Size(734, 371);
            chartBetStatus.TabIndex = 0;
            // 
            // lblBetStatusDesc
            // 
            lblBetStatusDesc.Dock = DockStyle.Bottom;
            lblBetStatusDesc.Font = new Font("Times New Roman", 9F);
            lblBetStatusDesc.ForeColor = Color.FromArgb(100, 100, 100);
            lblBetStatusDesc.Location = new Point(10, 401);
            lblBetStatusDesc.Name = "lblBetStatusDesc";
            lblBetStatusDesc.Size = new Size(734, 22);
            lblBetStatusDesc.TabIndex = 1;
            lblBetStatusDesc.Text = "Breakdown of all bet outcomes";
            lblBetStatusDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBetStatusTitle
            // 
            lblBetStatusTitle.Dock = DockStyle.Top;
            lblBetStatusTitle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblBetStatusTitle.ForeColor = Color.FromArgb(241, 241, 241);
            lblBetStatusTitle.Location = new Point(10, 0);
            lblBetStatusTitle.Name = "lblBetStatusTitle";
            lblBetStatusTitle.Size = new Size(734, 30);
            lblBetStatusTitle.TabIndex = 2;
            lblBetStatusTitle.Text = "Bet Outcomes";
            lblBetStatusTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTransactionVolume
            // 
            pnlTransactionVolume.BackColor = Color.Transparent;
            pnlTransactionVolume.Controls.Add(chartTransactionVolume);
            pnlTransactionVolume.Controls.Add(lblTransactionVolumeDesc);
            pnlTransactionVolume.Controls.Add(lblTransactionVolumeTitle);
            pnlTransactionVolume.Dock = DockStyle.Left;
            pnlTransactionVolume.Location = new Point(220, 10);
            pnlTransactionVolume.Name = "pnlTransactionVolume";
            pnlTransactionVolume.Padding = new Padding(0, 0, 10, 0);
            pnlTransactionVolume.Size = new Size(200, 423);
            pnlTransactionVolume.TabIndex = 1;
            // 
            // chartTransactionVolume
            // 
            chartTransactionVolume.Dock = DockStyle.Fill;
            chartTransactionVolume.Location = new Point(0, 30);
            chartTransactionVolume.Name = "chartTransactionVolume";
            chartTransactionVolume.Size = new Size(190, 371);
            chartTransactionVolume.TabIndex = 0;
            // 
            // lblTransactionVolumeDesc
            // 
            lblTransactionVolumeDesc.Dock = DockStyle.Bottom;
            lblTransactionVolumeDesc.Font = new Font("Times New Roman", 9F);
            lblTransactionVolumeDesc.ForeColor = Color.FromArgb(100, 100, 100);
            lblTransactionVolumeDesc.Location = new Point(0, 401);
            lblTransactionVolumeDesc.Name = "lblTransactionVolumeDesc";
            lblTransactionVolumeDesc.Size = new Size(190, 22);
            lblTransactionVolumeDesc.TabIndex = 1;
            lblTransactionVolumeDesc.Text = "Volume by type per month · last 12 months";
            lblTransactionVolumeDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTransactionVolumeTitle
            // 
            lblTransactionVolumeTitle.Dock = DockStyle.Top;
            lblTransactionVolumeTitle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblTransactionVolumeTitle.ForeColor = Color.FromArgb(241, 241, 241);
            lblTransactionVolumeTitle.Location = new Point(0, 0);
            lblTransactionVolumeTitle.Name = "lblTransactionVolumeTitle";
            lblTransactionVolumeTitle.Size = new Size(190, 30);
            lblTransactionVolumeTitle.TabIndex = 2;
            lblTransactionVolumeTitle.Text = "Transaction Volume";
            lblTransactionVolumeTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlProfitLoss
            // 
            pnlProfitLoss.BackColor = Color.Transparent;
            pnlProfitLoss.Controls.Add(chartProfitLoss);
            pnlProfitLoss.Controls.Add(lblProfitLossDesc);
            pnlProfitLoss.Controls.Add(lblProfitLossTitle);
            pnlProfitLoss.Dock = DockStyle.Left;
            pnlProfitLoss.Location = new Point(20, 10);
            pnlProfitLoss.Name = "pnlProfitLoss";
            pnlProfitLoss.Padding = new Padding(0, 0, 10, 0);
            pnlProfitLoss.Size = new Size(200, 423);
            pnlProfitLoss.TabIndex = 0;
            // 
            // chartProfitLoss
            // 
            chartProfitLoss.Dock = DockStyle.Fill;
            chartProfitLoss.Location = new Point(0, 30);
            chartProfitLoss.Name = "chartProfitLoss";
            chartProfitLoss.Size = new Size(190, 371);
            chartProfitLoss.TabIndex = 0;
            // 
            // lblProfitLossDesc
            // 
            lblProfitLossDesc.Dock = DockStyle.Bottom;
            lblProfitLossDesc.Font = new Font("Times New Roman", 9F);
            lblProfitLossDesc.ForeColor = Color.FromArgb(100, 100, 100);
            lblProfitLossDesc.Location = new Point(0, 401);
            lblProfitLossDesc.Name = "lblProfitLossDesc";
            lblProfitLossDesc.Size = new Size(190, 22);
            lblProfitLossDesc.TabIndex = 1;
            lblProfitLossDesc.Text = "Monthly revenue vs payouts · last 12 months";
            lblProfitLossDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProfitLossTitle
            // 
            lblProfitLossTitle.Dock = DockStyle.Top;
            lblProfitLossTitle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblProfitLossTitle.ForeColor = Color.FromArgb(241, 241, 241);
            lblProfitLossTitle.Location = new Point(0, 0);
            lblProfitLossTitle.Name = "lblProfitLossTitle";
            lblProfitLossTitle.Size = new Size(190, 30);
            lblProfitLossTitle.TabIndex = 2;
            lblProfitLossTitle.Text = "Profit & Loss";
            lblProfitLossTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAiReport
            // 
            pnlAiReport.BackColor = Color.FromArgb(40, 40, 40);
            pnlAiReport.Controls.Add(rtbAiReport);
            pnlAiReport.Controls.Add(lblAiReportStatus);
            pnlAiReport.Controls.Add(pnlAiReportHeader);
            pnlAiReport.CornerRadius = 12;
            pnlAiReport.Dock = DockStyle.Bottom;
            pnlAiReport.Location = new Point(0, 665);
            pnlAiReport.Name = "pnlAiReport";
            pnlAiReport.Padding = new Padding(16, 10, 16, 12);
            pnlAiReport.Size = new Size(1184, 46);
            pnlAiReport.TabIndex = 4;
            // 
            // rtbAiReport
            // 
            rtbAiReport.BackColor = Color.FromArgb(31, 31, 31);
            rtbAiReport.BorderStyle = BorderStyle.None;
            rtbAiReport.Dock = DockStyle.Fill;
            rtbAiReport.Font = new Font("Times New Roman", 10F);
            rtbAiReport.ForeColor = Color.FromArgb(210, 210, 210);
            rtbAiReport.Location = new Point(16, 46);
            rtbAiReport.Name = "rtbAiReport";
            rtbAiReport.ReadOnly = true;
            rtbAiReport.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbAiReport.Size = new Size(1152, 0);
            rtbAiReport.TabIndex = 2;
            rtbAiReport.Text = "";
            // 
            // lblAiReportStatus
            // 
            lblAiReportStatus.Dock = DockStyle.Bottom;
            lblAiReportStatus.Font = new Font("Times New Roman", 9F, FontStyle.Italic);
            lblAiReportStatus.ForeColor = Color.FromArgb(100, 100, 100);
            lblAiReportStatus.Location = new Point(16, 14);
            lblAiReportStatus.Name = "lblAiReportStatus";
            lblAiReportStatus.Size = new Size(1152, 20);
            lblAiReportStatus.TabIndex = 3;
            lblAiReportStatus.Text = "Click Generate Report to analyse current financial data";
            lblAiReportStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlAiReportHeader
            // 
            pnlAiReportHeader.BackColor = Color.Transparent;
            pnlAiReportHeader.Controls.Add(lblAiReportTitle);
            pnlAiReportHeader.Controls.Add(btnGenerateReport);
            pnlAiReportHeader.Dock = DockStyle.Top;
            pnlAiReportHeader.Location = new Point(16, 10);
            pnlAiReportHeader.Name = "pnlAiReportHeader";
            pnlAiReportHeader.Size = new Size(1152, 36);
            pnlAiReportHeader.TabIndex = 0;
            // 
            // lblAiReportTitle
            // 
            lblAiReportTitle.Dock = DockStyle.Fill;
            lblAiReportTitle.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblAiReportTitle.ForeColor = Color.FromArgb(241, 241, 241);
            lblAiReportTitle.Location = new Point(0, 0);
            lblAiReportTitle.Name = "lblAiReportTitle";
            lblAiReportTitle.Size = new Size(1002, 36);
            lblAiReportTitle.TabIndex = 0;
            lblAiReportTitle.Text = "AI Financial Report";
            lblAiReportTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = Color.FromArgb(93, 185, 64);
            btnGenerateReport.CornerRadius = 10;
            btnGenerateReport.Cursor = Cursors.Hand;
            btnGenerateReport.Dock = DockStyle.Right;
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.FromArgb(241, 241, 241);
            btnGenerateReport.Location = new Point(1002, 0);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(150, 36);
            btnGenerateReport.TabIndex = 1;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // AdminFinancialPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1184, 711);
            Controls.Add(pnlAiReport);
            Controls.Add(pnlCharts);
            Controls.Add(pnlSummaryCards);
            Controls.Add(lblTitle);
            Controls.Add(adminNavBar1);
            MinimumSize = new Size(1200, 750);
            Name = "AdminFinancialPage";
            Text = "Financial Overview";
            pnlSummaryCards.ResumeLayout(false);
            pnlCharts.ResumeLayout(false);
            pnlBetStatus.ResumeLayout(false);
            pnlTransactionVolume.ResumeLayout(false);
            pnlProfitLoss.ResumeLayout(false);
            pnlAiReport.ResumeLayout(false);
            pnlAiReportHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void SetupSummaryCard(RoundedPanel card, Label lbl, Label val, string labelText)
        {
            card.BackColor = Color.FromArgb(40, 40, 40);
            card.CornerRadius = 12;
            card.Anchor = AnchorStyles.None;
            card.Size = new Size(180, 70);
            card.Controls.Add(val);
            card.Controls.Add(lbl);

            lbl.AutoSize = false;
            lbl.Dock = DockStyle.Top;
            lbl.Height = 26;
            lbl.Font = new Font("Times New Roman", 9F);
            lbl.ForeColor = Color.FromArgb(150, 150, 150);
            lbl.Text = labelText;
            lbl.TextAlign = ContentAlignment.MiddleCenter;

            val.AutoSize = false;
            val.Dock = DockStyle.Fill;
            val.Font = new Font("Times New Roman", 15F, FontStyle.Bold);
            val.ForeColor = Color.FromArgb(93, 185, 64);
            val.Text = "-";
            val.TextAlign = ContentAlignment.MiddleCenter;
        }

        private CustomControls.AdminNavBar adminNavBar1;
        private Label lblTitle;
        private Panel pnlSummaryCards;
        private RoundedPanel cardRevenue;
        private Label lblRevenueLbl;
        private Label lblRevenueVal;
        private RoundedPanel cardActiveUsers;
        private Label lblActiveUsersLbl;
        private Label lblActiveUsersVal;
        private RoundedPanel cardBetsPlaced;
        private Label lblBetsPlacedLbl;
        private Label lblBetsPlacedVal;
        private RoundedPanel cardDeposits;
        private Label lblDepositsLbl;
        private Label lblDepositsVal;
        private RoundedPanel cardWithdrawals;
        private Label lblWithdrawalsLbl;
        private Label lblWithdrawalsVal;
        private Panel pnlCharts;
        private Panel pnlProfitLoss;
        private FormsPlot chartProfitLoss;
        private Label lblProfitLossTitle;
        private Label lblProfitLossDesc;
        private Panel pnlTransactionVolume;
        private FormsPlot chartTransactionVolume;
        private Label lblTransactionVolumeTitle;
        private Label lblTransactionVolumeDesc;
        private Panel pnlBetStatus;
        private FormsPlot chartBetStatus;
        private Label lblBetStatusTitle;
        private Label lblBetStatusDesc;
        private RoundedPanel pnlAiReport;
        private Panel pnlAiReportHeader;
        private Label lblAiReportTitle;
        private RoundedButton btnGenerateReport;
        private RichTextBox rtbAiReport;
        private Label lblAiReportStatus;
    }
}