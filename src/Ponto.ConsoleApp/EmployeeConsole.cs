using Ponto.Classes;

namespace Ponto.ConsoleApp
{
    public class EmployeeConsole
    {
        private ConsoleUtils utils = new ConsoleUtils();
        private Employee logedEmployee;

        public void SetLogedEmployee(Employee employee)
        {
            logedEmployee = employee;
        }
        
        public void NewEmployee()
        {
            utils.ShowHeader(message: "Novo Funcionário");
            string registration = ReadRegistration();
            if (utils.EmployeeExists(registration))
                utils.HandleError("Funcionário já cadastrado");
            CPF cpf = ReadCPF();
            string name = ReadName();
            string password = ReadPassword();
            Employee employee = new Employee()
            {
                CPF = cpf,
                name = name,
                password = password,
                registration = registration
            };

            utils.HandleSuccess("Funcionário criado com sucesso");
        }

        public void PunchClock()
        {
            try
            {
                logedEmployee.PunchClock();
            }
            catch (System.Exception e)
            {
                utils.HandleError(e.Message);
            }
        }
    }
}