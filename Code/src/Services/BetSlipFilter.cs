using BettingSystem.Data_Structures;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class BetSlipFilter
    {
        public readonly MyList<BetHistorySlip> BetSlips;
        public BetSlipFilter(MyList<BetHistorySlip> betSlips  )
        {
            //already sorted in descending order of date
            BetSlips = betSlips;
        }

        //sort by date and filter by status
        public MyList<BetHistorySlip> FilterBetSlips(string? status, bool ascending)
        {
            MyList<BetHistorySlip> filteredBetSlips = new MyList<BetHistorySlip>(BetSlips);

            //filter by status
            if (!String.IsNullOrWhiteSpace(status) && status != "All")
            {
                foreach (var slip in BetSlips)
                {
                    if (slip.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                    {
                        filteredBetSlips.Add(slip);
                    }
                }
            }

            //sort in ascending order of date by reversing the list
            if (ascending) 
            {
                filteredBetSlips.Reverse();
            }

            return filteredBetSlips;
        }
    }
}
