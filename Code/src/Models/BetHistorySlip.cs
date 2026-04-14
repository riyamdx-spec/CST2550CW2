using BettingSystem.Data_Structures;

namespace BettingSystem.Models
{
    public class BetHistorySlip
    {
        public int SlipID { get; set; }
        public int UserID { get; set; }
        public DateTime BetDate { get; set; }
        public decimal Stake { get; set; }
        public decimal TotalOdds { get; set; }
        public decimal Payout { get; set; }
        public string Status { get; set; }
        public bool Claimed { get; set; }
        public MyList<HistoryBet> Bets { get; set; }

        public BetHistorySlip(int slipID, int userID, DateTime betDate, decimal stake, decimal totalOdds, decimal payout, string status, bool claimed)
        {
            SlipID = slipID;
            UserID = userID;
            BetDate = betDate;
            Stake = stake;
            TotalOdds = totalOdds;
            Payout = payout;
            Status = status;
            Claimed = claimed;
            Bets = new MyList<HistoryBet>();
        }
    }
}