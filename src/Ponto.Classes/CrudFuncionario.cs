using System;
using System.Collections.Generic;
using System.Linq;

namespace Ponto.Classes
{
    public class CrudFuncionario
    {
        private Dictionary<String, Funcionario> employees = new();

        public void Add(Funcionario funcionario)
        {
            employees.Add(funcionario.Registration, funcionario);
        }

        public List<Funcionario> ConsultarTodos()
        {
            return employees.Values.ToList();
        }

        public Funcionario ConsultarCPF(string registration)
        {
            return employees.GetValueOrDefault(registration);
        }

        public void Editar(Funcionario funcionario)
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
