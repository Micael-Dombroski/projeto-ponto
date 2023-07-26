using System;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    public class AdminConsole
    {
        string menuOption;
        AdminCRUD crud = new();
        ConsoleUtils utils = new();
        Administrator loggedAdmin;
        EmployeeCRUD employeeCRUD = new();

        public void CreateAdmin()
        {
            Console.Clear();
            Create();
            Menu();
        }

        void Create()
        {
            utils.ShowHeader("criar Administrador");

            Console.Write("Digite o login de Administrador: ");
            string login = Console.ReadLine();

            Console.Write("Digite a senha: ");
            string password = Console.ReadLine();

            var admin = new Administrator(login, password);
            crud.Add(admin);
        }

        public void Login()
        {
            utils.ShowHeader("Login Administrador");

            Console.Write("Login: ");
            string login = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            var admin = crud.Get();

            if (admin.Login == login && admin.Password == password)
            {
                Menu();
            }
        }

        void Menu()
        {
            while (true)
            {
                Console.Clear();
                utils.ShowHeader("Menu do administrator");
                ShowMenu();
                ReadMenuOption();
                HandleMenu();
            }
        }

        void ShowMenu()
        {

            Console.WriteLine("[1] Cadastrar funcionário");
            Console.WriteLine("[2] Editar carga horária de funcionário");
            Console.WriteLine("[0] Voltar");
        }

        void ReadMenuOption()
        {
            Console.Write("=> ");
            menuOption = Console.ReadLine();
        }

        void HandleMenu()
        {
            Console.Clear();
            switch (menuOption)
            {
                case "1":
                    RegisterEmployee();
                    break;
                case "2":
                    EditEmployeeWorkLoad();
                    break;
                case "0":
                    BackToMainMenu();
                    break;
                default: break;
            }
            BackToMenu();
        }

        void RegisterEmployee()
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

                employeeCRUD.Add(employee);
            }
            catch (Exception e)
            {
                utils.HandleError(e.Message);
            }
        }

        void EditEmployeeWorkLoad()
        {
            utils.ShowHeader("Editar carga horária");

            Console.Write("Matrícula do funcionário: ");
            string registration = Console.ReadLine();

            var employee = employeeCRUD.Get(registration);

            if (employee is null)
            {
                utils.HandleError("Funcionário não encontrado");
                return;
            }

            Console.WriteLine("Carga horária atual:");
            Console.WriteLine($"Horário de ENTRADA: {employee.WorkLoad.StartToString()}");
            Console.WriteLine($"Horário de INÍCIO da PAUSE: {employee.WorkLoad.StartPause}");
            Console.WriteLine($"Horário de TÉRMINO da PAUSE: {employee.WorkLoad.FinishPause}");
            Console.WriteLine($"Horário de SAÍDA: {employee.WorkLoad.EndToString()}");
        }

        void BackToMenu()
        {
            Console.WriteLine(
                "\nPressione qualquer tecla para prosseguir..."
            );
            Console.ReadKey();
        }

        void BackToMainMenu()
        {
            Program.MainMenu();
        }

        public bool AdminExists()
        {
            return crud.Get() is null;
        }
    }
}
