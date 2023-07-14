using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ElectronicPointControl.Library
{
    public class EmployeeCRUD
    {
        private string filePath;

        private Dictionary<String, Employee> employees = new();

        public EmployeeCRUD(string filePath
                = "/home/natan/www/jp/projeto-ponto/src/ElectronicPointControl.Library/employees.txt")
        {
            this.filePath = filePath;
        }

        public void Add(Employee employee)
        {
            if (!File.Exists(filePath))
            {
                Stream file = File.Open(filePath, FileMode.Create);
                file.Close();
            }
            using (Stream file = File.Open(filePath, FileMode.Append))
            {
                using (StreamWriter writer = new(file))
                {
                    writer.WriteLine(employee);
                }
            }

        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new();
            using (Stream file = File.Open(filePath, FileMode.Open))
            {
                using (StreamReader reader = new(file))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var props = line.Split(";");
                        var employee = new Employee(
                                cpf: new CPF(props[0]),
                                name: props[1],
                                registration: props[2],
                                password: props[3],
                                workLoad: new WorkLoad
                                {
                                    StartHour = Convert.ToDateTime(props[4]),
                                    EndHour = Convert.ToDateTime(props[5])
                                });
                        employees.Add(employee);
                        line = reader.ReadLine();
                    }
                }
            }
            return employees;
        }

        public Employee Get(string registration)
        {
            var employees = GetAll();
            return employees.Find(employee => employee.Registration == registration);
        }

        public void Update(Employee employee)
        {
            Delete(employee.Registration);
            Add(employee);
        }

        public void Delete(string registration)
        {
            var employees = GetAll();
            employees.Remove(Get(registration));
            using (Stream file = File.Open(filePath, FileMode.Create))
            {
                using (StreamWriter writer = new(file))
                {
                    foreach (var employee in employees)
                    {
                        writer.WriteLine(employee);
                    }
                }
            }

        }
    }
}
