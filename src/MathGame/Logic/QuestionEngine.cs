// -------------------------------------------------------------------------------------------------
// MathGame.Logic.QuestionEngine
// -------------------------------------------------------------------------------------------------
// Question related business logic.
// Generates questions for all game types configured by difficulty and amount of questions.
// -------------------------------------------------------------------------------------------------
using MathGame.Enums;
using MathGame.Models;

namespace MathGame.Logic
{
    public static class QuestionEngine
    {
        #region Methods: Public Static

        public static List<Question> GenerateQuestions(GameType gameType, GameDifficulty gameDifficulty, int questionCount)
        {
            var settings = new DifficultySettings(gameDifficulty, questionCount);

            return gameType switch
            {
                GameType.Addition => GenerateAdditionQuestions(settings),
                GameType.Subtraction => GenerateSubtractionNumbers(settings),
                GameType.Multiplication => GenerateMultiplicationNumbers(settings),
                GameType.Division => GenerateDivisionNumbers(settings),
                _ => throw new ArgumentOutOfRangeException(nameof(gameType))
            };
        }

        #endregion
        #region Methods: Private Static

        private static List<Question> GenerateAdditionQuestions(DifficultySettings settings)
        {
            List<Question> result = [];

            for (int i = 0; i < settings.QuestionCount; i++)
            {
                var firstNumber = Random.Shared.Next(settings.AdditionNumberMin, settings.AdditionNumberMax);
                var secondNumber = Random.Shared.Next(settings.AdditionNumberMin, settings.AdditionNumberMax);

                result.Add(new Question()
                {
                    Id = i + 1,
                    FirstNumber = firstNumber,
                    SecondNumber = secondNumber,
                    Type = GameType.Addition
                });
            }

            return result;
        }

        private static List<Question> GenerateSubtractionNumbers(DifficultySettings settings)
        {
            List<Question> result = [];

            for (int i = 0; i < settings.QuestionCount; i++)
            {
                var firstNumber = Random.Shared.Next(settings.SubtractionNumberMin, settings.SubtractionNumberMax);
                var secondNumber = Random.Shared.Next(settings.SubtractionNumberMin, settings.SubtractionNumberMax);

                while (firstNumber < secondNumber)
                {
                    firstNumber = Random.Shared.Next(settings.SubtractionNumberMin, settings.SubtractionNumberMax);
                    secondNumber = Random.Shared.Next(settings.SubtractionNumberMin, settings.SubtractionNumberMax);
                }

                result.Add(new Question()
                {
                    Id = i + 1,
                    FirstNumber = firstNumber,
                    SecondNumber = secondNumber,
                    Type = GameType.Subtraction
                });
            }

            return result;
        }

        private static List<Question> GenerateMultiplicationNumbers(DifficultySettings settings)
        {
            List<Question> result = [];

            for (int i = 0; i < settings.QuestionCount; i++)
            {
                var firstNumber = Random.Shared.Next(settings.SubtractionNumberMin, settings.SubtractionNumberMax);
                var secondNumber = Random.Shared.Next(settings.SubtractionNumberMin, settings.SubtractionNumberMax);

                result.Add(new Question()
                {
                    Id = i + 1,
                    FirstNumber = firstNumber,
                    SecondNumber = secondNumber,
                    Type = GameType.Multiplication
                });
            }

            return result;
        }

        private static List<Question> GenerateDivisionNumbers(DifficultySettings settings)
        {
            List<Question> result = [];

            for (int i = 0; i < settings.QuestionCount; i++)
            {
                var firstNumber = Random.Shared.Next(settings.DivisionNumberMin, settings.DivisionNumberMax);
                var secondNumber = Random.Shared.Next(settings.DivisionNumberMin, settings.DivisionNumberMax);

                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = Random.Shared.Next(settings.DivisionNumberMin, settings.DivisionNumberMax);
                    secondNumber = Random.Shared.Next(settings.DivisionNumberMin, settings.DivisionNumberMax);
                }

                result.Add(new Question()
                {
                    Id = i + 1,
                    FirstNumber = firstNumber,
                    SecondNumber = secondNumber,
                    Type = GameType.Division
                });
            }

            return result;
        }

        #endregion
    }
}
