using BettingSystem.Services;

namespace BettingSystemsTests;

/// <summary>
/// Test class for Validation service
/// Tests all public methods of the Validation class
/// </summary>
[TestClass]
public sealed class ValidationTests
{
    // Private field to hold instance of Validation class
    // We'll initialize it before each test
    private Validation _validation = null!;

    /// <summary>
    /// Runs before EACH test method
    /// Sets up fresh test data
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        _validation = new Validation();
    }

    // ==================== CHECKNUMBER TESTS ====================
    
    /// <summary>
    /// Test: CheckNumber should return TRUE when string contains digits
    /// </summary>
    [TestMethod]
    public void CheckNumber_WithDigits_ReturnsTrue()
    {
        // ARRANGE - Set up test data
        string textWithNumber = "Password123";

        // ACT - Call the method being tested
        bool result = _validation.CheckNumber(textWithNumber);

        // ASSERT - Verify the result is what we expect
        Assert.IsTrue(result, "CheckNumber should return true when text contains digits");
    }

    /// <summary>
    /// Test: CheckNumber should return FALSE when string has no digits
    /// </summary>
    [TestMethod]
    public void CheckNumber_WithoutDigits_ReturnsFalse()
    {
        // ARRANGE
        string textWithoutNumber = "PasswordOnly";

        // ACT
        bool result = _validation.CheckNumber(textWithoutNumber);

        // ASSERT
        Assert.IsFalse(result, "CheckNumber should return false when text has no digits");
    }

    // ==================== CHECKLENGTH TESTS ====================

    /// <summary>
    /// Test: CheckLength should return TRUE for exactly 8 characters
    /// </summary>
    [TestMethod]
    public void CheckLength_With8Characters_ReturnsTrue()
    {
        // ARRANGE
        string password = "Pass1234";  // Exactly 8 characters

        // ACT
        bool result = _validation.CheckLength(password);

        // ASSERT
        Assert.IsTrue(result, "CheckLength should return true for 8+ character passwords");
    }

    /// <summary>
    /// Test: CheckLength should return TRUE for more than 8 characters
    /// </summary>
    [TestMethod]
    public void CheckLength_With15Characters_ReturnsTrue()
    {
        // ARRANGE
        string password = "Password123456";  // More than 8 characters

        // ACT
        bool result = _validation.CheckLength(password);

        // ASSERT
        Assert.IsTrue(result);
    }

    /// <summary>
    /// Test: CheckLength should return FALSE for less than 8 characters
    /// </summary>
    [TestMethod]
    public void CheckLength_With7Characters_ReturnsFalse()
    {
        // ARRANGE
        string password = "Pass123";  // Only 7 characters

        // ACT
        bool result = _validation.CheckLength(password);

        // ASSERT
        Assert.IsFalse(result, "CheckLength should return false for passwords less than 8 characters");
    }

    /// <summary>
    /// Test: CheckLength should return FALSE for empty string
    /// </summary>
    [TestMethod]
    public void CheckLength_WithEmptyString_ReturnsFalse()
    {
        // ARRANGE
        string password = "";

        // ACT
        bool result = _validation.CheckLength(password);

        // ASSERT
        Assert.IsFalse(result);
    }

    // ==================== CHECKUPPERCASE TESTS ====================

    /// <summary>
    /// Test: CheckUpperCase should return TRUE when string contains uppercase letters
    /// </summary>
    [TestMethod]
    public void CheckUpperCase_WithUpperCaseLetters_ReturnsTrue()
    {
        // ARRANGE
        string password = "Password123";

        // ACT
        bool result = _validation.CheckUpperCase(password);

        // ASSERT
        Assert.IsTrue(result, "CheckUpperCase should return true when password contains uppercase letters");
    }

    /// <summary>
    /// Test: CheckUpperCase should return FALSE when string is all lowercase
    /// </summary>
    [TestMethod]
    public void CheckUpperCase_AllLowercase_ReturnsFalse()
    {
        // ARRANGE
        string password = "password123";

        // ACT
        bool result = _validation.CheckUpperCase(password);

        // ASSERT
        Assert.IsFalse(result, "CheckUpperCase should return false when password has no uppercase letters");
    }

    // ==================== CHECKSPECIALCHAR TESTS ====================

    /// <summary>
    /// Test: CheckSpecialChar should return TRUE when string contains special characters
    /// Valid special chars: -+_!@#$%^&*., ?
    /// </summary>
    [TestMethod]
    public void CheckSpecialChar_WithExclamationMark_ReturnsTrue()
    {
        // ARRANGE
        string password = "Password!";

        // ACT
        bool result = _validation.CheckSpecialChar(password);

        // ASSERT
        Assert.IsTrue(result);
    }

    /// <summary>
    /// Test: CheckSpecialChar with @ symbol
    /// </summary>
    [TestMethod]
    public void CheckSpecialChar_WithAtSymbol_ReturnsTrue()
    {
        // ARRANGE
        string password = "Pass@word";

        // ACT
        bool result = _validation.CheckSpecialChar(password);

        // ASSERT
        Assert.IsTrue(result);
    }

    /// <summary>
    /// Test: CheckSpecialChar with dash character
    /// </summary>
    [TestMethod]
    public void CheckSpecialChar_WithDash_ReturnsTrue()
    {
        // ARRANGE
        string password = "Pass-word";

        // ACT
        bool result = _validation.CheckSpecialChar(password);

        // ASSERT
        Assert.IsTrue(result);
    }

    /// <summary>
    /// Test: CheckSpecialChar should return FALSE when no special characters
    /// </summary>
    [TestMethod]
    public void CheckSpecialChar_NoSpecialCharacters_ReturnsFalse()
    {
        // ARRANGE
        string password = "Password123";

        // ACT
        bool result = _validation.CheckSpecialChar(password);

        // ASSERT
        Assert.IsFalse(result, "CheckSpecialChar should return false when password has no special characters");
    }

    // ==================== CHECKPASSWORDVALIDITY TESTS ====================

    /// <summary>
    /// Test: CheckPasswordValidity should return TRUE for a strong password
    /// Password must have: 8+ chars, uppercase, number, special char
    /// </summary>
    [TestMethod]
    public void CheckPasswordValidity_StrongPassword_ReturnsTrue()
    {
        // ARRANGE
        string validPassword = "StrongPass123!";

        // ACT
        bool result = _validation.CheckPasswordValidity(validPassword);

        // ASSERT
        Assert.IsTrue(result, "Strong password should pass validation");
    }

    /// <summary>
    /// Test: CheckPasswordValidity should return FALSE if missing numbers
    /// </summary>
    [TestMethod]
    public void CheckPasswordValidity_NoNumbers_ReturnsFalse()
    {
        // ARRANGE
        string password = "StrongPass!";  // Missing numbers

        // ACT
        bool result = _validation.CheckPasswordValidity(password);

        // ASSERT
        Assert.IsFalse(result, "Password without numbers should fail validation");
    }

    /// <summary>
    /// Test: CheckPasswordValidity should return FALSE if missing uppercase
    /// </summary>
    [TestMethod]
    public void CheckPasswordValidity_NoUppercase_ReturnsFalse()
    {
        // ARRANGE
        string password = "strongpass123!";  // All lowercase

        // ACT
        bool result = _validation.CheckPasswordValidity(password);

        // ASSERT
        Assert.IsFalse(result, "Password without uppercase should fail validation");
    }

    /// <summary>
    /// Test: CheckPasswordValidity should return FALSE if missing special character
    /// </summary>
    [TestMethod]
    public void CheckPasswordValidity_NoSpecialChar_ReturnsFalse()
    {
        // ARRANGE
        string password = "StrongPass123";  // Missing special character

        // ACT
        bool result = _validation.CheckPasswordValidity(password);

        // ASSERT
        Assert.IsFalse(result, "Password without special character should fail validation");
    }

    /// <summary>
    /// Test: CheckPasswordValidity should return FALSE if too short
    /// </summary>
    [TestMethod]
    public void CheckPasswordValidity_TooShort_ReturnsFalse()
    {
        // ARRANGE
        string password = "Sh0!";  // Only 4 characters

        // ACT
        bool result = _validation.CheckPasswordValidity(password);

        // ASSERT
        Assert.IsFalse(result, "Password less than 8 characters should fail validation");
    }

    // ==================== CHECKEMAIL TESTS ====================

    /// <summary>
    /// Test: CheckEmail should return (true, null) for valid email format
    /// </summary>
    [TestMethod]
    public void CheckEmail_ValidEmailFormat_ReturnsTrue()
    {
        // ARRANGE
        string validEmail = "user@example.com";

        // ACT
        var (valid, message) = _validation.CheckEmail(validEmail);

        // ASSERT
        Assert.IsTrue(valid, "Valid email should pass validation");
        Assert.IsNull(message, "Valid email should have no error message");
    }

    /// <summary>
    /// Test: CheckEmail with another valid format
    /// </summary>
    [TestMethod]
    public void CheckEmail_AnotherValidFormat_ReturnsTrue()
    {
        // ARRANGE
        string validEmail = "john.doe@company.co.uk";

        // ACT
        var (valid, message) = _validation.CheckEmail(validEmail);

        // ASSERT
        Assert.IsTrue(valid);
        Assert.IsNull(message);
    }

    /// <summary>
    /// Test: CheckEmail should return (false, message) when missing @ symbol
    /// </summary>
    [TestMethod]
    public void CheckEmail_NoAtSymbol_ReturnsFalse()
    {
        // ARRANGE
        string invalidEmail = "userexample.com";

        // ACT
        var (valid, message) = _validation.CheckEmail(invalidEmail);

        // ASSERT
        Assert.IsFalse(valid, "Email without @ symbol should fail");
        Assert.IsNotNull(message, "Should return error message");
    }

    /// <summary>
    /// Test: CheckEmail should return false for email with spaces
    /// </summary>
    [TestMethod]
    public void CheckEmail_WithSpaces_ReturnsFalse()
    {
        // ARRANGE
        string invalidEmail = "user @example.com";

        // ACT
        var (valid, message) = _validation.CheckEmail(invalidEmail);

        // ASSERT
        Assert.IsFalse(valid);
        Assert.IsNotNull(message);
    }

    /// <summary>
    /// Test: CheckEmail should return false for incomplete email
    /// </summary>
    [TestMethod]
    public void CheckEmail_NoDomain_ReturnsFalse()
    {
        // ARRANGE
        string invalidEmail = "user@";

        // ACT
        var (valid, message) = _validation.CheckEmail(invalidEmail);

        // ASSERT
        Assert.IsFalse(valid);
        Assert.IsNotNull(message);
    }

    // ==================== CHECKAGE TESTS ====================
    
    /// <summary>
    /// Test: Check if user is younger than 18 return false
    /// </summary>
    [TestMethod]
    public void CheckAge_TooLow_ReturnsFalse()
    {
        // ARRANGE
        DateTime invaliddob = DateTime.Today.AddYears(-17);  // 17 years old
        
        // ACT
        var (valid, message) = _validation.CheckAge(invaliddob);
        
        // ASSERT
        Assert.IsFalse(valid, " Age should fail validation");
        Assert.IsNotNull(message, " Should return error message");
    }
    
    /// <summary>
    /// Test: Check if user is 18 return true
    /// </summary>
    [TestMethod]
    public void CheckAge_is18_ReturnsTrue()
    {
        // ARRANGE
        DateTime validdob = DateTime.Today.AddYears(-18);  // 18 years old
        
        // ACT
        var (valid, message) = _validation.CheckAge(validdob);
        
        // ASSERT
        Assert.IsTrue(valid);
        Assert.IsNull(message);
    }
    
    /// <summary>
    /// Test: Check if user is older than 18 return true
    /// </summary>
    [TestMethod]
    public void CheckAge_isOlder_ReturnsTrue()
    {
        // ARRANGE
        DateTime validdob = DateTime.Today.AddYears(-19);  // 19 years old
        
        // ACT
        var (valid, message) = _validation.CheckAge(validdob);
        
        // ASSERT
        Assert.IsTrue(valid);
        Assert.IsNull(message);
    }

    // ==================== CHECKAMOUNT TESTS ====================
    /// <summary>
    /// Test: Check if amount is not a number return false
    /// </summary>
    [TestMethod]
    public void CheckAmount_NotANumber_ReturnsFalse()
    {
        // ARRANGE
        string invalidAmount = "thousand"; 
        
        // ACT
        var (valid, message) = _validation.CheckAmount(invalidAmount);
        
        //ASSERT
        Assert.IsFalse(valid, "Amount should fail deposit");
        Assert.IsNotNull(message, "Should return error message");
        
    }
    

    /// <summary>
    /// Test: Check if amount is less than or equal to 0 return false
    /// </summary>
    [TestMethod]
    public void CheckAmount_LessThanOrEqualToZero_ReturnsFalse()
    {
        // ARRANGE
        string invalidAmount = "-100";

        // ACT
        var (valid, message) = _validation.CheckAmount(invalidAmount);
        
        // ASSERT
        Assert.IsFalse(valid, "Amount should fail deposit");
        Assert.IsNotNull(message, "Should return error message");
    }

    /// <summary>
    /// Test: Check if amount has greater than 2 decimal places return false
    /// </summary>
    [TestMethod]
    public void CheckAmount_MoreThanTwoDecimalPlaces_ReturnsFalse()
    {
        // ARRANGE
        string invalidAmount = "100.123";

        // ACT
        var (valid, message) = _validation.CheckAmount(invalidAmount);
        
        // ASSERT
        Assert.IsFalse(valid, "Amount should fail deposit");
        Assert.IsNotNull(message, "Should return error message");
    }
    
    /// <summary>
    /// Test: CheckAmount should return false when amount is exactly zero
    /// </summary>
    [TestMethod]
    public void CheckAmount_ExactlyZero_ReturnsFalse()
    {
        // ARRANGE
        string invalidAmount = "0";

        // ACT
        var (valid, message) = _validation.CheckAmount(invalidAmount);

        // ASSERT
        Assert.IsFalse(valid, "Amount of exactly 0 should fail validation");
        Assert.IsNotNull(message, "Should return error message");
    }

    /// <summary>
    /// Test: CheckAmount should return true for an integer amount (no decimal places)
    /// </summary>
    [TestMethod]
    public void CheckAmount_WholeNumber_ReturnsTrue()
    {
        // ARRANGE
        string validAmount = "50";

        // ACT
        var (valid, message) = _validation.CheckAmount(validAmount);

        // ASSERT
        Assert.IsTrue(valid, "Whole number amount should pass validation");
        Assert.IsNull(message);
    }
    
    /// <summary>
    /// Test: Check if amount is greater than 0 return true
    /// </summary>
    [TestMethod]
    public void CheckAmount_GreaterThanZero_ReturnsTrue()
    {
        // ARRANGE
        string validAmount = "100.50";

        // ACT
        var (valid, message) = _validation.CheckAmount(validAmount);

        // ASSERT
        Assert.IsTrue(valid);
        Assert.IsNull(message);
    }
    
    // ==================== CHECKCARDNUMBER TESTS ====================
    
    /// <summary>
    /// Test: Check if card number has letters return false
    /// </summary>
    [TestMethod]
    public void CheckCardNumber_HasLetters_ReturnsFalse()
    {
        // ARRANGE
        string invalidCardNumber = "190083847653253a";
        
        // ACT
        var (valid, message) = _validation.CheckCardNumber(invalidCardNumber);
        
        //ASSERT
        Assert.IsFalse(valid, "Card number should fail validation");
        Assert.IsNotNull(message, "Should return error message");
    }

    /// <summary>
    /// Test: Check if card number is less than 16 digits return false
    /// </summary>
    [TestMethod]
    public void CheckCardNumber_TooShort_ReturnsFalse()
    {
        // ARRANGE
        string invalidCardNumber = "123456789012345"; // 15 digits

        // ACT
        var (valid, message) = _validation.CheckCardNumber(invalidCardNumber);

        // ASSERT
        Assert.IsFalse(valid, "Card number with fewer than 16 digits should fail validation");
        Assert.IsNotNull(message, "Should return error message");
    }

    /// <summary>
    /// Test: Check if card number is more than 16 digits return false
    /// </summary>
    [TestMethod]
    public void CheckCardNumber_TooLong_ReturnsFalse()
    {
        // ARRANGE
        string invalidCardNumber = "12345678901234567"; // 17 digits

        // ACT
        var (valid, message) = _validation.CheckCardNumber(invalidCardNumber);

        // ASSERT
        Assert.IsFalse(valid, "Card number with more than 16 digits should fail validation");
        Assert.IsNotNull(message, "Should return error message");
    }

    /// <summary>
    /// Test: Check if valid 16-digit card number returns true
    /// </summary>
    [TestMethod]
    public void CheckCardNumber_Valid16Digits_ReturnsTrue()
    {
        // ARRANGE
        string validCardNumber = "1234567890123456"; // exactly 16 digits

        // ACT
        var (valid, message) = _validation.CheckCardNumber(validCardNumber);

        // ASSERT
        Assert.IsTrue(valid, "16-digit numeric card number should pass validation");
        Assert.IsNull(message, "Valid card number should have no error message");
    }

    // ==================== CHECKNAMELENGTH TESTS ====================

    /// <summary>
    /// Test: CheckNameLength should return TRUE for a name of exactly 3 characters
    /// </summary>
    [TestMethod]
    public void CheckNameLength_ExactlyThreeChars_ReturnsTrue()
    {
        // ARRANGE
        string name = "Ali";

        // ACT
        bool result = _validation.CheckNameLength(name);

        // ASSERT
        Assert.IsTrue(result, "Name of exactly 3 characters should pass validation");
    }

    /// <summary>
    /// Test: CheckNameLength should return TRUE for a name of exactly 50 characters
    /// </summary>
    [TestMethod]
    public void CheckNameLength_ExactlyFiftyChars_ReturnsTrue()
    {
        // ARRANGE
        string name = new string('A', 50);

        // ACT
        bool result = _validation.CheckNameLength(name);

        // ASSERT
        Assert.IsTrue(result, "Name of exactly 50 characters should pass validation");
    }

    /// <summary>
    /// Test: CheckNameLength should return FALSE for a name shorter than 3 characters
    /// </summary>
    [TestMethod]
    public void CheckNameLength_TooShort_ReturnsFalse()
    {
        // ARRANGE
        string name = "Al"; // only 2 characters

        // ACT
        bool result = _validation.CheckNameLength(name);

        // ASSERT
        Assert.IsFalse(result, "Name shorter than 3 characters should fail validation");
    }

    /// <summary>
    /// Test: CheckNameLength should return FALSE for a name longer than 50 characters
    /// </summary>
    [TestMethod]
    public void CheckNameLength_TooLong_ReturnsFalse()
    {
        // ARRANGE
        string name = new string('A', 51); // 51 characters

        // ACT
        bool result = _validation.CheckNameLength(name);

        // ASSERT
        Assert.IsFalse(result, "Name longer than 50 characters should fail validation");
    }

    // ==================== CHECKEXPIRYDATE TESTS ====================

    /// <summary>
    /// Test: CheckExpiryDate should return true for a future expiry date
    /// </summary>
    [TestMethod]
    public void CheckExpiryDate_FutureDate_ReturnsTrue()
    {
        // ARRANGE – expiry two years from now
        string futureExpiry = DateTime.Today.AddYears(2).ToString("MM/yy");

        // ACT
        var (valid, message) = _validation.CheckExpiryDate(futureExpiry);

        // ASSERT
        Assert.IsTrue(valid, "A future expiry date should pass validation");
        Assert.IsNull(message, "No error message expected for a valid expiry date");
    }

    /// <summary>
    /// Test: CheckExpiryDate should return false for an expired card
    /// </summary>
    [TestMethod]
    public void CheckExpiryDate_ExpiredDate_ReturnsFalse()
    {
        // ARRANGE – expiry one year in the past
        string expiredExpiry = DateTime.Today.AddYears(-1).ToString("MM/yy");

        // ACT
        var (valid, message) = _validation.CheckExpiryDate(expiredExpiry);

        // ASSERT
        Assert.IsFalse(valid, "An expired date should fail validation");
        Assert.IsNotNull(message, "Should return error message for expired card");
    }

    /// <summary>
    /// Test: CheckExpiryDate should return false for wrong format
    /// </summary>
    [TestMethod]
    public void CheckExpiryDate_WrongFormat_ReturnsFalse()
    {
        // ARRANGE
        string badFormat = "2027-12"; // wrong separator

        // ACT
        var (valid, message) = _validation.CheckExpiryDate(badFormat);

        // ASSERT
        Assert.IsFalse(valid, "Wrongly formatted expiry date should fail validation");
        Assert.IsNotNull(message, "Should return error message for incorrect format");
    }

    /// <summary>
    /// Test: CheckExpiryDate with same month/year as today should return true (not yet expired)
    /// </summary>
    [TestMethod]
    public void CheckExpiryDate_CurrentMonth_ReturnsTrue()
    {
        // ARRANGE
        string currentMonthExpiry = DateTime.Today.ToString("MM/yy");

        // ACT
        var (valid, message) = _validation.CheckExpiryDate(currentMonthExpiry);

        // ASSERT
        Assert.IsTrue(valid, "A card expiring this month should still be valid");
        Assert.IsNull(message);
    }

    // ==================== CHECKCVV TESTS ====================

    /// <summary>
    /// Test: CheckCVV should return true for a valid 3-digit CVV
    /// </summary>
    [TestMethod]
    public void CheckCVV_ThreeDigits_ReturnsTrue()
    {
        // ARRANGE
        string cvv = "123";

        // ACT
        var (valid, message) = _validation.CheckCVV(cvv);

        // ASSERT
        Assert.IsTrue(valid, "3-digit CVV should pass validation");
        Assert.IsNull(message);
    }

    /// <summary>
    /// Test: CheckCVV should return true for a valid 4-digit CVV (e.g. Amex)
    /// </summary>
    [TestMethod]
    public void CheckCVV_FourDigits_ReturnsTrue()
    {
        // ARRANGE
        string cvv = "1234";

        // ACT
        var (valid, message) = _validation.CheckCVV(cvv);

        // ASSERT
        Assert.IsTrue(valid, "4-digit CVV should pass validation");
        Assert.IsNull(message);
    }

    /// <summary>
    /// Test: CheckCVV should return false when CVV contains letters
    /// </summary>
    [TestMethod]
    public void CheckCVV_ContainsLetters_ReturnsFalse()
    {
        // ARRANGE
        string cvv = "12a";

        // ACT
        var (valid, message) = _validation.CheckCVV(cvv);

        // ASSERT
        Assert.IsFalse(valid, "CVV with letters should fail validation");
        Assert.IsNotNull(message, "Should return error message");
    }

    /// <summary>
    /// Test: CheckCVV should return false when CVV is only 2 digits
    /// </summary>
    [TestMethod]
    public void CheckCVV_TwoDigits_ReturnsFalse()
    {
        // ARRANGE
        string cvv = "12";

        // ACT
        var (valid, message) = _validation.CheckCVV(cvv);

        // ASSERT
        Assert.IsFalse(valid, "2-digit CVV should fail validation");
        Assert.IsNotNull(message, "Should return error message");
    }

    /// <summary>
    /// Test: CheckCVV should return false when CVV is 5 digits
    /// </summary>
    [TestMethod]
    public void CheckCVV_FiveDigits_ReturnsFalse()
    {
        // ARRANGE
        string cvv = "12345";

        // ACT
        var (valid, message) = _validation.CheckCVV(cvv);

        // ASSERT
        Assert.IsFalse(valid, "5-digit CVV should fail validation");
        Assert.IsNotNull(message, "Should return error message");
    }

    // ==================== CHECKSCORES TESTS ====================

    /// <summary>
    /// Test: CheckScores should return true for valid numeric scores
    /// </summary>
    [TestMethod]
    public void CheckScores_ValidScores_ReturnsTrue()
    {
        // ARRANGE
        string homeScore = "2";
        string awayScore = "1";

        // ACT
        var (valid, message) = _validation.CheckScores(homeScore, awayScore);

        // ASSERT
        Assert.IsTrue(valid, "Valid numeric scores should pass validation");
        Assert.IsNull(message);
    }

    /// <summary>
    /// Test: CheckScores should return true for a 0-0 draw
    /// </summary>
    [TestMethod]
    public void CheckScores_ZeroZero_ReturnsTrue()
    {
        // ARRANGE
        string homeScore = "0";
        string awayScore = "0";

        // ACT
        var (valid, message) = _validation.CheckScores(homeScore, awayScore);

        // ASSERT
        Assert.IsTrue(valid, "0-0 score should pass validation");
        Assert.IsNull(message);
    }

    /// <summary>
    /// Test: CheckScores should return false when home score is not a number
    /// </summary>
    [TestMethod]
    public void CheckScores_HomeScoreNotNumeric_ReturnsFalse()
    {
        // ARRANGE
        string homeScore = "two";
        string awayScore = "1";

        // ACT
        var (valid, message) = _validation.CheckScores(homeScore, awayScore);

        // ASSERT
        Assert.IsFalse(valid, "Non-numeric home score should fail validation");
        Assert.IsNotNull(message, "Should return error message");
    }

    /// <summary>
    /// Test: CheckScores should return false when away score is not a number
    /// </summary>
    [TestMethod]
    public void CheckScores_AwayScoreNotNumeric_ReturnsFalse()
    {
        // ARRANGE
        string homeScore = "1";
        string awayScore = "one";

        // ACT
        var (valid, message) = _validation.CheckScores(homeScore, awayScore);

        // ASSERT
        Assert.IsFalse(valid, "Non-numeric away score should fail validation");
        Assert.IsNotNull(message, "Should return error message");
    }

    /// <summary>
    /// Test: CheckScores should return false when home score is negative
    /// </summary>
    [TestMethod]
    public void CheckScores_NegativeHomeScore_ReturnsFalse()
    {
        // ARRANGE
        string homeScore = "-1";
        string awayScore = "2";

        // ACT
        var (valid, message) = _validation.CheckScores(homeScore, awayScore);

        // ASSERT
        Assert.IsFalse(valid, "Negative home score should fail validation");
        Assert.IsNotNull(message, "Should return error message");
    }

    /// <summary>
    /// Test: CheckScores should return false when away score is negative
    /// </summary>
    [TestMethod]
    public void CheckScores_NegativeAwayScore_ReturnsFalse()
    {
        // ARRANGE
        string homeScore = "2";
        string awayScore = "-3";

        // ACT
        var (valid, message) = _validation.CheckScores(homeScore, awayScore);

        // ASSERT
        Assert.IsFalse(valid, "Negative away score should fail validation");
        Assert.IsNotNull(message, "Should return error message");
    }

    // ==================== CHECKMATCHENTRIES TESTS ====================

    /// <summary>
    /// Test: CheckMatchEntries should return true when home and away teams are different
    /// </summary>
    [TestMethod]
    public void CheckMatchEntries_DifferentTeams_ReturnsTrue()
    {
        // ARRANGE
        int homeId = 1;
        int awayId = 2;

        // ACT
        var (valid, message) = _validation.CheckMatchEntries(homeId, awayId);

        // ASSERT
        Assert.IsTrue(valid, "Different team IDs should pass validation");
        Assert.IsNull(message);
    }

    /// <summary>
    /// Test: CheckMatchEntries should return false when home and away teams are the same
    /// </summary>
    [TestMethod]
    public void CheckMatchEntries_SameTeam_ReturnsFalse()
    {
        // ARRANGE
        int homeId = 5;
        int awayId = 5;

        // ACT
        var (valid, message) = _validation.CheckMatchEntries(homeId, awayId);

        // ASSERT
        Assert.IsFalse(valid, "Same home and away team ID should fail validation");
        Assert.IsNotNull(message, "Should return error message");
    }


    
}
