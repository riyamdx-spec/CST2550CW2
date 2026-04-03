using BettingSystem.Data_Structures;
using BettingSystem.Models;

namespace BettingSystem.Forms.CustomControls
{
    public partial class HistoryBetPanel : UserControl
    {
        private HistoryBet _bet;
        public HistoryBetPanel(HistoryBet bet, string actualResult, MyList<Player>? players)
        {
            _bet = bet;
            InitializeComponent();
            DisplayDetails(actualResult, players);
            betTableLayoutBgPanel.CellPaint += TableLayoutAddBorders;
        }
            
        private void DisplayDetails(string actualResult, MyList<Player>? players)
        {
            betMatchDateLbl.Text = _bet.MatchDate.ToString("dd/MM/yyyy") + " - " + _bet.MatchDate.ToString("HH:mm");
            betMatchLeagueLbl.Text = _bet.LeagueName;
            betHomeTeamLbl.Text = _bet.HomeTeam;
            betAwayTeamLbl.Text = _bet.AwayTeam;
            betTypeLbl.Text = $"Bet Type: {_bet.BetTypeName}";
            betSelectionLbl.Text = $"Selection: {(_bet.BetTypeId == 6 ? DisplaySelectedPlayer(players) : _bet.Selection)}";
            betOddLbl.Text = $"Odd: {Math.Round(_bet.OddValue, 2)}";
            betResultLbl.Text = "Actual Result: " + actualResult;
            DisplayBetResult();
        }

        private string DisplaySelectedPlayer(MyList<Player> players)
        {
            string selectionText;
           
            if (int.TryParse(_bet.Selection, out int id))
            {
                selectionText = players.FirstOrDefault(p => p.PlayerId == id)?.Name ?? "Unknown";
            }
            else
            {
                selectionText = "Unknown";
            }
            return selectionText;
        }

        //display if the person has make a correct bet
        private void DisplayBetResult()
        {
            betOutcomeLbl.Text = _bet.Result;

            switch (_bet.Result)
            {
                case "Won":
                    betOutcomeLbl.BackColor = Color.FromArgb(93, 185, 64);
                    break;
                case "Lost":
                    betOutcomeLbl.BackColor = Color.Firebrick;
                    break;
                case "Pending":
                    betOutcomeLbl.BackColor = Color.Gray;
                    break;
            }
        }

        //add borders to table layout panel
        private void TableLayoutAddBorders(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column == 1 && e.Row == 0)
            {
                var rectangle = e.CellBounds;
                rectangle.Inflate(-1, -1);

                ControlPaint.DrawBorder(e.Graphics, rectangle,
                    Color.FromArgb(36, 36, 36), 2, ButtonBorderStyle.Solid,
                    Color.FromArgb(36, 36, 36), 0, ButtonBorderStyle.Solid,
                    Color.FromArgb(36, 36, 36), 2, ButtonBorderStyle.Solid,
                    Color.FromArgb(36, 36, 36), 0, ButtonBorderStyle.Solid
                );
            }
        }
    }
}
