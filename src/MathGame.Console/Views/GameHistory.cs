using MathGame.Data;
using MathGame.Models;

namespace MathGame.Console.Views
{
    internal static class GameHistory
    {
        internal const string Title = "Game History";

        internal static void Show(IReadOnlyList<Game> gameHistory)
        {
            System.Console.Clear();
            System.Console.WriteLine(Title);
            System.Console.WriteLine("--------------------");

            foreach (var game in gameHistory)
            {
                System.Console.WriteLine($"{game.DatePlayed} - {game.Type} ({game.Difficulty}): {game.Score}pts");
            }
            System.Console.WriteLine("--------------------");
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to return to the Main Menu...");
            System.Console.ReadLine();
        }
    }
}
