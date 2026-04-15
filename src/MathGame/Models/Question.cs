using MathGame.Constants;
using MathGame.Enums;

namespace MathGame.Models;

/// <summary>
/// Holds the question data.
/// </summary>
public class Question
{
    public int Id { get; init; }

    public int FirstNumber { get; set; }

    public int SecondNumber { get; set; }

    public GameType Type { get; set; }

    public string Operation 
    {
        get => Type switch
        {
            GameType.Addition => GameTypeSymbol.Addition,
            GameType.Subtraction => GameTypeSymbol.Subtraction,
            GameType.Multiplication => GameTypeSymbol.Multiplication,
            GameType.Division => GameTypeSymbol.Division,
            _ => throw new ArgumentOutOfRangeException($"Invalid GameType {Type}")
        };
    }

    public int Answer
    {
        get => Type switch
        {
            GameType.Addition => FirstNumber + SecondNumber,
            GameType.Subtraction => FirstNumber - SecondNumber,
            GameType.Multiplication => FirstNumber * SecondNumber,
            GameType.Division => FirstNumber / SecondNumber,
            _ => throw new ArgumentOutOfRangeException($"Invalid GameType {Type}")
        };
    }

    public override string ToString()
    {
        return $"{FirstNumber} {Operation} {SecondNumber} = ?";
    }
}
