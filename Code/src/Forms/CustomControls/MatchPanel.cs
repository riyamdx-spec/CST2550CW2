using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class MatchPanel : UserControl
    {
        public event Action<MatchDisplayInfo> SeeBetsClicked;
        private MatchDisplayInfo MatchDetails;
        private ImageLoader ImgLoader;

        public MatchPanel(MatchDisplayInfo matchInfo)
        {
            InitializeComponent();
            MatchDetails = matchInfo;
            ImgLoader = new ImageLoader();
            DisplayDetails();
            _ = DisplayLogo();
        }

        //display match details
        private async Task DisplayDetails()
        {
            matchDateLbl.Text = MatchDetails.CurrentMatch.GameDate.ToString("dd/MM/yyyy");
            matchTimeLbl.Text = MatchDetails.CurrentMatch.GameDate.ToString("HH:mm");
            matchLeagueLbl.Text = MatchDetails.LeagueName;
            homeTeamLbl.Text = MatchDetails.HomeTeam.TeamName;
            awayTeamLbl.Text = MatchDetails.AwayTeam.TeamName;
        }

        private async Task DisplayLogo()
        {
            homeTeamImg.Image = await ImgLoader.GetImageAsync(MatchDetails.HomeTeam.LogoPath);
            awayTeamImg.Image = await ImgLoader.GetImageAsync(MatchDetails.AwayTeam.LogoPath);
        }

        //clicking on see bets button raises an event
        private void seeBetsBtn_Click(object sender, EventArgs e)
        {
            SeeBetsClicked?.Invoke(MatchDetails);
        }
    }
}
