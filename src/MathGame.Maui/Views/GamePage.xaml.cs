using MathGame.Maui.Models;

namespace MathGame.Maui;

public partial class GamePage : ContentPage
{
    #region Constants

    const int TotalQuestions = 2;
    
    #endregion
    #region Variables

    int _firstNumber = 0;
    int _secondNumber = 0;
    int _score = 0;
    int _questionsRemaining = TotalQuestions;

    string _gameSymbol = string.Empty;

    #endregion
    #region Constructors

    public GamePage(string gameSymbol)
	{
		InitializeComponent();

        _gameSymbol = gameSymbol;
		GameType = GetGameType(_gameSymbol);
        
        Title = $"Math Game: {GameType}";

        CreateNewQuestion();
	}

    #endregion
    #region Properties

    public GameOperation GameType { get; set; }
    
    #endregion
    #region Event Handlers

    private void OnAnswerSubmit_Clicked(object sender, EventArgs e)
    {
        // Validation.
        if (string.IsNullOrEmpty(AnswerEntry.Text) || !int.TryParse(AnswerEntry.Text, out _))
        {
            return;
        }

        var answer = int.Parse(AnswerEntry.Text);
        var isCorrect = false;

        switch (GameType)
        {
            case GameOperation.Addition:
                isCorrect = (answer == _firstNumber + _secondNumber);
                break;
            case GameOperation.Subtraction:
                isCorrect = (answer == _firstNumber - _secondNumber);
                break;
            case GameOperation.Multiplication:
                isCorrect = (answer == _firstNumber * _secondNumber);
                break;
            case GameOperation.Division:
                isCorrect = (answer == _firstNumber / _secondNumber);
                break;            
        }

        ProcessAnswer(isCorrect);
    }

    private void OnContinueButton_Clicked(object sender, EventArgs e)
    {
        _questionsRemaining -= 1;
        AnswerEntry.Text = "";

        if (_questionsRemaining > 0)
        {
            CreateNewQuestion();
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

    private void CreateNewQuestion()
	{
        QuestionSection.IsVisible = true;
        FeedbackSection.IsVisible = false;

        _firstNumber = GameType == GameOperation.Division ? Random.Shared.Next(1, 9) : Random.Shared.Next(1, 99);
        _secondNumber = GameType == GameOperation.Division ? Random.Shared.Next(1, 9) : Random.Shared.Next(1, 99);

        if (GameType == GameOperation.Division)
        {
            while (_firstNumber < _secondNumber || _firstNumber % _secondNumber != 0)
            {
                _firstNumber = Random.Shared.Next(1, 9);
                _secondNumber = Random.Shared.Next(1, 9);
            }
        }

        QuestionNumberLabel.Text = $"Question: {TotalQuestions - _questionsRemaining + 1}";
        QuestionLabel.Text = $"{_firstNumber} {_gameSymbol} {_secondNumber}";
    }

    private void ProcessAnswer(bool isCorrect)
    {
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

        GameOverLabel.Text = $"Game Over. You scored {_score}/{TotalQuestions}!";

        App.GameRepository.InsertGame(new Game
        {
            DatePlayed = DateTime.Now,
            Score = _score,
            Type = GameType,
        });
    }

    private static GameOperation GetGameType(string gameType)
    {
        return gameType switch
        {
            "+" => GameOperation.Addition,
            "-" => GameOperation.Subtraction,
            "×" => GameOperation.Multiplication,
            "÷" => GameOperation.Division,
            _ => throw new ArgumentException($"Unsupported game type: {gameType}")
        };
    }
        
    #endregion
}