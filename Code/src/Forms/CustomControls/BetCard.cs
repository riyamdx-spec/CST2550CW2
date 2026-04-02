namespace BettingSystem.Forms.CustomControls
{
    public partial class BetCard : UserControl
    {
        public event Action OnRemove;

        public BetCard()
        {
            InitializeComponent();
            betTableLayoutBgPanel.CellPaint += BetTableLayoutBgPanel_CellPaint;
        }

        //add borders
        private void BetTableLayoutBgPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
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

        public void SetData(string league, string home, string away,
                            string betType, string selection, string odds,
                            DateTime matchDate)
        {
            matchLeagueLbl.Text = league;
            homeTeamLbl.Text = home;
            awayTeamLbl.Text = away;
            lblBetTypeVal.Text = betType;
            lblSelectionVal.Text = selection;
            lblOddsVal.Text = odds;
            matchDateLbl.Text = matchDate.ToString("dd/MM/yyyy");
            matchTimeLbl.Text = matchDate.ToString("HH:mm");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            OnRemove?.Invoke();
        }
    }
}