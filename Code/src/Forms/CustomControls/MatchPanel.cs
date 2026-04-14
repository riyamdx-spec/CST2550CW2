using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class MatchPanel : UserControl
    {
        public event Action<MatchDisplayInfo> SeeBetsClicked;
        private MatchDisplayInfo _matchDetails;
        private ImageLoader _imgLoader;

        public MatchPanel(MatchDisplayInfo matchInfo)
        {
            InitializeComponent();
            _matchDetails = matchInfo;
            _imgLoader = new ImageLoader();
            _ = DisplayDetails();
            _ = DisplayLogo();
        }

        //display match details
        private async Task DisplayDetails()
        {
            matchDateLbl.Text = _matchDetails.CurrentMatch.GameDate.ToString("dd/MM/yyyy");
            matchTimeLbl.Text = _matchDetails.CurrentMatch.GameDate.ToString("HH:mm");
            matchLeagueLbl.Text = _matchDetails.LeagueName;
            homeTeamLbl.Text = _matchDetails.HomeTeam.TeamName;
            awayTeamLbl.Text = _matchDetails.AwayTeam.TeamName;
        }

        private async Task DisplayLogo()
        {
            homeTeamImg.Image = await _imgLoader.GetImageAsync(_matchDetails.HomeTeam.LogoPath);
            awayTeamImg.Image = await _imgLoader.GetImageAsync(_matchDetails.AwayTeam.LogoPath);
        }

        //clicking on see bets button raises an event
        private void seeBetsBtn_Click(object sender, EventArgs e)
        {
            SeeBetsClicked?.Invoke(_matchDetails);
        }
    }
}
