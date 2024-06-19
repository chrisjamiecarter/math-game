namespace MathGame.Console.Utilities
{
    internal static class UserInputReader
    {
        internal static int GetInt()
        {
            string? input = System.Console.ReadLine();
            int output;

            while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _))
            {
                System.Console.WriteLine("Input must be an Integer.");
                input = System.Console.ReadLine();

            };

            output = int.Parse(input);

            return output;
        }

        internal static string GetString(bool allowNullOrEmpty = false)
        {
            string? input = System.Console.ReadLine();

            if (!allowNullOrEmpty)
            {
                while (string.IsNullOrEmpty(input))
                {
                    System.Console.WriteLine("Input must not be empty.");
                    input = System.Console.ReadLine();
                };

            }

            return string.IsNullOrEmpty(input) ? "" : input;
        }
    }
}
