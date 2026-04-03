using System.Text.RegularExpressions;

namespace BettingSystem.Services
{
    internal class Validation
    {
        private Regex upperCase = new Regex(@"[A-Z]");
        private Regex number = new Regex(@"\d");
        private Regex specialChar = new Regex(@"[-+_!@#$%^&*., ?]");
        private Regex emailFormat = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        private Regex dateFormat = new Regex(@"^\d{2}/\d{2}$"); // for expiry date in deposit money popup

        //check if text contains at least 1 number (used for password and names)
        public bool CheckNumber(string text)
        {
            return number.IsMatch(text);
        }

        //check if name contains between 3 and 50 characters
        public bool CheckNameLength(string name)
        {
            return name.Length >= 3 && name.Length <= 50;
        }

        //check if password contains at least 8 characters
        public bool CheckLength(string password)
        {
            return password.Length >= 8;
        }

        //check if password contains at least 1 upper case character

        public bool CheckUpperCase(string password)
        {
            return upperCase.IsMatch(password);
        }

        //check if password contains at least 1 special character
        public bool CheckSpecialChar(string password)
        {
            return specialChar.IsMatch(password);
        }

        //check password format
        public bool CheckPasswordValidity(string password)
        {
            return CheckLength(password) && CheckUpperCase(password) && CheckNumber(password) && CheckSpecialChar(password);
        }

        //check format of email
        public (bool valid, string? message) CheckEmail(string email)
        {
            if (email.Length > 100)
                return (false, "Email cannot be more than 100 characters");

            if (emailFormat.IsMatch(email))
            {
                return (true, null);
            }
            else
            {
                return (false, "Email is not valid");
            }
        }

        //check if user is older than 18 years old
        public (bool valid, string? message) CheckAge(DateTime dob)
        {
            var currentDay = DateTime.Today;
            int age = currentDay.Year - dob.Year;

            //calculate their age
            if (dob.Date > currentDay.AddYears(-age))
            {
                age--;
            }
            if (age >= 18)
            {
                return (true, null);
            }
            return (false, "You must be at least 18 years old");
        }

        // check amount in deposit
        public (bool valid, string? message) CheckAmount(string amountInput)
        {
            if (!decimal.TryParse(amountInput, out decimal amount))
                return (false, "Amount should be a number.");

            if (amount <= 0)
                return (false, "Amount should be greater than 0.");

            if (decimal.Round(amount, 2) != amount)
                return (false, "Amount cannot have more than 2 decimal places");

            return (true, null);
        }

        // check card number
        public (bool valid, string? message) CheckCardNumber(string cardNumberInput)
        {
            if (!long.TryParse(cardNumberInput, out long cardNumber))
                return (false, "Card number should only contain numbers.");

            if (cardNumberInput.Length != 16)
                return (false, "Card number must be 16 digits");

            return (true, null);
        }

        // check expiry date
        public (bool valid, string? message) CheckExpiryDate(string expiryDateInput)
        {
            if (!dateFormat.IsMatch(expiryDateInput))
                return (false, "Expiry date should be in correct format");

            DateTime expiryDate = DateTime.ParseExact(expiryDateInput, "MM/yy", null);

            var currentDay = DateTime.Today;

            int expiryYear = expiryDate.Year;
            int expiryMonth = expiryDate.Month;

            int currentYear = currentDay.Year;
            int currentMonth = currentDay.Month;

            if (expiryYear < currentYear || expiryYear == currentYear && expiryMonth < currentMonth)
                return (false, "Your card has expired.");

            return (true, null);
        }

        // check CVV
        public (bool valid, string? message) CheckCVV(string cvv)
        {
            if (!int.TryParse(cvv, out int _))
                return (false, "CVV must contain only numbers.");

            int cvvLength = cvv.Length;

            if (cvvLength != 3 && cvvLength != 4)
                return (false, "CVV should be 3 or 4 digits.");

            return (true, null);
        }

        // check scores entered
        public (bool valid, string? message) CheckScores(string homeScore, string awayScore)
        {
            var isHomeNumeric = int.TryParse(homeScore, out int homeInputScore);
            var isAwayNumeric = int.TryParse(awayScore, out int awayInputScore);
           
            if (!isHomeNumeric || !isAwayNumeric)
            {
                return (false, "Scores must be numbers");
            }

            if (homeInputScore < 0 || awayInputScore < 0)
            {
                return (false, "Scores must be greater or equal to 0");
            }
            return (true, null);
        }

        //check new match detail entered by admin
        public (bool valid, string? message) CheckMatchEntries(int homeId, int awayId, DateTime matchDate)
        {
            //check if home and away team are the same
            if (homeId == awayId)
            {
                return (false, "Home and Away Teams cannot be the same");
            }

            // check if match is not starting in less than 5 minutes
            if (matchDate < DateTime.Now.AddMinutes(5))
            {
                return (false, "Please select a start time at least 5 minutes from now");
            }
            return (true, null);

        }
    }
}