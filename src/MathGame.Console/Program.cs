using MathGame.Console.Enums;
using MathGame.Console.Utilities;
using MathGame.Console.Views;
using MathGame.Data;

namespace MathGame.Console;

/// <summary>
/// Insertion point for the application.
/// It initializes the data manager, shows the menu, and handles user input to play the game or view previous games.
/// </summary>
internal static class Program
{
    private static readonly DateTime _date = DateTime.Now;
    private static MathGameDataManager? _dataManager;
    private static GameStatus _status;

    private static void Main(string[] args)
    {
        var (parsedArgs, error) = ArgumentParser.Parse(args);

        if (error != null)
        {
            System.Console.WriteLine(error);
            System.Console.WriteLine(ArgumentParser.GetUsage());
            Environment.Exit(-1);
        }

        var databaseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"math-game.db");
        _dataManager = new MathGameDataManager(databaseFilePath);

        string? name = parsedArgs.Name ?? GetName();

        var menu = new Menu(_dataManager);

        _status = GameStatus.Started;

        while (_status != GameStatus.Stopped)
        {
            _status = menu.Show(name, _date, parsedArgs.GameDifficulty, parsedArgs.QuestionCount);
        }

        Environment.Exit(1);
    }

    internal static string? GetName()
    {
        System.Console.WriteLine("Please type your name: ");

        var name = UserInputReader.GetString(false);
        return name;
    }
}
