using BettingSystem.Data_Structures;
using BettingSystem.Forms.CustomControls;
using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class HistoryBetsPopup : Form
    {
        private MyList<HistoryBet> _bets;
        private MyDictionary<int, GameResult> _gameResults;
        public HistoryBetsPopup(MyList<HistoryBet> bets, MyDictionary<int, GameResult> gameResults, MyDictionary<int, MyList<Player>> players)
        {
            _bets = bets;
            _gameResults = gameResults;

            InitializeComponent();
            DisplayBets(players);
        }

        private void DisplayBets(MyDictionary<int, MyList<Player>> players)
        {
            betsFlowLayoutPanel.Hide();
            betsFlowLayoutPanel.Controls.Clear();
            string actualResult;
            foreach (HistoryBet bet in _bets)
            {
                actualResult = FindActualResult(bet.GameId, bet.BetTypeId);
                HistoryBetPanel betPanel = new HistoryBetPanel(bet, actualResult, players);
                betPanel.Margin = new Padding(0, 10, 0, 0);
                betsFlowLayoutPanel.Controls.Add(betPanel);
            }
            betsFlowLayoutPanel.Show();
        }

        //find actual result of match to display it
        private string FindActualResult(int gameId, int betTypeId)
        {
            GameResult matchResult = _gameResults[gameId];

            switch (betTypeId)
            {
                case 1:
                    if (matchResult.HomeTeamScore > matchResult.AwayTeamScore)
                        return "Home Win";
                       
                    if (matchResult.HomeTeamScore == matchResult.AwayTeamScore)
                        return "Draw";

                    return "Away Win";

                case 2:
                    if (matchResult.HomeTeamScore > matchResult.AwayTeamScore)
                        return "1";

                    if (matchResult.HomeTeamScore == matchResult.AwayTeamScore)
                        return "X";

                    return "2";
                case 3:
                    return $"{matchResult.HomeTeamScore} - {matchResult.AwayTeamScore}";
                case 4:
                    if ((matchResult.HomeTeamScore + matchResult.AwayTeamScore) > 2.5)
                        return "Over 2.5";
                    return "Under 2.5";

                case 5: 
                    if (matchResult.HomeTeamScore > 0 && matchResult.AwayTeamScore > 0)
                        return "Yes";

                    return "No";

                case 6:
                    return (matchResult.FirstScorerName is null) ? "None" :matchResult.FirstScorerName;
                    
                case 7:
                    return matchResult.TotalCorners.ToString();

                case 8:
                    return matchResult.YellowCards.ToString();
                    
                case 9:
                    return matchResult.RedCards.ToString();
            }
            return "-";
        }
    }
}