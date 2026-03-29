using BettingSystem.Models;

namespace BettingSystem.Forms
{
    public partial class MatchResultPopup : Form
    {

        public MatchResultPopup(GameResult matchResult, string homeTeamName, string awayTeamName)
        {
            InitializeComponent();
            DisplayResults(matchResult, homeTeamName, awayTeamName );
        }

        private void DisplayResults(GameResult matchResult, string homeTeamName, string awayTeamName)
        {
            homeTeamLbl.Text = homeTeamName;
            awayTeamLbl.Text = awayTeamName;
            scoreLbl.Text = $"{matchResult.HomeTeamScore} - {matchResult.AwayTeamScore}";
            scorerNameLbl.Text = string.IsNullOrEmpty(matchResult.FirstScorerName)? "-" : matchResult.FirstScorerName;
            yellowCardsNum.Text = matchResult.YellowCards.ToString();
            redCardsNum.Text = matchResult.RedCards.ToString();
            cornersNum.Text = matchResult.TotalCorners.ToString();
        }
    }
}
