using BettingSystem.Data_Structures;

namespace BettingSystem.Models
{
    public class Bet
    {
        public int OddID { get; set; }
        public string Selection { get; set; }
        public decimal OddValue { get; set; }
        public int GameID { get; set; }
        public int BetTypeID { get; set; }
        public DateTime Date { get; set; }

        // store node reference 
        public MyLinkedList<Bet>.Node? Node { get; set; }

        public Bet(int oddID, string selection, decimal oddValue, int betTypeID, int gameID, DateTime date)
        {
            OddID = oddID;
            Selection = selection;
            OddValue = oddValue;
            GameID = gameID;
            BetTypeID = betTypeID;
            Date = date;
        }
    }
}

