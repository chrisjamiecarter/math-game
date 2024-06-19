using MathGame.Console.Utilities;

namespace MathGame.Console.Models
{
    internal class GameEngine
    {
        internal enum GameStatus
        {
            Started,
            Stopped
        }

        internal GameStatus Status;

        public GameEngine()
        {
            Status = GameStatus.Started;
        }

        internal void PerformOption(string option)
        {
            switch (option)
            {
                case "v":
                    Helper.DisplayGameHistory("Games History");
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
                    Status = GameStatus.Stopped;
                    break;
                default:
                    System.Console.WriteLine("Invalid option selected. Press any key to continue.");
                    System.Console.ReadLine();
                    break;
            }
        }

        internal static void AdditionGame(string message)
        {
            int score = 0;
            int questionCount = 5;

            List<int[]> numbers = Helper.GetAdditionNumbers(questionCount);

            for (int i = 0; i < 5; i++)
            {
                System.Console.Clear();
                System.Console.WriteLine(message);
                System.Console.WriteLine("--------------------");

                var firstNumber = numbers[i][0];
                var secondNumber = numbers[i][1];

                System.Console.WriteLine($"{firstNumber} + {secondNumber} = ?");

                var result = firstNumber + secondNumber;
                var answer = UserInputReader.GetInt();

                if (answer == result)
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

            System.Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
            System.Console.ReadLine();

            Helper.AddGameHistory(GameType.Addition, score);
        }

        internal static void SubtractionGame(string message)
        {
            int score = 0;
            int questionCount = 5;

            List<int[]> numbers = Helper.GetSubtractionNumbers(questionCount);

            for (int i = 0; i < 5; i++)
            {
                System.Console.Clear();
                System.Console.WriteLine(message);
                System.Console.WriteLine("--------------------");

                var firstNumber = numbers[i][0];
                var secondNumber = numbers[i][1];

                System.Console.WriteLine($"{firstNumber} - {secondNumber} = ?");

                var result = firstNumber - secondNumber;
                var answer = UserInputReader.GetInt();

                if (answer == result)
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
            Helper.AddGameHistory(GameType.Subtraction, score);
        }

        internal static void MultiplicationGame(string message)
        {
            int score = 0;
            int questionCount = 5;

            List<int[]> numbers = Helper.GetMultiplicationNumbers(questionCount);

            for (int i = 0; i < questionCount; i++)
            {
                System.Console.Clear();
                System.Console.WriteLine(message);
                System.Console.WriteLine("--------------------");

                var firstNumber = numbers[i][0];
                var secondNumber = numbers[i][1];

                System.Console.WriteLine($"{firstNumber} * {secondNumber} = ?");

                var result = firstNumber * secondNumber;
                var answer = UserInputReader.GetInt();

                if (answer == result)
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
            Helper.AddGameHistory(GameType.Multiplication, score);
        }

        internal static void DivisionGame(string message)
        {
            int score = 0;
            int questionCount = 5;

            List<int[]> numbers = Helper.GetDivisionNumbers(questionCount);

            for (int i = 0; i < questionCount; i++)
            {
                System.Console.Clear();
                System.Console.WriteLine(message);
                System.Console.WriteLine("--------------------");

                var firstNumber = numbers[i][0];
                var secondNumber = numbers[i][1];

                System.Console.WriteLine($"{firstNumber} / {secondNumber} = ?");

                var result = firstNumber / secondNumber;
                var answer = UserInputReader.GetInt();

                if (answer == result)
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
            Helper.AddGameHistory(GameType.Division, score);
        }

    }
}
