namespace BettingSystem.Models
{
    public class HistoryBet
    {
        public string Selection { get; set; }
        public decimal OddValue { get; set; }
        public int BetTypeId { get; set; }
        public string BetTypeName { get; set; }
        public string Result { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime MatchDate { get; set; }
        public string LeagueName { get; set; }
        public int GameId { get; set; }

        public HistoryBet(string selection, decimal oddValue, int betTypeId, string betTypeName, string result, string homeTeam, string awayTeam, DateTime matchDate, string leagueName, int gameId)
        {
            Selection = selection;
            OddValue = oddValue;
            BetTypeId = betTypeId;
            BetTypeName = betTypeName;
            Result = result;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            MatchDate = matchDate;
            LeagueName = leagueName;
            GameId = gameId;
        }
    }
}