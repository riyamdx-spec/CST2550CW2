namespace BettingSystem.Forms.CustomControls
{
    public partial class BetCard : UserControl
    {
        public event Action OnRemove;
        private Label _homeTeamLbl;

        public BetCard()
        {
            InitializeComponent();

            _homeTeamLbl = new Label();
            _homeTeamLbl.Dock = DockStyle.Fill;
            _homeTeamLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            _homeTeamLbl.ForeColor = Color.FromArgb(241, 241, 241);
            _homeTeamLbl.TextAlign = ContentAlignment.MiddleRight;
            _homeTeamLbl.AutoSize = false;
            tableLayoutPanel1.Controls.Add(_homeTeamLbl, 1, 0);

            betInfoPanel.Resize += CenterBetInfo;
            tlpBetInfo.Resize += CenterBetInfo;
            dateTimePanel.Resize += CenterDateTimeLabels;
        }

        public void SetData(string league, string home, string away,
                            string betType, string selection, string odds,
                            DateTime matchDate)
        {
            matchLeagueLbl.Text = league;
            _homeTeamLbl.Text = home;
            awayTeamLbl.Text = away;
            lblBetTypeVal.Text = betType;
            lblSelectionVal.Text = selection;
            lblOddsVal.Text = odds;
            matchDateLbl.Text = matchDate.ToString("dd/MM/yyyy");
            matchTimeLbl.Text = matchDate.ToString("HH:mm");
        }

        private void CenterDateTimeLabels(object sender, EventArgs e)
        {
            int totalHeight = matchDateLbl.Height + matchTimeLbl.Height;
            int startY = (dateTimePanel.Height - totalHeight) / 2;
            matchDateLbl.Location = new Point((dateTimePanel.Width - matchDateLbl.Width) / 2, startY);
            matchTimeLbl.Location = new Point((dateTimePanel.Width - matchTimeLbl.Width) / 2, startY + matchDateLbl.Height);
        }

        private void CenterBetInfo(object sender, EventArgs e)
        {
            tlpBetInfo.Left = (betInfoPanel.Width - tlpBetInfo.Width) / 2;
            tlpBetInfo.Top = (betInfoPanel.Height - tlpBetInfo.Height) / 2;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            OnRemove?.Invoke();
        }


    }
}