// -------------------------------------------------------------------------------------------------
// MathGame.Maui.GameHistoryPage
// -------------------------------------------------------------------------------------------------
// The game history content page view of the application.
// -------------------------------------------------------------------------------------------------
namespace MathGame.Maui
{
    public partial class GameHistoryPage : ContentPage
    {
        #region Constructors

        public GameHistoryPage()
        {
            InitializeComponent();

            Title = $"Math Game: Game History";

            RefreshGameCollection();

        }

        #endregion
        #region EventHandlers

        private void OnDeleteButton_Clicked(object sender, EventArgs e)
    	{
    		var button = (ImageButton)sender;
    		var id = (int)button.BindingContext;

            App.DataManager.DeleteGame(id);
    		RefreshGameCollection();
        }

        #endregion
        #region Methods: Private Static

        private void RefreshGameCollection()
    	{
            GamesCollection.ItemsSource = App.DataManager.GetGames();
        }

        #endregion
    }
}