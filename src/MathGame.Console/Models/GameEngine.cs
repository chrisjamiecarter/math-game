using MathGame.Console.Utilities;
using MathGame.Data;
using MathGame.Enums;
using MathGame.Logic;
using MathGame.Models;

namespace MathGame.Console.Models
{
    internal class GameEngine
    {
        internal readonly MathGameDataManager _dataManager;

        internal GameEngine(MathGameDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        
        internal void PlayGame(GameType gameType)
        {
            int score = 0;

            // TODO: Implement difficulty settings (enum, max values).
            System.Console.Clear();
            System.Console.WriteLine($"{gameType} game");
            System.Console.WriteLine("--------------------");

            System.Console.WriteLine("Please select a difficulty: ");
            System.Console.WriteLine("1 - Easy ");
            System.Console.WriteLine("2 - Normal ");
            System.Console.WriteLine("3 - Hard ");
            
            var gameDifficulty = UserInputReader.GetGameDifficulty();
                        
            List<Question> questions = QuestionEngine.GenerateQuestions(gameType, gameDifficulty);
                                   
            foreach (Question question in questions)
            {
                System.Console.Clear();
                System.Console.WriteLine($"{gameType} game: {gameDifficulty}");
                System.Console.WriteLine("--------------------");

                System.Console.WriteLine(question);

                var userAnswer = UserInputReader.GetInt();

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
                Difficulty = gameDifficulty
            });
        }
    }
}
