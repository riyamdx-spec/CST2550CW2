using BettingSystem.Data;
using BettingSystem.Data_Structures;
using BettingSystem.Models;
using BettingSystem.Services;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace BettingSystemsTests;

/// <summary>
/// Integration tests for DatabaseManager, verifying all data access operations
/// against a real SQL Server database using the configured BettingDB connection string.
/// </summary>
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
            string deleteBets = "DELETE FROM Bet WHERE slip_id IN (SELECT slip_id FROM BetSlip WHERE app_user_id = @id)";
            await using (SqlCommand cmd0 = new SqlCommand(deleteBets, connection, tx))
            {
                cmd0.Parameters.AddWithValue("@id", userId.Value);
                await cmd0.ExecuteNonQueryAsync();
            }

            string deleteBetSlips = "DELETE FROM BetSlip WHERE app_user_id = @id";
            await using (SqlCommand cmd0b = new SqlCommand(deleteBetSlips, connection, tx))
            {
                cmd0b.Parameters.AddWithValue("@id", userId.Value);
                await cmd0b.ExecuteNonQueryAsync();
            }

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

    private static async Task SetUserStatusAsync(string email, string status)
    {
        string query = "UPDATE AppUser SET user_status = @status WHERE email = @email";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@status", status);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }

    private static async Task<(string FirstName, string LastName, string Email)?> GetUserProfileByIdAsync(int userId)
    {
        string query = "SELECT first_name, last_name, email FROM AppUser WHERE app_user_id = @id";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", userId);

        await connection.OpenAsync();
        await using SqlDataReader reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
        {
            return null;
        }

        return (
            reader["first_name"].ToString()!,
            reader["last_name"].ToString()!,
            reader["email"].ToString()!
        );
    }

    private static async Task<Odd?> GetAnyScheduledOddAsync()
    {
        const string query = @"SELECT TOP 1 o.odd_id, o.game_id, o.bet_type_id, o.selection, o.odd_value
                               FROM Odd o
                               INNER JOIN Game g ON g.game_id = o.game_id
                               WHERE g.game_status = 'Scheduled'
                               ORDER BY o.odd_id DESC";

        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        await connection.OpenAsync();
        await using SqlDataReader reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
        {
            return null;
        }

        return new Odd(
            Convert.ToInt32(reader["odd_id"]),
            Convert.ToInt32(reader["game_id"]),
            Convert.ToInt32(reader["bet_type_id"]),
            reader["selection"].ToString()!,
            Convert.ToDecimal(reader["odd_value"])
        );
    }

    private static async Task<bool> IsGameScheduledAsync(int gameId)
    {
        const string query = "SELECT game_status FROM Game WHERE game_id = @id";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", gameId);

        await connection.OpenAsync();
        string? status = (await command.ExecuteScalarAsync())?.ToString();
        return status == "Scheduled";
    }

    private static async Task<(Odd odd, int homeTeamId, int awayTeamId, int leagueId, int homeGoals, int awayGoals)?> GetExistingCorrectScoreOddWithContextAsync()
    {
        const string query = @"SELECT TOP 25 o.odd_id, o.game_id, o.bet_type_id, o.selection, o.odd_value,
                                      g.home_team_id, g.away_team_id, g.league_id
                               FROM Odd o
                               INNER JOIN BetType bt ON bt.bet_type_id = o.bet_type_id
                               INNER JOIN Game g ON g.game_id = o.game_id
                               WHERE bt.bet_type_name = 'Correct Score'
                                 AND g.game_status = 'Scheduled'
                               ORDER BY o.odd_id DESC";

        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);

        await connection.OpenAsync();
        await using SqlDataReader reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            string selection = reader["selection"].ToString()!;
            string[] parts = selection.Split('-');
            if (parts.Length != 2) continue;
            if (!int.TryParse(parts[0], out int homeGoals)) continue;
            if (!int.TryParse(parts[1], out int awayGoals)) continue;

            Odd odd = new Odd(
                Convert.ToInt32(reader["odd_id"]),
                Convert.ToInt32(reader["game_id"]),
                Convert.ToInt32(reader["bet_type_id"]),
                selection,
                Convert.ToDecimal(reader["odd_value"])
            );

            return (
                odd,
                Convert.ToInt32(reader["home_team_id"]),
                Convert.ToInt32(reader["away_team_id"]),
                Convert.ToInt32(reader["league_id"]),
                homeGoals,
                awayGoals
            );
        }

        return null;
    }

    private static async Task<int?> GetLatestSlipIdByUserAsync(int userId)
    {
        const string query = "SELECT TOP 1 slip_id FROM BetSlip WHERE app_user_id = @id ORDER BY slip_id DESC";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", userId);

        await connection.OpenAsync();
        object? result = await command.ExecuteScalarAsync();
        return result == null ? null : Convert.ToInt32(result);
    }

    private static async Task<int> GetBetCountBySlipIdAsync(int slipId)
    {
        const string query = "SELECT COUNT(*) FROM Bet WHERE slip_id = @slipId";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@slipId", slipId);

        await connection.OpenAsync();
        return Convert.ToInt32(await command.ExecuteScalarAsync());
    }

    private static async Task<List<Odd>> GetScheduledOddsAsync(int count)
    {
        string query = $@"SELECT TOP {count} o.odd_id, o.game_id, o.bet_type_id, o.selection, o.odd_value
                          FROM Odd o
                          INNER JOIN Game g ON g.game_id = o.game_id
                          WHERE g.game_status = 'Scheduled'
                          ORDER BY o.odd_id DESC";

        List<Odd> odds = new List<Odd>();
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        await connection.OpenAsync();

        await using SqlDataReader reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            odds.Add(new Odd(
                Convert.ToInt32(reader["odd_id"]),
                Convert.ToInt32(reader["game_id"]),
                Convert.ToInt32(reader["bet_type_id"]),
                reader["selection"].ToString()!,
                Convert.ToDecimal(reader["odd_value"])
            ));
        }

        return odds;
    }

    private static async Task<(decimal TotalOdds, decimal Stake, decimal Payout)?> GetSlipSnapshotAsync(int slipId)
    {
        const string query = "SELECT total_odds, stake, payout FROM BetSlip WHERE slip_id = @slipId";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@slipId", slipId);

        await connection.OpenAsync();
        await using SqlDataReader reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
        {
            return null;
        }

        return (
            Convert.ToDecimal(reader["total_odds"]),
            Convert.ToDecimal(reader["stake"]),
            Convert.ToDecimal(reader["payout"])
        );
    }

    private static async Task<bool> CorrectScoreOddExistsAsync(int gameId, string selection)
    {
        const string query = @"SELECT COUNT(*)
                               FROM Odd o
                               INNER JOIN BetType bt ON bt.bet_type_id = o.bet_type_id
                               WHERE o.game_id = @gameId
                                 AND bt.bet_type_name = 'Correct Score'
                                 AND o.selection = @selection";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@gameId", gameId);
        command.Parameters.AddWithValue("@selection", selection);

        await connection.OpenAsync();
        return Convert.ToInt32(await command.ExecuteScalarAsync()) > 0;
    }

    private static async Task DeleteCorrectScoreOddAsync(int gameId, string selection)
    {
        const string query = @"DELETE o
                               FROM Odd o
                               INNER JOIN BetType bt ON bt.bet_type_id = o.bet_type_id
                               WHERE o.game_id = @gameId
                                 AND bt.bet_type_name = 'Correct Score'
                                 AND o.selection = @selection";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@gameId", gameId);
        command.Parameters.AddWithValue("@selection", selection);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }

    private static async Task<(int HomeGoals, int AwayGoals, string Selection)?> FindMissingCorrectScoreSelectionAsync(int gameId)
    {
        for (int homeGoals = 12; homeGoals >= 8; homeGoals--)
        {
            for (int awayGoals = 12; awayGoals >= 8; awayGoals--)
            {
                string selection = $"{homeGoals}-{awayGoals}";
                if (!await CorrectScoreOddExistsAsync(gameId, selection))
                {
                    return (homeGoals, awayGoals, selection);
                }
            }
        }

        return null;
    }

    private static async Task<GameResult?> GetGameResultByGameIdAsync(int gameId)
    {
        const string query = @"SELECT game_id, home_team_score, away_team_score, first_scorer_id, total_corners, red_cards, yellow_cards
                               FROM GameResult
                               WHERE game_id = @gameId";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@gameId", gameId);

        await connection.OpenAsync();
        await using SqlDataReader reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
        {
            return null;
        }

        return new GameResult(
            Convert.ToInt32(reader["game_id"]),
            Convert.ToInt32(reader["home_team_score"]),
            Convert.ToInt32(reader["away_team_score"]),
            Convert.ToInt32(reader["total_corners"]),
            Convert.ToInt32(reader["red_cards"]),
            Convert.ToInt32(reader["yellow_cards"]),
            null,
            reader["first_scorer_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["first_scorer_id"])
        );
    }

    private static async Task<int> GetOddsCountByGameIdAsync(int gameId)
    {
        const string query = "SELECT COUNT(*) FROM Odd WHERE game_id = @gameId";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@gameId", gameId);

        await connection.OpenAsync();
        return Convert.ToInt32(await command.ExecuteScalarAsync());
    }

    private static async Task<int> GetGameResultCountAsync()
    {
        const string query = "SELECT COUNT(*) FROM GameResult";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);

        await connection.OpenAsync();
        return Convert.ToInt32(await command.ExecuteScalarAsync());
    }

    /// <summary>
    /// Verifies that registering with a new unique email persists the user and returns a success message.
    /// </summary>
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

    /// <summary>
    /// Verifies that attempting to register with an already-registered email returns a duplicate account message and a null user object.
    /// </summary>
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

    /// <summary>
    /// Verifies that a registered active user can log in with correct credentials and receives a successful login response.
    /// </summary>
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

    /// <summary>
    /// Verifies that providing an incorrect password for a valid account returns the incorrect credentials message.
    /// </summary>
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

    /// <summary>
    /// Verifies that attempting to log in with an unregistered email returns the incorrect credentials message.
    /// </summary>
    [TestMethod]
    public async Task LoginAsync_UnknownEmail_ReturnsIncorrectMessage()
    {
        string email = $"dbtest_missing_{Guid.NewGuid():N}@ray.com";

        await DeleteUserByEmailAsync(email);

        var (userObj, message) = await _db.LoginAsync(email, "SomePassword123!");

        Assert.IsNull(userObj);
        Assert.AreEqual("Incorrect Email or Password", message);
    }

    /// <summary>
    /// Verifies that logging in with a suspended account returns the account suspension message.
    /// </summary>
    [TestMethod]
    public async Task LoginAsync_SuspendedAccount_ReturnsStatusMessage()
    {
        string email = $"dbtest_suspended_{Guid.NewGuid():N}@gmail.com";
        const string password = "Strongpassword123!";

        await DeleteUserByEmailAsync(email);

        var reg = await _db.RegisterAsync("Test", "Suspended", new DateTime(2017, 2, 1), email, password);
        Assert.IsNotNull(reg.userObj);

        await SetUserStatusAsync(email, "suspended");

        var (userObj, message) = await _db.LoginAsync(email, password);

        Assert.IsNull(userObj);
        Assert.AreEqual("Your account has been suspended. Please contact admin@gmail.com for support.", message);

        await DeleteUserByEmailAsync(email);
    }

    /// <summary>
    /// Verifies that updating first name, last name, and email for a valid user persists all changes to the database.
    /// </summary>
    [TestMethod]
    public async Task UpdateUserDetailsAsync_ValidInput_PersistsChangesInDatabase()
    {
        string oldEmail = $"dbtest_update_old_{Guid.NewGuid():N}@gmail.com";
        string newEmail = $"dbtest_update_new_{Guid.NewGuid():N}@gmail.com";
        const string password = "Strongpassword123!";

        await DeleteUserByEmailAsync(oldEmail);
        await DeleteUserByEmailAsync(newEmail);

        var reg = await _db.RegisterAsync("OldFirst", "OldLast", new DateTime(2018, 3, 1), oldEmail, password);
        Assert.IsNotNull(reg.userObj);

        AppUser currentUser = reg.userObj!;
        var (valid, message) = await _db.UpdateUserDetailsAsync(currentUser.UserID, "NewFirst", "NewLast", newEmail);
        var dbProfile = await GetUserProfileByIdAsync(currentUser.UserID);

        Assert.IsTrue(valid);
        Assert.AreEqual("Profile updated successfully", message);
        Assert.IsNotNull(dbProfile);
        Assert.AreEqual("NewFirst", dbProfile!.Value.FirstName);
        Assert.AreEqual("NewLast", dbProfile.Value.LastName);
        Assert.AreEqual(newEmail, dbProfile.Value.Email);

        await DeleteUserByEmailAsync(newEmail);
        await DeleteUserByEmailAsync(oldEmail);
    }

    /// <summary>
    /// Verifies that updating a user's email to one already in use returns a duplicate email message.
    /// </summary>
    [TestMethod]
    public async Task UpdateUserDetailsAsync_DuplicateEmail_ReturnsDuplicateMessage()
    {
        string firstEmail = $"dbtest_update_dup_first_{Guid.NewGuid():N}@gmail.com";
        string secondEmail = $"dbtest_update_dup_second_{Guid.NewGuid():N}@gmail.com";
        const string password = "Strongpassord123!";

        await DeleteUserByEmailAsync(firstEmail);
        await DeleteUserByEmailAsync(secondEmail);

        var firstUser = await _db.RegisterAsync("First", "User", new DateTime(2019, 4, 1), firstEmail, password);
        var secondUser = await _db.RegisterAsync("Second", "User", new DateTime(2019, 4, 2), secondEmail, password);

        Assert.IsNotNull(firstUser.userObj);
        Assert.IsNotNull(secondUser.userObj);

        var (valid, message) = await _db.UpdateUserDetailsAsync(firstUser.userObj!.UserID, "New", "Name", secondEmail);

        Assert.IsFalse(valid);
        Assert.AreEqual("This email is already linked to an existing account", message);

        await DeleteUserByEmailAsync(firstEmail);
        await DeleteUserByEmailAsync(secondEmail);
    }

    /// <summary>
    /// Verifies that a valid password change updates the stored hash and the old password no longer grants access.
    /// </summary>
    [TestMethod]
    public async Task ChangePasswordAsync_ValidCurrentPassword_UpdatesPassword()
    {
        string email = $"dbtest_change_pwd_{Guid.NewGuid():N}@gmail.com";
        const string oldPassword = "Strongpassword123!";
        const string newPassword = "NewStrongPassword456!";

        await DeleteUserByEmailAsync(email);

        var reg = await _db.RegisterAsync("Change", "Password", new DateTime(2020, 5, 1), email, oldPassword);
        Assert.IsNotNull(reg.userObj);

        var beforeHash = await _db.FetchPasswordAsync(reg.userObj!.UserID);
        var (valid, message) = await _db.ChangePasswordAsync(oldPassword, newPassword, reg.userObj.UserID);
        var afterHash = await _db.FetchPasswordAsync(reg.userObj.UserID);

        Assert.IsTrue(valid);
        Assert.AreEqual("Password changed successfully", message);
        Assert.IsNotNull(beforeHash);
        Assert.IsNotNull(afterHash);
        Assert.AreNotEqual(beforeHash, afterHash);

        await SetUserStatusActiveAsync(email);

        var oldLogin = await _db.LoginAsync(email, oldPassword);
        var newLogin = await _db.LoginAsync(email, newPassword);

        Assert.IsNull(oldLogin.userObj);
        Assert.AreEqual("Incorrect Email or Password", oldLogin.message);
        Assert.IsNotNull(newLogin.userObj);
        Assert.AreEqual("Logged In Successfully", newLogin.message);

        await DeleteUserByEmailAsync(email);
    }

    /// <summary>
    /// Verifies that providing an incorrect current password during a password change returns a validation message.
    /// </summary>
    [TestMethod]
    public async Task ChangePasswordAsync_WrongCurrentPassword_ReturnsValidationMessage()
    {
        string email = $"dbtest_change_wrong_current_{Guid.NewGuid():N}@gmail.com";
        const string currentPassword = "StrongPassword123!";
        const string wrongCurrentPassword = "WrongPassword678!";

        await DeleteUserByEmailAsync(email);

        var reg = await _db.RegisterAsync("Change", "WrongCurrent", new DateTime(2021, 6, 1), email, currentPassword);
        Assert.IsNotNull(reg.userObj);

        var (valid, message) = await _db.ChangePasswordAsync(wrongCurrentPassword, "NewPass204!", reg.userObj!.UserID);

        Assert.IsFalse(valid);
        Assert.AreEqual("Password entered does not match your current password", message);

        await DeleteUserByEmailAsync(email);
    }

    /// <summary>
    /// Verifies that attempting to change to the same password returns a validation message.
    /// </summary>
    [TestMethod]
    public async Task ChangePasswordAsync_SameAsCurrentPassword_ReturnsValidationMessage()
    {
        string email = $"dbtest_change_same_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        var reg = await _db.RegisterAsync("Change", "Same", new DateTime(2021, 7, 1), email, password);
        Assert.IsNotNull(reg.userObj);

        var (valid, message) = await _db.ChangePasswordAsync(password, password, reg.userObj!.UserID);

        Assert.IsFalse(valid);
        Assert.AreEqual("New password cannot be the same as your current password", message);

        await DeleteUserByEmailAsync(email);
    }

    /// <summary>
    /// Verifies that requesting the password hash for a non-existent user returns null.
    /// </summary>
    [TestMethod]
    public async Task FetchPasswordAsync_UnknownUser_ReturnsNull()
    {
        string? hash = await _db.FetchPasswordAsync(-1);
        Assert.IsNull(hash);
    }

    /// <summary>
    /// Verifies that updating the password hash for a non-existent user returns false.
    /// </summary>
    [TestMethod]
    public async Task UpdatePasswordAsync_UnknownUser_ReturnsFalse()
    {
        bool updated = await _db.UpdatePasswordAsync(-1, Convert.ToBase64String(Guid.NewGuid().ToByteArray()));
        Assert.IsFalse(updated);
    }

    /// <summary>
    /// Verifies that the returned odds dictionary contains only odds for games with a Scheduled status.
    /// </summary>
    [TestMethod]
    public async Task FetchOddsAsync_ReturnsOnlyScheduledGames()
    {
        MyDictionary<int, MyList<Odd>> odds = await _db.FetchOddsAsync();

        if (odds.Count == 0)
        {
            Assert.Inconclusive("No scheduled odds in seed database to validate FetchOddsAsync.");
        }

        foreach ((int gameId, MyList<Odd> gameOdds) in odds)
        {
            Assert.IsTrue(gameOdds.Count > 0);
            Assert.IsTrue(await IsGameScheduledAsync(gameId));
            Assert.IsTrue(gameOdds.All(x => x.GameID == gameId));
        }
    }

    /// <summary>
    /// Verifies that saving a bet slip with no bets returns a failure message.
    /// </summary>
    [TestMethod]
    public async Task SaveBetSlipAsync_EmptySlip_ReturnsFailureMessage()
    {
        string email = $"dbtest_empty_slip_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        try
        {
            var reg = await _db.RegisterAsync("Slip", "Empty", new DateTime(2001, 1, 1), email, password);
            Assert.IsNotNull(reg.userObj);

            BetSlip slip = new BetSlip(reg.userObj!.UserID) { Stake = 10m };
            var (success, message) = await _db.SaveBetSlipAsync(slip);

            Assert.IsFalse(success);
            Assert.AreEqual("Bet slip is empty", message);
        }
        finally
        {
            await DeleteUserByEmailAsync(email);
        }
    }

    /// <summary>
    /// Verifies that saving a slip with one bet persists both the slip and the bet row to the database.
    /// </summary>
    [TestMethod]
    public async Task SaveBetSlipAsync_ValidSingleBet_PersistsSlipAndBet()
    {
        string email = $"dbtest_valid_slip_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        try
        {
            Odd? odd = await GetAnyScheduledOddAsync();
            if (odd == null)
            {
                Assert.Inconclusive("No scheduled odd exists in seed database for SaveBetSlipAsync test.");
            }

            var reg = await _db.RegisterAsync("Slip", "Valid", new DateTime(2001, 2, 1), email, password);
            Assert.IsNotNull(reg.userObj);

            BetSlip slip = new BetSlip(reg.userObj!.UserID) { Stake = 15m };
            slip.AddBet(new Bet(odd.OddID, odd.Selection, odd.OddValue, odd.BetTypeID, odd.GameID, DateTime.Today));

            var (success, message) = await _db.SaveBetSlipAsync(slip);
            int? savedSlipId = await GetLatestSlipIdByUserAsync(reg.userObj.UserID);

            Assert.IsTrue(success);
            Assert.AreEqual("Bet placed successfully", message);
            Assert.IsNotNull(savedSlipId);
            Assert.AreEqual(1, await GetBetCountBySlipIdAsync(savedSlipId.Value));
        }
        finally
        {
            await DeleteUserByEmailAsync(email);
        }
    }

    /// <summary>
    /// Verifies that saving a multi-bet slip persists all bet rows and correctly calculates total odds and payout.
    /// </summary>
    [TestMethod]
    public async Task SaveBetSlipAsync_MultipleBets_PersistsAllBetRowsAndTotals()
    {
        string email = $"dbtest_multi_slip_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        try
        {
            List<Odd> odds = await GetScheduledOddsAsync(2);
            if (odds.Count < 2)
            {
                Assert.Inconclusive("Need at least two scheduled odds in seed database for multi-bet slip test.");
            }

            var reg = await _db.RegisterAsync("Slip", "Multi", new DateTime(2001, 3, 1), email, password);
            Assert.IsNotNull(reg.userObj);

            BetSlip slip = new BetSlip(reg.userObj!.UserID) { Stake = 20m };
            foreach (Odd odd in odds)
            {
                slip.AddBet(new Bet(odd.OddID, odd.Selection, odd.OddValue, odd.BetTypeID, odd.GameID, DateTime.Today));
            }

            decimal expectedOdds = odds.Aggregate(1m, (current, odd) => current * odd.OddValue);
            decimal expectedPayout = Math.Round(20m * expectedOdds, 2);

            var (success, message) = await _db.SaveBetSlipAsync(slip);
            int? savedSlipId = await GetLatestSlipIdByUserAsync(reg.userObj.UserID);
            var savedSlip = savedSlipId.HasValue ? await GetSlipSnapshotAsync(savedSlipId.Value) : null;

            Assert.IsTrue(success);
            Assert.AreEqual("Bet placed successfully", message);
            Assert.IsNotNull(savedSlipId);
            Assert.IsNotNull(savedSlip);
            Assert.AreEqual(2, await GetBetCountBySlipIdAsync(savedSlipId!.Value));
            Assert.AreEqual(expectedOdds, savedSlip!.Value.TotalOdds);
            Assert.AreEqual(20m, savedSlip.Value.Stake);
            Assert.AreEqual(expectedPayout, savedSlip.Value.Payout);
        }
        finally
        {
            await DeleteUserByEmailAsync(email);
        }
    }

    /// <summary>
    /// Verifies that requesting an existing correct-score odd returns the same odd without creating a duplicate.
    /// </summary>
    [TestMethod]
    public async Task GetOrCreateCorrectScoreOddAsync_WhenOddAlreadyExists_ReturnsExistingOdd()
    {
        var existing = await GetExistingCorrectScoreOddWithContextAsync();
        if (existing == null)
        {
            Assert.Inconclusive("No scheduled correct-score odd exists in seed database.");
        }

        var createdOrFound = await _db.GetOrCreateCorrectScoreOddAsync(
            existing.Value.odd.GameID,
            existing.Value.homeGoals,
            existing.Value.awayGoals,
            existing.Value.homeTeamId,
            existing.Value.awayTeamId,
            existing.Value.leagueId);

        Assert.IsNotNull(createdOrFound);
        Assert.AreEqual(existing.Value.odd.OddID, createdOrFound.OddID);
        Assert.AreEqual(existing.Value.odd.GameID, createdOrFound.GameID);
        Assert.AreEqual(existing.Value.odd.Selection, createdOrFound.Selection);
    }

    /// <summary>
    /// Verifies that requesting a missing correct-score selection creates and persists a new odd.
    /// </summary>
    [TestMethod]
    public async Task GetOrCreateCorrectScoreOddAsync_WhenOddIsMissing_CreatesAndReturnsOdd()
    {
        var existing = await GetExistingCorrectScoreOddWithContextAsync();
        if (existing == null)
        {
            Assert.Inconclusive("No scheduled correct-score context exists in seed database.");
        }

        var missingSelection = await FindMissingCorrectScoreSelectionAsync(existing.Value.odd.GameID);
        if (missingSelection == null)
        {
            Assert.Inconclusive("Could not identify a missing correct-score selection for the scheduled game.");
        }

        await DeleteCorrectScoreOddAsync(existing.Value.odd.GameID, missingSelection.Value.Selection);

        try
        {
            Odd? created = await _db.GetOrCreateCorrectScoreOddAsync(
                existing.Value.odd.GameID,
                missingSelection.Value.HomeGoals,
                missingSelection.Value.AwayGoals,
                existing.Value.homeTeamId,
                existing.Value.awayTeamId,
                existing.Value.leagueId);

            Assert.IsNotNull(created);
            Assert.AreEqual(existing.Value.odd.GameID, created!.GameID);
            Assert.AreEqual(missingSelection.Value.Selection, created.Selection);
            Assert.IsTrue(created.OddValue > 0);
            Assert.IsTrue(await CorrectScoreOddExistsAsync(existing.Value.odd.GameID, missingSelection.Value.Selection));
        }
        finally
        {
            await DeleteCorrectScoreOddAsync(existing.Value.odd.GameID, missingSelection.Value.Selection);
        }
    }

    // -----------------------------------------------------------------------
    // ProcessWalletTransactionAsync
    // -----------------------------------------------------------------------

    /// <summary>
    /// Verifies that a deposit transaction updates the user's wallet balance and creates a transaction record.
    /// </summary>
    [TestMethod]
    public async Task ProcessWalletTransactionAsync_Deposit_UpdatesWalletAndRecordsTransaction()
    {
        string email = $"dbtest_deposit_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        try
        {
            var reg = await _db.RegisterAsync("Wallet", "Deposit", new DateTime(2000, 1, 1), email, password);
            Assert.IsNotNull(reg.userObj);
            int userId = reg.userObj!.UserID;

            const decimal depositAmount = 50m;
            const decimal newBalance = 50m;

            bool result = await _db.ProcessWalletTransactionAsync(userId, "deposit", newBalance, depositAmount);

            Assert.IsTrue(result);
            decimal dbBalance = await GetWalletBalanceAsync(userId);
            Assert.AreEqual(newBalance, dbBalance);
            Assert.IsTrue(await TransactionRowExistsAsync(userId, "deposit", depositAmount));
        }
        finally
        {
            await DeleteUserByEmailAsync(email);
        }
    }

    /// <summary>
    /// Verifies that a withdrawal transaction updates the user's wallet balance and creates a transaction record.
    /// </summary>
    [TestMethod]
    public async Task ProcessWalletTransactionAsync_Withdrawal_UpdatesWalletAndRecordsTransaction()
    {
        string email = $"dbtest_withdraw_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        try
        {
            var reg = await _db.RegisterAsync("Wallet", "Withdraw", new DateTime(2000, 1, 1), email, password);
            Assert.IsNotNull(reg.userObj);
            int userId = reg.userObj!.UserID;

            await _db.ProcessWalletTransactionAsync(userId, "deposit", 100m, 100m);

            bool result = await _db.ProcessWalletTransactionAsync(userId, "withdrawal", 80m, 20m);

            Assert.IsTrue(result);
            decimal dbBalance = await GetWalletBalanceAsync(userId);
            Assert.AreEqual(80m, dbBalance);
            Assert.IsTrue(await TransactionRowExistsAsync(userId, "withdrawal", 20m));
        }
        finally
        {
            await DeleteUserByEmailAsync(email);
        }
    }

    /// <summary>
    /// Verifies that a payout transaction marks the referenced bet slip as claimed and records the transaction.
    /// </summary>
    [TestMethod]
    public async Task ProcessWalletTransactionAsync_Payout_MarksBetSlipAsClaimed()
    {
        string email = $"dbtest_payout_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        try
        {
            Odd? odd = await GetAnyScheduledOddAsync();
            if (odd == null)
            {
                Assert.Inconclusive("No scheduled odd in seed database for payout test.");
            }

            var reg = await _db.RegisterAsync("Wallet", "Payout", new DateTime(2000, 1, 1), email, password);
            Assert.IsNotNull(reg.userObj);
            int userId = reg.userObj!.UserID;

            await _db.ProcessWalletTransactionAsync(userId, "deposit", 100m, 100m);

            BetSlip slip = new BetSlip(userId) { Stake = 10m };
            slip.AddBet(new Bet(odd.OddID, odd.Selection, odd.OddValue, odd.BetTypeID, odd.GameID, DateTime.Today));
            await _db.SaveBetSlipAsync(slip);

            int? slipId = await GetLatestSlipIdByUserAsync(userId);
            Assert.IsNotNull(slipId);

            decimal payout = slip.CalculatePayout();
            bool result = await _db.ProcessWalletTransactionAsync(userId, "payout", 100m + payout, payout, slipId);

            Assert.IsTrue(result);
            Assert.IsTrue(await IsSlipClaimedAsync(slipId.Value));
            Assert.IsTrue(await TransactionRowExistsAsync(userId, "payout", payout));
        }
        finally
        {
            await DeleteUserByEmailAsync(email);
        }
    }

    /// <summary>
    /// Verifies that a wallet transaction for a non-existent user returns false.
    /// </summary>
    [TestMethod]
    public async Task ProcessWalletTransactionAsync_InvalidUserId_ReturnsFalse()
    {
        bool result = await _db.ProcessWalletTransactionAsync(-1, "deposit", 100m, 100m);
        Assert.IsFalse(result);
    }

    // -----------------------------------------------------------------------
    // FetchLeaguesAsync
    // -----------------------------------------------------------------------

    /// <summary>
    /// Verifies that the leagues array contains at least one entry with a valid ID and non-empty name.
    /// </summary>
    [TestMethod]
    public async Task FetchLeaguesAsync_ReturnsNonEmptyArrayWithValidData()
    {
        League[] leagues = await _db.FetchLeaguesAsync();

        if (leagues.Length == 0)
        {
            Assert.Inconclusive("No leagues in seed database.");
        }

        foreach (League league in leagues)
        {
            if (league == null) continue;
            Assert.IsTrue(league.LeagueId > 0);
            Assert.IsFalse(string.IsNullOrWhiteSpace(league.Name));
        }
    }

    // -----------------------------------------------------------------------
    // FetchTeamsAsync
    // -----------------------------------------------------------------------

    /// <summary>
    /// Verifies that fetching teams in non-all mode returns only teams linked to scheduled games.
    /// </summary>
    [TestMethod]
    public async Task FetchTeamsAsync_ScheduledOnly_ReturnsTeamsInScheduledGames()
    {
        MyDictionary<int, Team> teams = await _db.FetchTeamsAsync(all: false);

        if (teams.Count == 0)
        {
            Assert.Inconclusive("No scheduled games in seed database.");
        }

        foreach ((int id, Team team) in teams)
        {
            Assert.AreEqual(id, team.TeamId);
            Assert.IsFalse(string.IsNullOrWhiteSpace(team.TeamName));
        }
    }

    /// <summary>
    /// Verifies that fetching all teams returns at least as many entries as the scheduled-only query.
    /// </summary>
    [TestMethod]
    public async Task FetchTeamsAsync_AllTeams_ReturnsAtLeastAsManyAsScheduledOnly()
    {
        MyDictionary<int, Team> scheduled = await _db.FetchTeamsAsync(all: false);
        MyDictionary<int, Team> all = await _db.FetchTeamsAsync(all: true);

        if (all.Count == 0)
        {
            Assert.Inconclusive("No teams in seed database.");
        }

        Assert.IsTrue(all.Count >= scheduled.Count);

        foreach ((int id, Team team) in all)
        {
            Assert.AreEqual(id, team.TeamId);
            Assert.IsFalse(string.IsNullOrWhiteSpace(team.TeamName));
        }
    }

    // -----------------------------------------------------------------------
    // FetchMatchesAsync
    // -----------------------------------------------------------------------

    /// <summary>
    /// Verifies that the match collection returned in non-all mode contains only matches with a Scheduled status.
    /// </summary>
    [TestMethod]
    public async Task FetchMatchesAsync_ScheduledOnly_ReturnsOnlyScheduledMatches()
    {
        FootballMatchCollection result = await _db.FetchMatchesAsync(all: false);

        if (result.AllMatches.Count == 0)
        {
            Assert.Inconclusive("No scheduled matches in seed database.");
        }

        foreach (FootballMatch match in result.AllMatches)
        {
            Assert.AreEqual("Scheduled", match.GameStatus);
            Assert.IsTrue(result.MatchesByLeague.ContainsKey(match.LeagueID));
        }
    }

    /// <summary>
    /// Verifies that fetching all matches returns at least as many entries as the scheduled-only query.
    /// </summary>
    [TestMethod]
    public async Task FetchMatchesAsync_AllMatches_ReturnsAtLeastAsManyAsScheduledOnly()
    {
        FootballMatchCollection scheduled = await _db.FetchMatchesAsync(all: false);
        FootballMatchCollection all = await _db.FetchMatchesAsync(all: true);

        if (all.AllMatches.Count == 0)
        {
            Assert.Inconclusive("No matches in seed database.");
        }

        Assert.IsTrue(all.AllMatches.Count >= scheduled.AllMatches.Count);
    }

    // -----------------------------------------------------------------------
    // FetchBetHistoryAsync
    // -----------------------------------------------------------------------

    /// <summary>
    /// Verifies that a newly registered user with no bet slips has an empty bet history.
    /// </summary>
    [TestMethod]
    public async Task FetchBetHistoryAsync_UserWithNoSlips_ReturnsEmptyList()
    {
        string email = $"dbtest_history_empty_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        try
        {
            var reg = await _db.RegisterAsync("History", "Empty", new DateTime(2000, 1, 1), email, password);
            Assert.IsNotNull(reg.userObj);

            MyList<BetHistorySlip> history = await _db.FetchBetHistoryAsync(reg.userObj!.UserID);

            Assert.IsNotNull(history);
            Assert.AreEqual(0, history.Count);
        }
        finally
        {
            await DeleteUserByEmailAsync(email);
        }
    }

    /// <summary>
    /// Verifies that a user with one saved bet slip has that slip and its bets returned in their history.
    /// </summary>
    [TestMethod]
    public async Task FetchBetHistoryAsync_UserWithSlip_ReturnsSlipWithBets()
    {
        string email = $"dbtest_history_slip_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        try
        {
            Odd? odd = await GetAnyScheduledOddAsync();
            if (odd == null)
            {
                Assert.Inconclusive("No scheduled odd in seed database for FetchBetHistoryAsync test.");
            }

            var reg = await _db.RegisterAsync("History", "WithSlip", new DateTime(2000, 1, 1), email, password);
            Assert.IsNotNull(reg.userObj);
            int userId = reg.userObj!.UserID;

            BetSlip slip = new BetSlip(userId) { Stake = 5m };
            slip.AddBet(new Bet(odd.OddID, odd.Selection, odd.OddValue, odd.BetTypeID, odd.GameID, DateTime.Today));
            await _db.SaveBetSlipAsync(slip);

            MyList<BetHistorySlip> history = await _db.FetchBetHistoryAsync(userId);

            Assert.IsNotNull(history);
            Assert.AreEqual(1, history.Count);
            Assert.AreEqual(userId, history[0].UserID);
            Assert.AreEqual(1, history[0].Bets.Count);
            Assert.AreEqual("Pending", history[0].Status);
            Assert.IsFalse(history[0].Claimed);
        }
        finally
        {
            await DeleteUserByEmailAsync(email);
        }
    }

    // -----------------------------------------------------------------------
    // FetchGameResultsAsync
    // -----------------------------------------------------------------------

    /// <summary>
    /// Verifies that passing null to FetchGameResultsAsync returns an empty result dictionary.
    /// </summary>
    [TestMethod]
    public async Task FetchGameResultsAsync_NullList_ReturnsEmptyDictionary()
    {
        MyDictionary<int, GameResult> results = await _db.FetchGameResultsAsync(null);
        Assert.IsNotNull(results);
        Assert.AreEqual(0, results.Count);
    }

    /// <summary>
    /// Verifies that passing an empty list to FetchGameResultsAsync returns an empty result dictionary.
    /// </summary>
    [TestMethod]
    public async Task FetchGameResultsAsync_EmptyList_ReturnsEmptyDictionary()
    {
        MyDictionary<int, GameResult> results = await _db.FetchGameResultsAsync(new MyList<int>());
        Assert.IsNotNull(results);
        Assert.AreEqual(0, results.Count);
    }

    /// <summary>
    /// Verifies that passing completed game IDs returns matching GameResult entries with valid score data.
    /// </summary>
    [TestMethod]
    public async Task FetchGameResultsAsync_ValidGameIds_ReturnsMatchedResults()
    {
        MyList<int> completedGameIds = await GetCompletedGameIdsAsync(5);
        if (completedGameIds.Count == 0)
        {
            Assert.Inconclusive("No completed games with results in seed database.");
        }

        MyDictionary<int, GameResult> results = await _db.FetchGameResultsAsync(completedGameIds);

        Assert.IsTrue(results.Count > 0);
        foreach ((int id, GameResult gr) in results)
        {
            Assert.IsTrue(completedGameIds.Contains(id));
            Assert.AreEqual(id, gr.GameId);
            Assert.IsTrue(gr.HomeTeamScore >= 0);
            Assert.IsTrue(gr.AwayTeamScore >= 0);
        }
    }

    /// <summary>
    /// Verifies that the all=true flag ignores the provided ID filter and returns all game results in the database.
    /// </summary>
    [TestMethod]
    public async Task FetchGameResultsAsync_AllTrue_IgnoresProvidedFilterAndReturnsAllResults()
    {
        MyList<int> completedGameIds = await GetCompletedGameIdsAsync(1);
        if (completedGameIds.Count == 0)
        {
            Assert.Inconclusive("No completed games with results in seed database.");
        }

        MyDictionary<int, GameResult> filtered = await _db.FetchGameResultsAsync(completedGameIds, all: false);
        MyDictionary<int, GameResult> allResults = await _db.FetchGameResultsAsync(completedGameIds, all: true);
        int totalResults = await GetGameResultCountAsync();

        Assert.IsTrue(filtered.Count > 0);
        Assert.IsTrue(allResults.Count >= filtered.Count);
        Assert.AreEqual(totalResults, allResults.Count);
        foreach (int gameId in filtered.Keys)
        {
            Assert.IsTrue(allResults.ContainsKey(gameId));
        }
    }

    // -----------------------------------------------------------------------
    // FetchPlayersAsync
    // -----------------------------------------------------------------------

    /// <summary>
    /// Verifies that players are returned grouped by team ID with valid normalized positions and non-empty names.
    /// </summary>
    [TestMethod]
    public async Task FetchPlayersAsync_ReturnsPlayersGroupedByTeam()
    {
        MyDictionary<int, MyList<Player>> players = await _db.FetchPlayersAsync();

        if (players.Count == 0)
        {
            Assert.Inconclusive("No players in seed database.");
        }

        string[] validPositions = { "ATT", "MID", "DEF", "GK" };

        foreach ((int teamId, MyList<Player> teamPlayers) in players)
        {
            Assert.IsTrue(teamPlayers.Count > 0);
            foreach (Player player in teamPlayers)
            {
                Assert.AreEqual(teamId, player.TeamId);
                Assert.IsFalse(string.IsNullOrWhiteSpace(player.Name));
                Assert.IsTrue(validPositions.Contains(player.Position),
                    $"Unexpected position '{player.Position}' for player '{player.Name}'");
            }
        }
    }

    // -----------------------------------------------------------------------
    // FetchLeagueTeamAsync
    // -----------------------------------------------------------------------

    /// <summary>
    /// Verifies that the league-team mapping dictionary contains valid league IDs and non-duplicate team ID lists.
    /// </summary>
    [TestMethod]
    public async Task FetchLeagueTeamAsync_ReturnsLeagueTeamMappings()
    {
        MyDictionary<int, MyList<int>> leagueTeams = await _db.FetchLeagueTeamAsync();

        if (leagueTeams.Count == 0)
        {
            Assert.Inconclusive("No LeagueTeam data in seed database.");
        }

        foreach ((int leagueId, MyList<int> teamIds) in leagueTeams)
        {
            Assert.IsTrue(leagueId > 0);
            Assert.IsTrue(teamIds.Count > 0);
            Assert.AreEqual(teamIds.Count, teamIds.Distinct().Count(), "Duplicate team IDs found in league.");
        }
    }

    // -----------------------------------------------------------------------
    // AddNewMatchAsync
    // -----------------------------------------------------------------------

    /// <summary>
    /// Verifies that adding a new match persists the game, its result, and generated odds to the database.
    /// </summary>
    [TestMethod]
    public async Task AddNewMatchAsync_ValidMatchAndResult_PersistsAndReturnsTrue()
    {
        var leagueTeams = await _db.FetchLeagueTeamAsync();
        if (leagueTeams.Count == 0)
        {
            Assert.Inconclusive("No league-team data in seed database for AddNewMatchAsync test.");
        }

        int leagueId = leagueTeams.Keys.First();
        MyList<int> teams = leagueTeams[leagueId];
        if (teams.Count < 2)
        {
            Assert.Inconclusive("Not enough teams in league for AddNewMatchAsync test.");
        }

        FootballMatch newMatch = new FootballMatch(0, leagueId, teams[0], teams[1], DateTime.Now.AddDays(30));
        GameResult result = new GameResult(0, 2, 1, 4, 0, 3, null, null);

        int? insertedGameId = null;
        try
        {
            bool success = await _db.AddNewMatchAsync(newMatch, result);

            Assert.IsTrue(success);
            Assert.IsTrue(newMatch.GameID > 0, "GameID should be set on the match object after insert.");
            insertedGameId = newMatch.GameID;
            Assert.AreEqual(insertedGameId.Value, result.GameId);

            FootballMatchCollection all = await _db.FetchMatchesAsync(all: true);
            GameResult? savedResult = await GetGameResultByGameIdAsync(insertedGameId.Value);
            int generatedOddsCount = await GetOddsCountByGameIdAsync(insertedGameId.Value);

            Assert.IsTrue(all.AllMatches.Any(m => m.GameID == insertedGameId));
            Assert.IsNotNull(savedResult);
            Assert.AreEqual(2, savedResult!.HomeTeamScore);
            Assert.AreEqual(1, savedResult.AwayTeamScore);
            Assert.AreEqual(4, savedResult.TotalCorners);
            Assert.IsTrue(generatedOddsCount > 0);
        }
        finally
        {
            if (insertedGameId.HasValue)
            {
                await DeleteMatchByIdAsync(insertedGameId.Value);
            }
        }
    }

    // -----------------------------------------------------------------------
    // WrapTableUpdatesAsync
    // -----------------------------------------------------------------------

    /// <summary>
    /// Verifies that all four output collections are non-null when no games are scheduled for today.
    /// </summary>
    [TestMethod]
    public async Task WrapTableUpdatesAsync_WhenNoGamesToday_ReturnsEmptyCollections()
    {
        var (startedGames, completedGames, updatedBets, updatedSlips) = await _db.WrapTableUpdatesAsync();

        Assert.IsNotNull(startedGames);
        Assert.IsNotNull(completedGames);
        Assert.IsNotNull(updatedBets);
        Assert.IsNotNull(updatedSlips);
    }

    // -----------------------------------------------------------------------
    // Additional helpers for new tests
    // -----------------------------------------------------------------------

    private static async Task<decimal> GetWalletBalanceAsync(int userId)
    {
        const string query = "SELECT wallet_balance FROM AppUser WHERE app_user_id = @id";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", userId);

        await connection.OpenAsync();
        return Convert.ToDecimal(await command.ExecuteScalarAsync());
    }

    private static async Task<bool> TransactionRowExistsAsync(int userId, string type, decimal amount)
    {
        const string query = "SELECT COUNT(*) FROM SystemTransaction WHERE app_user_id = @id AND transaction_type = @type AND amount = @amount";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", userId);
        command.Parameters.AddWithValue("@type", type);
        command.Parameters.AddWithValue("@amount", amount);

        await connection.OpenAsync();
        return Convert.ToInt32(await command.ExecuteScalarAsync()) > 0;
    }

    private static async Task<bool> IsSlipClaimedAsync(int slipId)
    {
        const string query = "SELECT claimed FROM BetSlip WHERE slip_id = @id";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", slipId);

        await connection.OpenAsync();
        return Convert.ToBoolean(await command.ExecuteScalarAsync());
    }

    private static async Task<MyList<int>> GetCompletedGameIdsAsync(int top)
    {
        string query = $"SELECT TOP {top} gr.game_id FROM GameResult gr INNER JOIN Game g ON g.game_id = gr.game_id WHERE g.game_status = 'Completed'";
        MyList<int> ids = new MyList<int>();

        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);

        await connection.OpenAsync();
        await using SqlDataReader reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            ids.Add(Convert.ToInt32(reader["game_id"]));
        }

        return ids;
    }

    private static async Task DeleteMatchByIdAsync(int gameId)
    {
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await connection.OpenAsync();
        await using SqlTransaction tx = connection.BeginTransaction();

        try
        {
            string deleteBets = "DELETE FROM Bet WHERE slip_id IN (SELECT slip_id FROM BetSlip WHERE slip_id IN (SELECT slip_id FROM Bet b INNER JOIN Odd o ON b.odd_id = o.odd_id WHERE o.game_id = @id))";
            await using (SqlCommand cmd = new SqlCommand(deleteBets, connection, tx))
            {
                cmd.Parameters.AddWithValue("@id", gameId);
                await cmd.ExecuteNonQueryAsync();
            }

            string deleteOdds = "DELETE FROM Odd WHERE game_id = @id";
            await using (SqlCommand cmd = new SqlCommand(deleteOdds, connection, tx))
            {
                cmd.Parameters.AddWithValue("@id", gameId);
                await cmd.ExecuteNonQueryAsync();
            }

            string deleteResult = "DELETE FROM GameResult WHERE game_id = @id";
            await using (SqlCommand cmd = new SqlCommand(deleteResult, connection, tx))
            {
                cmd.Parameters.AddWithValue("@id", gameId);
                await cmd.ExecuteNonQueryAsync();
            }

            string deleteGame = "DELETE FROM Game WHERE game_id = @id";
            await using (SqlCommand cmd = new SqlCommand(deleteGame, connection, tx))
            {
                cmd.Parameters.AddWithValue("@id", gameId);
                await cmd.ExecuteNonQueryAsync();
            }

            await tx.CommitAsync();
        }
        catch
        {
            await tx.RollbackAsync();
            throw;
        }
    }

    /// <summary>
    /// Verifies that a temporarily inserted game without odds appears in the GetMatchesWithoutOdds result.
    /// </summary>
    [TestMethod]
    public async Task GetMatchesWithoutOdds_WithTemporaryGame_IncludesInsertedGame()
    {
        var leagueTeams = await GetLeagueWithTwoRatedTeamsAsync();
        if (leagueTeams == null)
        {
            Assert.Inconclusive("No two rated teams from the same league were found for GetMatchesWithoutOdds test.");
        }

        int gameId = await InsertTemporaryGameAsync(leagueTeams!.Value.LeagueId, leagueTeams.Value.HomeTeamId, leagueTeams.Value.AwayTeamId);
        try
        {
            List<GameInfo> matchesWithoutOdds = await _db.GetMatchesWithoutOdds();
            GameInfo? insertedGame = matchesWithoutOdds.FirstOrDefault(x => x.GameId == gameId);

            Assert.IsNotNull(insertedGame);
            Assert.AreEqual(leagueTeams.Value.HomeTeamId, insertedGame!.HomeTeamId);
            Assert.AreEqual(leagueTeams.Value.AwayTeamId, insertedGame.AwayTeamId);
            Assert.AreEqual(leagueTeams.Value.LeagueId, insertedGame.LeagueId);
            Assert.IsFalse(string.IsNullOrWhiteSpace(insertedGame.HomeTeamName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(insertedGame.AwayTeamName));
        }
        finally
        {
            await DeleteMatchByIdAsync(gameId);
        }
    }

    /// <summary>
    /// Verifies that saving the same selection twice within a transaction upserts to keep only the latest odd value.
    /// </summary>
    [TestMethod]
    public async Task SaveOddsAsync_WithSharedConnection_UpsertsSingleSelection()
    {
        var leagueTeams = await GetLeagueWithTwoRatedTeamsAsync();
        if (leagueTeams == null)
        {
            Assert.Inconclusive("No two rated teams from the same league were found for SaveOddsAsync test.");
        }

        int gameId = await InsertTemporaryGameAsync(leagueTeams!.Value.LeagueId, leagueTeams.Value.HomeTeamId, leagueTeams.Value.AwayTeamId);
        const int betTypeId = 1;
        const string selection = "Home Win";

        try
        {
            await using SqlConnection connection = new SqlConnection(GetConnectionString());
            await connection.OpenAsync();
            await using SqlTransaction tx = connection.BeginTransaction();

            await _db.SaveOddsAsync(new[] { new GeneratedOdd(gameId, betTypeId, selection, 1.75m) }, connection, tx);
            await _db.SaveOddsAsync(new[] { new GeneratedOdd(gameId, betTypeId, selection, 2.35m) }, connection, tx);

            await tx.CommitAsync();

            int rows = await GetOddsCountByGameBetTypeAndSelectionAsync(gameId, betTypeId, selection);
            decimal? latestValue = await GetOddValueAsync(gameId, betTypeId, selection);

            Assert.AreEqual(1, rows);
            Assert.AreEqual(2.35m, latestValue);
        }
        finally
        {
            await DeleteMatchByIdAsync(gameId);
        }
    }

    /// <summary>
    /// Verifies that passing an empty collection to SaveOddsAsync inserts no rows.
    /// </summary>
    [TestMethod]
    public async Task SaveOddsAsync_EmptyCollection_DoesNotInsertRows()
    {
        var leagueTeams = await GetLeagueWithTwoRatedTeamsAsync();
        if (leagueTeams == null)
        {
            Assert.Inconclusive("No two rated teams from the same league were found for SaveOddsAsync empty-input test.");
        }

        int gameId = await InsertTemporaryGameAsync(leagueTeams!.Value.LeagueId, leagueTeams.Value.HomeTeamId, leagueTeams.Value.AwayTeamId);

        try
        {
            int before = await GetOddsCountByGameIdAsync(gameId);

            await _db.SaveOddsAsync(Array.Empty<GeneratedOdd>());

            int after = await GetOddsCountByGameIdAsync(gameId);

            Assert.AreEqual(before, after);
            Assert.AreEqual(0, after);
        }
        finally
        {
            await DeleteMatchByIdAsync(gameId);
        }
    }

    /// <summary>
    /// Verifies that generating and saving a correct-score odd persists the expected selection and value.
    /// </summary>
    [TestMethod]
    public async Task GenerateAndSaveCorrectScoreOddAsync_PersistsExpectedCorrectScoreSelection()
    {
        var leagueTeams = await GetLeagueWithTwoRatedTeamsAsync();
        if (leagueTeams == null)
        {
            Assert.Inconclusive("No two rated teams from the same league were found for GenerateAndSaveCorrectScoreOddAsync test.");
        }

        int gameId = await InsertTemporaryGameAsync(leagueTeams!.Value.LeagueId, leagueTeams.Value.HomeTeamId, leagueTeams.Value.AwayTeamId);
        const int homeGoals = 2;
        const int awayGoals = 1;
        string selection = $"{homeGoals}-{awayGoals}";

        try
        {
            decimal generatedOdd = await _db.GenerateAndSaveCorrectScoreOddAsync(
                gameId,
                homeGoals,
                awayGoals,
                leagueTeams.Value.HomeTeamId,
                leagueTeams.Value.AwayTeamId,
                leagueTeams.Value.LeagueId);

            decimal? savedOdd = await GetOddValueAsync(gameId, 3, selection);

            Assert.IsTrue(generatedOdd > 0m);
            Assert.IsNotNull(savedOdd);
            Assert.AreEqual(generatedOdd, savedOdd!.Value);
        }
        finally
        {
            await DeleteMatchByIdAsync(gameId);
        }
    }

    /// <summary>
    /// Verifies that all generated odds for a new game are persisted with the correct game ID and distinct selections.
    /// </summary>
    [TestMethod]
    public async Task GenerateAndSaveAllOddsAsync_PersistsReturnedOddsForNewGame()
    {
        var leagueTeams = await GetLeagueWithTwoRatedTeamsAsync();
        if (leagueTeams == null)
        {
            Assert.Inconclusive("No two rated teams from the same league were found for GenerateAndSaveAllOddsAsync test.");
        }

        int gameId = await InsertTemporaryGameAsync(leagueTeams!.Value.LeagueId, leagueTeams.Value.HomeTeamId, leagueTeams.Value.AwayTeamId);

        try
        {
            IReadOnlyList<GeneratedOdd> generated = await _db.GenerateAndSaveAllOddsAsync(
                gameId,
                leagueTeams.Value.HomeTeamId,
                leagueTeams.Value.AwayTeamId,
                leagueTeams.Value.LeagueId);

            int persistedRows = await GetOddsCountByGameIdAsync(gameId);
            int distinctSelections = generated.Select(x => (x.BetTypeId, x.Selection)).Distinct().Count();

            Assert.IsTrue(generated.Count > 0);
            Assert.IsTrue(generated.All(x => x.GameId == gameId));
            Assert.AreEqual(distinctSelections, persistedRows);
        }
        finally
        {
            await DeleteMatchByIdAsync(gameId);
        }
    }

    /// <summary>
    /// Verifies that all returned player positions are normalized to one of the four expected values.
    /// </summary>
    [TestMethod]
    public async Task GetPlayersAsync_ReturnsNormalizedPlayerPositions()
    {
        MyDictionary<int, MyList<PlayerInfo>> players = await _db.GetPlayersAsync();

        if (players.Count == 0)
        {
            Assert.Inconclusive("No Player/PlayerRating data in seed database.");
        }

        string[] validPositions = { "ATT", "MID", "DEF", "GK" };

        foreach ((int teamId, MyList<PlayerInfo> teamPlayers) in players)
        {
            Assert.IsTrue(teamPlayers.Count > 0);
            foreach (PlayerInfo player in teamPlayers)
            {
                Assert.AreEqual(teamId, player.TeamId);
                Assert.IsFalse(string.IsNullOrWhiteSpace(player.PlayerName));
                Assert.IsTrue(validPositions.Contains(player.Position),
                    $"Unexpected normalized position '{player.Position}' for player '{player.PlayerName}'");
            }
        }
    }

    /// <summary>
    /// Verifies that financial summary totals increase by the expected amounts after inserting test transactions and a bet slip.
    /// </summary>
    [TestMethod]
    public async Task FetchFinancialSummaryAsync_WithNewTransactionsAndSlip_ReflectsExpectedDeltas()
    {
        FinancialSummary baseline = await _db.FetchFinancialSummaryAsync();

        string email = $"dbtest_financial_summary_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        try
        {
            var reg = await _db.RegisterAsync("Finance", "Summary", new DateTime(2000, 1, 1), email, password);
            Assert.IsNotNull(reg.userObj);
            int userId = reg.userObj!.UserID;

            await SetUserStatusAsync(email, "Active");

            await InsertSystemTransactionAsync(userId, "deposit", 50m, DateTime.Now);
            await InsertSystemTransactionAsync(userId, "withdrawal", 20m, DateTime.Now);
            await InsertSystemTransactionAsync(userId, "bet", 30m, DateTime.Now);
            await InsertSystemTransactionAsync(userId, "payout", 10m, DateTime.Now);
            await InsertBetSlipWithStatusAsync(userId, "Pending");

            FinancialSummary after = await _db.FetchFinancialSummaryAsync();

            Assert.AreEqual(baseline.TotalDeposits + 50m, after.TotalDeposits);
            Assert.AreEqual(baseline.TotalWithdrawals + 20m, after.TotalWithdrawals);
            Assert.AreEqual(baseline.TotalRevenue + 20m, after.TotalRevenue);
            Assert.AreEqual(baseline.TotalBetsPlaced + 1, after.TotalBetsPlaced);
            Assert.IsTrue(after.TotalActiveUsers >= baseline.TotalActiveUsers + 1);
        }
        finally
        {
            await DeleteUserByEmailAsync(email);
        }
    }

    /// <summary>
    /// Verifies that the current month's revenue and payout figures increase by the expected amounts after inserting test transactions.
    /// </summary>
    [TestMethod]
    public async Task FetchMonthlyProfitLossAsync_WithCurrentMonthTransactions_IncludesExpectedIncrements()
    {
        string currentMonth = await GetCurrentMonthLabelAsync();
        MyList<MonthlyProfitLoss> baseline = await _db.FetchMonthlyProfitLossAsync();
        decimal baselineRevenue = GetMonthlyRevenue(baseline, currentMonth);
        decimal baselinePayouts = GetMonthlyPayouts(baseline, currentMonth);

        string email = $"dbtest_monthly_pl_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        try
        {
            var reg = await _db.RegisterAsync("Finance", "ProfitLoss", new DateTime(2000, 1, 1), email, password);
            Assert.IsNotNull(reg.userObj);
            int userId = reg.userObj!.UserID;

            await InsertSystemTransactionAsync(userId, "bet", 42m, DateTime.Now);
            await InsertSystemTransactionAsync(userId, "payout", 13m, DateTime.Now);

            MyList<MonthlyProfitLoss> after = await _db.FetchMonthlyProfitLossAsync();
            decimal afterRevenue = GetMonthlyRevenue(after, currentMonth);
            decimal afterPayouts = GetMonthlyPayouts(after, currentMonth);

            Assert.AreEqual(baselineRevenue + 42m, afterRevenue);
            Assert.AreEqual(baselinePayouts + 13m, afterPayouts);
        }
        finally
        {
            await DeleteUserByEmailAsync(email);
        }
    }

    /// <summary>
    /// Verifies that each transaction type's monthly volume total increases by the expected amount after inserting test rows.
    /// </summary>
    [TestMethod]
    public async Task FetchMonthlyTransactionVolumeAsync_WithCurrentMonthTransactions_IncludesTypeTotals()
    {
        string currentMonth = await GetCurrentMonthLabelAsync();
        MyList<MonthlyTransactionVolume> baseline = await _db.FetchMonthlyTransactionVolumeAsync();

        decimal baseDeposit = GetMonthlyTransactionAmount(baseline, currentMonth, "deposit");
        decimal baseWithdrawal = GetMonthlyTransactionAmount(baseline, currentMonth, "withdrawal");
        decimal baseBet = GetMonthlyTransactionAmount(baseline, currentMonth, "bet");
        decimal basePayout = GetMonthlyTransactionAmount(baseline, currentMonth, "payout");

        string email = $"dbtest_monthly_tv_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        try
        {
            var reg = await _db.RegisterAsync("Finance", "Volume", new DateTime(2000, 1, 1), email, password);
            Assert.IsNotNull(reg.userObj);
            int userId = reg.userObj!.UserID;

            await InsertSystemTransactionAsync(userId, "deposit", 60m, DateTime.Now);
            await InsertSystemTransactionAsync(userId, "withdrawal", 25m, DateTime.Now);
            await InsertSystemTransactionAsync(userId, "bet", 15m, DateTime.Now);
            await InsertSystemTransactionAsync(userId, "payout", 5m, DateTime.Now);

            MyList<MonthlyTransactionVolume> after = await _db.FetchMonthlyTransactionVolumeAsync();

            Assert.AreEqual(baseDeposit + 60m, GetMonthlyTransactionAmount(after, currentMonth, "deposit"));
            Assert.AreEqual(baseWithdrawal + 25m, GetMonthlyTransactionAmount(after, currentMonth, "withdrawal"));
            Assert.AreEqual(baseBet + 15m, GetMonthlyTransactionAmount(after, currentMonth, "bet"));
            Assert.AreEqual(basePayout + 5m, GetMonthlyTransactionAmount(after, currentMonth, "payout"));
        }
        finally
        {
            await DeleteUserByEmailAsync(email);
        }
    }

    /// <summary>
    /// Verifies that inserting bet slips with different statuses causes each status count to increase by one.
    /// </summary>
    [TestMethod]
    public async Task FetchBetStatusBreakdownAsync_WithInsertedStatuses_ReturnsUpdatedCounts()
    {
        string email = $"dbtest_bet_status_{Guid.NewGuid():N}@gmail.com";
        const string password = "StrongPassword123!";

        await DeleteUserByEmailAsync(email);

        try
        {
            var reg = await _db.RegisterAsync("Finance", "Status", new DateTime(2000, 1, 1), email, password);
            Assert.IsNotNull(reg.userObj);
            int userId = reg.userObj!.UserID;

            MyList<BetStatusCount> before = await _db.FetchBetStatusBreakdownAsync();

            await InsertBetSlipWithStatusAsync(userId, "Pending");
            await InsertBetSlipWithStatusAsync(userId, "Won");
            await InsertBetSlipWithStatusAsync(userId, "Lost");

            MyList<BetStatusCount> after = await _db.FetchBetStatusBreakdownAsync();

            Assert.AreEqual(
                GetBetStatusCount(before, "Pending") + 1,
                GetBetStatusCount(after, "Pending") 
            );
            Assert.AreEqual(
                GetBetStatusCount(before, "Won") + 1,
                GetBetStatusCount(after, "Won")
            );
            Assert.AreEqual(
                GetBetStatusCount(before, "Lost") + 1,
                GetBetStatusCount(after, "Lost")
            );
        }
        finally
        {
            await DeleteUserByEmailAsync(email);
        }
    }

    private static async Task<string> GetCurrentMonthLabelAsync()
    {
        const string query = "SELECT FORMAT(GETDATE(), 'MMM yy')";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        await connection.OpenAsync();
        return (await command.ExecuteScalarAsync())?.ToString() ?? string.Empty;
    }

    private static decimal GetMonthlyRevenue(MyList<MonthlyProfitLoss> rows, string month)
    {
        for (int i = 0; i < rows.Count; i++)
        {
            MonthlyProfitLoss row = rows[i];
            if (row.Month == month) return row.Revenue;
        }

        return 0m;
    }

    private static decimal GetMonthlyPayouts(MyList<MonthlyProfitLoss> rows, string month)
    {
        for (int i = 0; i < rows.Count; i++)
        {
            MonthlyProfitLoss row = rows[i];
            if (row.Month == month) return row.Payouts;
        }

        return 0m;
    }

    private static decimal GetMonthlyTransactionAmount(MyList<MonthlyTransactionVolume> rows, string month, string type)
    {
        for (int i = 0; i < rows.Count; i++)
        {
            MonthlyTransactionVolume row = rows[i];
            if (row.Month == month && string.Equals(row.Type, type, StringComparison.OrdinalIgnoreCase))
            {
                return row.Amount;
            }
        }

        return 0m;
    }

    private static int GetBetStatusCount(MyList<BetStatusCount> rows, string status)
    {
        for (int i = 0; i < rows.Count; i++)
        {
            BetStatusCount row = rows[i];
            if (string.Equals(row.Status, status, StringComparison.OrdinalIgnoreCase))
            {
                return row.Count;
            }
        }

        return 0;
    }

    private static async Task InsertSystemTransactionAsync(int userId, string transactionType, decimal amount, DateTime timestamp)
    {
        const string query = @"INSERT INTO SystemTransaction (app_user_id, transaction_type, amount, transaction_timestamp)
                               VALUES (@userId, @type, @amount, @timestamp)";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@userId", userId);
        command.Parameters.AddWithValue("@type", transactionType);
        command.Parameters.AddWithValue("@amount", amount);
        command.Parameters.AddWithValue("@timestamp", timestamp);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }

    private static async Task InsertBetSlipWithStatusAsync(int userId, string status)
    {
        const string query = @"INSERT INTO BetSlip (app_user_id, bet_status, total_odds, stake, payout, claimed)
                               VALUES (@userId, @status, @totalOdds, @stake, @payout, @claimed)";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@userId", userId);
        command.Parameters.AddWithValue("@status", status);
        command.Parameters.AddWithValue("@totalOdds", 1m);
        command.Parameters.AddWithValue("@stake", 1m);
        command.Parameters.AddWithValue("@payout", 1m);
        command.Parameters.AddWithValue("@claimed", false);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }

    private static async Task<int> GetOddsCountByGameBetTypeAndSelectionAsync(int gameId, int betTypeId, string selection)
    {
        const string query = "SELECT COUNT(*) FROM Odd WHERE game_id = @gameId AND bet_type_id = @betTypeId AND selection = @selection";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@gameId", gameId);
        command.Parameters.AddWithValue("@betTypeId", betTypeId);
        command.Parameters.AddWithValue("@selection", selection);

        await connection.OpenAsync();
        return Convert.ToInt32(await command.ExecuteScalarAsync());
    }

    private static async Task<decimal?> GetOddValueAsync(int gameId, int betTypeId, string selection)
    {
        const string query = "SELECT TOP 1 odd_value FROM Odd WHERE game_id = @gameId AND bet_type_id = @betTypeId AND selection = @selection";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@gameId", gameId);
        command.Parameters.AddWithValue("@betTypeId", betTypeId);
        command.Parameters.AddWithValue("@selection", selection);

        await connection.OpenAsync();
        object? value = await command.ExecuteScalarAsync();
        return value == null ? null : Convert.ToDecimal(value);
    }

    private static async Task<(int LeagueId, int HomeTeamId, int AwayTeamId)?> GetLeagueWithTwoRatedTeamsAsync()
    {
        const string query = @"SELECT TOP 1 tr1.league_id AS league_id, tr1.team_id AS home_team_id, tr2.team_id AS away_team_id
                               FROM TeamRating tr1
                               INNER JOIN TeamRating tr2 ON tr1.league_id = tr2.league_id AND tr1.team_id < tr2.team_id
                               ORDER BY tr1.league_id, tr1.team_id, tr2.team_id";

        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);

        await connection.OpenAsync();
        await using SqlDataReader reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
        {
            return null;
        }

        return (
            Convert.ToInt32(reader["league_id"]),
            Convert.ToInt32(reader["home_team_id"]),
            Convert.ToInt32(reader["away_team_id"])
        );
    }

    private static async Task<int> InsertTemporaryGameAsync(int leagueId, int homeTeamId, int awayTeamId)
    {
        const string query = @"INSERT INTO Game (league_id, home_team_id, away_team_id, game_date)
                               OUTPUT INSERTED.game_id
                               VALUES (@leagueId, @homeTeamId, @awayTeamId, @gameDate)";
        await using SqlConnection connection = new SqlConnection(GetConnectionString());
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@leagueId", leagueId);
        command.Parameters.AddWithValue("@homeTeamId", homeTeamId);
        command.Parameters.AddWithValue("@awayTeamId", awayTeamId);
        command.Parameters.AddWithValue("@gameDate", DateTime.UtcNow.AddDays(14));

        await connection.OpenAsync();
        return Convert.ToInt32(await command.ExecuteScalarAsync());
    }
}
