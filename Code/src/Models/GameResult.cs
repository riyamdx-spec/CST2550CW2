namespace BettingSystem.Models
{
    public class GameResult
    {
        public int GameId { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public int TotalCorners { get; set; }
        public int RedCards { get; set; }
        public int YellowCards { get; set; }

        public int? FirstScorerId { get; set; }
        public string? FirstScorerName { get; set; }

        public GameResult(int gameId, int homeTeamScore, int awayTeamScore, int totalCorners, int redCards, int yellowCards, string? firstScorerName, int? firstScorerId)
        {
            GameId = gameId;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
            TotalCorners = totalCorners;
            RedCards = redCards;
            YellowCards = yellowCards;
            FirstScorerName = firstScorerName;
            FirstScorerId = firstScorerId;
        }
    }
}