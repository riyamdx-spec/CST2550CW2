using System.Text.RegularExpressions;

namespace BettingSystem.Services
{
    internal class Validation
    {
        private Regex upperCase = new Regex(@"[A-Z]");
        private Regex number = new Regex(@"\d");
        private Regex specialChar = new Regex(@"[-+_!@#$%^&*., ?]");
        private Regex emailFormat = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        //check if text contains at least 1 number (used for password and names)
        public bool CheckNumber(string text)
        {
            return number.IsMatch(text);
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
    }
}