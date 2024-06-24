// -------------------------------------------------------------------------------------------------
// MathGame.Console.Program
// -------------------------------------------------------------------------------------------------
// The insertion point of the console application.
// -------------------------------------------------------------------------------------------------
using MathGame.Console.Enums;
using MathGame.Console.Utilities;
using MathGame.Console.Views;
using MathGame.Data;

namespace MathGame.Console
{
    internal class Program
    {
        #region Variables

        private static readonly DateTime _date = DateTime.Now;
        private static MathGameDataManager? _dataManager;
        private static GameStatus _status;

        #endregion
        #region Methods: Private Static

        private static void Main(string[] args)
        {
            var databaseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"math-game.db");
            _dataManager = new MathGameDataManager(databaseFilePath);
            
            string? name = GetName();
            
            var menu = new Menu(_dataManager);

            _status = GameStatus.Started;
            
            while (_status != GameStatus.Stopped)
            {
                _status = menu.Show(name, _date);
                
            }

            // Close the application.
            Environment.Exit(1);
        }

        #endregion
        #region Methods: Internal Static

        internal static string? GetName()
        {
            System.Console.WriteLine("Please type your name: ");

            var name = UserInputReader.GetString(false);
            return name;
        }

        #endregion
    }
}
