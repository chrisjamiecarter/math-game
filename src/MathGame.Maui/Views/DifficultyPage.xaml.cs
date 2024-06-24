// -------------------------------------------------------------------------------------------------
// MathGame.Maui.DifficultyPage
// -------------------------------------------------------------------------------------------------
// The difficulty content page view of the application.
// -------------------------------------------------------------------------------------------------
using MathGame.Enums;

namespace MathGame.Maui.Views
{
    public partial class DifficultyPage : ContentPage
    {
        #region Variables
    
        private double _questionsSliderDisplayValue = 1;

        #endregion
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
            Navigation.PushAsync(new GamePage(Type, GameDifficulty.Easy, _questionsSliderDisplayValue));
        }

        private void OnNormal_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage(Type, GameDifficulty.Normal, _questionsSliderDisplayValue));
        }

        private void OnHard_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage(Type, GameDifficulty.Hard, _questionsSliderDisplayValue));
        }

        private void OnQuestionsSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var slider = (Slider)sender;

            var sliderValue = Math.Round(slider.Value);

            if (sliderValue != _questionsSliderDisplayValue)
            {
                _questionsSliderDisplayValue = sliderValue;
                QuestionsSliderLabel.Text = _questionsSliderDisplayValue.ToString();
            }
        }

        private void OnQuestionsSlider_DragCompleted(object sender, EventArgs e)
        {
            QuestionsSlider.Value = _questionsSliderDisplayValue;
        }

        #endregion
    }
}