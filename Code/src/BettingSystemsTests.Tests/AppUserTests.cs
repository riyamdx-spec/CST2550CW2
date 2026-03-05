using BettingSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingSystemsTests;

[TestClass]
public class AppUserTests
{
    [TestMethod]
    public void Constructor_AssignsAllPropertiesCorrectly()
    {
        var dob = new DateTime(1999, 5, 10);

        var user = new AppUser(
            id: 42,
            fName: "Rayan",
            lName: "Sedo",
            DOB: dob,
            mail: "rayan@example.com",
            balance: 250.75m,
            userRole: "customer");

        Assert.AreEqual(42, user.UserID);
        Assert.AreEqual("Rayan", user.FirstName);
        Assert.AreEqual("Sedo", user.LastName);
        Assert.AreEqual(dob, user.Dob);
        Assert.AreEqual("rayan@example.com", user.Email);
        Assert.AreEqual(250.75m, user.WalletBalance);
        Assert.AreEqual("customer", user.Role);
    }

    [TestMethod]
    public void Properties_CanBeUpdatedAfterConstruction()
    {
        var user = new AppUser(
            id: 1,
            fName: "A",
            lName: "B",
            DOB: new DateTime(2000, 1, 1),
            mail: "a@b.com",
            balance: 0m,
            userRole: "customer");

        user.FirstName = "Updated";
        user.LastName = "Name";
        user.Email = "updated@example.com";
        user.WalletBalance = 99.99m;
        user.Role = "admin";

        Assert.AreEqual("Updated", user.FirstName);
        Assert.AreEqual("Name", user.LastName);
        Assert.AreEqual("updated@example.com", user.Email);
        Assert.AreEqual(99.99m, user.WalletBalance);
        Assert.AreEqual("admin", user.Role);
    }
}