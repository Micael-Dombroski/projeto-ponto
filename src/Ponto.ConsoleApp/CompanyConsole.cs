using System;

namespace Ponto.ConsoleApp
{
    public class CompanyConsole
    {
        private ConsoleUtils _utils = new();
        private string menuOption;

        public void Execute()
        {
            while (true)
            {
                Console.Clear();
                _utils.ShowHeader("Menu Empresa");
                ShowMenu();
                ReadMenuOption();
                HandleMenu();
            }
        }

        private void ShowMenu()
        {
            throw new NotImplementedException();
        }

        private void HandleMenu()
        {
            throw new NotImplementedException();
        }

        private void ReadMenuOption()
        {
            Console.Write("=> ");
            menuOption = Console.ReadLine();
        }
    }
}
