namespace BettingSystem.Models
{
    public class FinancialSummary
    {
        public decimal TotalRevenue { get; set; }
        public int TotalActiveUsers { get; set; }
        public int TotalBetsPlaced { get; set; }
        public decimal TotalDeposits { get; set; }
        public decimal TotalWithdrawals { get; set; }
    }

    public class MonthlyProfitLoss
    {
        public string Month { get; set; }
        public decimal Revenue { get; set; }
        public decimal Payouts { get; set; }
    }

    public class MonthlyTransactionVolume
    {
        public string Month { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
    }

    public class BetStatusCount
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }
}
