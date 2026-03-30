using BettingSystem.Data;
using BettingSystem.Models;
using BettingSystem.Services;
using ScottPlot;
using ScottPlot.WinForms;

namespace BettingSystem.Forms
{
    public partial class AdminFinancialPage : BaseForm
    {
        private AppUser CurrentAdmin;
        private SessionManager CurrentSession;
        private readonly DatabaseManager DBManager = new DatabaseManager();

        // colours
        private readonly ScottPlot.Color SpGreen = new ScottPlot.Color(93, 185, 64);
        private readonly ScottPlot.Color SpRed = new ScottPlot.Color(220, 53, 53);
        private readonly ScottPlot.Color SpOrange = new ScottPlot.Color(255, 165, 0);
        private readonly ScottPlot.Color SpBlue = new ScottPlot.Color(55, 138, 221);
        private readonly ScottPlot.Color SpBg = new ScottPlot.Color(31, 31, 31);
        private readonly ScottPlot.Color SpCard = new ScottPlot.Color(40, 40, 40);
        private readonly ScottPlot.Color SpGrid = new ScottPlot.Color(50, 50, 50);
        private readonly ScottPlot.Color SpLabel = new ScottPlot.Color(180, 180, 180);
        private readonly ScottPlot.Color SpText = new ScottPlot.Color(241, 241, 241);

        public AdminFinancialPage(AppUser admin, SessionManager session)
        {
            InitializeComponent();
            CurrentAdmin = admin;
            CurrentSession = session;

            adminNavBar1.SetAdmin(CurrentAdmin);
            adminNavBar1.UsersPageClicked += async (s, e) => await CurrentSession.OpenAdminViewUsersPage(this);
            adminNavBar1.SearchMatchesPageClicked += async (s, e) => await CurrentSession.OpenAdminMatchPage(this);
            adminNavBar1.AddMatchesPageClicked += (s, e) => CurrentSession.OpenAdminAddMatchPage(this);
            adminNavBar1.FinancialPageClicked += async (s, e) => await CurrentSession.OpenAdminFinancialPage(this);
            adminNavBar1.LogoutClicked += (s, e) => CurrentSession.LogOut(this);

            this.Load += AdminFinancialPage_Load;
        }

        private async void AdminFinancialPage_Load(object sender, EventArgs e)
        {
            CaptureBaseLayout();
            PositionSummaryCards();
            SetChartPanelWidths();
            await LoadAllData();
        }

        public async Task ReloadPage()
        {
            await LoadAllData();
        }

        private async Task LoadAllData()
        {
            var summary = await DBManager.FetchFinancialSummaryAsync();
            var profitLoss = await DBManager.FetchMonthlyProfitLossAsync();
            var transactionVolume = await DBManager.FetchMonthlyTransactionVolumeAsync();
            var betStatus = await DBManager.FetchBetStatusBreakdownAsync();

            UpdateSummaryCards(summary);
            BuildProfitLossChart(profitLoss);
            BuildTransactionVolumeChart(transactionVolume);
            BuildBetStatusChart(betStatus);
        }

        private void SetChartPanelWidths()
        {
            void Resize()
            {
                int available = pnlCharts.ClientSize.Width - pnlCharts.Padding.Horizontal;
                int w = available / 3;
                pnlProfitLoss.Width = w;
                pnlTransactionVolume.Width = w;
            }
            Resize();
            pnlCharts.Resize += (s, e) => Resize();
        }

