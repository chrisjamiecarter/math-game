using MathGame.Console.Models;
using MathGame.Console.Utilities;
using MathGame.Console.Views;

namespace MathGame.Console
{
    internal class Program
    {
        #region Variables

        private static readonly DateTime _date = DateTime.Now;
        private static GameEngine? _gameEngine;

        #endregion
        #region Methods: Static

        static void Main(string[] args)
        {
            string? name = Helper.GetName();
            
            var menu = new Menu();
            
            _gameEngine = new GameEngine();
            
            while (_gameEngine.Status != GameEngine.GameStatus.Stopped)
            {
                menu.Show(name, _date);
                
                var option = Helper.GetOption();

                _gameEngine.PerformOption(option);
            }

            Helper.QuitApplication();
        }
        
        #endregion
    }
}
