using System.Collections.Generic;
using System.Security.AccessControl;
using MathGame.Enums;
using MathGame.Logic;
using MathGame.Models;
using SQLitePCL;

namespace MathGame.Maui;

public partial class GamePage : ContentPage
{
    #region Constants

    // TODO: Implement difficulty settings (enum, max values).
    private const int TotalQuestions = 2;
    
    #endregion
    #region Variables

    //int _firstNumber = 0;
    //int _secondNumber = 0;
    private int _score = 0;
    //int _questionsRemaining = TotalQuestions;

    private readonly GameType _gameType;
    private readonly List<Question> _questions;
    private int _currentQuestionIndex = 0;

    #endregion
    #region Constructors

    public GamePage(string gameSymbol)
    {
        InitializeComponent();

        _gameType = GetGameType(gameSymbol);
        _questions = QuestionEngine.GenerateQuestions(_gameType, TotalQuestions);
                
        Title = $"Math Game: {_gameType}";

        ShowNextQuestion();
	}

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

        App.DataManager.InsertGame(new Game
        {
            DatePlayed = DateTime.Now,
            Score = _score,
            Type = _gameType
        });
    }

    private static GameType GetGameType(string gameType)
    {
        return gameType switch
        {
            "+" => GameType.Addition,
            "-" => GameType.Subtraction,
            "×" => GameType.Multiplication,
            "÷" => GameType.Division,
            _ => throw new ArgumentException($"Unsupported game type: {gameType}")
        };
    }
        
    #endregion
}