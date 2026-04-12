using BettingSystem.Data_Structures;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class BetSlipFilter
    {
        public BetSlipFilter() { }

        //sort by date and filter by status
        public MyList<BetHistorySlip> FilterBetSlips(MyList<BetHistorySlip> betSlips, string? status, bool ascending)
        {
            MyList<BetHistorySlip> filteredBetSlips = new MyList<BetHistorySlip>();

            //filter by status
            if (!String.IsNullOrWhiteSpace(status) && status != "All")
            {
                foreach (var slip in betSlips)
                {
                    if (slip.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                    {
                        filteredBetSlips.Add(slip);
                    }
                }
            }
            else
            {
                foreach(var slip in betSlips)
                {
                    filteredBetSlips.Add(slip);
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
