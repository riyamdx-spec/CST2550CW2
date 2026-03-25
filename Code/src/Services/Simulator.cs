using BettingSystem.Data;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class Simulator
    {
        private readonly DatabaseManager DbManager = new DatabaseManager();
        private SessionManager CurrentSession;

        private PeriodicTimer _timer;
        private Task _timerTask;
        private CancellationTokenSource _cts;

        public event Action? MatchStatusUpdated;
        public event Action? BetSlipUpdated;
        public event Action? HistoryUpdated;

        public Simulator(AppUser currentUser, SessionManager session)
        {
            CurrentSession = session;
            _timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
            _cts = new CancellationTokenSource();
            _timerTask = TimerExecution(_cts.Token);
        }

        private async Task TimerExecution(CancellationToken token)
        {
            while (await _timer.WaitForNextTickAsync(token))
            {
                try
                {
                    await UpdatesDB();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void Cancel() => _cts.Cancel();
        public async ValueTask DisposeAsync()
        {
            _timer.Dispose();
            await _timerTask;
            GC.SuppressFinalize(this);
        }

        private async Task UpdatesDB()
        {
            var (startedMatchIds, completedMatchIds, updatedBets, updatedSlips) = await DbManager.WrapTableUpdatesAsync();
            if (startedMatchIds?.Count > 0 || completedMatchIds?.Count > 0)
            {
                UpdateMemory(startedMatchIds, completedMatchIds, updatedBets, updatedSlips);
            }
        }

        private void UpdateMemory(List<int> startedMatchIds, List<int> completedMatchIds, Dictionary<int, string> updatedBets, Dictionary<int, string> updatedSlips)
        {
            var removedMatchesId = new List<int>();
            var memoryBetSlip = CurrentSession.UserSlip;
            var historyBetSlips = CurrentSession.HistoryBetSlips;

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
            var allMatches = CurrentSession.MatchesCollection.AllMatches;
            var matchesByLeague = CurrentSession.MatchesCollection.MatchesByLeague;
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
            MatchStatusUpdated?.Invoke();
        }

        // update slips and bets in history
        private bool UpdateHistoryBets(Dictionary<int, string> updatedBets, Dictionary<int, string> updatedSlips)
        {
            var historyBetSlips = CurrentSession.HistoryBetSlips;
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
