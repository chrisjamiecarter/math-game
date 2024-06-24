// -------------------------------------------------------------------------------------------------
// MathGame.Maui.App
// -------------------------------------------------------------------------------------------------
// Initialises the App.
// -------------------------------------------------------------------------------------------------
using MathGame.Data;

namespace MathGame.Maui
{
    public partial class App : Application
    {
        public static MathGameDataManager DataManager { get; private set; }

        public App(MathGameDataManager dataManager)
        {
            InitializeComponent();

            DataManager = dataManager;

            MainPage = new AppShell();
        }
    }
}
