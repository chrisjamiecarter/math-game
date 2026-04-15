using System.Text;
using MathGame.Console.Enums;
using MathGame.Console.Models;
using MathGame.Data;
using MathGame.Enums;
using MathGame.Models;

namespace MathGame.Console.Views;

/// <summary>
/// The menu console view of the application.
/// </summary>
/// <param name="dataManager">The data manager for the application.</param>
internal class Menu(MathGameDataManager dataManager)
{
    private bool _startup = true;
    private readonly MathGameDataManager _dataManager = dataManager;

    internal static string MenuText
    {
        get
        {
            var menuTextSb = new StringBuilder();
            menuTextSb.AppendLine("V - View previous games");
            menuTextSb.AppendLine("A - Addition");
            menuTextSb.AppendLine("S - Subtraction");
            menuTextSb.AppendLine("M - Multiplication");
            menuTextSb.AppendLine("D - Division");
            menuTextSb.AppendLine("R - Random");
            menuTextSb.AppendLine("Q - Quit the application");
            menuTextSb.AppendLine("");
            menuTextSb.AppendLine("Enter your selection: ");

            return menuTextSb.ToString();
        }
    }

    internal GameStatus Show(string? name, DateTime date, GameDifficulty? gameDifficulty, int? questionCount)
    {
        if (_startup)
        {
            System.Console.Clear();
            System.Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. This is your math's game.\n");
            System.Console.WriteLine($"Press any key to show menu...");
            System.Console.ReadLine();
            _startup = false;
        }

        System.Console.Clear();
        System.Console.Write(MenuText);

        var option = GetOption();

        return PerformOption(option, gameDifficulty, questionCount);
    }

    internal GameStatus PerformOption(string option, GameDifficulty? gameDifficulty, int? questionCount)
    {
        var result = GameStatus.Started;

        var gameEngine = new GameEngine(_dataManager);

        switch (option)
        {
            case "v":
                IReadOnlyList<Game> gameHistory = [];
                if (_dataManager != null)
                {
                    gameHistory = _dataManager.GetGames();
                }
                GameHistory.Show(gameHistory);
                break;
            case "a":
                gameEngine.PlayGame(GameType.Addition, gameDifficulty, questionCount);
                break;
            case "s":
                gameEngine.PlayGame(GameType.Subtraction, gameDifficulty, questionCount);
                break;
            case "m":
                gameEngine.PlayGame(GameType.Multiplication, gameDifficulty, questionCount);
                break;
            case "d":
                gameEngine.PlayGame(GameType.Division, gameDifficulty, questionCount);
                break;
            case "r":
                gameEngine.PlayGame(GameType.Random, gameDifficulty, questionCount);
                break;
            case "q":
                result = GameStatus.Stopped;
                break;
            default:
                System.Console.WriteLine("Invalid option selected. Press any key to continue...");
                System.Console.ReadLine();
                break;
        }

        return result;
    }

    internal static string GetOption()
    {
        var option = System.Console.ReadLine();

        option = string.IsNullOrWhiteSpace(option) ? "" : option.Trim().ToLower();

        return option;
    }
}
