using MathGame.Console.Models;

namespace MathGame.Console.Utilities
{
    internal static class Helper
    {
        private static List<Game> _gameHistory = new List<Game>
        {
            //new Game {Date = DateTime.Now.AddDays(-15), Type = GameType.Addition, Score = 5},
            //new Game {Date = DateTime.Now.AddDays(-14), Type = GameType.Multiplication, Score = 4},
            //new Game {Date = DateTime.Now.AddDays(-13), Type = GameType.Division, Score = 4},
            //new Game {Date = DateTime.Now.AddDays(-12), Type = GameType.Subtraction, Score = 3},
            //new Game {Date = DateTime.Now.AddDays(-11), Type = GameType.Addition, Score = 1},
            //new Game {Date = DateTime.Now.AddDays(-10), Type = GameType.Multiplication, Score = 2},
            //new Game {Date = DateTime.Now.AddDays(-9), Type = GameType.Division, Score = 3},
            //new Game {Date = DateTime.Now.AddDays(-8), Type = GameType.Subtraction, Score = 4},
            //new Game {Date = DateTime.Now.AddDays(-7), Type = GameType.Addition, Score = 4},
            //new Game {Date = DateTime.Now.AddDays(-6), Type = GameType.Multiplication, Score = 1},
            //new Game {Date = DateTime.Now.AddDays(-5), Type = GameType.Division, Score = 0},
            //new Game {Date = DateTime.Now.AddDays(-4), Type = GameType.Subtraction, Score = 2},
            //new Game {Date = DateTime.Now.AddDays(-3), Type = GameType.Addition, Score = 5},
            //new Game {Date = DateTime.Now.AddDays(-2), Type = GameType.Multiplication, Score = 4},
            //new Game {Date = DateTime.Now.AddDays(-1), Type = GameType.Division, Score = 4},
            //new Game {Date = DateTime.Now, Type = GameType.Addition, Score = 5},
        };

        internal static void DisplayGameHistory(string message)
        {
            System.Console.Clear();
            System.Console.WriteLine(message);
            System.Console.WriteLine("--------------------");

            foreach (var game in _gameHistory)
            {
                System.Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts");
            }
            System.Console.WriteLine("--------------------");
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to return to the Main Menu");
            System.Console.ReadLine();
        }

        internal static void AddGameHistory(GameType gameType, int gameScore)
        {
            _gameHistory.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }

        internal static List<int[]> GetAdditionNumbers(int generateCount)
        {
            List<int[]> result = [];

            for (int i = 0; i < generateCount; i++)
            {
                var firstNumber = Random.Shared.Next(1, 99);
                var secondNumber = Random.Shared.Next(1, 99);

                result.Add([firstNumber, secondNumber]);
            }

            return result;
        }

        internal static List<int[]> GetSubtractionNumbers(int generateCount)
        {
            List<int[]> result = [];

            for (int i = 0; i < generateCount; i++)
            {
                var firstNumber = Random.Shared.Next(1, 99);
                var secondNumber = Random.Shared.Next(1, 99);

                while (firstNumber > secondNumber)
                {
                    firstNumber = Random.Shared.Next(1, 99);
                    secondNumber = Random.Shared.Next(1, 99);
                }

                result.Add([firstNumber, secondNumber]);
            }

            return result;
        }

        internal static List<int[]> GetMultiplicationNumbers(int generateCount)
        {
            List<int[]> result = [];

            for (int i = 0; i < generateCount; i++)
            {
                var firstNumber = Random.Shared.Next(1, 12);
                var secondNumber = Random.Shared.Next(1, 12);

                result.Add([firstNumber, secondNumber]);
            }

            return result;
        }

        internal static List<int[]> GetDivisionNumbers(int numberToGenerate)
        {
            List<int[]> result = [];

            for (int i = 0; i < numberToGenerate; i++)
            {
                var firstNumber = Random.Shared.Next(1, 99);
                var secondNumber = Random.Shared.Next(1, 99);

                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = Random.Shared.Next(1, 99);
                    secondNumber = Random.Shared.Next(1, 99);
                }

                result.Add([firstNumber, secondNumber]);
            }

            return result;
        }

        internal static string? GetName()
        {
            System.Console.WriteLine("Please type your name: ");

            var name = UserInputReader.GetString(false);
            return name;
        }

        internal static void QuitApplication()
        {
            System.Console.Clear();
            System.Console.WriteLine("Quitting application");
            Environment.Exit(1);
        }

        internal static string GetOption()
        {
            var option = System.Console.ReadLine();

            // Normalise.
            option = string.IsNullOrWhiteSpace(option) ? "" : option.Trim().ToLower();

            return option;
        }
    }
}
