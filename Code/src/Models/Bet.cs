namespace BettingSystem.Models
{
    public class Bet
    {
        public int OddID { get; set; }
        public string Selection { get; set; }
        public decimal OddValue { get; set; }
        public int GameID { get; set; }
        public int BetTypeID { get; set; }

        // store node reference 
        public LinkedListNode<Bet>? Node { get; set; }

        public Bet(int oddID, string selection, decimal oddValue, int betTypeID, int gameID)
        {
            OddID = oddID;
            Selection = selection;
            OddValue = oddValue;
            GameID = gameID;
            BetTypeID = betTypeID;
        }
    }
}

