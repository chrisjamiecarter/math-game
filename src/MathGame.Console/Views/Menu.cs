using System.Text;

namespace MathGame.Console.Views
{
    internal class Menu
    {
        private bool _startup = true;

        internal void Show(string? name, DateTime date)
        {
            if (_startup)
            {
                System.Console.Clear();
                System.Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. This is your math's game.\n");
                System.Console.WriteLine($"Press any key to show menu");
                System.Console.ReadLine();
                _startup = false;
            }

            var questionSb = new StringBuilder();
            questionSb.AppendLine("V - View previous games");
            questionSb.AppendLine("A - Addition");
            questionSb.AppendLine("S - Subtraction");
            questionSb.AppendLine("M - Multiplication");
            questionSb.AppendLine("D - Division");
            questionSb.AppendLine("Q - Quit the application");
            questionSb.AppendLine("");
            questionSb.AppendLine("Enter your selection: ");

            System.Console.Clear();
            System.Console.Write(questionSb.ToString());
        }
    }
}
