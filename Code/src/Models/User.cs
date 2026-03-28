namespace BettingSystem.Models
{
    //represents a user
    public class AppUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public decimal WalletBalance { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }

        public AppUser(int id, string fName, string lName, DateTime DOB, string mail, decimal balance, string userRole, string status  )
        {
            UserID = id;
            FirstName = fName;
            LastName = lName;
            Dob = DOB;
            Email = mail;
            WalletBalance = balance;
            Role = userRole;
            Status = status;
        }
    }
}
