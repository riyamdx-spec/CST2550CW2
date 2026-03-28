using BettingSystem.Data;
using BettingSystem.Data_Structures;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class AddNewMatchService
    {
        private MyList<Player> HomeTeamPlayers;
        private MyList<Player> AwayTeamPlayers;
        private readonly DatabaseManager DbManager = new DatabaseManager();
        private FootballMatch NewMatch;
        private SessionManager _currentSession;
        Random Rdm = new Random();

        public AddNewMatchService(FootballMatch newMatch, MyList<Player> homeTeamPlayers, MyList<Player> awayTeamPlayers, SessionManager currentSession)
        {
            NewMatch = newMatch;
            HomeTeamPlayers = homeTeamPlayers;
            AwayTeamPlayers = awayTeamPlayers;
            _currentSession = currentSession;
        }

        //insert to database
        public async Task<(bool valid, string message, GameResult? generatedResult)> AddMatchToDatabase()
        {
            GameResult generatedResult = GenerateGameResults();
            bool valid = await DbManager.AddNewMatchAsync(NewMatch, generatedResult);
            if (valid)
            {
                return (true, "Match Successfully Added", generatedResult);
            }
            return (false, "Failed to Add Match", generatedResult);
        }

        // generate random results for match
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

            //assigning a temporary Game id of 0
            return new GameResult(0, homeScore, awayScore, corners, redCards, yellowCards, firstScorer?.Name, firstScorerId);
        }
    }
}