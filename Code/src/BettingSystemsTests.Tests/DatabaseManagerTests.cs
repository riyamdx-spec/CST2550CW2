using BettingSystem.Data;
using BettingSystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace BettingSystemsTests;

[TestClass]
public class DatabaseManagerTests
{
    private readonly DatabaseManager _db = new DatabaseManager();

    private static string GetConnectionString()
    {
        string? cs = ConfigurationManager.ConnectionStrings["BettingDB"]?.ConnectionString;
        if (string.IsNullOrWhiteSpace(cs))
        {
            Assert.Inconclusive("Missing BettingDB connection string for test project.");
        }
        return cs!;
    }

    private static async Task<int?> GetUserIdByEmailAsync(string email)
    {
        string query = "SELECT app_user_id FROM AppUser WHERE email = @email";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@email", email);

        await connection.OpenAsync();
        object? result = await command.ExecuteScalarAsync();
        return result == null ? null : Convert.ToInt32(result);
    }

    private static async Task DeleteUserByEmailAsync(string email)
    {
        int? userId = await GetUserIdByEmailAsync(email);
        if (userId == null) return;

        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await connection.OpenAsync();
        await using SqlTransaction tx = connection.BeginTransaction();

        try
        {
            string deleteTransactions = "DELETE FROM SystemTransaction WHERE app_user_id = @id";
            await using (SqlCommand cmd1 = new SqlCommand(deleteTransactions, connection, tx))
            {
                cmd1.Parameters.AddWithValue("@id", userId.Value);
                await cmd1.ExecuteNonQueryAsync();
            }

            string deleteUser = "DELETE FROM AppUser WHERE app_user_id = @id";
            await using (SqlCommand cmd2 = new SqlCommand(deleteUser, connection, tx))
            {
                cmd2.Parameters.AddWithValue("@id", userId.Value);
                await cmd2.ExecuteNonQueryAsync();
            }

            await tx.CommitAsync();
        }
        catch
        {
            await tx.RollbackAsync();
            throw;
        }
    }

    private static async Task SetUserStatusActiveAsync(string email)
    {
        string query = "UPDATE AppUser SET user_status = 'active' WHERE email = @email";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@email", email);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }

    [TestMethod]
    public async Task RegisterAsync_NewEmail_ReturnsUserAndSuccessMessage()
    {
        string email = $"dbtest_register_{Guid.NewGuid():N}@example.com";
        const string password = "StrongPass123!";

        await DeleteUserByEmailAsync(email);

        var (userObj, message) = await _db.RegisterAsync("Test", "Register", new DateTime(2000, 1, 1), email, password);

        Assert.IsNotNull(userObj);
        Assert.AreEqual("Registered Successfully", message);
        Assert.AreEqual(email, userObj!.Email);

        await DeleteUserByEmailAsync(email);
    }

    [TestMethod]
    public async Task RegisterAsync_DuplicateEmail_ReturnsDuplicateMessage()
    {
        string email = $"dbtest_duplicate_{Guid.NewGuid():N}@example.com";
        const string password = "StrongPass123!";

        await DeleteUserByEmailAsync(email);

        var first = await _db.RegisterAsync("Test", "Dup", new DateTime(2000, 2, 8), email, password);
        Assert.IsNotNull(first.userObj);

        var second = await _db.RegisterAsync("Test", "Dup2", new DateTime(2001, 3, 21), email, password);

        Assert.IsNull(second.userObj);
        Assert.AreEqual("This email is already linked to an existing account", second.message);

        await DeleteUserByEmailAsync(email);
    }

    [TestMethod]
    public async Task LoginAsync_ValidCredentials_ReturnsUser()
    {
        string email = $"dbtest_login_{Guid.NewGuid():N}@example.com";
        const string password = "StrongPass123!";

        await DeleteUserByEmailAsync(email);

        var reg = await _db.RegisterAsync("Test", "Login", new DateTime(2000, 2, 8), email, password);
        Assert.IsNotNull(reg.userObj);

        // LoginAsync requires active status.
        await SetUserStatusActiveAsync(email);

        var (userObj, message) = await _db.LoginAsync(email, password);

        Assert.IsNotNull(userObj);
        Assert.AreEqual("Logged In Successfully", message);
        Assert.AreEqual(email, userObj!.Email);

        await DeleteUserByEmailAsync(email);
    }

    [TestMethod]
    public async Task LoginAsync_WrongPassword_ReturnsIncorrectMessage()
    {
        string email = $"dbtest_wrongpass_{Guid.NewGuid():N}@example.com";
        const string rightPassword = "StrongPass123!";
        const string wrongPassword = "WrongPass123!";

        await DeleteUserByEmailAsync(email);

        var reg = await _db.RegisterAsync("Test", "WrongPass", new DateTime(2000, 1, 1), email, rightPassword);
        Assert.IsNotNull(reg.userObj);

        await SetUserStatusActiveAsync(email);

        var (userObj, message) = await _db.LoginAsync(email, wrongPassword);

        Assert.IsNull(userObj);
        Assert.AreEqual("Incorrect Email or Password", message);

        await DeleteUserByEmailAsync(email);
    }

    [TestMethod]
    public async Task UpdateUserDetailsAsync_ValidInput_UpdatesUserObject()
    {
        string oldEmail = $"dbtest_update_old_{Guid.NewGuid():N}@example.com";
        string newEmail = $"dbtest_update_new_{Guid.NewGuid():N}@example.com";
        const string password = "StrongPass123!";

        await DeleteUserByEmailAsync(oldEmail);
        await DeleteUserByEmailAsync(newEmail);

        var reg = await _db.RegisterAsync("OldFirst", "OldLast", new DateTime(2000, 1, 1), oldEmail, password);
        Assert.IsNotNull(reg.userObj);

        AppUser currentUser = reg.userObj!;
        var (valid, message) = await _db.UpdateUserDetailsAsync(currentUser, "NewFirst", "NewLast", newEmail);

        Assert.IsTrue(valid);
        Assert.AreEqual("Profile updated successfully", message);
        Assert.AreEqual("NewFirst", currentUser.FirstName);
        Assert.AreEqual("NewLast", currentUser.LastName);
        Assert.AreEqual(newEmail, currentUser.Email);

        await DeleteUserByEmailAsync(newEmail);
        await DeleteUserByEmailAsync(oldEmail);
    }
}
