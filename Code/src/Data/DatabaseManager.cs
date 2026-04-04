using BettingSystem.Data_Structures;
using BettingSystem.Models;
using BettingSystem.Services;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Configuration;
using System.Security.Cryptography;

namespace BettingSystem.Data
{
    // class to read from or write to database
    public class DatabaseManager
    {
        private readonly string _connectionString;
        private readonly OddsGenerator _oddsGenerator;
        private MyDictionary<int, MyList<PlayerInfo>>? _playersRatings;

        public DatabaseManager() : this(null) { }

        public DatabaseManager(string? connectionString)
        {
            _connectionString = string.IsNullOrWhiteSpace(connectionString)
                ? ConfigurationManager.ConnectionStrings["BettingDB"].ConnectionString
                : connectionString;
            _oddsGenerator = new OddsGenerator();
        }

        //to login
        public async Task<(AppUser? userObj, string message)> LoginAsync(string email, string password)
        {
            //fetch user's data
            string query = "SELECT app_user_id, first_name, last_name, email, dob, wallet_balance, password_hash, user_role, user_status, registration_date FROM AppUser WHERE email = @email";
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
                        if (status != "Active")
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
                           reader["user_role"].ToString()!,
                           reader["user_status"].ToString()!
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@dob", dob);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);

                await connection.OpenAsync();

                await connection.OpenAsync();

                //get app_user_id
                userId = (int)await command.ExecuteScalarAsync();
                return new AppUser(userId, firstName, lastName, dob, email, 0, "user", "active");
            }
        }

