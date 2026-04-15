using MathGame.Constants;
using MathGame.Enums;

namespace MathGame.Console.Utilities;

/// <summary>
/// Helper class to present a question and return a valid user response from the console.
/// </summary>
internal static class UserInputReader
{
    internal static int GetInt()
    {
        string? input = System.Console.ReadLine();
        int output;

        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _))
        {
            System.Console.WriteLine("Input must be an Integer.");
            input = System.Console.ReadLine();
        }

        output = int.Parse(input);

        return output;
    }

    internal static int GetInt(int min, int max)
    {
        string? input = System.Console.ReadLine();
        int output;

        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _) || int.Parse(input) < min || int.Parse(input) > max)
        {
            System.Console.WriteLine($"Input must be an Integer between {min} and {max}.");
            input = System.Console.ReadLine();
        }
        
        output = int.Parse(input);
                    
        return output;
    }

    internal static GameDifficulty GetGameDifficulty()
    {
        System.Console.WriteLine("Please select a difficulty: ");
        System.Console.WriteLine("1 - Easy ");
        System.Console.WriteLine("2 - Normal ");
        System.Console.WriteLine("3 - Hard ");

        string? input = System.Console.ReadLine();
        GameDifficulty output;

        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _) || !Enum.IsDefined(typeof(GameDifficulty), int.Parse(input)))
        {
            System.Console.WriteLine("Input must be an Integer that represents the Game Difficulty option.");
            input = System.Console.ReadLine();
        }

        output = (GameDifficulty)int.Parse(input);

        return output;
    }

    internal static int GetQuestionCount()
    {
        System.Console.WriteLine($"Please enter amount of questions ({QuestionCount.Min}-{QuestionCount.Max}): ");
        return GetInt(QuestionCount.Min, QuestionCount.Max);
    }

    internal static string? GetString(bool allowNullOrEmpty = false)
    {
        string? input = System.Console.ReadLine();

        if (!allowNullOrEmpty)
        {
            while (string.IsNullOrEmpty(input))
            {
                System.Console.WriteLine("Input must not be empty.");
                input = System.Console.ReadLine();
            }
        }

        return input;
    }
}
