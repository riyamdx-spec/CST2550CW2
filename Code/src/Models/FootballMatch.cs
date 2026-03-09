namespace BettingSystem.Models
{
    public class FootballMatch // to represent a match and store its details
    {
        public int GameID {  get; set; }
        public int LeagueID { get; set; }
        public int HomeTeamID { get; set; }
        public int AwayTeamID { get; set; }
        public DateTime GameDate { get; set; }
        public string GameStatus { get; set; }

        public FootballMatch(int gameID, int leagueID, int homeTeamID, int awayTeamID, DateTime gameDate, string gameStatus)
        {
            GameID = gameID;
            LeagueID = leagueID;
            HomeTeamID = homeTeamID;
            AwayTeamID = awayTeamID;
            GameDate = gameDate;
            GameStatus = gameStatus;
        }
    }
}