        //update user details in table AppUser
        public async Task<(bool valid, string message)> UpdateUserDetailsAsync(int userID, string firstName, string lastName, string email)
        {
            string query = "UPDATE AppUser SET first_name=@firstName, last_name=@lastName, email=@mail WHERE app_user_id=@userID";
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
        public async Task<bool> ProcessWalletTransactionAsync(int userId, string transactionType, decimal newWalletAmount, decimal transactionAmount, int? slipId=null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
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

                        //update claim status bet slip
                        if (transactionType == "payout")
                        {
                            string updateSlipQuery = "UPDATE BetSlip SET claimed=1 WHERE slip_id=@slipId";
                            using (SqlCommand updateSlipCmd = new SqlCommand(updateSlipQuery, connection, transaction))
                            {
                                updateSlipCmd.Parameters.AddWithValue("@slipId", slipId);
                                int updatedRow = await updateSlipCmd.ExecuteNonQueryAsync();
                                if (updatedRow <= 0)
                                    throw new Exception("Bet Slip Claimed Status Update Failed");
                            }
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
                                reader["logo_path"].ToString() ?? "",
                                reader["banner_path"].ToString() ?? ""
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
        public async Task<MyDictionary<int, Team>> FetchTeamsAsync(bool all=false)
        {
            //store teams in dictionary keyed by id
            MyDictionary<int, Team> teamsByID = new MyDictionary<int, Team>();
            string query;

            //fetch all teams
            if (all)
            {
                query = "SELECT team_id, team_name, logo_path FROM Team";
            }

            //fetch teams in upcoming matches only
            else
            {
                query = @"SELECT team_id, team_name, logo_path
                          FROM Team
                          WHERE team_id IN (
                                SELECT home_team_id FROM Game WHERE game_status = 'Scheduled'
                                UNION
                                SELECT away_team_id FROM Game WHERE game_status = 'Scheduled'
                          )";
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
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
                    return new MyDictionary<int, Team>();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new MyDictionary<int, Team>();
                }
            }
        }
        // fetch matches from database
        public async Task<FootballMatchCollection> FetchMatchesAsync(bool all=false)
        {
            MyList<FootballMatch> matches = new MyList<FootballMatch>();

            //dictionary for league filtering
            MyDictionary<int, MyList<FootballMatch>> matchesByLeague = new MyDictionary<int, MyList<FootballMatch>>();
            string query;

            if (all)
            {
                query = "SELECT * FROM Game ORDER BY game_date DESC";
            }
            //fetch upcoming matches in descending order of date
            else
            {
                query = "SELECT * FROM Game WHERE game_status = 'Scheduled' ORDER BY game_date DESC";
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
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
                                reader["game_status"].ToString()!
                            );

                            matches.Add(matchObj);

                            //check if a list exists for the league
                            if (!matchesByLeague.TryGetValue(leagueID, out var leagueMatches))
                            {
                                leagueMatches = new MyList<FootballMatch>();
                                matchesByLeague[leagueID] = leagueMatches;
                            }
                            //add match in the list for that league
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
                        new MyList<FootballMatch>(),
                        new MyDictionary<int, MyList<FootballMatch>>()
                    );
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new FootballMatchCollection(
                        new MyList<FootballMatch>(),
                        new MyDictionary<int, MyList<FootballMatch>>()
                    );
                }
            }
        }

        // save bet slip and bets in bet slip
        public async Task<(bool success, string message)> SaveBetSlipAsync(BetSlip betSlip)
        {

            if (!betSlip.Bets.Any())
                return (false, "Bet slip is empty");

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // insert bet slip 
                        string insertSlipQuery = @"INSERT INTO BetSlip (app_user_id, bet_status, total_odds, stake, payout) 
                                         OUTPUT INSERTED.slip_id
                                         VALUES (@userID, 'Pending', @totalOdds, @stake, @payout)";

                        int slipID;

                        using (SqlCommand command = new SqlCommand(insertSlipQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userID", betSlip.UserID);
                            command.Parameters.AddWithValue("@totalOdds", betSlip.TotalOdds);
                            command.Parameters.AddWithValue("@stake", betSlip.Stake);
                            command.Parameters.AddWithValue("@payout", betSlip.CalculatePayout());
                            slipID = (int)await command.ExecuteScalarAsync();
                        }

                        // insert each bet in linked list
                        string insertBetQuery = @"INSERT INTO Bet (slip_id, odd_id, result) 
                                        VALUES (@slipID, @oddID, 'Pending')";

                        foreach (Bet bet in betSlip.Bets)
                        {
                            using (SqlCommand command = new SqlCommand(insertBetQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@slipID", slipID);
                                command.Parameters.AddWithValue("@oddID", bet.OddID);
                                await command.ExecuteNonQueryAsync();
                            }
                        }

                        transaction.Commit();
                        return (true, "Bet placed successfully");
                    }
                    catch (SqlException e)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Database error: {e.Message}");
                        return (false, "Failed to place bet. Please try again.");
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error: {e.Message}");
                        return (false, "Failed to place bet. Please try again.");
                    }
                }
            }
        }

        // fetch all odds for upcoming matches
        public async Task<MyDictionary<int, MyList<Odd>>> FetchOddsAsync()
        {
            MyDictionary<int, MyList<Odd>> oddsByGameId = new MyDictionary<int, MyList<Odd>>();
            int gameID;
            string query = @"SELECT odd_id, o.game_id, bet_type_id, selection, odd_value
                     FROM Odd o
                     INNER JOIN Game g ON g.game_id = o.game_id
                     WHERE game_status = 'Scheduled'";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            gameID = Convert.ToInt32(reader["game_id"]);

                            Odd odd = new Odd(
                                Convert.ToInt32(reader["odd_id"]),
                                gameID,
                                Convert.ToInt32(reader["bet_type_id"]),
                                reader["selection"].ToString()!,
                                Convert.ToDecimal(reader["odd_value"])
                            );

                            //check if a list of odds exist for the game
                            if (!oddsByGameId.TryGetValue(gameID, out var oddList))
                            {
                                oddList = new MyList<Odd>();
                                oddsByGameId[gameID] = oddList;
                            }
                            oddList.Add(odd);
                        }
                    }
                    return oddsByGameId;
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Database error: {e.Message}");
                    return new MyDictionary<int, MyList<Odd>>();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new MyDictionary<int, MyList<Odd>>();
                }
            }
        }

        //find matches which do not have odd in database
        public async Task<List<GameInfo>> GetMatchesWithoutOdds()
        {
            var games = new List<GameInfo>();
            string query = @"SELECT g.game_id,
                                g.home_team_id,
                                g.away_team_id,
                                g.league_id,
                                homeTeam.team_name AS home_team_name,
                                awayTeam.team_name AS away_team_name
                             FROM Game g
                             INNER JOIN Team homeTeam ON homeTeam.team_id = g.home_team_id
                             INNER JOIN Team awayTeam ON awayTeam.team_id = g.away_team_id
                             WHERE NOT EXISTS (
                                   SELECT 1
                                   FROM Odd o
                                   WHERE o.game_id = g.game_id
                               )";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                await conn.OpenAsync();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        games.Add(new GameInfo(
                            Convert.ToInt32(reader["game_id"]),
                            Convert.ToInt32(reader["home_team_id"]),
                            Convert.ToInt32(reader["away_team_id"]),
                            Convert.ToInt32(reader["league_id"]),
                            Convert.ToString(reader["home_team_name"]) ?? string.Empty,
                            Convert.ToString(reader["away_team_name"]) ?? string.Empty)
                        );
                    }
                }
            }

            return games;
        }

        // fetch an existing correct score odd
        // generate and persist one if missing
        public async Task<Odd?> GetOrCreateCorrectScoreOddAsync(int gameId, int homeGoals, int awayGoals, int homeTeamId, int awayTeamId, int leagueId)
        {
            string selection = $"{homeGoals}-{awayGoals}";
            const int betTypeId = 3;

            Odd? existingOdd = await FetchOddByBetTypeNameAsync(gameId, betTypeId, selection);
            if (existingOdd is not null)
            {
                return existingOdd;
            }

            try
            {
                await GenerateAndSaveCorrectScoreOddAsync(
                    gameId,
                    homeGoals,
                    awayGoals,
                    homeTeamId,
                    awayTeamId,
                    leagueId
                );
            }
            catch (Exception e)
            {
                Console.WriteLine($"Correct score odds generation failed for game {gameId}: {e.Message}");
                return null;
            }

            return await FetchOddByBetTypeNameAsync(gameId, betTypeId, selection);
        }

        private async Task<Odd?> FetchOddByBetTypeNameAsync(int gameId, int betTypeId, string selection)
        {
            const string query = @"SELECT TOP 1 o.odd_id, o.game_id, o.bet_type_id, o.selection, o.odd_value
                                   FROM Odd o
                                   INNER JOIN BetType bt ON bt.bet_type_id = o.bet_type_id
                                   WHERE o.game_id = @gameId
                                     AND o.selection = @selection";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@gameId", gameId);
                command.Parameters.AddWithValue("@betTypeId", betTypeId);
                command.Parameters.AddWithValue("@selection", selection);

                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Odd(
                                Convert.ToInt32(reader["odd_id"]),
                                Convert.ToInt32(reader["game_id"]),
                                Convert.ToInt32(reader["bet_type_id"]),
                                reader["selection"].ToString()!,
                                Convert.ToDecimal(reader["odd_value"])
                            );
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Database error: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }

            return null;
        }

        public async Task<MyList<BetHistorySlip>> FetchBetHistoryAsync(int userID)
        {
            MyList<BetHistorySlip> history = new MyList<BetHistorySlip>();

            // fetch completed slips by most recent
            string slipQuery = @"SELECT slip_id, app_user_id, bet_date, bet_status, total_odds, stake, payout, claimed
                         FROM BetSlip 
                         WHERE app_user_id = @userID
                         ORDER BY bet_date DESC";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(slipQuery, connection))
            {
                command.Parameters.AddWithValue("@userID", userID);

                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            BetHistorySlip slip = new BetHistorySlip(
                                Convert.ToInt32(reader["slip_id"]),
                                Convert.ToInt32(reader["app_user_id"]),
                                Convert.ToDateTime(reader["bet_date"]),
                                Convert.ToDecimal(reader["stake"]),
                                Convert.ToDecimal(reader["total_odds"]),
                                Convert.ToDecimal(reader["payout"]),
                                reader["bet_status"].ToString()!,
                                Convert.ToBoolean(reader["claimed"])
                            );

                            history.Add(slip);
                        }
                    }

                    if (history.Count > 0)
                    {
                        // fetch bets for each slip
                        string betQuery = @"SELECT b.bet_id, b.result, o.selection, o.odd_value, bt.bet_type_id, bt.bet_type_name,
                                                ht.team_name AS home_team, at.team_name AS away_team, 
                                                g.game_date, l.league_name, g.game_id
                                            FROM Bet b
                                            INNER JOIN Odd o ON b.odd_id = o.odd_id
                                            INNER JOIN BetType bt ON o.bet_type_id = bt.bet_type_id
                                            INNER JOIN Game g ON o.game_id = g.game_id
                                            INNER JOIN Team ht ON g.home_team_id = ht.team_id
                                            INNER JOIN Team at ON g.away_team_id = at.team_id
                                            INNER JOIN League l ON g.league_id = l.league_id
                                            WHERE b.slip_id = @slipID";

                        using (SqlConnection betConnection = new SqlConnection(_connectionString))
                        {
                            await betConnection.OpenAsync();

                            // loop through slips and fetch bets for each slip
                            foreach (BetHistorySlip slip in history)
                            {
                                using (SqlCommand betCmd = new SqlCommand(betQuery, betConnection))
                                {
                                    betCmd.Parameters.AddWithValue("@slipID", slip.SlipID);

                                    using (SqlDataReader betReader = await betCmd.ExecuteReaderAsync())
                                    {
                                        while (await betReader.ReadAsync())
                                        {
                                            HistoryBet bet = new HistoryBet(
                                                Convert.ToInt32(betReader["bet_id"]),
                                                betReader["selection"].ToString()!,
                                                Convert.ToDecimal(betReader["odd_value"]),
                                                Convert.ToInt32(betReader["bet_type_id"]),
                                                betReader["bet_type_name"].ToString()!,
                                                betReader["result"].ToString()!,
                                                betReader["home_team"].ToString()!,
                                                betReader["away_team"].ToString()!,
                                                Convert.ToDateTime(betReader["game_date"]),
                                                betReader["league_name"].ToString()!,
                                                Convert.ToInt32(betReader["game_id"])
                                            );

                                            slip.Bets.Add(bet);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return history;
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Database error: {e.Message}");
                    return new MyList<BetHistorySlip>();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new MyList<BetHistorySlip>();
                }
            }
        }

        //fetch results of games
        public async Task<MyDictionary<int, GameResult>> FetchGameResultsAsync(MyList<int>? gameIds, bool all = false)
        {
            MyDictionary<int, GameResult> gameResult = new MyDictionary<int, GameResult>();

            if (!all & (gameIds is null || gameIds.Count == 0))
                return gameResult;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;

                    await connection.OpenAsync();
                    if (all)
                    {
                        command.CommandText = $@"SELECT game_id, home_team_score, away_team_score, first_scorer_id, player_name, total_corners, red_cards, yellow_cards
                                            FROM GameResult gr
                                            LEFT JOIN Player p ON gr.first_scorer_id = p.player_id";
                    }
                    else
                    {
                        if (gameIds is null || gameIds.Count == 0)
                            return gameResult;

                        MyList<string> idParams = new MyList<string>();

                        for (int i = 0; i < gameIds.Count; i++)
                        {
                            command.Parameters.AddWithValue($"@game_id{i}", gameIds[i]);
                            idParams.Add($"@game_id{i}");
                        }

                        command.CommandText = $@"SELECT game_id, home_team_score, away_team_score, first_scorer_id, player_name, total_corners, red_cards, yellow_cards
                                            FROM GameResult gr
                                            LEFT JOIN Player p ON gr.first_scorer_id = p.player_id
                                            WHERE game_id IN ({String.Join(',', idParams)})";
                    }

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int matchId = Convert.ToInt32(reader["game_id"]);
                            GameResult matchResult = new GameResult(
                                    matchId,
                                    Convert.ToInt32(reader["home_team_score"]),
                                    Convert.ToInt32(reader["away_team_score"]),
                                    Convert.ToInt32(reader["total_corners"]),
                                    Convert.ToInt32(reader["red_cards"]),
                                    Convert.ToInt32(reader["yellow_cards"]),
                                    reader["player_name"]?.ToString() ?? null,
                                    reader["first_scorer_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["first_scorer_id"])
                                );

                            gameResult[matchId] = matchResult;
                        }
                    }
                    return gameResult;
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Database error: {e.Message}");
                    return new MyDictionary<int, GameResult>();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new MyDictionary<int, GameResult>();
                }
            }
        }

        // fetch players details
        public async Task<MyDictionary<int, MyList<Player>>> FetchPlayersAsync()
        {
            //store players in dictionary keyed by TeamId
            MyDictionary<int, MyList<Player>> PlayersByTeamId = new MyDictionary<int, MyList<Player>>();
            string query = "SELECT player_id, player_name, team_id, player_position FROM Player";
                
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
                            string? rawPosition = reader["player_position"].ToString();
                            string normalizedPosition = string.IsNullOrWhiteSpace(rawPosition)
                                ? "ATT"
                                : rawPosition.Trim().ToUpperInvariant() switch
                                {
                                    "ATT" => "ATT",
                                    "MID" => "MID",
                                    "DEF" => "DEF",
                                    "GK" => "GK",
                                    "FW" => "ATT",
                                    "MF" => "MID",
                                    "DF" => "DEF",
                                    _ => "ATT"
                                };

                            Player playerObj = new Player(
                                Convert.ToInt32(reader["player_id"]),
                                reader["player_name"].ToString()!,
                                teamID,
                                normalizedPosition
                            );

                            //check if a list of players exist for the game
                            if (!PlayersByTeamId.TryGetValue(teamID, out var playersList))
                            {
                                playersList = new MyList<Player>();
                                PlayersByTeamId[teamID] = playersList;
                            }

                            playersList.Add(playerObj);
                        }
                    }
                    return PlayersByTeamId;
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Database error: {e.Message}");
                    return new MyDictionary<int, MyList<Player>>();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new MyDictionary<int, MyList<Player>>();
                }
            }
        }

        // add new match in database
        public async Task<bool> AddNewMatchAsync(FootballMatch newMatch, GameResult matchResult)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int insertedGameId;

                        //add match to Game table
                        string insertMatchQuery = @"INSERT INTO Game (league_id, home_team_id, away_team_id, game_date)
                                                 OUTPUT INSERTED.game_id
                                                 VALUES (@leagueId, @homeTeamId, @awayTeamId, @matchDate)";

                        using (SqlCommand insertMatchCmd = new SqlCommand(insertMatchQuery, connection, transaction))
                        {
                            insertMatchCmd.Parameters.AddWithValue("@leagueId", newMatch.LeagueID);
                            insertMatchCmd.Parameters.AddWithValue("@homeTeamId", newMatch.HomeTeamID);
                            insertMatchCmd.Parameters.AddWithValue("@awayTeamId", newMatch.AwayTeamID);
                            insertMatchCmd.Parameters.AddWithValue("@matchDate", newMatch.GameDate);

                            insertedGameId = (int)await insertMatchCmd.ExecuteScalarAsync();

                            if (insertedGameId <= 0)
                                throw new Exception("Insert New Match Failed");
                        }

                        // add Generated Match Result to MatchResult table
                        string insertResultQuery = @"INSERT INTO GameResult (game_id, home_team_score, away_team_score, first_scorer_id, total_corners, red_cards, yellow_cards) 
                                                    VALUES (@gameId, @homeScore, @awayScore, @scorerId, @corners, @redCards, @yellowCards)";

                        using (SqlCommand insertResultCmd = new SqlCommand(insertResultQuery, connection, transaction))
                        {
                            insertResultCmd.Parameters.AddWithValue("@gameId", insertedGameId);
                            insertResultCmd.Parameters.AddWithValue("@homeScore", matchResult.HomeTeamScore);
                            insertResultCmd.Parameters.AddWithValue("@awayScore", matchResult.AwayTeamScore);
                            insertResultCmd.Parameters.AddWithValue("@scorerId", matchResult.FirstScorerId is null ? DBNull.Value : matchResult.FirstScorerId);
                            insertResultCmd.Parameters.AddWithValue("@corners", matchResult.TotalCorners);
                            insertResultCmd.Parameters.AddWithValue("@redCards", matchResult.RedCards);
                            insertResultCmd.Parameters.AddWithValue("@yellowCards", matchResult.YellowCards);

                            int insertedRow = await insertResultCmd.ExecuteNonQueryAsync();

                            //check if match result was inserted
                            if (insertedRow <= 0)
                                throw new Exception("Insert Match Result Failed");
                        }

                        //generate odds for the new match
                        await GenerateAndSaveAllOddsAsync(insertedGameId, newMatch.HomeTeamID, newMatch.AwayTeamID, newMatch.LeagueID, connection, transaction);

                        newMatch.GameID = insertedGameId;
                        matchResult.GameId = insertedGameId;

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
        public async Task<MyDictionary<int, MyList<int>>> FetchLeagueTeamAsync()
        {
            MyDictionary<int, MyList<int>> leagueTeam = new MyDictionary<int, MyList<int>>();
            string query = "SELECT * FROM LeagueTeam";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int TeamId = Convert.ToInt32(reader["team_id"]);
                            int LeagueId = Convert.ToInt32(reader["league_id"]);

                            if (!leagueTeam.TryGetValue(LeagueId, out var leagueTeams))
                            {
                                leagueTeams = new MyList<int>();
                                leagueTeam[LeagueId] = leagueTeams;
                            }
                            //add team in the list for that league
                            leagueTeam[LeagueId].Add(TeamId);
                        }
                    }
                    return leagueTeam;
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Database error: {e.Message}");
                    return new MyDictionary<int, MyList<int>>();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new MyDictionary<int, MyList<int>>();
                }
            }
        }

        // methods for the simulator to update database

        // update match status in table to started or completed
        private async Task<(MyList<int> startedGames, MyList<int> completedGames)> UpdateMatchStatusAsync(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            MyList<int> startedGames = new MyList<int>();
            MyList<int> completedGames = new MyList<int>();

            string query = @"DECLARE @now DATETIME = GETDATE();
                            
                            UPDATE Game
                            SET game_status = CASE 
                                WHEN @now >= DATEADD(MINUTE, 5, game_date) AND game_status <> 'Completed' THEN 'Completed'
                                WHEN @now >= game_date AND game_status = 'Scheduled' THEN 'Started'
                                ELSE game_status
                            END
                            OUTPUT inserted.game_id, inserted.game_status
                            WHERE
                                (@now >= game_date AND game_status = 'Scheduled')
                                OR
                                (@now >= DATEADD(MINUTE, 5, game_date) AND game_status <> 'Completed');";

            using (SqlCommand command = new SqlCommand(query, sqlConnection, sqlTransaction))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string gameStatus = reader["game_status"].ToString()!;
                        if (gameStatus == "Completed")
                        {
                            completedGames.Add(Convert.ToInt32(reader["game_id"]));
                        }
                        else if (gameStatus == "Started")
                        {
                            startedGames.Add(Convert.ToInt32(reader["game_id"]));
                        }
                    }
                }
                //return list of ids for games whose status was modified
                return (startedGames, completedGames);
            }
        }


        //update bets in Bet Table for completed games
        private async Task<MyDictionary<int, string>> UpdateBetResultAsync(MyList<int> updatedGameIds, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            MyDictionary<int, string> updatedBets = new MyDictionary<int, string>();

            if (updatedGameIds is null || updatedGameIds.Count == 0)
                return updatedBets;

            MyList<int> modifiedGameIds = updatedGameIds;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = sqlConnection;
                command.Transaction = sqlTransaction;

                MyList<string> idParams = new MyList<string>();

                for (int i = 0; i < modifiedGameIds.Count; i++)
                {
                    command.Parameters.AddWithValue($"@game_id{i}", modifiedGameIds[i]);
                    idParams.Add($"@game_id{i}");
                }
                //compare user selection to match results to set bet result as Won or Lost
                command.CommandText = $@"
                        UPDATE B
                        SET B.result = CASE 
                            WHEN B.result = 'Pending' AND
                                ( 
                                    (O.bet_type_id = 1 AND 
                                        (
                                            (GR.home_team_score > GR.away_team_score AND O.[Selection]='Home Win') OR 
                                            (GR.home_team_score < GR.away_team_score AND O.[Selection]='Away Win') OR 
                                            (GR.home_team_score = GR.away_team_score AND O.[Selection]='Draw')
                                        )
                                    )

                                    OR
                                    (O.bet_type_id = 2 AND 
                                        (
                                            (GR.home_team_score >= GR.away_team_score AND O.[Selection]='1X') OR 
                                            (GR.home_team_score != GR.away_team_score AND O.[Selection]='12') OR 
                                            (GR.home_team_score <= GR.away_team_score AND O.[Selection]='X2')
                                        )
                                    )

                                    OR
                                    (O.bet_type_id = 3 AND CONCAT(GR.home_team_score, '-', GR.away_team_score) = O.[Selection])

                                    OR
                                    (O.bet_type_id = 4 AND 
                                        (
                                            ((GR.home_team_score + GR.away_team_score) > 2.5 AND O.[Selection]='Over 2.5') OR 
                                            ((GR.home_team_score + GR.away_team_score) < 2.5 AND O.[Selection]='Under 2.5')
                                        )
                                    )

                                    OR
                                    (O.bet_type_id = 5 AND 
                                        (
                                            ((GR.home_team_score > 0 AND GR.away_team_score > 0) AND O.[Selection]='Yes') OR 
                                            ((GR.home_team_score = 0 OR GR.away_team_score = 0) AND O.[Selection]='No')
                                        )
                                    )

                                    OR
                                    (O.bet_type_id = 6 AND (GR.first_scorer_id IS NOT NULL AND CAST(GR.first_scorer_id AS VARCHAR) = O.[Selection]))

                                    OR
                                    (O.bet_type_id = 7 AND 
                                        (
                                            (LEFT(O.[Selection], 4) = 'Over' AND GR.total_corners > CAST(SUBSTRING(O.[Selection], 6, LEN(O.[Selection])) AS DECIMAL(3, 1))) OR 
                                            (LEFT(O.[Selection], 5) = 'Under' AND GR.total_corners < CAST(SUBSTRING(O.[Selection], 7, LEN(O.[Selection])) AS DECIMAL(3, 1)))
                                        )
                                    )
                                    OR
                                    (O.bet_type_id = 8 AND 
                                        (
                                            (LEFT(O.[Selection], 4) = 'Over' AND GR.yellow_cards > CAST(SUBSTRING(O.[Selection], 6, LEN(O.[Selection])) AS DECIMAL(2, 1))) OR 
                                            (LEFT(O.[Selection], 5) = 'Under' AND GR.yellow_cards < CAST(SUBSTRING(O.[Selection], 7, LEN(O.[Selection])) AS DECIMAL(2, 1)))
                                        )
                                    )

                                    OR
                                    (O.bet_type_id = 9 AND 
                                        (
                                            (LEFT(O.[Selection], 4) = 'Over' AND GR.red_cards > CAST(SUBSTRING(O.[Selection], 6, LEN(O.[Selection])) AS DECIMAL(2, 1))) 
                                            OR (LEFT(O.[Selection], 5) = 'Under' AND GR.red_cards < CAST(SUBSTRING(O.[Selection], 7, LEN(O.[Selection])) AS DECIMAL(2, 1)))
                                        )
                                    )
                                ) 

                            THEN 'Won'
                            ELSE 'Lost'
                        END
                        OUTPUT inserted.bet_id, inserted.result
                        FROM Bet AS B
                        INNER JOIN Odd O ON B.odd_id = O.odd_id
                        INNER JOIN GameResult GR ON GR.game_id = O.game_id
                        WHERE B.result = 'Pending' 
                        AND O.game_id IN ({String.Join(',', idParams)})
                ";
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string betStatus = reader["result"].ToString()!;
                        if (betStatus != "Pending")
                        {
                            int betId = Convert.ToInt32(reader["bet_id"]);
                            updatedBets[betId] = betStatus;
                        }
                    }
                }
                //return bets that were updated
                return updatedBets;
            }
        }


        // update bet slip status
        private async Task<MyDictionary<int, string>> UpdateBetSlipStatusAsync(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            MyDictionary<int, string> updatedSlips = new MyDictionary<int, string>();

            // set status of bets slip as 'Won' if all the bets in it have result 'Won'
            string query = @"
                UPDATE BS
                SET bet_status = CASE 
                    WHEN NOT EXISTS(
                        SELECT 1
                        FROM BET B
                        WHERE B.slip_id = BS.slip_id AND B.result != 'Won'
                    ) 
                    THEN 'Won'

                    WHEN NOT EXISTS(
                        SELECT 1
                        FROM BET B
                        WHERE B.slip_id = BS.slip_id AND B.result = 'Pending'
                    ) 
                    THEN 'Lost'

                    ELSE bet_status
                END
                OUTPUT inserted.slip_id, inserted.bet_status
                FROM BetSlip AS BS
                WHERE bet_status = 'Pending'
            ";

            using (SqlCommand command = new SqlCommand(query, sqlConnection, sqlTransaction))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string slipStatus = reader["bet_status"].ToString()!;
                        if (slipStatus != "Pending")
                        {
                            int slipId = Convert.ToInt32(reader["slip_id"]);
                            updatedSlips[slipId] = slipStatus;
                        }
                    }
                }
            }
            //return updated bet slips
            return updatedSlips;
        }

        // execute updates for the match status, bet results and bet slip status
        public async Task<(MyList<int> startedGames, MyList<int> completedGames, MyDictionary<int, string> updatedBets, MyDictionary<int, string> updatedSlips)> WrapTableUpdatesAsync()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        (MyList<int> startedMatchIds, MyList<int> completedMatchIds) = await UpdateMatchStatusAsync(connection, transaction);
                        MyDictionary<int, string> updatedBets = new MyDictionary<int, string>();
                        MyDictionary<int, string> updatedSlips = new MyDictionary<int, string>();

                        if (completedMatchIds is not null)
                        {
                            updatedBets = await UpdateBetResultAsync(completedMatchIds, connection, transaction);
                            updatedSlips = await UpdateBetSlipStatusAsync(connection, transaction);
                        }
                        transaction.Commit();
                        return (startedMatchIds, completedMatchIds, updatedBets, updatedSlips);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                        transaction.Rollback();
                        return (new MyList<int>(), new MyList<int>(), new MyDictionary<int, string>(), new MyDictionary<int, string>());
                    }
                }
            }
        }

        // Save generated odds to database
        public async Task SaveOddsAsync(IEnumerable<GeneratedOdd> odds, SqlConnection? sqlConnection=null, SqlTransaction? transaction=null)
        {
            var oddList = odds.ToList();
            if (oddList.Count == 0)
                return;

            if (sqlConnection is not null)
            {
                foreach (var odd in oddList)
                {
                    await SaveSingleOddAsync(sqlConnection, odd, transaction);
                }
                return;
            }
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                foreach (var odd in oddList)
                {
                    await SaveSingleOddAsync(connection, odd);
                }
            }
        }

        // Save a single odd (INSERT or UPDATE if exists)
        private async Task SaveSingleOddAsync(SqlConnection connection, GeneratedOdd odd, SqlTransaction? transaction=null)
        {
            try
            {
                const string query = @"BEGIN TRY
                                          INSERT INTO Odd (game_id, bet_type_id, selection, odd_value)
                                          VALUES (@gameId, @betTypeId, @selection, @oddValue)
                                      END TRY
                                      BEGIN CATCH
                                          IF ERROR_NUMBER() IN (2601, 2627)
                                          BEGIN
                                              UPDATE Odd
                                              SET odd_value = @oddValue
                                              WHERE game_id = @gameId
                                                AND bet_type_id = @betTypeId
                                                AND selection = @selection
                                          END
                                          ELSE
                                          BEGIN
                                              THROW
                                          END
                                      END CATCH";

                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@gameId", odd.GameId);
                    command.Parameters.AddWithValue("@betTypeId", odd.BetTypeId);
                    command.Parameters.AddWithValue("@selection", odd.Selection);
                    command.Parameters.AddWithValue("@oddValue", odd.OddValue);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error saving odd for game {odd.GameId}, selection '{odd.Selection}': {e.Message}");
                throw;
            }
        }

        // Public wrapper for OddsGenerator to persist odds with the persist parameter
        public async Task<decimal> GenerateAndSaveCorrectScoreOddAsync(int gameId, int homeGoals, int awayGoals, int homeTeamId, int awayTeamId, int leagueId)
        {
            try
            {
                // Get team ratings from database
                var homeRatings = await GetTeamRatingsAsync(homeTeamId, leagueId);
                var awayRatings = await GetTeamRatingsAsync(awayTeamId, leagueId);

                // Generate the odd (just calculation, no persistence)
                var generatedOdd = _oddsGenerator.GenerateCorrectScoreOdd(
                    gameId,
                    homeGoals,
                    awayGoals,
                    homeRatings,
                    awayRatings);

                // Persist to database
                await SaveOddsAsync(new[] { generatedOdd });
                
                return generatedOdd.OddValue;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generating/saving correct score odd: {e.Message}");
                throw;
            }
        }

        // Helper: Get team ratings from database
        private async Task<TeamRatings> GetTeamRatingsAsync(int teamId, int leagueId)
        {
            string query = @"SELECT attack_rating, defense_rating, discipline_rating, avg_corners_per_game
                            FROM TeamRating
                            WHERE team_id = @teamId AND league_id = @leagueId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@teamId", teamId);
                command.Parameters.AddWithValue("@leagueId", leagueId);

                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new TeamRatings(
                                Convert.ToInt32(reader["attack_rating"]),
                                Convert.ToInt32(reader["defense_rating"]),
                                Convert.ToInt32(reader["discipline_rating"]),
                                Convert.ToDecimal(reader["avg_corners_per_game"]));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error retrieving team ratings: {e.Message}");
                }

                // Default ratings if team not found
                return new TeamRatings(60, 60, 60, 5.0m);
            }
        }

        //Get player information and ratings from database
        public async Task<MyDictionary<int, MyList<PlayerInfo>>> GetPlayersAsync()
        {
            var playersRatingsDict = new MyDictionary<int, MyList<PlayerInfo>>();
            string query = @"SELECT p.player_id, player_name, team_id, player_position, scoring_rating
                            FROM Player p
                            INNER JOIN PlayerRating pr ON p.player_id = pr.player_id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
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
                            string? rawPosition = reader["player_position"].ToString();
                            string normalizedPosition = string.IsNullOrWhiteSpace(rawPosition)
                                ? "ATT"
                                : rawPosition.Trim().ToUpperInvariant() switch
                                {
                                    "ATT" => "ATT",
                                    "MID" => "MID",
                                    "DEF" => "DEF",
                                    "GK" => "GK",
                                    "FW" => "ATT",
                                    "MF" => "MID",
                                    "DF" => "DEF",
                                    _ => "ATT"
                                };

                            var player = new PlayerInfo(
                                Convert.ToInt32(reader["player_id"]),
                                reader["player_name"].ToString()!,
                                normalizedPosition,
                                Convert.ToInt32(reader["scoring_rating"]),
                                teamID
                            );

                            //check if a list of players exist for the game
                            if (!playersRatingsDict.TryGetValue(teamID, out var playersList))
                            {
                                playersList = new MyList<PlayerInfo>();
                                playersRatingsDict[teamID] = playersList;
                            }

                            playersList.Add(player);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error retrieving player details and ratings: {e.Message}");
                }

                return playersRatingsDict;
            }
        }

        // Public wrapper for GenerateAllOddsForGame with persistence
        public async Task<IReadOnlyList<GeneratedOdd>> GenerateAndSaveAllOddsAsync(int gameId, int homeTeamId, int awayTeamId, int leagueId, SqlConnection? sqlConnection=null, SqlTransaction? transaction=null)
        {
            try
            {
                // Get team ratings
                var homeRatings = await GetTeamRatingsAsync(homeTeamId, leagueId);
                var awayRatings = await GetTeamRatingsAsync(awayTeamId, leagueId);

                _playersRatings ??= await GetPlayersAsync();

                List<PlayerInfo> gamePlayers = new List<PlayerInfo>();

                if (_playersRatings.TryGetValue(homeTeamId, out var homePlayers))
                {
                    gamePlayers.AddRange(homePlayers);
                }

                if (_playersRatings.TryGetValue(awayTeamId, out var awayPlayers))
                {
                    gamePlayers.AddRange(awayPlayers);
                }

                // odds calculations
                var generatedOdds = _oddsGenerator.BuildAllOddsForGame(gameId, homeRatings, awayRatings, gamePlayers);

                // Persist to database
                await SaveOddsAsync(generatedOdds, sqlConnection, transaction);

                return generatedOdds;
            }

            catch (Exception e)
            {
                Console.WriteLine($"Error generating/saving all odds for game {gameId}: {e.Message}");
                throw;
            }
        }
    }
}