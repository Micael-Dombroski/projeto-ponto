using System;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    class Program
    {
        static string menuOption;
        static EmployeeConsole employeeConsole = new();
        static AdminConsole adminConsole = new();

        static ConsoleUtils utils = new();

        static AdminCRUD administratorCRUD = new();

        static void Main(string[] args)
        {
            if (administratorCRUD.Get() is null)
            {
                Console.Clear();
                CreateAdmin();
                AdminMenu();
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
                    employeeConsole.DoLogin();
                    break;
                case "2":
                    DoLoginAsAdmin();
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

        private static void DoLoginAsAdmin()
        {
            utils.ShowHeader("Login Administrador");

            Console.Write("Login: ");
            string login = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            var admin = administratorCRUD.Get();

            if (admin.Login == login && admin.Password == password)
            {
                AdminMenu();
            }
        }

        private static void AdminMenu()
        {
            while (true)
            {
                Console.Clear();
                utils.ShowHeader("Menu do administrator");
                ShowAdminMenu();
                ReadMenuOption();
                HandleAdminMenu();
            }
        }


        private static void BackToMainMenu()
        {
            BackToMenu();
            MainMenu();
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

        private static void CreateAdmin()
        {
            utils.ShowHeader("criar Administrador");

            Console.Write("Digite o login de Administrador: ");
            string login = Console.ReadLine();

            Console.Write("Digite a senha: ");
            string password = Console.ReadLine();

            var admin = new Administrator(login, password);
            administratorCRUD.Add(admin);
        }
    }
}
