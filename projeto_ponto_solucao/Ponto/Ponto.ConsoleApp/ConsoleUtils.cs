using System;

namespace Ponto.ConsoleApp
{
    public class ConsoleUtils
    {
        public void ShowHeader(string header)
        {
            Console.WriteLine($"==== {header.ToUpper()} ====");
        }
    }
}
