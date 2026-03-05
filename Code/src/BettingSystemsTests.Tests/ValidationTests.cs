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
}