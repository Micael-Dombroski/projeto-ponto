using System;

namespace ElectronicPointControl.ConsoleApp
{
    class Program
    {
        static string menuOption;
        static ConsoleUtils utils = new();
        static AdminConsole adminConsole = new();
        static EmployeeConsole employeeConsole = new();

        static void Main(string[] args)
        {
            if (adminConsole.AdminExists())
            {
                adminConsole.CreateAdmin();
            }
            MainMenu();
        }

        private static void HandleAdminMenu()
        {
            Console.Clear();
            switch (menuOption)
            {
                case "1":
                    employeeConsole.RegisterEmployee();
                    break;
                case "2":
                    AboutUs();
                    break;
                case "0":
                    Exit(); break;
                default:
                    utils.HandleError("Opção inválida"); 
                    break;
            }
            BackToMenu();
        }


        private static void ShowAdminMenu()
        {
            Console.WriteLine("[1] Cadastrar funcionário");
            Console.WriteLine("[2] Sobre");
            Console.WriteLine("[0] Sair");
        }
        static void ShowMainMenu()
        {
            Console.WriteLine("[1] Fazer login como FUNCIONÁRIO");
            Console.WriteLine("[2] Fazer login como ADMINISTRADOR");
            Console.WriteLine("[3] Sobre");
            Console.WriteLine("[0] Sair");
        }

        private static void HandleMainMenu()
        {
            Console.Clear();
            switch (menuOption)
            {
                case "1":
                    employeeConsole.Login();
                    break;
                case "2":
                    adminConsole.Login();
                    break;
                case "3":
                    AboutUs();
                    break;
                case "0":
                    Exit(); break;
                default:
                    utils.HandleError("Opção inválida"); 
                    break;
            }
            BackToMenu();
        }

        public static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                utils.ShowHeader("Main Menu");
                ShowMainMenu();
                ReadMenuOption();
                HandleMainMenu();
            }
        }

        private static void AboutUs()
        {
            utils.ShowHeader("Projeto Integrador SENAC");
            Console.WriteLine("Alunos: Micael & Natan");
            Console.WriteLine("Nome do Projeto: Projeto Ponto");
            Console.WriteLine("Versão: 1.0.0");
        }

        private static void Exit()
        {
            Console.WriteLine("Saindo do sistema...");
            Environment.Exit(1);
        }

        static void ReadMenuOption()
        {
            Console.Write("=> ");
            menuOption = Console.ReadLine();
        }

        static void BackToMenu()
        {
            Console.WriteLine("\nPressione qualquer tecla para prosseguir...");
            Console.ReadKey();
        }
    }
}
