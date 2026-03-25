using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class MatchManager
    {
        private FootballMatchCollection MatchCollections;
        private Dictionary<int, Team> TeamsById;

        public MatchManager(FootballMatchCollection matchCollection, Dictionary<int, Team> teamDict)
        {
            MatchCollections = matchCollection;
            TeamsById = teamDict;
        }

        //filter matches by leagues 
        public SortedSet<FootballMatch> FilterMatchByLeague(int leagueID)
        {
            //get matches for that league
            if (MatchCollections.MatchesByLeague.TryGetValue(leagueID, out var leagueMatches))
            {
                return leagueMatches;
            }
            //if there are no matches for that league
            return new SortedSet<FootballMatch>();
        }

        //filter matches by teams
        public SortedSet<FootballMatch> FilterMatchByTeams(string searchedTeamName, SortedSet<FootballMatch>? matches=null)
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
                return new SortedSet<FootballMatch>();

            //find matches with the teams
            SortedSet<FootballMatch> correspondingMatches = new SortedSet<FootballMatch>(
                matches
                .Where(m => teamIds.Contains(m.HomeTeamID) || teamIds.Contains(m.AwayTeamID)),
                new FootballMatchKeyComparer());
    
            return correspondingMatches;
        }
    }
}
