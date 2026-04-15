using MathGame.Console.Models;
using MathGame.Constants;
using MathGame.Enums;

namespace MathGame.Console.Utilities;

internal static class ArgumentParser
{
    private const int MinDifficulty = 1;
    private const int MaxDifficulty = 3;

    /// <summary>
    /// Parses command-line arguments into a CommandLineArgs object.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    /// <returns>A tuple containing the parsed arguments and any validation error message.</returns>
    public static (CommandLineArgs Args, string? Error) Parse(string[] args)
    {
        var result = new CommandLineArgs();

        if (args.Length == 0)
        {
            return (result, null);
        }

        // Parse named arguments.
        for (int i = 0; i < args.Length; i++)
        {
            var arg = args[i];

            if (arg.Equals("-n", StringComparison.OrdinalIgnoreCase) || arg.Equals("--name", StringComparison.OrdinalIgnoreCase))
            {
                if (i + 1 >= args.Length || string.IsNullOrWhiteSpace(args[i + 1]))
                {
                    return (result, "Error: -n requires a name value.");
                }
                result.Name = args[++i];
            }
            else if (arg.Equals("-q", StringComparison.OrdinalIgnoreCase) || arg.Equals("--questions", StringComparison.OrdinalIgnoreCase))
            {
                if (i + 1 >= args.Length || string.IsNullOrWhiteSpace(args[i + 1]))
                {
                    return (result, "Error: -q requires a number value.");
                }
                if (!int.TryParse(args[++i], out int questionCount))
                {
                    return (result, "Error: -q requires a valid number.");
                }
                if (questionCount < QuestionCount.Min || questionCount > QuestionCount.Max)
                {
                    return (result, $"Error: -q must be between {QuestionCount.Min} and {QuestionCount.Max}.");
                }
                result.QuestionCount = questionCount;
            }
            else if (arg.Equals("-d", StringComparison.OrdinalIgnoreCase) || arg.Equals("--difficulty", StringComparison.OrdinalIgnoreCase))
            {
                if (i + 1 >= args.Length || string.IsNullOrWhiteSpace(args[i + 1]))
                {
                    return (result, "Error: -d requires a difficulty value (1, 2, or 3).");
                }
                if (!int.TryParse(args[++i], out int gameDifficulty))
                {
                    return (result, "Error: -d requires a valid number.");
                }
                if (gameDifficulty < MinDifficulty || gameDifficulty > MaxDifficulty)
                {
                    return (result, $"Error: -d must be between {MinDifficulty} (Easy) and {MaxDifficulty} (Hard).");
                }
                try
                {
                    result.GameDifficulty = (GameDifficulty)gameDifficulty;
                }
                catch (Exception exception)
                {
                    return (result, $"Error: {exception}");
                }
            }
            else
            {
                return (result, $"Error: Unknown argument '{arg}'. Valid arguments are: -n, -q, -d");
            }
        }

        return (result, null);
    }

    /// <summary>
    /// Returns a usage message string.
    /// </summary>
    public static string GetUsage()
    {
        return @"Usage: MathGame.Console.exe [-n <name>] [-q <questions>] [-d <difficulty>]

Arguments:
  -n, --name        Player name (optional)
  -q, --questions   Number of questions 1-100 (optional)
  -d, --difficulty  Difficulty level: 1=Easy, 2=Normal, 3=Hard (optional)

Examples:
  MathGame.Console.exe -n Chris -q 10 -d 1
  MathGame.Console.exe -q 5 -n John
  MathGame.Console.exe -d 2";
    }
}
