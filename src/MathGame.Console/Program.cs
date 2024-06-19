using System;
using System.Text;

namespace MathGame.Console
{
    internal class Program
    {
        #region variables

        private static readonly DateTime _date = DateTime.Now;
        private static bool _quitApplication = false;
        private static List<string> _gameHistory = [];

        #endregion
        #region Methods: Static

        static void Main(string[] args)
        {
            string? name = GetName();
            
            while (!_quitApplication)
            {
                var option = GetOption(name);
                PerformOption(option);
            }
        }

        private static string? GetName()
        {
            System.Console.WriteLine("Please type your name: ");

            var name = System.Console.ReadLine();
            return name;
        }

        private static string GetOption(string? name)
        {
            System.Console.Clear();
            System.Console.WriteLine($"Hello {name}. It's {_date.DayOfWeek}. This is your math's game.\n");
            System.Console.WriteLine("--------------------");

            var questionSb = new StringBuilder();
            questionSb.AppendLine("V - View previous games");
            questionSb.AppendLine("A - Addition");
            questionSb.AppendLine("S - Subtraction");
            questionSb.AppendLine("M - Multiplication");
            questionSb.AppendLine("D - Division");
            questionSb.AppendLine("Q - Quit the application");
            questionSb.AppendLine("");
            questionSb.AppendLine("Enter your selection: ");

            System.Console.Write(questionSb.ToString());
            
            var game = System.Console.ReadLine();

            // Normalise.
            game = string.IsNullOrWhiteSpace(game) ? "" : game.Trim().ToLower();
           
            return game;
        }

        private static void PerformOption(string option)
        {
            switch (option)
            {
                case "v":
                    GetGames("Games History");
                    break;
                case "a":
                    AdditionGame("Addition Game");
                    break;
                case "s":
                    SubtractionGame("Subtraction Game");
                    break;
                case "m":
                    MultiplicationGame("Multiplication Game");
                    break;
                case "d":
                    DivisionGame("Division Game");
                    break;
                case "q":
                    _quitApplication = true;
                    QuitApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid option selected. Press any key to continue.");
                    System.Console.ReadLine();
                    break;
            }
        }

        private static void GetGames(string message)
        {
            System.Console.Clear();
            System.Console.WriteLine(message);
            System.Console.WriteLine("--------------------");

            foreach(var game in _gameHistory)
            {
                System.Console.WriteLine(game);
            }
            System.Console.WriteLine("--------------------");
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to return to the Main Menu");
            System.Console.ReadLine();
        }

        private static void AddGameToHistory(string gameType, int gameScore)
        {
            _gameHistory.Add($"{DateTime.Now} - {gameType}: Score = {gameScore}");

        }

        private static void AdditionGame(string message)
        {
            int score = 0;
            int questionCount = 5;

            List<int[]> numbers = GetNumbers(questionCount);

            for (int i = 0; i < 5; i++)
            {
                System.Console.Clear();
                System.Console.WriteLine(message);
                System.Console.WriteLine("--------------------");

                var firstNumber = numbers[i][0];
                var secondNumber = numbers[i][1];

                System.Console.WriteLine($"{firstNumber} + {secondNumber} = ?");
                
                var result = firstNumber + secondNumber;
                var answer = System.Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(answer) && int.Parse(answer) == result)
                {
                    System.Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    System.Console.WriteLine("Incorrect...");
                }

                System.Console.WriteLine("Press any key for the next question.");
                System.Console.ReadLine();
            }

            System.Console.WriteLine($"Game over. Your final score is {score}");
            AddGameToHistory("Addition", score);
        }

        private static void SubtractionGame(string message)
        {
            int score = 0;
            int questionCount = 5;

            List<int[]> numbers = GetNumbers(questionCount);

            for (int i = 0; i < 5; i++)
            {
                System.Console.Clear();
                System.Console.WriteLine(message);
                System.Console.WriteLine("--------------------");

                var firstNumber = numbers[i][0];
                var secondNumber = numbers[i][1];

                System.Console.WriteLine($"{firstNumber} - {secondNumber} = ?");

                var result = firstNumber - secondNumber;
                var answer = System.Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(answer) && int.Parse(answer) == result)
                {
                    System.Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    System.Console.WriteLine("Incorrect...");
                }

                System.Console.WriteLine("Press any key for the next question.");
                System.Console.ReadLine();
            }

            System.Console.WriteLine($"Game over. Your final score is {score}");
            AddGameToHistory("Subtraction", score);
        }

        private static void MultiplicationGame(string message)
        {
            int score = 0;
            int questionCount = 5;

            List<int[]> numbers = GetNumbers(questionCount);

            for (int i = 0; i < questionCount; i++)
            {
                System.Console.Clear();
                System.Console.WriteLine(message);
                System.Console.WriteLine("--------------------");

                var firstNumber = numbers[i][0];
                var secondNumber = numbers[i][1];

                System.Console.WriteLine($"{firstNumber} * {secondNumber} = ?");

                var result = firstNumber * secondNumber;
                var answer = System.Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(answer) && int.Parse(answer) == result)
                {
                    System.Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    System.Console.WriteLine("Incorrect...");
                }

                System.Console.WriteLine("Press any key for the next question.");
                System.Console.ReadLine();
            }

            System.Console.WriteLine($"Game over. Your final score is {score}");
            AddGameToHistory("Multiplication", score);
        }

        private static void DivisionGame(string message)
        {
            int score = 0;
            int questionCount = 5;

            List<int[]> numbers = GetDivisionNumbers(questionCount);

            for (int i = 0; i < questionCount; i++)
            {
                System.Console.Clear();
                System.Console.WriteLine(message);
                System.Console.WriteLine("--------------------");
                                
                var firstNumber = numbers[i][0];
                var secondNumber = numbers[i][1];

                System.Console.WriteLine($"{firstNumber} / {secondNumber} = ?");

                var result = firstNumber / secondNumber;
                var answer = System.Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(answer) && int.Parse(answer) == result)
                {
                    System.Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    System.Console.WriteLine("Incorrect...");
                }

                System.Console.WriteLine("Press any key for the next question.");
                System.Console.ReadLine();
            }

            System.Console.WriteLine($"Game over. Your final score is {score}");
            AddGameToHistory("Division", score);
        }

        private static void QuitApplication()
        {
            System.Console.Clear();
            System.Console.WriteLine("Quitting application");
            Environment.Exit(1);
        }

        private static List<int[]> GetNumbers(int generateCount)
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

        private static List<int[]> GetDivisionNumbers(int numberToGenerate)
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

        #endregion
    }
}