        private void PositionSummaryCards()
        {
            void Position()
            {
                var cards = new[] { cardRevenue, cardActiveUsers, cardBetsPlaced, cardDeposits, cardWithdrawals };
                int totalWidth = pnlSummaryCards.ClientSize.Width - pnlSummaryCards.Padding.Horizontal;
                int gap = 15;
                int cardWidth = (totalWidth - (cards.Length - 1) * gap) / cards.Length;
                int cardHeight = 70;
                int y = (pnlSummaryCards.ClientSize.Height - pnlSummaryCards.Padding.Vertical - cardHeight) / 2;
                for (int i = 0; i < cards.Length; i++)
                {
                    cards[i].Size = new Size(cardWidth, cardHeight);
                    cards[i].Location = new Point(
                        pnlSummaryCards.Padding.Left + i * (cardWidth + gap),
                        pnlSummaryCards.Padding.Top + y
                    );
                }
            }
            Position();
            pnlSummaryCards.Resize += (s, e) => Position();
        }

        private void UpdateSummaryCards(FinancialSummary data)
        {
            lblRevenueVal.Text = $"${data.TotalRevenue:N2}";
            lblActiveUsersVal.Text = data.TotalActiveUsers.ToString("N0");
            lblBetsPlacedVal.Text = data.TotalBetsPlaced.ToString("N0");
            lblDepositsVal.Text = $"${data.TotalDeposits:N2}";
            lblWithdrawalsVal.Text = $"${data.TotalWithdrawals:N2}";
        }

        private void ApplyDarkTheme(FormsPlot plot)
        {
            plot.Plot.FigureBackground.Color = SpBg;
            plot.Plot.DataBackground.Color = SpCard;
            plot.Plot.Axes.Color(SpLabel);
            plot.Plot.Grid.MajorLineColor = SpGrid;
            plot.Plot.Grid.MajorLineWidth = 0.5f;
            plot.Plot.Legend.BackgroundColor = SpCard;
            plot.Plot.Legend.FontColor = SpLabel;
            plot.Plot.Legend.OutlineColor = SpGrid;
            plot.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
        }

        private void BuildProfitLossChart(List<MonthlyProfitLoss> data)
        {
            chartProfitLoss.Plot.Clear();
            ApplyDarkTheme(chartProfitLoss);

            if (!data.Any())
            {
                chartProfitLoss.Plot.Add.Text("No data available", 0, 0);
                chartProfitLoss.Refresh();
                return;
            }

            double[] xs = Enumerable.Range(0, data.Count).Select(i => (double)i).ToArray();
            double[] revenue = data.Select(d => (double)d.Revenue).ToArray();
            double[] payouts = data.Select(d => (double)d.Payouts).ToArray();
            string[] labels = data.Select(d => d.Month).ToArray();

            // revenue line
            var revLine = chartProfitLoss.Plot.Add.Scatter(xs, revenue);
            revLine.Color = SpGreen;
            revLine.LineWidth = 2.5f;
            revLine.MarkerSize = 7;
            revLine.LegendText = "Revenue";

            // payouts line
            var payLine = chartProfitLoss.Plot.Add.Scatter(xs, payouts);
            payLine.Color = SpRed;
            payLine.LineWidth = 2.5f;
            payLine.MarkerSize = 7;
            payLine.LegendText = "Payouts";

            // fill between lines
            var fill = chartProfitLoss.Plot.Add.FillY(xs, payouts, revenue);
            fill.FillColor = new ScottPlot.Color(93, 185, 64, 30);
            fill.LineColor = ScottPlot.Colors.Transparent;

            // x axis labels
            chartProfitLoss.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(
                xs, labels
            );
            chartProfitLoss.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
            chartProfitLoss.Plot.Axes.Bottom.TickLabelStyle.FontSize = 9;
            chartProfitLoss.Plot.Axes.Left.TickLabelStyle.FontSize = 9;

            chartProfitLoss.Plot.ShowLegend(Alignment.LowerRight);
            chartProfitLoss.Refresh();
        }

