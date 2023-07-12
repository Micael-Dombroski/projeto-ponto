using System;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    class Program
    {
        static string menuOption;

        static EmployeeConsole employeeConsole = new();
        static CompanyConsole companyConsole = new();
        static AdminConsole adminConsole = new();

        static ConsoleUtils utils = new();

        static EmployeeCRUD employees = new EmployeeCRUD();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                utils.ShowHeader("Menu");
                ShowMainMenu();
                ReadMenuOption();
                HandleMenu();
            }
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("[1] Fazer Login");
            Console.WriteLine("[2] Registrar-se");
            Console.WriteLine("[3] Sobre");
            Console.WriteLine("[0] Sair");
        }

        private static void HandleMenu()
        {
            Console.Clear();
            switch (menuOption)
            {
                case "1":
                    DoLogin(); break;
                case "2":
                    DoSignUp(); break;
                case "3":
                    AboutUs(); break;
                case "0":
                    Exit(); break;
                default: break;
            }
            BackToMainMenu();
        }

        private static void DoLogin()
        {
            utils.ShowHeader("login");

            Console.Write("Digite sua matrícula: ");
            string registration = Console.ReadLine();

            Employee employee = employees.Get(registration);
            if (employee is null)
            {
                utils.HandleError("Usuário não encontrado");
                return;
            }

            Console.Write("Digite sua senha: ");
            string password = Console.ReadLine();

            if (employee.PasswordIsCorrect(password))
                utils.HandleSuccess("Acesso concedido");
            else
                utils.HandleError("Senha incorreta");

            employeeConsole.SetLogedEmployee(employee);
        }

        private static void DoSignUp()
        {
            do
            {
                Console.Clear();
                utils.ShowHeader("Registrar-se");
                ShowSignUpMenu();
                ReadMenuOption();
                HandleSignUp();
            } while (menuOption != "4");
        }

        private static void ShowSignUpMenu()
        {
            Console.WriteLine("[1] Novo funcionário");
            Console.WriteLine("[2] Novo administrador");
            Console.WriteLine("[3] Nova empresa");
            Console.WriteLine("[4] Voltar");
        }

        private static void HandleSignUp()
        {
            switch (menuOption)
            {
                case "1":
                    NewEmployee();
                    break;
                case "2":
                    NewAdmin();
                    break;
                case "3":
                    NewCompany();
                    break;
                default:
                    break;
            }
        }

        private static void NewEmployee()
        {
            adminConsole.NewEmployee();
        }

        private static void NewAdmin()
        {
            adminConsole.NewAdmin();
        }

        private static void NewCompany()
        {
            companyConsole.NewCompany();
        }

        private static void AboutUs()
        {
            throw new NotImplementedException();
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

        static void BackToMainMenu()
        {
            Console.WriteLine("\nPressione qualquer tecla para prosseguir...");
            Console.ReadKey();
        }
    }
}
