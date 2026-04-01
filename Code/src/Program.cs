using BettingSystem.Data;
using BettingSystem.Forms;
using BettingSystem.Services;

namespace BettingSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            ApplicationConfiguration.Initialize();

            OddsAutoGeneratorService? oddsAutoGenerator = null;
            try
            {
                Simulator appSimulator = new Simulator();
                var dbManager = new DatabaseManager();
                oddsAutoGenerator = dbManager.CreateOddsAutoGeneratorService();

                var initialRun = oddsAutoGenerator.RunOnce();
                Console.WriteLine($"Odds bootstrap complete. Games processed: {initialRun.ProcessedGames}, odds generated: {initialRun.GeneratedOdds}.");

                oddsAutoGenerator.Start();
                Application.ApplicationExit += (_, _) => oddsAutoGenerator?.Dispose();
                Application.ApplicationExit += (_, _) =>
                {
                    if (appSimulator != null)
                    {
                        appSimulator.Cancel();
                        appSimulator.DisposeAsync().AsTask().GetAwaiter().GetResult();
                    }
                };

                var landingPage = new landingPage(appSimulator);
                appSimulator.Start();
                Application.Run(landingPage);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Odds auto-generator could not start: {ex.Message}");
            }

        }
    }
}