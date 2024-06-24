// -------------------------------------------------------------------------------------------------
// MathGame.Maui.GamePage
// -------------------------------------------------------------------------------------------------
// The game content page view of the application.
// -------------------------------------------------------------------------------------------------
using System.Diagnostics;
using MathGame.Enums;
using MathGame.Logic;
using MathGame.Models;

namespace MathGame.Maui
{
    public partial class GamePage : ContentPage
    {
        #region Variables

        private int _currentQuestionIndex = 0;
        private int _score = 0;
        private TimeSpan _timeTaken;
        private readonly List<Question> _questions;
        private readonly Stopwatch _stopwatch;
    
        #endregion
        #region Constructors

        public GamePage(GameType gameType, GameDifficulty gameDifficulty, double questionCount)
        {
            InitializeComponent();

            Type = gameType;
            Difficulty = gameDifficulty;

            _questions = QuestionEngine.GenerateQuestions(Type, Difficulty, (int)questionCount);
            _timeTaken = new TimeSpan();
            _stopwatch = new Stopwatch();

            Title = $"Math Game: {Type} - {Difficulty}";

            ShowNextQuestion();
    	}

        #endregion
        #region Properties

        public GameDifficulty Difficulty { get; }
    
        public GameType Type { get; }

        #endregion
        #region Event Handlers

        private void OnAnswerSubmit_Clicked(object sender, EventArgs e)
        {
            // Validation.
            if (string.IsNullOrEmpty(AnswerEntry.Text) || !int.TryParse(AnswerEntry.Text, out _))
            {
                return;
            }

            var question = _questions[_currentQuestionIndex];

            var userAnswer = int.Parse(AnswerEntry.Text);
            var isCorrect = userAnswer == question.Answer;

            ProcessAnswer(isCorrect);
        }

        private void OnContinueButton_Clicked(object sender, EventArgs e)
        {
            // Increment the current question to next.
            _currentQuestionIndex++;

            AnswerEntry.Text = "";

            if (_currentQuestionIndex < _questions.Count)
            {
                ShowNextQuestion();
            }
            else
            {
                GameOver();
            }
        }

        private void OnBackToMenuButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        #endregion
        #region Methods: Private

        private void ShowNextQuestion()
    	{
            var question = _questions[_currentQuestionIndex];

            QuestionSection.IsVisible = true;
            FeedbackSection.IsVisible = false;

            QuestionNumberLabel.Text = $"Question: {question.Id}";
            QuestionLabel.Text = $"{question}";

            _stopwatch.Start();
        }

        private void ProcessAnswer(bool isCorrect)
        {
            _stopwatch.Stop();
            _timeTaken = _timeTaken.Add(_stopwatch.Elapsed);

            QuestionSection.IsVisible = false;
            FeedbackSection.IsVisible = true;

            if (isCorrect)
            {
                _score += 1;
            }

            FeedbackLabel.Text = isCorrect ? "Correct" : "Incorrect";
        }

        private void GameOver()
        {
            FeedbackSection.IsVisible = false;
            GameOverSection.IsVisible = true;

            GameOverLabel.Text = $"Game Over. You scored {_score} points!";

            App.DataManager.InsertGame(new Game
            {
                DatePlayed = DateTime.Now,
                Score = _score,
                Type = Type,
                Difficulty = Difficulty,
                TimeTakenInSeconds = _timeTaken.TotalSeconds
            });
        }
        
        #endregion
    }
}