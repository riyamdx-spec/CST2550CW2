namespace BettingSystem.Models
{
	public class Odd
	{
		public int OddID { get; set; }
		public int GameID { get; set; }
		public int BetTypeID { get; set; }
		public string Selection { get; set; }
		public decimal OddValue { get; set; }

		public Odd(int oddID, int gameID, int betTypeID, string selection, decimal oddValue)
		{
			OddID = oddID;
			GameID = gameID;
			BetTypeID = betTypeID;
			Selection = selection;
			OddValue = oddValue;
		}
	}
}