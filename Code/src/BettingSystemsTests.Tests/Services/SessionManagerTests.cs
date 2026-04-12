using BettingSystem.Models;
using BettingSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingSystemsTests.Services;

/// <summary>
/// Validates SessionManager constructor behavior for user/admin roles and mutable flags.
/// </summary>
[TestClass]
public class SessionManagerTests
{
    /// <summary>
    /// Creates a minimal AppUser used by session construction tests.
    /// </summary>
    private static AppUser CreateUser(string role)
    {
        return new AppUser(
            id: 7,
            fName: "Test",
            lName: "User",
            DOB: new DateTime(2000, 1, 1),
            mail: "test@example.com",
            balance: 50m,
            userRole: role,
            registrationDate: new DateTime(2025, 1, 1),
            status: "active");
    }

    /// <summary>
    /// Tests that the session constructor initializes the user state correctly when the role is 'user'.
    /// </summary>
    [TestMethod]
    public void Constructor_UserRole_InitialisesUserState()
    {
        var session = new SessionManager(CreateUser("user"), new Simulator());

        Assert.IsFalse(session.IsAdmin);
        Assert.IsFalse(session.IsLoggingOut);
        Assert.IsFalse(session.IsExiting);
        Assert.IsNotNull(session.UserSlip);
        Assert.IsNotNull(session.GameResults);
        Assert.AreEqual(7, session.UserSlip.UserID);
    }

    /// <summary>
    /// Tests that the session constructor marks the session as admin and skips user slip initialization when the role is 'admin'.
    /// </summary>
    [TestMethod]
    public void Constructor_AdminRole_MarksAdminAndSkipsUserSlipInitialisation()
    {
        var session = new SessionManager(CreateUser("admin"), new Simulator());

        Assert.IsTrue(session.IsAdmin);
        Assert.IsFalse(session.IsLoggingOut);
        Assert.IsFalse(session.IsExiting);
        Assert.IsNull(session.UserSlip);
        Assert.IsNull(session.GameResults);
    }

    /// <summary>
    /// Tests that an unknown role is treated as an admin role, with no user slip or game results initialized.
    /// </summary>
    [TestMethod]
    public void Constructor_UnknownRole_IsTreatedAsAdmin()
    {
        var session = new SessionManager(CreateUser("manager"), new Simulator());

        Assert.IsTrue(session.IsAdmin);
        Assert.IsNull(session.UserSlip);
        Assert.IsNull(session.GameResults);
    }

    /// <summary>
    /// Tests that the role check in the session constructor is case-sensitive.
    /// </summary>
    [TestMethod]
    public void Constructor_RoleCheck_IsCaseSensitive()
    {
        var session = new SessionManager(CreateUser("User"), new Simulator());

        Assert.IsTrue(session.IsAdmin);
        Assert.IsNull(session.UserSlip);
        Assert.IsNull(session.GameResults);
    }

    /// <summary>
    /// Tests that the simulator reference is correctly assigned in the session manager.
    /// </summary>
    [TestMethod]
    public void Constructor_AssignsSimulatorReference()
    {
        var simulator = new Simulator();
        var session = new SessionManager(CreateUser("user"), simulator);

        Assert.AreSame(simulator, session.AppSimulator);
    }

    /// <summary>
    /// Tests that the IsExiting property can be updated after the session manager has been constructed.
    /// </summary>
    [TestMethod]
    public void IsExiting_CanBeUpdatedAfterConstruction()
    {
        var session = new SessionManager(CreateUser("user"), new Simulator());

        session.IsExiting = true;

        Assert.IsTrue(session.IsExiting);
    }
}
