using System;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    public class AdminConsole
    {
        private string menuOption;
        private string UserTypeOption;
        private Administrator logedAdministrator;
        private ConsoleUtils utils= new();
        private EmployeeCRUD employees = new();
        private AdminCRUD admins = new();

        public void SetLogedAdministrator(Administrator administrator)
        {
            logedAdministrator = administrator;
            if (administrator.Registration == "root")
                ExecuteRoot();
            else
                Execute();
        }

        public void Execute()
        {
            string optionToBack = "5";

            do
            {
                Console.Clear();
                utils.ShowHeader("Menu Administrador");
                ShowMenu();
                ReadMenuOption();
                HandleMenu();
            } while (menuOption != optionToBack);
        }

        public void ExecuteRoot()
        {
            string optionToBack = "6";

            do
            {
                Console.Clear();
                utils.ShowHeader("Menu Root");
                ShowMenuRoot();
                ReadMenuOption();
                HandleMenuRoot();
            } while (menuOption != optionToBack);
        }

        public void NewAdmin()
        {
            utils.ShowHeader("Novo Administrador");
            string registration = utils.ReadRegistration();
            if (utils.EmployeeExists(registration))
                utils.HandleError("Administrador já cadastrado");
            CPF cpf = utils.ReadCPF();
            string name = utils.ReadName();
            string password = utils.ReadPassword();
            Administrator administrator = new Administrator(cpf, name, registration, password);
            admins.Add(administrator);

            utils.HandleSuccess("Administrador criado com sucesso");
        }

        public void NewEmployee()
        {
            utils.ShowHeader("Novo Funcionário");
            string registration = utils.ReadRegistration();
            if (utils.EmployeeExists(registration))
                utils.HandleError("Funcionário já cadastrado");
            CPF cpf = utils.ReadCPF();
            string name = utils.ReadName();
            string password = utils.ReadPassword();
            WorkLoad workLoad = utils.ReadWorkLoad();
            Employee employee = new Employee(cpf, name, password: password, registration: registration, workLoad: workLoad);
            employees = new EmployeeCRUD();
            employees.Add(employee);

            utils.HandleSuccess("Funcionário criado com sucesso");
        }

        public void DeleteAdmin()
        {
            utils.ShowHeader("Deletar Administrador");
            string registration = utils.ReadRegistration();
            if (utils.AdministratorExists(registration))
            {
                admins.Delete(registration);
                utils.HandleSuccess("Administrador deletado com sucesso");
            }
            else
                Console.WriteLine("Administrador não encontrado");
        }
        public void DeleteEmployee()
        {
            utils.ShowHeader("Deletar Funcionário");
            string registration = utils.ReadRegistration();
            if (utils.EmployeeExists(registration))
            {
                employees.Delete(registration);
                utils.HandleSuccess("Funcionário deletado com sucesso");
            }
            else
                Console.WriteLine("Funcionário não encontrado");
        }

        public void AdminList()
        {
            utils.ShowHeader("Lita de Administradores");
            Console.WriteLine("      CPF      |     Nome     |   Usuário   |   Senha   ");
            foreach (Administrator admin in admins.GetAll())
            {
                Console.WriteLine($"{admin.CPF} | {admin.Name} | {admin.Registration} | {admin.Password}");
            }
        }

        public void EmployeeList()
        {
            utils.ShowHeader("Lita de Funcionários");
            Console.WriteLine("      CPF      |     Nome     |   Usuário   |   Senha   | Carga Horária ");
            foreach (Employee emp in employees.GetAll())
            {
                Console.WriteLine($"{emp.CPF} | {emp.Name} | {emp.Registration} | {emp.Password} | {emp.WorkLoad.StartHour.ToString("hh:mm:ss")} - {emp.WorkLoad.EndHour.ToString("hh:mm:ss")}");
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("[1] Cadastrar");
            Console.WriteLine("[2] Editar");
            Console.WriteLine("[3] Excluir");
            Console.WriteLine("[4] Exibir todos os Funcionários");
            Console.WriteLine("[5] Voltar");
        }

        private void ReadMenuOption()
        {
            Console.Write("=> ");
            menuOption = Console.ReadLine();
        }

        private void ShowMenuRoot()
        {
            Console.WriteLine("[1] Cadastrar");
            Console.WriteLine("[2] Editar");
            Console.WriteLine("[3] Excluir");
            Console.WriteLine("[4] Exibir todos os Funcionários");
            Console.WriteLine("[5] Exibir todos os Administradores");
            Console.WriteLine("[6] Voltar");
        }

        private void HandleMenu()
        {
            switch (menuOption)
            {
                case "1":
                    Console.WriteLine("Deseja cadastrar um: [1] Funcionário, [2] Administrador");
                    ReadUserTypeOption();
                    if (UserTypeOption == "1")
                        NewEmployee();
                    else if (UserTypeOption == "2")
                        NewAdmin();
                    else
                        Console.WriteLine("Opção Inválida");
                    break;
                case "2":

                    break;
                case "3":
                    Console.WriteLine("Deseja deletar um: [1] Funcionário, [2] Administrador");
                    ReadUserTypeOption();
                    if (UserTypeOption == "1")
                        DeleteEmployee();
                    else if (UserTypeOption == "2")
                        DeleteAdmin();
                    else
                        Console.WriteLine("Opção Inválida");
                    break;
                case "4":
                    Console.WriteLine("Lista de Funcionarios");
                    Console.WriteLine("CPF | Nome | Usuário | Senha | Carga Horária");
                    foreach (var item in employees.GetAll())
                    {
                        Console.WriteLine($"{item.CPF} | {item.Name} | {item.Registration} | {item.Password} | {item.WorkLoad.StartHour.ToString("hh:mm:ss")} - {item.WorkLoad.EndHour.ToString("hh:mm:ss")}");
                    }
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu");
                    Console.ReadLine();
                    break;
                    break;
                case "5":
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        }

        private void HandleMenuRoot()
        {
            switch (menuOption)
            {
                case "1":
                    Console.WriteLine("Deseja cadastrar um: [1] Funcionário, [2] Administrador");
                    ReadUserTypeOption();
                    if (UserTypeOption == "1")
                        NewEmployee();
                    else if (UserTypeOption == "2")
                        NewAdmin();
                    else
                        Console.WriteLine("Opção Inválida");
                    break;
                case "2":

                    break;
                case "3":
                    Console.WriteLine("Deseja deletar um: [1] Funcionário, [2] Administrador");
                    ReadUserTypeOption();
                    if (UserTypeOption == "1")
                        DeleteEmployee();
                    else if (UserTypeOption == "2")
                        DeleteAdmin();
                    else
                        Console.WriteLine("Opção Inválida");
                    break;
                case "4":
                    Console.WriteLine("Lista de Funcionarios");
                    Console.WriteLine("CPF | Nome | Usuário | Senha | Carga Horária");
                    foreach (var item in employees.GetAll())
                    {
                        Console.WriteLine($"{item.CPF} | {item.Name} | {item.Registration} | {item.Password} | {item.WorkLoad.StartHour.ToString("hh:mm:ss")} - {item.WorkLoad.EndHour.ToString("hh:mm:ss")}");
                    }
                    Console.WriteLine("Pressione qualquer tecla para voltar ao Menu");
                    Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine("Lista de Administradores");
                    Console.WriteLine("CPF | Nome | Usuário | Senha | Carga Horária");
                    foreach (var item in admins.GetAll())
                    {
                        Console.WriteLine($"{item.CPF} | {item.Name} | {item.Registration} | {item.Password}");
                    }
                    Console.WriteLine("Pressione qualquer tecla para voltar ao Menu");
                    Console.ReadLine();
                    break;
                case "6":
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        }

        private void ReadUserTypeOption()
        {
            Console.Write("=> ");
            UserTypeOption = Console.ReadLine();
        }

        /*public List<Administrator> SendAdmins ()
        {
            return admins.GetAll();
        }

        public List<Employee> SendEmployees ()
        {
            return employees.GetAll();
        }*/
    }
}
