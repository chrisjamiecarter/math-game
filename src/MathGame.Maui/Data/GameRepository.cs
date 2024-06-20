using MathGame.Maui.Models;
using SQLite;

namespace MathGame.Maui.Data
{
    public class GameRepository
    {
        #region Variables
        
        private string _filePath;
        
        #endregion
        #region Constructors

        public GameRepository(string filePath)
        {
            _filePath = filePath;
            Initialise();
        }

        #endregion
        #region Methods: Public - Initialise

        public void Initialise()
        {
            using (var connection = new SQLiteConnection(_filePath))
            {
                connection.CreateTable<Game>();
            }
        }
        #endregion
        #region Methods: Public - Create

        public void InsertGame(Game game)
        {
            using (var connection = new SQLiteConnection(_filePath))
            {
                connection.Insert(game);
            }
        }

        #endregion
        #region Methods: Public - Return

        public IReadOnlyList<Game> GetGames()
        {
            using (var connection = new SQLiteConnection(_filePath))
            {
                return [.. connection.Table<Game>()];
            }
        }

        #endregion
        #region Methods: Public - Update

        public void UpdateGame(Game game)
        {
            using (var connection = new SQLiteConnection(_filePath))
            {
                connection.Update(game);
            }
        }

        #endregion
        #region Methods: Public - Delete
        
        public void DeleteGame(int id)
        {
            using (var connection = new SQLiteConnection(_filePath))
            {
                connection.Delete<Game>(id);
            }
        }

        #endregion
    }
}
