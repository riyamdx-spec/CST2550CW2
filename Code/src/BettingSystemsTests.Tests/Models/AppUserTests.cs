using BettingSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingSystemsTests;

/// <summary>
/// Tests the AppUser model constructor and mutable properties.
/// </summary>
[TestClass]
public class AppUserTests
{
    /// <summary>
    /// Verifies that constructor arguments are persisted to all exposed properties.
    /// </summary>
    [TestMethod]
    public void Constructor_AssignsAllPropertiesCorrectly()
    {
        var dob = new DateTime(1999, 5, 10);
        var registrationDate = new DateTime(2026, 3, 1);

        var user = new AppUser(
            id: 42,
            fName: "Rayan",
            lName: "Sedo",
            DOB: dob,
            mail: "rayan@example.com",
            balance: 250.75m,
            userRole: "customer",
            registrationDate: registrationDate,
            status: "active");

        Assert.AreEqual(42, user.UserID);
        Assert.AreEqual("Rayan", user.FirstName);
        Assert.AreEqual("Sedo", user.LastName);
        Assert.AreEqual(dob, user.Dob);
        Assert.AreEqual("rayan@example.com", user.Email);
        Assert.AreEqual(250.75m, user.WalletBalance);
        Assert.AreEqual("customer", user.Role);
        Assert.AreEqual(registrationDate, user.RegistrationDate);
        Assert.AreEqual("active", user.Status);
    }

    /// <summary>
    /// Verifies that mutable properties can be changed after object creation.
    /// </summary>
    [TestMethod]
    public void Properties_CanBeUpdatedAfterConstruction()
    {
        var registrationDate = new DateTime(2026, 3, 15);

        var user = new AppUser(
            id: 1,
            fName: "A",
            lName: "B",
            DOB: new DateTime(2000, 1, 1),
            mail: "a@b.com",
            balance: 0m,
            userRole: "customer",
            registrationDate: registrationDate,
            status: "pending");

        user.FirstName = "Updated";
        user.LastName = "Name";
        user.Email = "updated@example.com";
        user.WalletBalance = 99.99m;
        user.Role = "admin";
        user.Status = "active";
        user.RegistrationDate = registrationDate.AddDays(1);

        Assert.AreEqual("Updated", user.FirstName);
        Assert.AreEqual("Name", user.LastName);
        Assert.AreEqual("updated@example.com", user.Email);
        Assert.AreEqual(99.99m, user.WalletBalance);
        Assert.AreEqual("admin", user.Role);
        Assert.AreEqual("active", user.Status);
        Assert.AreEqual(registrationDate.AddDays(1), user.RegistrationDate);
    }
}