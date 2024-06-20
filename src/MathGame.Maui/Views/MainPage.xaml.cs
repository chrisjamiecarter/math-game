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

            Navigation.PushAsync(new GamePage(button.Text));
        }

        private void OnViewGameHistory_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Navigation.PushAsync(new GameHistoryPage());
        }
    }
}
