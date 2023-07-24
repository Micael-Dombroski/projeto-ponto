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

        static EmployeeCRUD employees = new();
        static AdminCRUD administratorCRUD = new();
        static bool userExist;

        static void Main(string[] args)
        {
            if (administratorCRUD.Get() is null)
            {
                Console.Clear();
                CreateAdmin();
                AdminMenu();
            }

            while (true)
            {
                Console.Clear();
                utils.ShowHeader("Main Menu");
                ShowMainMenu();
                ReadMenuOption();
                HandleMainMenu();
            }
        }

        private static void HandleAdminMenu()
        {
            Console.Clear();
            switch (menuOption)
            {
                case "1":
                    RegisterEmployee();
                    break;
                case "2":
                    AboutUs();
                    break;
                case "0":
                    Exit(); break;
                default: break;
            }
            BackToMenu();
        }

        private static void RegisterEmployee()
        {
            try
            {
                Console.Write("Digite o nome do número do CPF: ");
                var cpf = new CPF(Console.ReadLine());

                Console.Write("Digite o nome do funcionário: ");
                string name = Console.ReadLine();

                Console.Write("Digite a matrícula: ");
                string registration = Console.ReadLine();

                Console.Write("Digite a senha para acessar o sistema: ");
                string password = Console.ReadLine();

                Console.Write("Digite a hora de INÍCIO do espediente: ");
                var hourToStart = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Digite a hora do FIM do espediente: ");
                var hourToEnd = Convert.ToDateTime(Console.ReadLine());

                WorkLoad workLoad = new(hourToStart, hourToEnd);

                var employee = new Employee(cpf, name, registration, password, workLoad);

                employees.Add(employee);
            }
            catch (Exception e)
            {
                utils.HandleError(e.Message);
            }
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
                    DoLoginAsEmployee();
                    break;
                case "2":
                    DoLoginAsAdmin();
                    break;
                case "3":
                    AboutUs();
                    break;
                case "0":
                    Exit(); break;
                default: break;
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

        private static void DoLoginAsEmployee()
        {
            throw new NotImplementedException();
        }

        private static void DoLogin()
        {
            userExist = false;
            utils.ShowHeader("login");

            Console.Write("Digite sua matrícula: ");
            string registration = Console.ReadLine();

            Employee employee = employees.Get(registration);
            Administrator administrator = administratorCRUD.Get();
            int typeUser = 0;
            if (employee is null)
            {
                if (administrator.Login != registration)
                {
                    utils.HandleError("Usuário não encontrado");
                    return;
                }
                else
                {
                    typeUser = 2;
                    userExist = true;
                }
            }
            else
            {
                typeUser = 1;
                userExist = true;
            }
            if (userExist == true)
            {
                Console.Write("Digite sua senha: ");
                string password = Console.ReadLine();
                if (typeUser == 1)
                {
                    if (employee.PasswordIsCorrect(password))
                    {
                        typeUser = 1;
                        utils.HandleSuccess("Acesso concedido");

                        employeeConsole.SetLogedEmployee(employee);
                    }
                    else
                    {
                        utils.HandleError("Senha incorreta");
                    }
                }
                else if (typeUser == 2)
                {
                    if (administrator.PasswordIsCorrect(password))
                    {
                        typeUser = 2;
                        utils.HandleSuccess("Acesso concedido");

                        adminConsole.SetLogedAdministrator(administrator);
                    }
                    else
                    {
                        utils.HandleError("Senha incorreta");
                    }
                }
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
