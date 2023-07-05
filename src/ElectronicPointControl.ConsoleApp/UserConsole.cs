using System;

namespace ElectronicPointControl.ConsoleApp
{
    public class UserConsole
    {
        private string menuOption;
        private ConsoleUtils _utils = new();

        public void Execute()
        {
            string optionToBack = "3";

            do
            {
                Console.Clear();
                _utils.ShowHeader("Menu Funcionário");
                ShowMenu();
                ReadMenuOption();
                HandleMenu();
            } while (menuOption != optionToBack);
        }

        private void ShowMenu()
        {
            Console.WriteLine("[1] Exibir Informações do Funcionário");
            Console.WriteLine("[2] Marcar Ponto");
            Console.WriteLine("[3] Voltar");
        }

        private void HandleMenu()
        {
            switch (menuOption)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    break;
            }
        }

        private void ReadMenuOption()
        {
            Console.Write("=> ");
            menuOption = Console.ReadLine();
        }
    }
}
