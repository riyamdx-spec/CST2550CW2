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
            adminNavBar1 = new CustomControls.AdminNavBar();
            lblTitle = new Label();
            pnlSummaryCards = new Panel();
            cardRevenue = new RoundedPanel();
            lblRevenueLbl = new Label();
            lblRevenueVal = new Label();
            cardActiveUsers = new RoundedPanel();
            lblActiveUsersLbl = new Label();
            lblActiveUsersVal = new Label();
            cardBetsPlaced = new RoundedPanel();
            lblBetsPlacedLbl = new Label();
            lblBetsPlacedVal = new Label();
            cardDeposits = new RoundedPanel();
            lblDepositsLbl = new Label();
            lblDepositsVal = new Label();
            cardWithdrawals = new RoundedPanel();
            lblWithdrawalsLbl = new Label();
            lblWithdrawalsVal = new Label();
            pnlCharts = new Panel();
            pnlProfitLoss = new Panel();
            chartProfitLoss = new FormsPlot();
            lblProfitLossTitle = new Label();
            lblProfitLossDesc = new Label();
            pnlTransactionVolume = new Panel();
            chartTransactionVolume = new FormsPlot();
            lblTransactionVolumeTitle = new Label();
            lblTransactionVolumeDesc = new Label();
            pnlBetStatus = new Panel();
            chartBetStatus = new FormsPlot();
            lblBetStatusTitle = new Label();
            lblBetStatusDesc = new Label();
            pnlAiReport = new RoundedPanel();
            pnlAiReportHeader = new Panel();
            lblAiReportTitle = new Label();
            btnGenerateReport = new RoundedButton();
            rtbAiReport = new RichTextBox();
            lblAiReportStatus = new Label();

            adminNavBar1.SuspendLayout();
            pnlSummaryCards.SuspendLayout();
            pnlCharts.SuspendLayout();
            pnlProfitLoss.SuspendLayout();
            pnlTransactionVolume.SuspendLayout();
            pnlBetStatus.SuspendLayout();
            pnlAiReport.SuspendLayout();
            pnlAiReportHeader.SuspendLayout();
            SuspendLayout();

            // adminNavBar1
            adminNavBar1.Dock = DockStyle.Top;
            adminNavBar1.Location = new Point(0, 0);
            adminNavBar1.Name = "adminNavBar1";
            adminNavBar1.Size = new Size(1168, 85);
            adminNavBar1.TabIndex = 0;

            // lblTitle
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(241, 241, 241);
            lblTitle.Height = 90;
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Financial Overview";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.TabIndex = 1;

            // pnlSummaryCards
            pnlSummaryCards.Dock = DockStyle.Top;
            pnlSummaryCards.Height = 100;
            pnlSummaryCards.Name = "pnlSummaryCards";
            pnlSummaryCards.Padding = new Padding(20, 10, 20, 10);
            pnlSummaryCards.BackColor = Color.Transparent;
            pnlSummaryCards.TabIndex = 2;
            pnlSummaryCards.Controls.Add(cardWithdrawals);
            pnlSummaryCards.Controls.Add(cardDeposits);
            pnlSummaryCards.Controls.Add(cardBetsPlaced);
            pnlSummaryCards.Controls.Add(cardActiveUsers);
            pnlSummaryCards.Controls.Add(cardRevenue);

            SetupSummaryCard(cardRevenue, lblRevenueLbl, lblRevenueVal, "Total Revenue");
            SetupSummaryCard(cardActiveUsers, lblActiveUsersLbl, lblActiveUsersVal, "Active Users");
            SetupSummaryCard(cardBetsPlaced, lblBetsPlacedLbl, lblBetsPlacedVal, "Bets Placed");
            SetupSummaryCard(cardDeposits, lblDepositsLbl, lblDepositsVal, "Total Deposits");
            SetupSummaryCard(cardWithdrawals, lblWithdrawalsLbl, lblWithdrawalsVal, "Withdrawals");
            lblWithdrawalsVal.ForeColor = Color.FromArgb(220, 53, 53);

            // pnlCharts
            pnlCharts.Dock = DockStyle.Fill;
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Padding = new Padding(20, 10, 20, 20);
            pnlCharts.BackColor = Color.Transparent;
            pnlCharts.Controls.Add(pnlBetStatus);
            pnlCharts.Controls.Add(pnlTransactionVolume);
            pnlCharts.Controls.Add(pnlProfitLoss);
            pnlCharts.TabIndex = 3;

            // pnlProfitLoss
            pnlProfitLoss.Dock = DockStyle.Left;
            pnlProfitLoss.Name = "pnlProfitLoss";
            pnlProfitLoss.Padding = new Padding(0, 0, 10, 0);
            pnlProfitLoss.BackColor = Color.Transparent;
            pnlProfitLoss.Controls.Add(chartProfitLoss);
            pnlProfitLoss.Controls.Add(lblProfitLossDesc);
            pnlProfitLoss.Controls.Add(lblProfitLossTitle);
            pnlProfitLoss.TabIndex = 0;

            // lblProfitLossTitle
            lblProfitLossTitle.Dock = DockStyle.Top;
            lblProfitLossTitle.Height = 30;
            lblProfitLossTitle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblProfitLossTitle.ForeColor = Color.FromArgb(241, 241, 241);
            lblProfitLossTitle.Text = "Profit & Loss";
            lblProfitLossTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblProfitLossTitle.Name = "lblProfitLossTitle";
            lblProfitLossTitle.TabIndex = 2;

            // chartProfitLoss
            chartProfitLoss.Dock = DockStyle.Fill;
            chartProfitLoss.Name = "chartProfitLoss";
            chartProfitLoss.TabIndex = 0;

            // lblProfitLossDesc
            lblProfitLossDesc.Dock = DockStyle.Bottom;
            lblProfitLossDesc.Height = 22;
            lblProfitLossDesc.Font = new Font("Times New Roman", 9F);
            lblProfitLossDesc.ForeColor = Color.FromArgb(100, 100, 100);
            lblProfitLossDesc.Text = "Monthly revenue vs payouts · last 12 months";
            lblProfitLossDesc.TextAlign = ContentAlignment.MiddleCenter;
            lblProfitLossDesc.Name = "lblProfitLossDesc";
            lblProfitLossDesc.TabIndex = 1;

            // pnlTransactionVolume
            pnlTransactionVolume.Dock = DockStyle.Left;
            pnlTransactionVolume.Name = "pnlTransactionVolume";
            pnlTransactionVolume.Padding = new Padding(0, 0, 10, 0);
            pnlTransactionVolume.BackColor = Color.Transparent;
            pnlTransactionVolume.Controls.Add(chartTransactionVolume);
            pnlTransactionVolume.Controls.Add(lblTransactionVolumeDesc);
            pnlTransactionVolume.Controls.Add(lblTransactionVolumeTitle);
            pnlTransactionVolume.TabIndex = 1;

            // lblTransactionVolumeTitle
            lblTransactionVolumeTitle.Dock = DockStyle.Top;
            lblTransactionVolumeTitle.Height = 30;
            lblTransactionVolumeTitle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblTransactionVolumeTitle.ForeColor = Color.FromArgb(241, 241, 241);
            lblTransactionVolumeTitle.Text = "Transaction Volume";
            lblTransactionVolumeTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTransactionVolumeTitle.Name = "lblTransactionVolumeTitle";
            lblTransactionVolumeTitle.TabIndex = 2;

            // chartTransactionVolume
            chartTransactionVolume.Dock = DockStyle.Fill;
            chartTransactionVolume.Name = "chartTransactionVolume";
            chartTransactionVolume.TabIndex = 0;

            // lblTransactionVolumeDesc
            lblTransactionVolumeDesc.Dock = DockStyle.Bottom;
            lblTransactionVolumeDesc.Height = 22;
            lblTransactionVolumeDesc.Font = new Font("Times New Roman", 9F);
            lblTransactionVolumeDesc.ForeColor = Color.FromArgb(100, 100, 100);
            lblTransactionVolumeDesc.Text = "Volume by type per month · last 12 months";
            lblTransactionVolumeDesc.TextAlign = ContentAlignment.MiddleCenter;
            lblTransactionVolumeDesc.Name = "lblTransactionVolumeDesc";
            lblTransactionVolumeDesc.TabIndex = 1;

            // pnlBetStatus
            pnlBetStatus.Dock = DockStyle.Fill;
            pnlBetStatus.Name = "pnlBetStatus";
            pnlBetStatus.Padding = new Padding(10, 0, 0, 0);
            pnlBetStatus.BackColor = Color.Transparent;
            pnlBetStatus.Controls.Add(chartBetStatus);
            pnlBetStatus.Controls.Add(lblBetStatusDesc);
            pnlBetStatus.Controls.Add(lblBetStatusTitle);
            pnlBetStatus.TabIndex = 2;

            // lblBetStatusTitle
            lblBetStatusTitle.Dock = DockStyle.Top;
            lblBetStatusTitle.Height = 30;
            lblBetStatusTitle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblBetStatusTitle.ForeColor = Color.FromArgb(241, 241, 241);
            lblBetStatusTitle.Text = "Bet Outcomes";
            lblBetStatusTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblBetStatusTitle.Name = "lblBetStatusTitle";
            lblBetStatusTitle.TabIndex = 2;

            // chartBetStatus
            chartBetStatus.Dock = DockStyle.Fill;
            chartBetStatus.Name = "chartBetStatus";
            chartBetStatus.TabIndex = 0;

            // lblBetStatusDesc
            lblBetStatusDesc.Dock = DockStyle.Bottom;
            lblBetStatusDesc.Height = 22;
            lblBetStatusDesc.Font = new Font("Times New Roman", 9F);
            lblBetStatusDesc.ForeColor = Color.FromArgb(100, 100, 100);
            lblBetStatusDesc.Text = "Breakdown of all bet outcomes";
            lblBetStatusDesc.TextAlign = ContentAlignment.MiddleCenter;
            lblBetStatusDesc.Name = "lblBetStatusDesc";
            lblBetStatusDesc.TabIndex = 1;

            // lblAiReportTitle
            lblAiReportTitle.AutoSize = false;
            lblAiReportTitle.Dock = DockStyle.Fill;
            lblAiReportTitle.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblAiReportTitle.ForeColor = Color.FromArgb(241, 241, 241);
            lblAiReportTitle.Text = "AI Financial Report";
            lblAiReportTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblAiReportTitle.Name = "lblAiReportTitle";
            lblAiReportTitle.TabIndex = 0;

            // btnGenerateReport
            btnGenerateReport.BackColor = Color.FromArgb(93, 185, 64);
            btnGenerateReport.CornerRadius = 10;
            btnGenerateReport.Cursor = Cursors.Hand;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.FromArgb(241, 241, 241);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(150, 30);
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Dock = DockStyle.Right;
            btnGenerateReport.TabIndex = 1;
            btnGenerateReport.Click += btnGenerateReport_Click;

            // pnlAiReportHeader
            pnlAiReportHeader.Dock = DockStyle.Top;
            pnlAiReportHeader.Height = 36;
            pnlAiReportHeader.BackColor = Color.Transparent;
            pnlAiReportHeader.Name = "pnlAiReportHeader";
            pnlAiReportHeader.TabIndex = 0;
            //pnlAiReportHeader.Controls.Add(lblAiReportStatus);
            pnlAiReportHeader.Controls.Add(lblAiReportTitle);
            pnlAiReportHeader.Controls.Add(btnGenerateReport);

            // lblAiReportStatus
            lblAiReportStatus.AutoSize = false;
            lblAiReportStatus.Dock = DockStyle.Bottom;
            lblAiReportStatus.Height = 20;
            lblAiReportStatus.Font = new Font("Times New Roman", 9F, FontStyle.Italic);
            lblAiReportStatus.ForeColor = Color.FromArgb(100, 100, 100);
            lblAiReportStatus.Text = "Click Generate Report to analyse current financial data";
            lblAiReportStatus.TextAlign = ContentAlignment.MiddleRight;
            lblAiReportStatus.Name = "lblAiReportStatus";
            lblAiReportStatus.TabIndex = 3;

            // rtbAiReport
            rtbAiReport.BackColor = Color.FromArgb(31, 31, 31);
            rtbAiReport.ForeColor = Color.FromArgb(210, 210, 210);
            rtbAiReport.Font = new Font("Times New Roman", 10F);
            rtbAiReport.Dock = DockStyle.Fill;
            rtbAiReport.ReadOnly = true;
            rtbAiReport.BorderStyle = BorderStyle.None;
            rtbAiReport.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbAiReport.Name = "rtbAiReport";
            rtbAiReport.TabIndex = 2;
            rtbAiReport.Text = "";

            // pnlAiReport
            pnlAiReport.BackColor = Color.FromArgb(40, 40, 40);
            pnlAiReport.CornerRadius = 12;
            pnlAiReport.Dock = DockStyle.Bottom;
            pnlAiReport.Height = 46;
            pnlAiReport.Padding = new Padding(16, 10, 16, 12);
            pnlAiReport.Name = "pnlAiReport";
            pnlAiReport.TabIndex = 4;
            pnlAiReport.Controls.Add(rtbAiReport);
            pnlAiReport.Controls.Add(lblAiReportStatus);
            pnlAiReport.Controls.Add(pnlAiReportHeader);

            // AdminFinancialPage
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            Controls.Add(pnlAiReport);
            Controls.Add(pnlCharts);
            Controls.Add(pnlSummaryCards);
            Controls.Add(lblTitle);
            Controls.Add(adminNavBar1);
            MinimumSize = new Size(1200, 750);
            Name = "AdminFinancialPage";
            Text = "Financial Overview";

            adminNavBar1.ResumeLayout(false);
            pnlSummaryCards.ResumeLayout(false);
            pnlCharts.ResumeLayout(false);
            pnlProfitLoss.ResumeLayout(false);
            pnlTransactionVolume.ResumeLayout(false);
            pnlBetStatus.ResumeLayout(false);
            pnlAiReportHeader.ResumeLayout(false);
            pnlAiReport.ResumeLayout(false);
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