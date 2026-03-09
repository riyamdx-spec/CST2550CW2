using BettingSystem.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace BettingSystem.Data
{
    // class to read from or write to database
    public class DatabaseManager
    {
        private readonly string connectionString;

        public DatabaseManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BettingDB"].ConnectionString;
        }

        //to login
        public async Task<(AppUser? userObj, string message)> LoginAsync(string email, string password)
        {
            //fetch user's data
            string query = "SELECT app_user_id, first_name, last_name, email, dob, wallet_balance, password_hash, user_role, user_status FROM AppUser WHERE email = @email";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@email", email);
                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        //check if an account was found
                        if (!await reader.ReadAsync())
                            return (null, "Incorrect Email or Password");

                        //user's hashed password
                        string storedHashedPassword = reader["password_hash"].ToString()!;

                        //check password
                        if (!ComparePassword(password, storedHashedPassword))
                        {
                            return (null, "Incorrect Email or Password");
                        }

                        //check status
                        string status = reader["user_status"].ToString()!;
                        if (status != "active")
                        {
                            return (null, $"Your account has been {status}. Please contact admin@gmail.com for support.");
                        }

                        //create user object if they are not banned or suspended
                        AppUser loggedInUser = new AppUser(
                            Convert.ToInt32(reader["app_user_id"]),
                            reader["first_name"].ToString()!,
                            reader["last_name"].ToString()!,
                            Convert.ToDateTime(reader["dob"]),
                            reader["email"].ToString()!,
                            Convert.ToDecimal(reader["wallet_balance"]),
                            reader["user_role"].ToString()!
                         );

                        return (loggedInUser, "Logged In Successfully");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Database error: {e.Message}");
                    return (null, "Login Failed. Please try again.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return (null, "Login Failed. Please try again.");
                }
            }
        }

        //register new user
        public async Task<(AppUser? userObj, string message)> RegisterAsync(string firstName, string lastName, DateTime dob, string email, string password)
        {
            try
            {
                string hashPassword = HashPassword(password);
                AppUser registeredUser = await AddNewUserAsync(firstName, lastName, dob, email, hashPassword);
                return (registeredUser, "Registered Successfully");
            }
            catch (SqlException e)
            {
                if (e.Number == 2627) //check if email already exists in database
                {
                    return (null, "This email is already linked to an existing account");
                }

                Console.WriteLine($"Database error: {e.Message}");
                return (null, "Registration Failed. Please try again.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return (null, "Registration Failed. Please try again.");
            }

        }

        // add new user to database and return User object
        private async Task<AppUser> AddNewUserAsync(string firstName, string lastName, DateTime dob, string email, string password)
        {
            int userId;
            string query = "INSERT INTO AppUser (first_name, last_name, dob, email, password_hash) OUTPUT INSERTED.app_user_id VALUES (@firstName, @lastName, @dob, @email, @password)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@dob", dob);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);

                await connection.OpenAsync();

                //get app_user_id
                userId = (int)await command.ExecuteScalarAsync();
                return new AppUser(userId, firstName, lastName, dob, email, 0, "user");
            }
        }

        //update user details in table AppUser
        public async Task<(bool valid, string message)> UpdateUserDetailsAsync(int userID, string firstName, string lastName, string email)
        {
            string query = "UPDATE AppUser SET first_name=@firstName, last_name=@lastName, email=@mail WHERE app_user_id=@userID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@mail", email);
                command.Parameters.AddWithValue("@userID", userID);

                try
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    return (true, "Profile updated successfully");
                }
                catch (SqlException e)
                {
                    if (e.Number == 2627) //check if email already exists in table
                    {
                        return (false, "This email is already linked to an existing account");
                    }
                    else
                    {
                        Console.WriteLine($"Database error: {e.Message}");
                        return (false, "Unable to update your profile. Please try again.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return (false, "Unable to update your profile. Please try again."); ;
                }
            }
        }

        // change user's password
        public async Task<(bool valid, string message)> ChangePasswordAsync(string currentPasswordEntered, string newPassword, int userID)
        {
            try
            {
                //fetch current password
                string? currentHashedPassword = await FetchPasswordAsync(userID);
                if (currentHashedPassword == null)
                {
                    return (false, "Unable to change your password. Please try again.");
                }

                //check if old password entered is correct
                if (!ComparePassword(currentPasswordEntered, currentHashedPassword))
                {
                    return (false, "Password entered does not match your current password");
                }

                //check if new password is same as old one
                if (ComparePassword(newPassword, currentHashedPassword))
                {
                    return (false, "New password cannot be the same as your current password");
                }

                //hash new password
                string newHashPassword = HashPassword(newPassword);

                //change password in database
                bool updated = await UpdatePasswordAsync(userID, newHashPassword);
                if (updated)
                    return (true, "Password changed successfully");

                return (false, "Password could not be updated");
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Database error: {e.Message}");
                return (false, "Unable to change your password. Please try again.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return (false, "Unable to change your password. Please try again.");
            }
        }

        //update password in database
        public async Task<bool> UpdatePasswordAsync(int userID, string newHashPassword)
        {
            string query = "UPDATE AppUser SET password_hash=@newHashPassword WHERE app_user_id=@userID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@newHashPassword", newHashPassword);
                command.Parameters.AddWithValue("@userID", userID);

                await connection.OpenAsync();

                int changedRows = await command.ExecuteNonQueryAsync();
                return changedRows > 0;
            }
        }


        // fetch user's current password
        public async Task<string?> FetchPasswordAsync(int userID)
        {
            //fetch user's password
            string query = "SELECT password_hash FROM AppUser WHERE app_user_id = @userID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@userID", userID);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())

                {
                    if (await reader.ReadAsync())
                    {
                        return reader["password_hash"].ToString()!;
                    }
                    return null;
                }
            }
        }

        //hash password 
        private string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, 100000, HashAlgorithmName.SHA256, 20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        //compare stored password and password entered
        private bool ComparePassword(string password, string storedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(storedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, 100000, HashAlgorithmName.SHA256, 20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        //update wallet balance and record transaction
        public async Task<bool> ProcessWalletTransactionAsync(int userId, string transactionType, decimal newWalletAmount, decimal transactionAmount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        //update user's wallet balance in database
                        string updateWalletQuery = "UPDATE AppUser SET wallet_balance=@new_amount WHERE app_user_id=@userID";
                        using (SqlCommand updateWalletCmd = new SqlCommand(updateWalletQuery, connection, transaction))
                        {
                            updateWalletCmd.Parameters.AddWithValue("@new_amount", newWalletAmount);
                            updateWalletCmd.Parameters.AddWithValue("@userID", userId);
                            int changedRows = await updateWalletCmd.ExecuteNonQueryAsync();

                            //check if a row was affected
                            if (changedRows <= 0)
                                throw new Exception("Wallet Update Failed");
                        }

                        // record transaction
                        string recordTransactionQuery = "INSERT INTO SystemTransaction (app_user_id, transaction_type, amount) VALUES (@userID, @type, @amount)";
                        using (SqlCommand recordTransactionCmd = new SqlCommand(recordTransactionQuery, connection, transaction))
                        {
                            recordTransactionCmd.Parameters.AddWithValue("@userID", userId);
                            recordTransactionCmd.Parameters.AddWithValue("@type", transactionType);
                            recordTransactionCmd.Parameters.AddWithValue("@amount", transactionAmount);

                            int insertedRow = await recordTransactionCmd.ExecuteNonQueryAsync();

                            //check if transaction record was inserted
                            if (insertedRow <= 0)
                                throw new Exception("Transaction Recording Failed");
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error: {e.Message}");
                        return false;
                    }
                }
            }
        }

        //fetch leagues from database
        public async Task<League[]> FetchLeaguesAsync()
        {
            //array to store leagues
            League[] leagues = new League[5];

            //fetch leagues info
            string query = "SELECT * FROM League";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync();
                    int index = 0;
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            League leagueObj = new League(
                                Convert.ToInt32(reader["league_id"]), 
                                reader["league_name"].ToString()!, 
                                reader["logo_path"].ToString() ?? ""
                            );

                            //add to array
                            leagues[index] = leagueObj;
                            index++;
                        }
                    }
                    return leagues;
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Database error: {e.Message}");
                    return [];
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return [];
                }
            }
        }

        //fetch teams info from database
        public async Task<Dictionary<int, Team>> FetchTeamsAsync()
        {
            //store teams in dictionary keyed by id
            Dictionary<int, Team> teamsByID = new Dictionary<int, Team>();

            string query = "SELECT * FROM Team";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int teamID = Convert.ToInt32(reader["team_id"]);
                            Team teamObj = new Team(
                                teamID,
                                reader["team_name"].ToString()!,
                                reader["logo_path"].ToString()!
                            );
                            teamsByID[teamID] = teamObj;
                        }
                    }
                    return teamsByID;
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Database error: {e.Message}");
                    return new Dictionary<int, Team>();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new Dictionary<int, Team>();
                }
            }
        }
        // fetch matches from database
        public async Task<FootballMatchCollection> FetchMatchesAsync()
        {
            //list to store matches in chronological order
            SortedSet<FootballMatch> matches = new SortedSet<FootballMatch>(new FootballMatchKeyComparer());

            //dictionary for league filtering
            Dictionary<int, SortedSet<FootballMatch>> matchesByLeague = new Dictionary<int, SortedSet<FootballMatch>>();

            //fetch upcoming matches in ascending order of date
            string query = "SELECT * FROM Game WHERE game_status='Scheduled' ORDER BY game_date ASC";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int leagueID = Convert.ToInt32(reader["league_id"]);

                            FootballMatch matchObj = new FootballMatch(
                                Convert.ToInt32(reader["game_id"]),
                                leagueID,
                                Convert.ToInt32(reader["home_team_id"]),
                                Convert.ToInt32(reader["away_team_id"]),
                                Convert.ToDateTime(reader["game_date"]),
                                reader["game_status"].ToString()!,
                                reader["home_team_score"] as int?,
                                reader["away_team_score"] as int?
                            );

                            matches.Add(matchObj);

                            //check if a sorted set exist for the league
                            if (!matchesByLeague.TryGetValue(leagueID, out var leagueMatches))
                            {
                                leagueMatches = new SortedSet<FootballMatch>(new FootballMatchKeyComparer());
                                matchesByLeague[leagueID] = leagueMatches;
                            }
                            //add match in the sorted set for that league
                            matchesByLeague[leagueID].Add(matchObj);
                        }
                    }
                    return new FootballMatchCollection(
                        matches,
                        matchesByLeague
                    );
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Database error: {e.Message}");
                    return new FootballMatchCollection(
                        new SortedSet<FootballMatch>(),
                        new Dictionary<int, SortedSet<FootballMatch>>()
                    );
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new FootballMatchCollection(
                        new SortedSet<FootballMatch>(),
                        new Dictionary<int, SortedSet<FootballMatch>>()
                    );
                }
            }
        }
    }
}