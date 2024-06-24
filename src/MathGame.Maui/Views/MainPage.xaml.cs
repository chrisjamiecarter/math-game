// -------------------------------------------------------------------------------------------------
// MathGame.Maui.MainPage
// -------------------------------------------------------------------------------------------------
// The main content page view of the application.
// -------------------------------------------------------------------------------------------------
using MathGame.Enums;
using MathGame.Maui.Views;

namespace MathGame.Maui
{
    public partial class MainPage : ContentPage
    {
        #region Constructors
        
        public MainPage()
        {
            InitializeComponent();

            Title = "Math Game";
        }

        #endregion
        #region EventHandlers

        private void OnGame_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var gameType = GetGameType(button.Text);

            Navigation.PushAsync(new DifficultyPage(gameType));
        }

        private void OnViewGameHistory_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameHistoryPage());
        }

        #endregion
        #region Methods: Private Static

        private static GameType GetGameType(string symbol)
        {
            return symbol switch
            {
                "+" => GameType.Addition,
                "-" => GameType.Subtraction,
                "×" => GameType.Multiplication,
                "÷" => GameType.Division,
                "🔀" => GameType.Random,
                _ => throw new ArgumentException($"Unsupported game type: {symbol}")
            };
        }

        #endregion
    }
}
