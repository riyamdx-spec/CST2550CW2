using BettingSystem.Data;
using BettingSystem.Forms;
using BettingSystem.Services;

namespace BettingSystem
{
    internal static class Program
    {
        [STAThread]
        //static async Task Main()
        static void Main()

        {
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            ApplicationConfiguration.Initialize();

            try
            {
                //start match simulator to update database
                Simulator appSimulator = new Simulator();

                var oddsService = new OddsAutoGeneratorService();

                //generate odds for matches
                oddsService.RunOnce().GetAwaiter().GetResult();

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