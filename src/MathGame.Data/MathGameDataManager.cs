using MathGame.Models;
using SQLite;

namespace MathGame.Data;

/// <summary>
/// Data manager class for the application database.
/// </summary>
public class MathGameDataManager
{
    private readonly string _filePath;

    public MathGameDataManager(string filePath)
    {
        _filePath = filePath;
        Initialise();
    }

    public void Initialise()
    {
        // Creates a connection, and also creates the database file if it doesn't exist.
        using var connection = new SQLiteConnection(_filePath, SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite);
        connection.CreateTable<Game>();
    }

    public void InsertGame(Game game)
    {
        using var connection = new SQLiteConnection(_filePath);
        connection.Insert(game);
    }

    public IReadOnlyList<Game> GetGames()
    {
        using var connection = new SQLiteConnection(_filePath);
        return [.. connection.Table<Game>()];
    }

    public void UpdateGame(Game game)
    {
        using var connection = new SQLiteConnection(_filePath);
        connection.Update(game);
    }

    public void DeleteGame(int id)
    {
        using var connection = new SQLiteConnection(_filePath);
        connection.Delete<Game>(id);
    }
}
