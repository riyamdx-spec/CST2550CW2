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

        private List<BetHistorySlip> ReverseList(List<BetHistorySlip> filteredSlips)
        {
            int maxIndex = filteredSlips.Count -1;
            int startIndex = 0;
            BetHistorySlip temp;

            while (startIndex < maxIndex)
            {
                temp = filteredSlips[startIndex];
                filteredSlips[startIndex] = filteredSlips[maxIndex];
                filteredSlips[maxIndex] = temp;
                startIndex++;
                maxIndex--;
            }
            return filteredSlips;
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

            //sort in ascending order of date by reversing the list
            if (ascending) 
            {
                return ReverseList(filteredBetSlips);
            }

            return filteredBetSlips;
        }
    }
}
