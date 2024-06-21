using System.Security.AccessControl;
using MathGame.Enums;
using MathGame.Maui.Views;

namespace MathGame.Maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Title = "Math Game";
        }

        private void OnGame_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var gameType = GetGameType(button.Text);

            Navigation.PushAsync(new DifficultyPage(gameType));
        }

        private void OnViewGameHistory_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Navigation.PushAsync(new GameHistoryPage());
        }

        private GameType GetGameType(string symbol)
        {
            return symbol switch
            {
                "+" => GameType.Addition,
                "-" => GameType.Subtraction,
                "×" => GameType.Multiplication,
                "÷" => GameType.Division,
                _ => throw new ArgumentException($"Unsupported game type: {symbol}")
            };

        }
    }
}
