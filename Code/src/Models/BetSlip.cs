namespace BettingSystem.Models
{
    public class BetSlip
    {
        public int UserID { get; set; }
        public LinkedList<Bet> Bets { get; set; }
        public decimal Stake { get; set; }
        public decimal TotalOdds { get; protected set; }
        public BetSlip(int userID)
        {
            UserID = userID;
            Bets = new LinkedList<Bet>();
            TotalOdds = 1;
        }

        // add bet or update
        public string AddBet(Bet bet)
        {
            // check if bet exists
            foreach (Bet existingBet in Bets)
            {
                if (existingBet.GameID == bet.GameID && existingBet.BetTypeID == bet.BetTypeID)
                {
                    // update bet if exists
                    existingBet.OddID = bet.OddID;
                    existingBet.Selection = bet.Selection;
                    existingBet.OddValue = bet.OddValue;
                    CalculateTotalOdds();
                    return "Bet updated";
                }
            }

            // add new bet at head
            LinkedListNode<Bet> node = Bets.AddFirst(bet);
            // store node reference 
            bet.Node = node;
            CalculateTotalOdds();
            return "Bet added";
        }

        // remove bet with node reference
        public (bool success, string message) RemoveBet(Bet bet)
        {
            if (bet.Node == null)
                return (false, "Bet not found in slip");

            Bets.Remove(bet.Node);
            bet.Node = null;
            CalculateTotalOdds();
            return (true, "Bet removed");
        }

        private void CalculateTotalOdds()
        {
            TotalOdds = 1;
            foreach (Bet bet in Bets)
            {
                TotalOdds *= bet.OddValue;
            }
        }

        // calculate payout if bet is success
        public decimal CalculatePayout()
        {
            return Math.Round(Stake * TotalOdds, 2);
        }

        // remove bets using game id
        public bool RemoveBetsByGameIds(List<int> gameIds)
        {
            var currentNode = Bets.First;
            int removedBets = 0;
            int initialBetsNum = Bets.Count;

            while (currentNode != null)
            {
                if (gameIds.Contains(currentNode.Value.GameID))
                {
                    Bets.Remove(currentNode);
                    currentNode.Value.Node = null;
                    removedBets++;
                }
                currentNode = currentNode.Next;
            }
            if (removedBets > 0)
                CalculateTotalOdds();

            return initialBetsNum != Bets.Count;
        }
    }
}