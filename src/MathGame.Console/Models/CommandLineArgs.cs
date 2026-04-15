using MathGame.Enums;

namespace MathGame.Console.Models;

/// <summary>
/// Holds the command line arguments passed to the application.
/// This allows for easier parsing and validation of the arguments, as well as providing a single place to access them throughout the application.
/// </summary>
internal class CommandLineArgs
{
    public string? Name { get; set; }
    public int? QuestionCount { get; set; }
    public GameDifficulty? GameDifficulty { get; set; }

    public bool HasAnyArguments => !string.IsNullOrWhiteSpace(Name) || QuestionCount.HasValue || GameDifficulty.HasValue;
}
