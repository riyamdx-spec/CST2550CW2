namespace BettingSystem.Models
{
    public class FootballMatchKeyComparer: IComparer<FootballMatch>
    {
        //to compare match objects added in the sorted set
        //sort by game date but use game id for matches with same date
        public int Compare(FootballMatch teamA, FootballMatch teamB)
        {
            if (teamA == null || teamB == null) 
                throw new ArgumentNullException("Cannot compare null values");

            //compare dates
            int dateComparison = teamB.GameDate.CompareTo(teamA.GameDate);

            //if the matches are on the same date
            if (dateComparison == 0)
            {
                return teamA.GameID.CompareTo(teamB.GameID); ;
            }
            return dateComparison; 
        }
    }
}