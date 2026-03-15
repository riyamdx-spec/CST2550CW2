using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class BetSlipFilter
    {
        public readonly List<BetHistorySlip> BetSlips;
        public BetSlipFilter(List<BetHistorySlip> betSlips  )
        {
            //already sorted in descending order of date
            BetSlips = betSlips;
        }

        //sort by date and filter by status
        public List<BetHistorySlip> FilterBetSlips(string? status, bool ascending)
        {
            List<BetHistorySlip> filteredBetSlips = new List<BetHistorySlip>(BetSlips);

            //filter by status
            if (!String.IsNullOrWhiteSpace(status) && status != "All")
            {
                filteredBetSlips = filteredBetSlips
                                .Where(b => b.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                                .ToList();
            }

            //sort in ascending order of date
            if (ascending) 
            {
                filteredBetSlips = filteredBetSlips
                               .OrderBy(b => b.BetDate)
                               .ToList();
            }

            return filteredBetSlips;
        }
    }
}
