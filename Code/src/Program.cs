using System;
using System.Windows.Forms;
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
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            ApplicationConfiguration.Initialize();

            OddsAutoGeneratorService? oddsAutoGenerator = null;
            try
            {
                var dbManager = new DatabaseManager();
                oddsAutoGenerator = dbManager.CreateOddsAutoGeneratorService();

                var initialRun = oddsAutoGenerator.RunOnce();
                Console.WriteLine($"Odds bootstrap complete. Games processed: {initialRun.ProcessedGames}, odds generated: {initialRun.GeneratedOdds}.");

                oddsAutoGenerator.Start();
                Application.ApplicationExit += (_, _) => oddsAutoGenerator?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Odds auto-generator could not start: {ex.Message}");
            }

            Application.Run(new landingPage());
        }
    }
}