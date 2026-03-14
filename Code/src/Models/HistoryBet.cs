namespace BettingSystem.Models
{
    public class HistoryBet
    {
        public string Selection { get; set; }
        public decimal OddValue { get; set; }
        public string BetTypeName { get; set; }
        public string Result { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime MatchDate { get; set; }
        public string LeagueName { get; set; }

        public HistoryBet(string selection, decimal oddValue, string betTypeName, string result, string homeTeam, string awayTeam, DateTime matchDate, string leagueName)
        {
            Selection = selection;
            OddValue = oddValue;
            BetTypeName = betTypeName;
            Result = result;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            MatchDate = matchDate;
            LeagueName = leagueName;
        }
    }
}