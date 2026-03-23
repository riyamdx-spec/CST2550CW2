using BettingSystem.Models;

namespace BettingSystem.Forms.CustomControls
{
    public partial class HistoryBetPanel : UserControl
    {
        private HistoryBet Bet;
        public HistoryBetPanel(HistoryBet bet, string actualResult)
        {
            Bet = bet;
            InitializeComponent();
            DisplayDetails(actualResult);
            betTableLayoutBgPanel.CellPaint += TableLayoutAddBorders;
        }
            
        private void DisplayDetails(string actualResult)
        {
            betMatchDateLbl.Text = Bet.MatchDate.ToString("dd/MM/yyyy") + "-" + Bet.MatchDate.ToString("HH:mm");
            betMatchLeagueLbl.Text = Bet.LeagueName;
            betHomeTeamLbl.Text = Bet.HomeTeam;
            betAwayTeamLbl.Text = Bet.AwayTeam;
            betTypeLbl.Text = $"Bet Type: {Bet.BetTypeName}";
            betSelectionLbl.Text = $"Selection: {Bet.Selection}";
            betOddLbl.Text = $"Odd: {Math.Round(Bet.OddValue, 2)}";
            betResultLbl.Text = "Actual Result: " + actualResult;
            DisplayBetResult();
        }

        //display if the person has make a correct bet
        private void DisplayBetResult()
        {
            betOutcomeLbl.Text = Bet.Result;

            switch (Bet.Result)
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
