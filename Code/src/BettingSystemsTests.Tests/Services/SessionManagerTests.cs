using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystemsTests.Services;

[TestClass]
public class SessionManagerTests
{
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

    [TestMethod]
    public void Constructor_UnknownRole_IsTreatedAsAdmin()
    {
        var session = new SessionManager(CreateUser("manager"), new Simulator());

        Assert.IsTrue(session.IsAdmin);
        Assert.IsNull(session.UserSlip);
        Assert.IsNull(session.GameResults);
    }

    [TestMethod]
    public void Constructor_RoleCheck_IsCaseSensitive()
    {
        var session = new SessionManager(CreateUser("User"), new Simulator());

        Assert.IsTrue(session.IsAdmin);
        Assert.IsNull(session.UserSlip);
        Assert.IsNull(session.GameResults);
    }

    [TestMethod]
    public void Constructor_AssignsSimulatorReference()
    {
        var simulator = new Simulator();
        var session = new SessionManager(CreateUser("user"), simulator);

        Assert.AreSame(simulator, session.AppSimulator);
    }

    [TestMethod]
    public void IsExiting_CanBeUpdatedAfterConstruction()
    {
        var session = new SessionManager(CreateUser("user"), new Simulator());

        session.IsExiting = true;

        Assert.IsTrue(session.IsExiting);
    }
}

