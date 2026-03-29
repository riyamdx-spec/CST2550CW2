using BettingSystem.Data_Structures;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class MatchManager
    {
        private FootballMatchCollection MatchCollections;
        private MyDictionary<int, Team> TeamsById;

        public MatchManager(FootballMatchCollection matchCollection, MyDictionary<int, Team> teamDict)
        {
            MatchCollections = matchCollection;
            TeamsById = teamDict;
        }

        //filter matches by leagues 
        public MyList<FootballMatch> FilterMatchByLeague(int leagueID)
        {
            //get matches for that league
            if (MatchCollections.MatchesByLeague.TryGetValue(leagueID, out var leagueMatches))
            {
                return leagueMatches;
            }
            //if there are no matches for that league
            return new MyList<FootballMatch>();
        }

        //filter matches by teams
        public MyList<FootballMatch> FilterMatchByTeams(string searchedTeamName, MyList<FootballMatch>? matches=null)
        {
            if (matches == null)
                matches = MatchCollections.AllMatches;

            //get ids of teams with name containing the searched term
            HashSet<int> teamIds = TeamsById
                .Where(t => t.Value.TeamName.Contains(searchedTeamName, StringComparison.InvariantCultureIgnoreCase))
                .Select(t => t.Key)
                .ToHashSet();

            //check if no corresponding teams were found
            if (teamIds.Count == 0) 
                return new MyList<FootballMatch>();

            //find matches with the teams
            MyList<FootballMatch> correspondingMatches = new MyList<FootballMatch>(
                matches
                .Where(m => teamIds.Contains(m.HomeTeamID) || teamIds.Contains(m.AwayTeamID)));
    
            return correspondingMatches;
        }
    }
}
