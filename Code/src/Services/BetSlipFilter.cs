using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class BetSlipFilter
    {
        public readonly List<BetHistorySlip> BetSlips;
        public BetSlipFilter(List<BetHistorySlip> betSlips  )
        {
            BetSlips = betSlips;
        }

        // sort by date 
        public List<BetHistorySlip> SortByDate(bool ascending)
        {
            if (ascending)
            {
                return BetSlips
                    .OrderBy(b => b.BetDate)
                    .ToList();
            }

            //BetSlips is already in descending order of date
            return BetSlips;
        }

        //filter by status
        public List<BetHistorySlip> FilterByStatus(string status)
        {
            return BetSlips
                .Where(b => b.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
