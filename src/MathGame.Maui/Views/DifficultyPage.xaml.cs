using MathGame.Enums;
using MathGame.Logic;
using MathGame.Models;

namespace MathGame.Maui.Views;

public partial class DifficultyPage : ContentPage
{
    #region Constructors

    public DifficultyPage(GameType gameType)
    {
        InitializeComponent();

        Type = gameType;

        Title = $"Math Game: {Type} - Select Difficulty";
    }

    #endregion
    #region Properties

    public GameType Type { get; }

    #endregion
    #region Event Handlers

    private void OnEasy_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GamePage(Type, GameDifficulty.Easy));
    }

    private void OnNormal_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GamePage(Type, GameDifficulty.Normal));
    }

    private void OnHard_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GamePage(Type, GameDifficulty.Hard));
    }

    #endregion
}