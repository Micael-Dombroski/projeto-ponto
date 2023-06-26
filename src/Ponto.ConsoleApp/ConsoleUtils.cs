using System;

namespace Ponto.ConsoleApp
{
    public class ConsoleUtils
    {
        public void ShowHeader(string header)
        {
            Console.WriteLine($"==== {header.ToUpper()} ====");
        }

        public void HandleError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void HandleSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
