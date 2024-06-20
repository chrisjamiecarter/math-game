using SQLite;

namespace MathGame.Maui.Models
{
    [Table("Game")]
    public class Game
    {
        #region Properties

        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        
        public GameOperation Type { get; set; }
        
        public int Score { get; set; }

        public DateTime DatePlayed { get; set; }

        #endregion
    }
}
