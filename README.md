# Football Betting System

## Project Overview
The Football Betting System is a C# Windows Form application that simulates a football betting platform. It allows users to register and log in, view upcoming football matches, place cummulative bets and monitor outcomes of their bets. 

Users can also manage their account by editing their profile details and password, as well as depositing or withdrawing funds from their digital wallet. The system includes authentication mechanisms, automated bet validation and payout calculations.

In addition, an admin interface is provided for managing users, matches and accessing financial reports

## Features
### System Features
- Simulates football matches using a periodic timer that updates the database every minute
- Generate odds based on team and player ratings
- Randomly generate results for matches added by Admin
- Generate odds for matches added by Admin
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
**Code Folder:**
```text
Code/
├── Assets/
├── db/
│   ├── DataSource/
│   ├── CreateDatabaseSQL.txt
│   ├── PopulateTablesSQL.txt
│   └── testData.txt
└── src/
    ├── Data/
    ├── Data Structures/
    ├── Forms/
    ├── Models/
    ├── Resources/
    └── Services/
```

**Source Folder (src) structure:**
- Data Structures: Contains custom data structures used in the system 
- Data: Contains class for database interaction
- Forms: Contains Windows Forms UI code & Custom controls (CustomControls folder) 
- Models: Contains data models
- Resources: Store images and assets used by winforms controls
- Services: Contains business logic and service classes 

## Technologies Used
- **C# (.NET Windows Form)** - Application interface
- **Microsoft SQL Server** - Database
- **Microsoft.Data.SqlClient** - Database communication
- **ScottPlot** - Financial graphs
- **GoogleGenAI** - Financial report generation

## How to Run the Project

### Database Setup
1. Download the `Code/db/DataSource` folder from the repository
2. Move `DataSource` folder to your **local drive** (typically, path `C:\`)
3. Open **SQL Server Management Studio (SSMS)**
4. Execute `Code/db/CreateDatabaseSQL.txt` in SSMS to create the database schema
5. Execute `Code/db/PopulateTablesSQL.txt` in SSMS to insert initial data
6. Execute `Code/db/testData.txt` in SSMS to insert sample data

### AI Agent Setup
1. Create a **Google Gemini API Key**
2. Replace the value of `GOOGLE_API_KEY` in `App.Config` with your key
3. Replace the connectionString for `BettingDB` in `App.Config` to match your created database

### Running the Application
1. Open the solution in **Visual studio**
2. Restore NuGet packages using `dotnet restore`
3. Build the solution
2. Run the application

## How to use the program

### User Flow
1. Register a new account or log in with existing credentials (Test data has been provided - current password for all users: `Hello123*`)
2. Browse upcoming matches on the Main Page
3. Select matches and place bets using the right panel, which add selections to your bet slip
4. Deposit funds into your wallet via the `Deposit` button in navigation bar or Profile Page
---
5. Navigate to the Bet Slip page to view or remove bets
6. Enter a stake amount (maximum $1000) and click on `Place Bet`
---
7. Access the dropdown in the nav bar to view Profile page or log out 
8. If logging out or exiting the application, confirm the action as the unpaid bet slip will be lost
9. On the Profile Page, edit your details or change password
10. Deposit or withdraw funds within Profile page 
---
11. Navigate to History page by clicking on `View History` button
12. Filter and sort bet slips by status (`All`, `Pending`, `Won`, `Loss`) and date
13. Click on a bet slip to view outcomes of individual bets
14. Claim winnings by clicking the Claim Button on winning bet slips
15. Logout from the dropdown menu in navbar 

### Admin Flow
1. Login using admin credentials
2. View all users and update their status from the View Users Page
3. View and filter matches on the Matches Page
4. Add new matches on the Add Match Page
5. Navigate to Finance page to view financial information and graphs
6. Generate a financial report using the **AI report generation feature** by clicking on `Generate Report`


***Note: For simulation purposes, each match lasts 5 minutes***

## Simulation System

A periodic timer runs every minute to simulate live match updates by modifying the database automatically.

### Database Updates
1. Update match status to `Completed` when the match duration has elapsed (5 minutes from current time)
2. Change match status to `Started` if current time reaches the match start time
3. Update bet results of completed matches based on user selection and game results
4. Update bet slips where all associated bets are completed
---

### Admin Behavior
- Match status are updated in memory
- Match status updates are reflected on the admin interface (Match page)
- Admin can then view results of those matches after update
---

### User Behavior
- Started and completed matches are removed from memory
- When returning to main page, only scheduled matches will be displayed 
- Remove started and completed matches from bet slip and trigger an event to update UI in real-time
- Keep count of bets removed from bet slip to display a notification on bet slip page
- Bet history and associated bet are updated in memory
- An event is triggered to to update bet slips status displayed

## Data Analyst Agent

1. System reads Google Gemini API Key
2. Builds a prompt based on financial data fetched from database (SystemTransaction and BetSlip tables)
3. Sends request to AI Agent
4. AI Agent analyses the data and executes a financial summary
5. Agent returns the report to be displayed on the interface