using System;
using System.Collections.Generic;

namespace Ponto.Classes
{
    public class CrudFuncionario
    {
        private Dictionary<String, Funcionario> funcionarios = new();
        private static int Index = 0;

        public void Cadastrar(Funcionario funcionario)
        {
            Index++;
            funcionario.ID = Index;
            funcionario.Tipo = "Comum";
            funcionarios.Add(funcionario.Registration, funcionario);
        }
        public void CadastrarAdm(Administrador administrador)
        {
            Index++;
            administrador.ID = Index;
            administrador.Tipo = "Adm";
            funcionarios.Add(administrador.Registration, administrador);
        }

        public Dictionary<String, Funcionario> ConsultarTodos()
        {
            return funcionarios;
        }

        public Funcionario ConsultarCPF(string registration)
        {
            return funcionarios.GetValueOrDefault(registration);
        }

        public void Editar(Funcionario funcionario)
        {
            foreach (KeyValuePair<string, Funcionario> par in funcionarios)
            {
                if (par.Key == funcionario.Registration)
                {
                    funcionarios.Remove(par.Key);
                    funcionarios.Add(funcionario.Registration, funcionario);
                }
            }
        }

        public void Excluir(string registration)
        {
            foreach (KeyValuePair<string, Funcionario> par in funcionarios)
            {
                if (par.Key == registration)
                {
                    funcionarios.Remove(par.Key);
                }
            }
        }
    }
}
