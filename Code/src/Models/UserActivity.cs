namespace BettingSystem.Models
{
    public class UserActivity
    {
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public string ActivityType { get; set; }
        public DateTime ActivityDate { get; set; }

        public int RiskScore { get; set; }

        public string? IPAddress { get; set; }

        public int? ReferenceId { get; set; }

        public UserActivity(int activityId, int userId, string activityType, DateTime activityDate, int score,  string? ipAddress, int? refId)
        {
            ActivityId = activityId;
            UserId = userId;
            ActivityType = activityType;
            ActivityDate = activityDate;
            RiskScore = score;
            IPAddress = ipAddress;
            ReferenceId = refId;
        }
    }
}
