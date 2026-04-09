using BettingSystem.Data;
using BettingSystem.Data_Structures;
using BettingSystem.Models;
using BettingSystem.Services;
using Google.GenAI;
using ScottPlot;
using ScottPlot.WinForms;
using System.Configuration;

namespace BettingSystem.Forms
{
    public partial class AdminFinancialPage : BaseForm
    {
        private AppUser _currentAdmin;
        private SessionManager _currentSession;
        private readonly DatabaseManager _dbManager = new DatabaseManager();

        // state for AI panel
        private bool _aiPanelExpanded = false;
        private const int _aiPanelCollapsedHeight = 46;
        private const int _aiPanelExpandedHeight = 250;

        // state for dragging AI panel
        private bool _isDragging = false;
        private int _dragStartY;
        private int _dragStartHeight;

        // colours
        private readonly ScottPlot.Color _spGreen = new ScottPlot.Color(93, 185, 64);
        private readonly ScottPlot.Color _spRed = new ScottPlot.Color(220, 53, 53);
        private readonly ScottPlot.Color _spOrange = new ScottPlot.Color(255, 165, 0);
        private readonly ScottPlot.Color _spBlue = new ScottPlot.Color(55, 138, 221);
        private readonly ScottPlot.Color _spBg = new ScottPlot.Color(31, 31, 31);
        private readonly ScottPlot.Color _spCard = new ScottPlot.Color(40, 40, 40);
        private readonly ScottPlot.Color _spGrid = new ScottPlot.Color(50, 50, 50);
        private readonly ScottPlot.Color _spLabel = new ScottPlot.Color(180, 180, 180);
        private readonly ScottPlot.Color _spText = new ScottPlot.Color(241, 241, 241);

        private static readonly HttpClient HttpClient = new HttpClient();
        private FinancialSummary _lastSummary;
        private MyList<MonthlyProfitLoss> _lastProfitLoss;
        private MyList<MonthlyTransactionVolume> _lastTransactionVolume;
        private MyList<BetStatusCount> _lastBetStatus;

        public AdminFinancialPage(AppUser admin, SessionManager session)
        {
            InitializeComponent();
            _currentAdmin = admin;
            _currentSession = session;

            adminNavBar1.SetAdmin(_currentAdmin);
            adminNavBar1.UsersPageClicked += async (s, e) => _currentSession.OpenAdminViewUsersPage(this);
            adminNavBar1.SearchMatchesPageClicked += async (s, e) => _currentSession.OpenAdminMatchPage(this);
            adminNavBar1.AddMatchesPageClicked += (s, e) => _currentSession.OpenAdminAddMatchPage(this);
            adminNavBar1.FinancialPageClicked += async (s, e) => _currentSession.OpenAdminFinancialPage(this);
            adminNavBar1.LogoutClicked += (s, e) => _currentSession.LogOut(this);

            this.Load += AdminFinancialPage_Load;
            this.FormClosing += AdminFinancialPage_FormClosing;
        }

        private void AdminFinancialPage_Load(object sender, EventArgs e)
        {
            CaptureBaseLayout();
            PositionSummaryCards();
            SetChartPanelWidths();
            PositionGenerateButton();
            pnlAiReport.Resize += (s, ev) => PositionGenerateButton();
            LoadAllData();

            // for dragging
            pnlAiReport.MouseDown += AiPanel_MouseDown;
            pnlAiReport.MouseMove += AiPanel_MouseMove;
            pnlAiReport.MouseUp += AiPanel_MouseUp;
            pnlAiReportHeader.MouseDown += AiPanel_MouseDown;
            pnlAiReportHeader.MouseMove += AiPanel_MouseMove;
            pnlAiReportHeader.MouseUp += AiPanel_MouseUp;

            lblAiReportStatus.Visible = false;

        }

        public void OnShow()
        {
            adminNavBar1.SetAdmin(_currentAdmin);
            LoadAllData();
            PositionSummaryCards();
            SetChartPanelWidths();
        }

        private void LoadAllData()
        {
            _lastSummary = _currentSession.FinancialSummary;
            _lastProfitLoss = _currentSession.ProfitLoss;
            _lastTransactionVolume = _currentSession.TransactionVolume;
            _lastBetStatus = _currentSession.BetStatus;

            UpdateSummaryCards(_lastSummary);
            BuildProfitLossChart(_lastProfitLoss);
            BuildTransactionVolumeChart(_lastTransactionVolume);
            BuildBetStatusChart(_lastBetStatus);
        }