        private void BuildTransactionVolumeChart(List<MonthlyTransactionVolume> data)
        {
            chartTransactionVolume.Plot.Clear();
            ApplyDarkTheme(chartTransactionVolume);

            if (!data.Any())
            {
                chartTransactionVolume.Plot.Add.Text("No data available", 0, 0);
                chartTransactionVolume.Refresh();
                return;
            }

            var months = data.Select(d => d.Month).Distinct().ToList();
            var types = new[] { "deposit", "withdrawal", "bet", "payout" };
            var colors = new[] { SpGreen, SpOrange, SpBlue, SpRed };
            var names = new[] { "Deposits", "Withdrawals", "Bets", "Payouts" };

            double barWidth = 0.6;
            double groupWidth = barWidth / types.Length;

            for (int t = 0; t < types.Length; t++)
            {
                double[] positions = new double[months.Count];
                double[] values = new double[months.Count];

                for (int m = 0; m < months.Count; m++)
                {
                    var entry = data.FirstOrDefault(d => d.Month == months[m] && d.Type == types[t]);
                    positions[m] = m + t * groupWidth - barWidth / 2 + groupWidth / 2;
                    values[m] = entry != null ? (double)entry.Amount : 0;
                }

                var bars = chartTransactionVolume.Plot.Add.Bars(positions, values);
                bars.Color = colors[t];
                bars.LegendText = names[t];
                foreach (var bar in bars.Bars)
                    bar.Size = groupWidth * 0.85;
            }

            // x axis labels centered 
            double[] tickPositions = Enumerable.Range(0, months.Count).Select(i => (double)i).ToArray();
            chartTransactionVolume.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(
                tickPositions, months.ToArray()
            );
            chartTransactionVolume.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
            chartTransactionVolume.Plot.Axes.Bottom.TickLabelStyle.FontSize = 9;
            chartTransactionVolume.Plot.Axes.Left.TickLabelStyle.FontSize = 9;

            chartTransactionVolume.Plot.ShowLegend(Alignment.UpperRight);
            chartTransactionVolume.Refresh();
        }

        private void BuildBetStatusChart(List<BetStatusCount> data)
        {
            chartBetStatus.Plot.Clear();
            ApplyDarkTheme(chartBetStatus);

            if (!data.Any())
            {
                chartBetStatus.Plot.Add.Text("No data available", 0, 0);
                chartBetStatus.Refresh();
                return;
            }

            var statusColors = new Dictionary<string, ScottPlot.Color>
            {
                { "Won", SpGreen },
                { "Lost", SpRed },
                { "Pending", SpOrange }
            };

            double[] values = data.Select(d => (double)d.Count).ToArray();
            string[] labels = data.Select(d => d.Status).ToArray();
            ScottPlot.Color[] colors = data.Select(d =>
                statusColors.TryGetValue(d.Status, out var c) ? c : SpLabel
            ).ToArray();

            var pie = chartBetStatus.Plot.Add.Pie(values);
            pie.Radius = 1.2;

            pie.LineColor = SpBg;
            pie.LineWidth = 2;

            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].FillColor = colors[i];
                pie.Slices[i].Label = $"{labels[i]}\n{values[i]:N0}";
                pie.Slices[i].LabelFontColor = SpText;
                pie.Slices[i].LabelFontSize = 10;
                pie.Slices[i].LegendText = $"{labels[i]} ({values[i]:N0})";
            }

            pie.DonutFraction = 0.55;
            pie.SliceLabelDistance = 1.35;

            chartBetStatus.Plot.Axes.SetLimits(-1.5, 1.5, -1.5, 1.5);

            // total in center
            int total = data.Sum(d => d.Count);
            var centerText = chartBetStatus.Plot.Add.Text($"{total:N0}\ntotal", 0, 0);
            centerText.LabelFontSize = 13;
            centerText.LabelFontColor = SpText;
            centerText.LabelBold = true;
            centerText.Alignment = Alignment.MiddleCenter;

            chartBetStatus.Plot.Axes.Frameless();
            chartBetStatus.Plot.HideGrid();
            chartBetStatus.Plot.ShowLegend(Alignment.LowerRight);
            chartBetStatus.Refresh();
        }

        protected override void AfterScaling()
        {
            PositionSummaryCards();
            SetChartPanelWidths();
        }
    }
}