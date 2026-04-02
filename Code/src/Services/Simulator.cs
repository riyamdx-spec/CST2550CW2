using BettingSystem.Data;
using BettingSystem.Data_Structures;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class Simulator
    {
        private readonly DatabaseManager _dbManager = new DatabaseManager();
        private SessionManager? _currentSession;

        private PeriodicTimer _timer;
        private Task _timerTask;
        private CancellationTokenSource _cts;
        private bool _isRunning;

        public event Action? MatchStatusUpdated;
        public event Action? BetSlipUpdated;
        public event Action? HistoryUpdated;

        public Simulator()
        {
            _currentSession = null;
            _timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
            _cts = new CancellationTokenSource();
        }

        //start timer
        public void Start()
        {
            _timerTask = Task.Run(async () =>
            {
                await UpdatesDB();
                await TimerExecution(_cts.Token);
            });
        }

        private async Task TimerExecution(CancellationToken token)
        {
            while (await _timer.WaitForNextTickAsync(token))
            {
                //prevent overlapping
                if (_isRunning)
                    continue;

                try
                {
                    _isRunning = true;
                    await UpdatesDB();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                finally
                {
                    _isRunning=false;
                }
            }
        }

        public void Cancel() => _cts.Cancel();
        public async ValueTask DisposeAsync()
        {
            _timer.Dispose();
            if (_timerTask != null)
            {
                try
                {
                    await _timerTask;
                }catch (Exception e)
                {
                    Console.WriteLine($"Error: {e}");
                }
            }
            GC.SuppressFinalize(this);
        }

        public void SetSession( SessionManager sessionManager)
        {
            _currentSession = sessionManager;
        }

        //update database
        private async Task UpdatesDB()
        {
            var (startedMatchIds, completedMatchIds, updatedBets, updatedSlips) = await _dbManager.WrapTableUpdatesAsync();

            //update in memory
            if (_currentSession is not null && (startedMatchIds?.Count > 0 || completedMatchIds?.Count > 0) )
            {
                if (_currentSession.IsAdmin)
                {
                    UpdateAdminSide(startedMatchIds, completedMatchIds);
                }
                else
                {
                    UpdateMemory(startedMatchIds, completedMatchIds, updatedBets, updatedSlips);
                }
            }
            
        }

        //update match status on admin panel
        private void UpdateAdminSide(MyList<int> startedMatchIds, MyList<int> completedMatchIds)
        {
            var allMatches = _currentSession.MatchesCollection.AllMatches;

            //update match status
            foreach(FootballMatch match in allMatches)
            {
                if (startedMatchIds.Contains(match.GameID))
                {
                    match.GameStatus = "Started";
                }else if (completedMatchIds.Contains(match.GameID))
                {
                    match.GameStatus = "Completed";
                }
            }
            //event to update UI
            MatchStatusUpdated?.Invoke();
        }

        private void UpdateMemory(MyList<int> startedMatchIds, MyList<int> completedMatchIds, MyDictionary<int, string> updatedBets, MyDictionary<int, string> updatedSlips)
        {
            var removedMatchesId = new List<int>();
            var memoryBetSlip = _currentSession.UserSlip;
            var historyBetSlips = _currentSession.HistoryBetSlips;

            if (startedMatchIds.Count > 0) 
                removedMatchesId.AddRange(startedMatchIds);

            if (completedMatchIds.Count > 0)
                removedMatchesId.AddRange(completedMatchIds);

            if (removedMatchesId.Count > 0)
            {
                UpdateMatches(removedMatchesId);

                // remove completed/started matches from in-memory bet slip
                if (memoryBetSlip.Bets.Count > 0 && memoryBetSlip.RemoveBetsByGameIds(removedMatchesId))
                    BetSlipUpdated?.Invoke();
            }

            if (updatedBets.Count > 0 && UpdateHistoryBets(updatedBets, updatedSlips))
                HistoryUpdated?.Invoke(); //event to update UI
        }

        // remove matches which already started or are completed
        private void UpdateMatches(List<int> removedMatchesId)
        {
            var allMatches = _currentSession.MatchesCollection.AllMatches;
            var matchesByLeague = _currentSession.MatchesCollection.MatchesByLeague;
            var removedMatches = allMatches
                .Where(m => removedMatchesId.Contains(m.GameID))
                .ToList();

            foreach (var match in removedMatches)
            {
                allMatches.Remove(match);
                foreach (int leagueId in matchesByLeague.Keys)
                {
                    matchesByLeague[leagueId].Remove(match);
                }
            }
        }

        // update slips and bets in history
        private bool UpdateHistoryBets(MyDictionary<int, string> updatedBets, MyDictionary<int, string> updatedSlips)
        {
            var historyBetSlips = _currentSession.HistoryBetSlips;
            bool changed = false;

            foreach (var slip in historyBetSlips)
            {
                //update slip status
                if (updatedSlips.TryGetValue(slip.SlipID, out var slipStatus))
                {
                    slip.Status = slipStatus;
                    changed = true;
                }

                // update bets in user's history bet slips
                foreach (var bet in slip.Bets)
                {
                    if (updatedBets.TryGetValue(bet.BetId, out string betResult))
                    {
                        bet.Result = betResult;
                        changed = true;
                    }
                }
            }
            return changed;
        }
    }
}
