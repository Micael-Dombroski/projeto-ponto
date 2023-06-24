using System;
using System.Collections.Generic;
using System.Linq;

namespace Ponto.Classes
{
    public class EmployeeCRUD
    {
        private Dictionary<String, Employee> employees = new();

        public void Add(Employee employee)
        {
            employees.Add(employee.Registration, employee);
        }

        public List<Employee> GetAll()
        {
            return employees.Values.ToList();
        }

        public Employee GetByCPF(string registration)
        {
            return employees.GetValueOrDefault(registration);
        }

        public void Update(Employee funcionario)
        {
            Delete(funcionario.Registration);
            Add(funcionario);
        }

        public void Delete(string registration)
        {
            employees.Remove(registration);
        }
    }
}
