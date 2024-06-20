using System.Security.AccessControl;
using MathGame.Maui.Models;

namespace MathGame.Maui;

public partial class GameHistoryPage : ContentPage
{
	public GameHistoryPage()
    {
        InitializeComponent();

        Title = $"Math Game: Game History";

        RefreshGameCollection();

    }

	private void OnDeleteButton_Clicked(object sender, EventArgs e)
	{
		var button = (ImageButton)sender;
		var id = (int)button.BindingContext;

        App.GameRepository.DeleteGame(id);
		RefreshGameCollection();
    }

	private void RefreshGameCollection()
	{
        GamesCollection.ItemsSource = App.GameRepository.GetGames();
    }
}