        private void AdminFinancialPage_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_currentSession.IsLoggingOut && !_currentSession.IsExiting)
            {
                logOutPopup closingPopup = new logOutPopup(false, true);

                DialogResult result = closingPopup.ShowDialog();

                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }

                else
                {
                    _currentSession.IsExiting = true;
                    Application.Exit();
                }
            }
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
            plot.Plot.FigureBackground.Color = _spBg;
            plot.Plot.DataBackground.Color = _spCard;
            plot.Plot.Axes.Color(_spLabel);
            plot.Plot.Grid.MajorLineColor = _spGrid;
            plot.Plot.Grid.MajorLineWidth = 0.5f;
            plot.Plot.Legend.BackgroundColor = _spCard;
            plot.Plot.Legend.FontColor = _spLabel;
            plot.Plot.Legend.OutlineColor = _spGrid;
            plot.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
        }

        private void BuildProfitLossChart(MyList<MonthlyProfitLoss> data)
        {
            var sorted = new MyList<MonthlyProfitLoss>(
                data.OrderBy(d => DateTime.ParseExact(d.Month, "MMM yy", null))
             );

            data = sorted;

            chartProfitLoss.Plot.Clear();
            ApplyDarkTheme(chartProfitLoss);

            if (data.Count == 0)
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
            revLine.Color = _spGreen;
            revLine.LineWidth = 2.5f;
            revLine.MarkerSize = 7;
            revLine.LegendText = "Revenue";

            // payouts line
            var payLine = chartProfitLoss.Plot.Add.Scatter(xs, payouts);
            payLine.Color = _spRed;
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
            chartProfitLoss.Plot.Axes.Bottom.TickLabelStyle.Rotation = 0;
            chartProfitLoss.Plot.Axes.Bottom.TickLabelStyle.FontSize = 9;
            chartProfitLoss.Plot.Axes.Left.TickLabelStyle.FontSize = 9;

            chartProfitLoss.Plot.ShowLegend(Alignment.LowerRight);

            chartProfitLoss.Plot.Axes.AutoScale();

            chartProfitLoss.Refresh();
        }

        private void BuildTransactionVolumeChart(MyList<MonthlyTransactionVolume> data)
        {
            chartTransactionVolume.Plot.Clear();
            ApplyDarkTheme(chartTransactionVolume);

            if (!data.Any())
            {
                chartTransactionVolume.Plot.Add.Text("No data available", 0, 0);
                chartTransactionVolume.Refresh();
                return;
            }

            var months = data.Select(d => d.Month).Distinct().OrderBy(m => DateTime.ParseExact(m, "MMM yy", null)).ToList();
            var types = new[] { "deposit", "withdrawal", "bet", "payout" };
            var colors = new[] { _spGreen, _spOrange, _spBlue, _spRed };
            var names = new[] { "Deposits", "Withdrawals", "Bets", "Payouts" };

            double barWidth = 0.8;
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
            chartTransactionVolume.Plot.Axes.Bottom.TickLabelStyle.Rotation = 0;
            chartTransactionVolume.Plot.Axes.Bottom.TickLabelStyle.FontSize = 9;
            chartTransactionVolume.Plot.Axes.Left.TickLabelStyle.FontSize = 9;

            chartTransactionVolume.Plot.ShowLegend(Alignment.UpperRight);
            chartTransactionVolume.Plot.Axes.AutoScale();

            var limits = chartTransactionVolume.Plot.Axes.GetLimits();
            chartTransactionVolume.Plot.Axes.SetLimitsY(0, limits.Top);

            chartTransactionVolume.Refresh();
        }

        private void BuildBetStatusChart(MyList<BetStatusCount> data)
        {
            chartBetStatus.Plot.Clear();
            ApplyDarkTheme(chartBetStatus);

            if (!data.Any())
            {
                chartBetStatus.Plot.Add.Text("No data available", 0, 0);
                chartBetStatus.Refresh();
                return;
            }

            var statusColors = new MyDictionary<string, ScottPlot.Color>
            {
                { "Won", _spGreen },
                { "Lost", _spRed },
                { "Pending", _spOrange }
            };

            double[] values = data.Select(d => (double)d.Count).ToArray();
            string[] labels = data.Select(d => d.Status).ToArray();
            ScottPlot.Color[] colors = data.Select(d =>
                statusColors.TryGetValue(d.Status, out var c) ? c : _spLabel
            ).ToArray();

            var pie = chartBetStatus.Plot.Add.Pie(values);
            pie.Radius = 1.2;

            pie.LineColor = _spBg;
            pie.LineWidth = 2;

            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].FillColor = colors[i];
                pie.Slices[i].Label = $"{labels[i]}\n{values[i]:N0}";
                pie.Slices[i].LabelFontColor = _spText;
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
            centerText.LabelFontColor = _spText;
            centerText.LabelBold = true;
            centerText.Alignment = Alignment.MiddleCenter;

            chartBetStatus.Plot.Axes.Frameless();
            chartBetStatus.Plot.HideGrid();
            chartBetStatus.Plot.ShowLegend(Alignment.LowerRight);
            chartBetStatus.Refresh();
        }

        private void PositionGenerateButton()
        {
            btnGenerateReport.Location = new Point(
                pnlAiReport.ClientSize.Width - pnlAiReport.Padding.Right - btnGenerateReport.Width,
                pnlAiReport.Padding.Top
            );
        }

        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (!_aiPanelExpanded)
            {
                // expand panel
                _aiPanelExpanded = true;
                pnlAiReport.Height = _aiPanelExpandedHeight;
                btnGenerateReport.Text = "Generating...";
                btnGenerateReport.Enabled = false;
                rtbAiReport.Text = "";
                lblAiReportStatus.Visible = true;
                lblAiReportStatus.Text = "Analysing financial data...";

                try
                {
                    string report = await GenerateFinancialReport();
                    FormatAiReport(report);
                    lblAiReportStatus.Text = $"Report generated · {DateTime.Now:dd/MM/yyyy HH:mm}";
                    btnGenerateReport.Text = "Hide Report";
                }
                catch (Exception ex)
                {
                    rtbAiReport.Text = "Failed to generate report. Please try again.";
                    lblAiReportStatus.Text = $"Error: {ex.Message}";
                    btnGenerateReport.Text = "Generate Report";
                    _aiPanelExpanded = false;
                    pnlAiReport.Height = _aiPanelCollapsedHeight;
                }
                finally
                {
                    btnGenerateReport.Enabled = true;
                }
            }
            else
            {
                // collapse panel
                _aiPanelExpanded = false;
                pnlAiReport.Height = _aiPanelCollapsedHeight;
                btnGenerateReport.Text = "Generate Report";
                lblAiReportStatus.Visible = false;
            }
        }

        private async Task<string> GenerateFinancialReport()
        {
            string apiKey = ConfigurationManager.AppSettings["GOOGLE_API_KEY"];
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new Exception("OpenAI API key not set in app.config.");

        var client = new Client(apiKey: apiKey);

        // build context from current data
        var profitLossSummary = string.Join(", ",
            _lastProfitLoss.Select(p => $"{p.Month}: Revenue ${p.Revenue:F0} / Payouts ${p.Payouts:F0}")
        );

        var betStatusSummary = string.Join(", ",
            _lastBetStatus.Select(b => $"{b.Status}: {b.Count}")
        );

        int totalBets = _lastBetStatus.Sum(b => b.Count);
        double winRate = totalBets > 0
            ? (_lastBetStatus.FirstOrDefault(b => b.Status == "Won")?.Count ?? 0) * 100.0 / totalBets
            : 0;

            string prompt = $"""
                                You are a financial analyst preparing an executive briefing for the board of 
                                Pitch Bet, a football betting platform.

                                Using the financial data below, write a polished executive summary. Structure it with 
                                these four clearly labelled sections:

                                PERFORMANCE OVERVIEW
                                A high-level summary of the platform's financial health and key metrics.

                                REVENUE & PROFITABILITY
                                Analysis of revenue trends, payout ratios, and profit margins across the reported months.

                                USER ACTIVITY & ENGAGEMENT
                                Insights on active users, betting volume, and what the bet outcome distribution reveals.

                                OUTLOOK & RECOMMENDATIONS
                                Key risks, opportunities, and strategic recommendations for the next quarter.

                                Write in a formal, executive tone. Each section should be 2-3 sentences. 
                                Do not use bullet points, markdown, asterisks, or any special formatting characters.
                                Use plain text only with the section headers in capitals as shown above.

                                Financial Summary:
                                - Total Revenue: ${_lastSummary.TotalRevenue:N2}
                                - Total Active Users: {_lastSummary.TotalActiveUsers:N0}
                                - Total Bets Placed: {_lastSummary.TotalBetsPlaced:N0}
                                - Total Deposits: ${_lastSummary.TotalDeposits:N2}
                                - Total Withdrawals: ${_lastSummary.TotalWithdrawals:N2}

                                Monthly Profit & Loss:
                                {profitLossSummary}

                                Bet Outcomes:
                                {betStatusSummary}
                                Platform win rate: {winRate:F1}%
                                """;
            
            var response = await client.Models.GenerateContentAsync(
            model: "gemini-3-flash-preview", contents: prompt);

            return response.Candidates[0].Content.Parts[0].Text;
        }


        private void AiPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_aiPanelExpanded) return;
            if (e.Y > 8) return; // only drag from top edge 
            _isDragging = true;
            _dragStartY = System.Windows.Forms.Cursor.Position.Y;
            _dragStartHeight = pnlAiReport.Height;
            Cursor = Cursors.SizeNS;

            chartProfitLoss.Visible = false;
            chartTransactionVolume.Visible = false;
            chartBetStatus.Visible = false;
        }

        private void AiPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_aiPanelExpanded)
            {
                Cursor = Cursors.Default;
                return;
            }

            // show resize Cursor when near top edge
            if (e.Y <= 8)
                Cursor = Cursors.SizeNS;
            else
                Cursor = Cursors.Default;

            if (!_isDragging) return;

            int delta = _dragStartY - System.Windows.Forms.Cursor.Position.Y;
            int newHeight = Math.Max(_aiPanelCollapsedHeight + 50, _dragStartHeight + delta);
            pnlAiReport.Height = newHeight;
        }

        private void AiPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                // restore charts after drag
                chartProfitLoss.Visible = true;
                chartTransactionVolume.Visible = true;
                chartBetStatus.Visible = true;
            }
            _isDragging = false;
            Cursor = Cursors.Default;
        }

        protected override void AfterScaling()
        {
            PositionSummaryCards();
            SetChartPanelWidths();
            
        }

        private void FormatAiReport(string report)
        {
            rtbAiReport.Clear();

            var sectionHeaders = new[]
            {
                "PERFORMANCE OVERVIEW",
                "REVENUE & PROFITABILITY",
                "USER ACTIVITY & ENGAGEMENT",
                "OUTLOOK & RECOMMENDATIONS"
            };

            string[] lines = report.Split('\n');

            foreach (string line in lines)
            {
                string trimmed = line.Trim();
                bool isHeader = sectionHeaders.Any(h => trimmed.StartsWith(h));

                if (isHeader)
                {
                    // add spacing before header 
                    if (rtbAiReport.TextLength > 0)
                    {
                        rtbAiReport.SelectionStart = rtbAiReport.TextLength;
                        rtbAiReport.SelectionLength = 0;
                        rtbAiReport.SelectionColor = System.Drawing.Color.FromArgb(210, 210, 210);
                        rtbAiReport.AppendText(System.Environment.NewLine);
                    }

                    // header styling
                    rtbAiReport.SelectionStart = rtbAiReport.TextLength;
                    rtbAiReport.SelectionLength = 0;
                    rtbAiReport.SelectionColor = System.Drawing.Color.FromArgb(93, 185, 64);
                    rtbAiReport.SelectionFont = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
                    rtbAiReport.AppendText(trimmed + System.Environment.NewLine);
                }
                else if (!string.IsNullOrWhiteSpace(trimmed))
                {
                    // body text styling
                    rtbAiReport.SelectionStart = rtbAiReport.TextLength;
                    rtbAiReport.SelectionLength = 0;
                    rtbAiReport.SelectionColor = System.Drawing.Color.FromArgb(210, 210, 210);
                    rtbAiReport.SelectionFont = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
                    rtbAiReport.AppendText(trimmed + System.Environment.NewLine);
                }
            }
        }
    }
}