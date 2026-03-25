using BettingSystem.Models;
using BettingSystem.Services;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace BettingSystem.Data
{
    // class to read from or write to database
    public class DatabaseManager
    {
        private readonly string connectionString;
        private readonly OddsGenerator oddsGenerator;

        public DatabaseManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BettingDB"].ConnectionString;
            oddsGenerator = new OddsGenerator(connectionString);
        }

        public OddsAutoGeneratorService CreateOddsAutoGeneratorService()
        {
            return new OddsAutoGeneratorService(connectionString);
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
        public async Task<bool> ProcessWalletTransactionAsync(int userId, string transactionType, decimal newWalletAmount, decimal transactionAmount, int? slipId=null)
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
        public async Task<Dictionary<int, Team>> FetchTeamsAsync(bool all=false)
        {
            //store teams in dictionary keyed by id
            Dictionary<int, Team> teamsByID = new Dictionary<int, Team>();
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
        public async Task<FootballMatchCollection> FetchMatchesAsync(bool all=false)
        {
            //list to store matches in chronological order
            SortedSet<FootballMatch> matches = new SortedSet<FootballMatch>(new FootballMatchKeyComparer());

            //dictionary for league filtering
            Dictionary<int, SortedSet<FootballMatch>> matchesByLeague = new Dictionary<int, SortedSet<FootballMatch>>();
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
                                reader["game_status"].ToString()!
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

        // save bet slip and bets in bet slip
        public async Task<(bool success, string message)> SaveBetSlipAsync(BetSlip betSlip)
        {

            if (!betSlip.Bets.Any())
                return (false, "Bet slip is empty");

            using (SqlConnection connection = new SqlConnection(connectionString))
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
        public async Task<Dictionary<int, List<Odd>>> FetchOddsAsync()
        {
            Dictionary<int, List<Odd>> oddsByGameId = new Dictionary<int, List<Odd>>();
            int gameID;
            string query = @"SELECT odd_id, o.game_id, bet_type_id, selection, odd_value
                     FROM Odd o
                     INNER JOIN Game g ON g.game_id = o.game_id
                     WHERE game_status = 'Scheduled'";

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
                                oddList = new List<Odd>();
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
                    return new Dictionary<int, List<Odd>>();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new Dictionary<int, List<Odd>>();
                }
            }
        }

        public async Task<List<BetHistorySlip>> FetchBetHistoryAsync(int userID)
        {
            List<BetHistorySlip> history = new List<BetHistorySlip>();

            // fetch completed slips by most recent
            string slipQuery = @"SELECT slip_id, app_user_id, bet_date, bet_status, total_odds, stake, payout, claimed
                         FROM BetSlip 
                         WHERE app_user_id = @userID
                         ORDER BY bet_date DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
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

                        using (SqlConnection betConnection = new SqlConnection(connectionString))
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
                    return new List<BetHistorySlip>();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new List<BetHistorySlip>();
                }
            }
        }

        //fetch results of games
        public async Task<Dictionary<int, GameResult>> FetchGameResultsAsync(List<int>? gameIds, bool all = false)
        {
            Dictionary<int, GameResult> gameResult = new Dictionary<int, GameResult>();

            if (gameIds is null || gameIds.Count == 0)
                return gameResult;

            using (SqlConnection connection = new SqlConnection(connectionString))
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

                        List<string> idParams = new List<string>();

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
                    return new Dictionary<int, GameResult>();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new Dictionary<int, GameResult>();
                }
            }
        }

        // fetch players details for upcoming matches
        public async Task<Dictionary<int, List<Player>>> FetchPlayersAsync()
        {
            //store players in dictionary keyed by TeamId
            Dictionary<int, List<Player>> PlayersByTeamId = new Dictionary<int, List<Player>>();
            string query = "SELECT player_id, player_name, team_id, player_position FROM Player";
                
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
                            Player playerObj = new Player(
                                Convert.ToInt32(reader["player_id"]),
                                reader["player_name"].ToString()!,
                                teamID,
                                reader["player_position"].ToString()!
                            );

                            //check if a list of players exist for the game
                            if (!PlayersByTeamId.TryGetValue(teamID, out var playersList))
                            {
                                playersList = new List<Player>();
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
                    return new Dictionary<int, List<Player>>();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new Dictionary<int, List<Player>>();
                }
            }
        }

        // add new match in database
        public async Task<bool> AddNewMatchAsync(FootballMatch newMatch, GameResult matchResult)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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
                        oddsGenerator.GenerateAllOddsForGame(insertedGameId, newMatch.HomeTeamID, newMatch.AwayTeamID, newMatch.LeagueID);

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
        public async Task<Dictionary<int, List<int>>> FetchLeagueTeamAsync()
        {
            Dictionary<int, List<int>> leagueTeam = new Dictionary<int, List<int>>();
            string query = "SELECT * FROM LeagueTeam";
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
                            int TeamId = Convert.ToInt32(reader["team_id"]);
                            int LeagueId = Convert.ToInt32(reader["league_id"]);

                            if (!leagueTeam.TryGetValue(LeagueId, out var leagueTeams))
                            {
                                leagueTeams = new List<int>();
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
                    return new Dictionary<int, List<int>>();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return new Dictionary<int, List<int>>();
                }
            }
        }

        // methods for the simulator to update database

        // update match status in table to started or completed
        private async Task<(List<int> startedGames, List<int> completedGames)> UpdateMatchStatusAsync(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            List<int> startedGames = new List<int>();
            List<int> completedGames = new List<int>();

            string query = @"UPDATE Game
                            SET game_status = CASE 
                                WHEN GETDATE() >= DATEADD(MINUTE, 5, game_date) THEN 'Completed'
                                WHEN GETDATE() >= game_date  THEN 'Started'
                                ELSE game_status
                            END
                            OUTPUT inserted.game_id, inserted.game_status
                            WHERE CAST(game_date AS DATE) = CAST(GETDATE() AS DATE)";

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
        private async Task<Dictionary<int, string>> UpdateBetResultAsync(List<int> updatedGameIds, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            Dictionary<int, string> updatedBets = new Dictionary<int, string>();

            if (updatedGameIds is null || updatedGameIds.Count == 0)
                return updatedBets;

            List<int> modifiedGameIds = updatedGameIds;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = sqlConnection;
                command.Transaction = sqlTransaction;

                List<string> idParams = new List<string>();

                for (int i = 0; i < modifiedGameIds.Count; i++)
                {
                    command.Parameters.AddWithValue($"@game_id{i}", modifiedGameIds[i]);
                    idParams.Add($"@game_id{i}");
                }
                //compare user selection to match results to set bet result as Won or Lost
                command.CommandText = $@"
                        UPDATE Bet B
                        SET B.result = CASE 
                            WHEN B.result = 'Pending' AND
                                ( 
                                    (O.bet_type_id = 1 AND 
                                        (
                                            (GR.home_team_score > GR.away_team_score AND O.Selection='Home Win') OR 
                                            (GR.home_team_score < GR.away_team_score AND O.Selection='Away Win') OR 
                                            (GR.home_team_score = GR.away_team_score AND O.Selection='Draw')
                                        )
                                    )

                                    OR
                                    (O.bet_type_id = 2 AND 
                                        (
                                            (GR.home_team_score >= GR.away_team_score AND O.Selection='1X') OR 
                                            (GR.home_team_score != GR.away_team_score AND O.Selection='12') OR 
                                            (GR.home_team_score <= GR.away_team_score AND O.Selection='X2')
                                        )
                                    )

                                    OR
                                    (O.bet_type_id = 3 AND CONCAT(GR.home_team_score, ' - ', GR.away_team_score) = O.Selection)

                                    OR
                                    (O.bet_type_id = 4 AND 
                                        (
                                            ((GR.home_team_score + GR.away_team_score) > 2.5 AND O.Selection='Over 2.5') OR 
                                            ((GR.home_team_score + GR.away_team_score) < 2.5 AND O.Selection='Under 2.5')
                                        )
                                    )

                                    OR
                                    (O.bet_type_id = 5 AND 
                                        (
                                            ((GR.home_team_score > 0 AND GR.away_team_score > 0) AND O.Selection='Yes') OR 
                                            ((GR.home_team_score = 0 OR GR.away_team_score = 0) AND O.Selection='No')
                                        )
                                    )

                                    OR
                                    (O.bet_type_id = 6 AND (GR.first_scorer_id IS NOT NULL AND CAST(GR.first_scorer_id AS VARCHAR) = O.Selection))

                                    OR
                                    (O.bet_type_id = 7 AND 
                                        (
                                            (LEFT(O.Selection, 4) = 'Over' AND GR.total_corners > CAST(SUBSTRING(O.Selection, 6, LEN(O.Selection)) AS DECIMAL(3, 1))) OR 
                                            (LEFT(O.Selection, 5) = 'Under' AND GR.total_corners < CAST(SUBSTRING(O.Selection, 7, LEN(O.Selection)) AS DECIMAL(3, 1)))
                                        )
                                    )
                                    OR
                                    (O.bet_type_id = 8 AND 
                                        (
                                            (LEFT(O.Selection, 4) = 'Over' AND GR.yellow_cards > CAST(SUBSTRING(O.Selection, 6, LEN(O.Selection)) AS DECIMAL(2, 1))) OR 
                                            (LEFT(O.Selection, 5) = 'Under' AND GR.yellow_cards < CAST(SUBSTRING(O.Selection, 7, LEN(O.Selection)) AS DECIMAL(2, 1)))
                                        )
                                    )

                                    OR
                                    (O.bet_type_id = 9 AND 
                                        (
                                            (LEFT(O.Selection, 4) = 'Over' AND GR.red_cards > CAST(SUBSTRING(O.Selection, 6, LEN(O.Selection)) AS DECIMAL(2, 1))) 
                                            OR (LEFT(O.Selection, 5) = 'Under' AND GR.red_cards < CAST(SUBSTRING(O.Selection, 7, LEN(O.Selection)) AS DECIMAL(2, 1)))
                                        )
                                    )
                                ) 

                            THEN 'Won'
                            ELSE 'Lost'
                        END
                        OUTPUT inserted.bet_id, inserted.result
                        FROM Bet B
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
                            int betId = Convert.ToInt32(reader["game_id"]);
                            updatedBets[betId] = betStatus;
                        }
                    }
                }
                //return bets that were updated
                return updatedBets;
            }
        }


        // update bet slip status
        private async Task<Dictionary<int, string>> UpdateBetSlipStatusAsync(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            Dictionary<int, string> updatedSlips = new Dictionary<int, string>();

            // set status of bets slip as 'Won' if all the bets in it have result 'Won'
            string query = @"
                UPDATE BetSlip BS
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
                OUTPUT inserted.B.slip_id, inserted.B.result
                WHERE bet_status = 'Pending'
            ";

            using (SqlCommand command = new SqlCommand(query, sqlConnection, sqlTransaction))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string slipStatus = reader["result"].ToString()!;
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
        public async Task<(List<int>? startedGames, List<int>? completedGames, Dictionary<int, string> updatedBets, Dictionary<int, string> updatedSlips)> WrapTableUpdatesAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        (List<int> startedMatchIds, List<int> completedMatchIds) = await UpdateMatchStatusAsync(connection, transaction);
                        Dictionary<int, string> updatedBets = new Dictionary<int, string>();
                        Dictionary<int, string> updatedSlips = new Dictionary<int, string>();

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
                        return (new List<int>(), new List<int>(), new Dictionary<int, string>(), new Dictionary<int, string>());
                    }
                }
            }
        }
    }
}