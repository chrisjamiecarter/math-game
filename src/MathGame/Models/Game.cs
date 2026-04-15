using MathGame.Enums;
using SQLite;

namespace MathGame.Models;

/// <summary>
/// Represents both a Game object and a Game database entity.
/// </summary>
[Table("Game")]
public class Game
{
    [PrimaryKey, AutoIncrement, Column("Id")]
    public int Id { get; set; }

    public GameType Type { get; set; }

    public int Score { get; set; }

    public DateTime DatePlayed { get; set; }

    public GameDifficulty Difficulty { get; set; }

    public double TimeTakenInSeconds { get; set; }
}
