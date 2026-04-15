# Football Betting System

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
    - [System Features](#system-features)
    - [User Features](#user-features)
    - [Admin Features](#admin-features)
- [Folder Structure](#folder-structure)
- [Technologies Used](#technologies-used)
- [Getting the Project](#getting-the-project)
- [How to Run the Project](#how-to-run-the-project)
    - [Database Setup](#database-setup)
    - [AI Agent Setup](#ai-agent-setup)
    - [Running the Application](#running-the-application)
    - [Sample Data](#sample-data-optional)
- [Troubleshooting](#troubleshooting)
    - [Database Setup Errors](#database-setup-errors)
    - [API Key / AI Report Errors](#api-key--ai-report-errors)
- [How to Use the Program](#how-to-use-the-program)
    - [User Flow](#user-flow)
    - [Admin Flow](#admin-flow)
- [Testing](#testing)
    - [Run Tests code](#run-tests-code)
- [Odds Generation](#odds-generation)
- [Simulation System](#simulation-system)
    - [Database Updates](#database-updates)
    - [Admin Behavior](#admin-behavior)
    - [User Behavior](#user-behavior)
- [Data Analyst Agent](#data-analyst-agent)
- [References](#references)


## Project Overview
The Football Betting System is a C# Windows Form application that simulates a football betting platform. It allows users to register and log in, view upcoming football matches, place cumulative bets and monitor outcomes of their bets. 

Users can also manage their account by editing their profile details and password, as well as depositing or withdrawing funds from their digital wallet. The system includes authentication mechanisms, automated bet validation and payout calculations.

In addition, an admin interface is provided for managing users, matches and accessing financial reports

## Features
### System Features
- Simulates football matches using a periodic timer that updates the database every minute
- Generates odds based on team and player ratings
- Randomly generates results for matches added by Admin
- Generates odds for matches added by Admin
- Uses an AI Agent to generate a financial report based on provided financial data

### User Features
- Search matches by team name
- Filter matches by league
- Place bets
- Remove bets from bet slip (unpaid bets list)
- Confirm bet slip & make payment
- View bet history
- Filter and sort bet history by status and date
- Claim winnings from completed bet slips
- View outcomes of each bet in history
- Edit profile details (except date of birth)
- Change password
- Deposit and Withdraw funds (card number must be 16 digits & CVV 3 or 4 digits)


### Admin Features
- View and update user status (banned users cannot be modified)
- Filter matches by league and team name
- View results of completed matches
- Add new scheduled matches 
- View financial data with graphical representation
- Generate financial reports

## Folder Structure

**Root Directory:**
```text
./
├── Code/
├── Daily Standups/
├── Project Management/
├── BettingSystemDemo.mp4
├── Project Report/
└── README.md
```

- Code: Contains the aplication source code
- Daily Standups: Contains all meeting minutes
- Project Management: Includes project management report, project requirements documentation, Gantt Chart, and activity diagrams
- BettingSystemDemo.mp4: MP4 video demonstration of the software
- Project Report: Contains the main project report PDF, algorithm analysis documentation, brainstorm documentation and detailed test cases

**Code Folder:**
```text
Code/
├── Assets/
├── db/
│   ├── DataSource/
│   ├── CreateDatabaseSQL.txt
│   ├── PopulateTablesSQL.txt
│   └── testData.txt
├── src/
│   ├── Data/
│   ├── Data Structures/
│   ├── Forms/
│   ├── Models/
│   ├── Resources/
│   └── Services/
└── Tests/
    └── BettingSystemsTests.Tests/
        ├── Data/
        ├── Data Structures/
        ├── Models/
        ├── Services/
        ├── MSTestSettings.cs
        └── App.Config
```

**Source Folder (src):**
- Data: Contains a class for database interaction
- Data Structures: Contains custom data structures used in the system 
- Forms: Contains Windows Forms UI code & Custom controls (CustomControls folder) 
- Models: Contains data models
- Resources: Store images and assets used by winforms controls
- Services: Contains business logic and service classes 

**Database Folder (db):**
- DataSource: Contains CSV files used for bulk insertion into the database (leagues, teams, league-team, players, games, and game results), as well as `insert_team_ratings.xlsx` used to populate player rating data
- `CreateDatabaseSQL.txt`: Text file with the SQL script to create the database schema
- `PopulateTablesSQL.txt`: Text file with the SQL script to bulk insert base data into the database
- `testData.txt`: Text file with the SQL script to insert sample user and transaction data

**Test Folder (`Code/Tests/BettingSystemsTests.Tests` on the **test** branch):**
- Data Structures: Tests for custom data structures
- Data: Integration tests for database operations
- Models: Unit tests for core domain models
- Services: Unit tests for service-layer logic
- MSTestSettings.cs: Shared MSTest setup/configuration helpers

## Technologies Used
- **C# (.NET Windows Form)** - Application interface
- **Microsoft SQL Server** - Database
- **Microsoft.Data.SqlClient** - Database communication
- **ScottPlot** - Financial graphs
- **GoogleGenAI** - Financial report generation
- **MSTest (v4)** - Unit and integration testing framework used in `Code/Tests/BettingSystemsTests.Tests`
- **Visual Studio Test Explorer** - Test execution and result inspection

## Getting the Project
1. Clone the repository from GitHub:
```bash
git clone https://github.com/riyamdx-spec/CST2550CW2.git
```
2. Ensure you are on the **main branch** to get the final deployed version of the app:
```bash
git checkout main
```
3. Open the solution `BettingSystem.slnx` in **Visual Studio 2026**

## How to Run the Project

### Database Setup
1. Copy `Code/db/DataSource` folder to your **local drive** (`C:\`)
2. Open **SQL Server Management Studio (SSMS)**
3. Execute `Code/db/CreateDatabaseSQL.txt` in SSMS **only once** to create the database schema
4. Execute `Code/db/PopulateTablesSQL.txt` in SSMS **only once** to insert initial data

### AI Agent Setup
1. Create a **Google Gemini API Key** at https://aistudio.google.com/api-keys
2. Replace the placeholder **YOUR_API_KEY** in the `App.Config` file with your Google Gemini API key
3. Update the `connectionString` for `BettingDB` in the `App.Config` file to match your local database configuration

### Running the Application
1. Open the solution in **Visual studio**
2. Restore NuGet packages using `dotnet restore` via terminal or go to **Tools -> NuGet Package Manager -> Restore NuGet Packages**
3. Build the solution (go to **Build -> Build Solution** or use `Ctrl + Shift + B`)
4. Run the application
5. The application will generate odds and populate `Odd` table on startup

### Sample Data (Optional)
To insert sample users and betting data:
1. Ensure the application has been launched at least once so that the `Odd` table is automatically populated
2. You can verify this by running the following in SSMS:

```sql
USE BettingSystemDB;
GO

SELECT COUNT(*) AS OddCount FROM Odd;
```

3. Proceed if the **OddCount** is **4041**
4. Execute `Code/db/testData.txt` in SSMS **only once** to insert sample data

> **Note:** The sample betting results are not representative of actual outcomes.  
> They were intentionally generated for testing purposes to demonstrate the functionality of the betting history page, including filtering by **Won**, **Lost**, and **Pending** statuses.

## Troubleshooting

### Database Setup Errors

If you encounter **foreign key constraint errors** when running `PopulateTablesSQL.txt`, this is usually caused by missing data in parent tables. Since tables such as `LeagueTeam`, `Player`, and `GameResult` depend on `League`, `Team` and `Game`, they must be populated in the correct order. If an earlier table is empty due to a failed bulk insert, all dependent tables will also fail.

Check each table in order to find where population failed:

1. In SSMS, run: `SELECT * FROM League` and verify rows exist and IDs start at 1.
2. Then check for `Team`, `LeagueTeam`, `Player`, `Game`, `GameResult` in sequence.
3. The first table that is empty or has an ID starting at `0` is the source of the issue.
4. If the `Game` table is empty, this is most likely caused by a line ending mismatch in the temporary table used during population.

**Fix:**

* Locate line 77 in `PopulateTablesSQL.txt`.
* Find delimeter value in the bulk insert for `#TempGame`.
* If it currently reads `0x0a`, change it to `0x0d0a`.
* Run the script again and verify if the `Game` table is now populated.

**If errors persist**, the cleanest fix is to drop the database and start from scratch by running this in SSMS:

```sql
DROP DATABASE BettingSystemDB;
```

> **Note:** If SSMS reports that the database is in use and cannot be dropped, run the following command first to force all active connections to close, then retry the DROP:
>
> ```sql
> ALTER DATABASE BettingSystemDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
> ```

> Then repeat the steps from the [How to Run the Project Section](#how-to-run-the-project)


### API Key / AI Report Errors

If the **Generate Report** button produces no output or throws an error, this is most likely due to high traffic on the Google Gemini API.

**Steps to resolve:**

1. Wait **2–3 minutes**, then click **Generate Report** again
2. If the issue persists, verify your API key is correctly set in `App.Config` under `GOOGLE_API_KEY`
3. Confirm the key is active at [https://aistudio.google.com/api-keys](https://aistudio.google.com/api-keys)
4. Check that you have not exceeded your free-tier quota for the day

## How to Use the Program

### User Flow
1. Register a new account or log in with existing credentials (Sample data has been provided - current password for all users: `Hello123*`)
2. Browse upcoming matches on the Main Page
3. Select matches and place bets using the right panel, which add selections to your bet slip
4. Deposit funds into your wallet via the `Deposit` button in navigation bar or Profile Page
---
5. Navigate to the Bet Slip page to view or remove bets
6. Enter a stake amount (maximum $1000) and click on `Place Bet`
---
7. Access the dropdown in the nav bar to view Profile page or log out 
8. When logging out or exiting the application, confirm the action as the unpaid bet slip will be lost
9. On the Profile Page, edit your details or change password
10. Deposit or withdraw funds within Profile page 
---
11. Navigate to History page by clicking on `View History` button
12. Filter and sort bet slips by status (`All`, `Pending`, `Won`, `Loss`) and date
13. Click on a bet slip to view outcomes of individual bets
14. Claim winnings by clicking the Claim Button on winning bet slips
15. Logout from the dropdown menu in navbar 

### Admin Flow
1. Login using admin credentials (email: `admin@pitchbet.com`, password: `Hello123*`)
2. View all users and update their status from the View Users Page
3. View and filter matches on the Matches Page
4. Add new matches on the Add Match Page
5. Navigate to Finance page to view financial information and graphs
6. Generate a financial report using the **AI report generation feature** by clicking on `Generate Report`


***Note: For simulation purposes, each match lasts 5 minutes***

## Testing
Test cases cover the following:

1. Validates custom data structures
2. Verifies core business-model logic
3. Checks all input-validation rules
4. Tests service-layer behaviour in memory
5. Integration-tests the database access layer

### Run Tests code
1. Switch to the **tester** branch to find the testing code:
```bash
git checkout tester
```
2. Open `Code/src/BettingSystem.slnx` in Visual Studio.
3. Wait for package restore to finish (or go to **Tools -> NuGet Package Manager -> Restore NuGet Packages**).
4. Build the solution: **Build -> Build Solution** (`Ctrl + Shift + B`).
5. Open the test window: **Test -> Test Explorer**.
6. In Test Explorer, click **Run All Tests**.
7. Review results:
   - Green check = passed
   - Red X = failed (double-click to view failure details and stack trace)

## Odds Generation

The odds logic is implemented in `Code/src/Services/OddsGenerator.cs` and applies a hybrid approach:

1. **Poisson probability model**
   Used in `GenerateCorrectScoreOdd` (via `PoissonProbability`) to estimate exact scoreline likelihood from expected goals before converting that probability into bookmaker odds.

2. **Overround margin model**
   Applied in `ToOdds` using `STANDARD_MARGIN` and `HIGH_VARIANCE_MARGIN` so fair probabilities are converted to priced odds that include bookmaker margin.

3. **Project heuristics (rule-based calibration)**
   Used across methods such as `CalculateOutcomeOdds`, `BuildOverUnderOdds`, `BuildCornerOdds`, `BuildYellowCardOdds`, `BuildRedCardOdds`, and `BuildFirstGoalScorerOdds` through tuned thresholds and weighting rules for match, cards, corners, and scorer markets.

## Simulation System

A periodic timer runs every minute to simulate live match updates by automatically modifying the database .
The simulation system logic is implemented in `Code/src/Service/Simulator.cs`, while database updates operation are handled in `Code/src/Data/DatabaseManager.cs`

### Database Updates
1. Update match status to `Completed` when the match duration has elapsed (5 minutes from match start time)
2. Change match status to `Started` if current time reaches the match start time
3. Update bet results of completed matches based on user selection and game results
4. Update bet slips where all associated bets are completed
---

### Admin Behavior
- Match status are updated in memory
- Match status updates are reflected on the admin interface (Match page)
- Admin can then view results of those completed matches after update
---

### User Behavior
- Started and completed matches are removed from memory
- When returning to main page, only scheduled matches will be displayed 
- Remove started and completed matches from bet slip and trigger an event to update UI in real-time
- Keep count of bets removed from bet slip to display a notification of how many bets were removed on bet slip page
- Bet history and associated bets are updated in memory
- An event is triggered to update bet slips status displayed and allow winning slips to be claimed

## Data Analyst Agent

1. Implementation located in `AdminFinancialManager.cs` (`GenerateFinancialReport` method).
2. The system retrieves the Google Gemini API key from the configuration file.
3. Financial data is fetched from the `SystemTransaction` and `BetSlip` tables.
4. A structured prompt is constructed using the retrieved data.
5. The prompt is sent to the AI agent via the Gemini API.
6. The AI agent analyses the data and generates a financial summary report.
7. The generated report is displayed on the interface for the admin to review.

## References
Password Hashing:
- Gollhardt, C. (2019) *How to hash a password*. Available at: https://stackoverflow.com/a/32191537 (Accessed: 7 February 2026). 

Periodic Timer:
- Kanavos, P. (2022) *How to use PeriodicTimer inside of constructor?*. Available at: https://stackoverflow.com/questions/70688080/how-to-use-periodictimer-inside-of-constructor (Accessed: 22 March 2026). 
Custom Data Structures:
- Davis, M. (2021) *Building a Linked List System From Scratch in C#, Part 1*. Available at: https://medium.com/geekculture/building-a-linked-list-system-from-scratch-in-c-part-1-51aa6c68ea19 (Accessed: 26 March 2026). 
- Microsoft. (2026) *Indexers*. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/ (Accessed: 26 March 2026). 
- Nemes, A. (2020) *Roll your own custom list with C# .NET*. Available at: https://dotnetcodr.com/2020/10/13/roll-your-own-custom-list-with-c-net/ (Accessed: 25 March).

Odds Generation:
- Maher, M. J. (1982) *Modelling association football scores*. Statistica Neerlandica, 36(3), 109-118.
- Dixon, M. J. and Coles, S. G. (1997) *Modelling association football scores and inefficiencies in the football betting market*. Journal of the Royal Statistical Society: Series C (Applied Statistics), 46(2), 265-280.
- Smarkets (n.d.) *Overround explained*. Available at: https://help.smarkets.com/hc/en-gb/articles/214554985-How-to-calculate-betting-margins (Accessed: 13 April 2026).
- Wikipedia (n.d.) *Poisson distribution*. Available at: https://en.wikipedia.org/wiki/Poisson_distribution (Accessed: 13 April 2026).