using MathGame.Enums;

namespace MathGame.Console.Models;

internal class CommandLineArgs
{
    public string? Name { get; set; }
    public int? QuestionCount { get; set; }
    public GameDifficulty? GameDifficulty { get; set; }

    public bool HasAnyArguments => !string.IsNullOrWhiteSpace(Name) || QuestionCount.HasValue || GameDifficulty.HasValue;
}
