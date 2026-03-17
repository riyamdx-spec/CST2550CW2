using BettingSystem.Data;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class AddNewMatchService
    {
        private List<Player> HomeTeamPlayers;
        private List<Player> AwayTeamPlayers;
        private readonly DatabaseManager DbManager = new DatabaseManager();
        private FootballMatch NewMatch;
        Random Rdm = new Random();

        public AddNewMatchService(FootballMatch newMatch, List<Player> homeTeamPlayers, List<Player> awayTeamPlayers)
        {
            NewMatch = newMatch;
            HomeTeamPlayers = homeTeamPlayers;
            AwayTeamPlayers = awayTeamPlayers;
        }

        public async Task<(bool valid, string message)> AddMatchToDatabase()
        {
            bool valid = await DbManager.AddNewMatchAsync(NewMatch, GenerateGameResults());
            if (valid)
            {
                return (true, "Match Successfully Added");
            }
            return (false, "Failed to Add Match");
        }

        private GameResult GenerateGameResults()
        {
            int homeScore = Rdm.Next(0, 7);
            int awayScore = Rdm.Next(0, 7);
            int corners = Rdm.Next(0, 16);
            int redCards = Rdm.Next(0, 2);
            int yellowCards = Rdm.Next(0, 11);
            int? firstScorerId = null;
            Player? firstScorer = null;

            List<Player> randomScorer = new List<Player>();
            if (homeScore > 0)
            {
                randomScorer.AddRange(HomeTeamPlayers);
            }
            if (awayScore > 0)
            {
                randomScorer.AddRange(AwayTeamPlayers);
            }

            if (randomScorer.Count > 0)
            {
                firstScorer = randomScorer[Rdm.Next(randomScorer.Count)];
                firstScorerId = firstScorer.PlayerId;
            }

            //putting a temporary Game id
            return new GameResult(0, homeScore, awayScore, corners, redCards, yellowCards, firstScorer?.Name, firstScorerId);
        }
    }
}