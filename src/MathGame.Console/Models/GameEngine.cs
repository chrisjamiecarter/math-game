// -------------------------------------------------------------------------------------------------
// MathGame.Console.Models.GameEngine
// -------------------------------------------------------------------------------------------------
// Game related business logic.
// Asks questions for the game, records answers, score, and records to database.
// -------------------------------------------------------------------------------------------------
using System.Diagnostics;
using MathGame.Console.Utilities;
using MathGame.Data;
using MathGame.Enums;
using MathGame.Logic;
using MathGame.Models;

namespace MathGame.Console.Models
{
    internal class GameEngine
    {
        #region Methods: Variables

        internal readonly MathGameDataManager _dataManager;

        #endregion
        #region Constructors

        internal GameEngine(MathGameDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        #endregion
        #region Methods: Internal

        internal void PlayGame(GameType gameType)
        {
            int score = 0;
            var timeTaken= new TimeSpan();
            
            System.Console.Clear();
            System.Console.WriteLine($"{gameType} game");
            System.Console.WriteLine("--------------------");

            System.Console.WriteLine("Please select a difficulty: ");
            System.Console.WriteLine("1 - Easy ");
            System.Console.WriteLine("2 - Normal ");
            System.Console.WriteLine("3 - Hard ");
            
            var gameDifficulty = UserInputReader.GetGameDifficulty();

            System.Console.WriteLine("Please enter amount of questions (1-20): ");

            var questionCount = UserInputReader.GetInt(1, 20);

            List<Question> questions = QuestionEngine.GenerateQuestions(gameType, gameDifficulty, questionCount);
                                   
            foreach (Question question in questions)
            {
                System.Console.Clear();
                System.Console.WriteLine($"{gameType} game: {gameDifficulty}");
                System.Console.WriteLine("--------------------");

                System.Console.WriteLine(question);

                var stopwatch = new Stopwatch();

                stopwatch.Start();
                var userAnswer = UserInputReader.GetInt();
                stopwatch.Stop();
                timeTaken = timeTaken.Add(stopwatch.Elapsed);

                if (userAnswer == question.Answer)
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

            _dataManager.InsertGame(new Game
            {
                DatePlayed = DateTime.Now,
                Score = score,
                Type = gameType,
                Difficulty = gameDifficulty,
                TimeTakenInSeconds = timeTaken.TotalSeconds
            });
        }

        #endregion
    }
}
