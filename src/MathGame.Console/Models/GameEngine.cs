using System.Diagnostics;
using MathGame.Console.Utilities;
using MathGame.Data;
using MathGame.Enums;
using MathGame.Logic;
using MathGame.Models;

namespace MathGame.Console.Models;

/// <summary>
/// Asks questions for the game, records answers, score, and records to database.
/// </summary>
internal class GameEngine(MathGameDataManager dataManager)
{
    internal readonly MathGameDataManager _dataManager = dataManager;

    internal void PlayGame(GameType gameType, GameDifficulty? gameDifficulty, int? questionCount)
    {
        int score = 0;
        var timeTaken= new TimeSpan();
        
        System.Console.Clear();
        System.Console.WriteLine($"{gameType} game");
        System.Console.WriteLine("--------------------");
        
        var selectedGameDifficulty = gameDifficulty ?? UserInputReader.GetGameDifficulty();

        var selectedQuestionCount = questionCount ?? UserInputReader.GetQuestionCount();

        List<Question> questions = QuestionEngine.GenerateQuestions(gameType, selectedGameDifficulty, selectedQuestionCount);
                               
        foreach (Question question in questions)
        {
            System.Console.Clear();
            System.Console.WriteLine($"{gameType} game: {selectedGameDifficulty} ({question.Id}/{questions.Count})");
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
            Difficulty = selectedGameDifficulty,
            TimeTakenInSeconds = timeTaken.TotalSeconds
        });
    }
}
