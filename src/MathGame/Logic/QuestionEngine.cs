using MathGame.Enums;
using MathGame.Models;

namespace MathGame.Logic
{
    public static class QuestionEngine
    {
        public static List<Question> GenerateQuestions(GameType gameType, int questionCount)
        {
            return gameType switch
            {
                GameType.Addition => GenerateAdditionQuestions(questionCount),
                GameType.Subtraction => GenerateSubtractionNumbers(questionCount),
                GameType.Multiplication => GenerateMultiplicationNumbers(questionCount),
                GameType.Division => GenerateDivisionNumbers(questionCount),
                _ => throw new ArgumentOutOfRangeException(nameof(gameType))
            };
        }

        private static List<Question> GenerateAdditionQuestions(int generateCount)
        {
            List<Question> result = [];

            for (int i = 0; i < generateCount; i++)
            {
                var firstNumber = Random.Shared.Next(1, 99);
                var secondNumber = Random.Shared.Next(1, 99);

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

        private static List<Question> GenerateSubtractionNumbers(int generateCount)
        {
            List<Question> result = [];

            for (int i = 0; i < generateCount; i++)
            {
                var firstNumber = Random.Shared.Next(1, 99);
                var secondNumber = Random.Shared.Next(1, 99);

                while (firstNumber < secondNumber)
                {
                    firstNumber = Random.Shared.Next(1, 99);
                    secondNumber = Random.Shared.Next(1, 99);
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

        private static List<Question> GenerateMultiplicationNumbers(int generateCount)
        {
            List<Question> result = [];

            for (int i = 0; i < generateCount; i++)
            {
                var firstNumber = Random.Shared.Next(1, 12);
                var secondNumber = Random.Shared.Next(1, 12);

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

        private static List<Question> GenerateDivisionNumbers(int numberToGenerate)
        {
            List<Question> result = [];

            for (int i = 0; i < numberToGenerate; i++)
            {
                var firstNumber = Random.Shared.Next(1, 99);
                var secondNumber = Random.Shared.Next(1, 99);

                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = Random.Shared.Next(1, 99);
                    secondNumber = Random.Shared.Next(1, 99);
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
    }
}
