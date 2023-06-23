using System;
using System.Collections.Generic;

namespace Ponto.Classes
{
    public class CrudFuncionario : Administrador
    {
        private Dictionary<String, Funcionario> funcionarios;
        private static int Index = 0;
        public CrudFuncionario(string cpf, string nome, string sobrenome, Endereco endereco) : base(cpf, nome, sobrenome, endereco)
        {
            funcionarios = new Dictionary<String, Funcionario>();
            Cpf = cpf;
            Name = nome;
        }

        public void Cadastrar(Funcionario funcionario)
        {
            Index++;
            funcionario.ID = Index;
            funcionario.Tipo = "Comum";
            funcionarios.Add(funcionario.Cpf, funcionario);
        }
        public void CadastrarAdm(Administrador administrador)
        {
            Index++;
            string cpf = administrador.Cpf;
            administrador.ChaveAdministrador = $"{cpf[5]}{cpf[6]}{cpf[7]}{cpf[8]}{cpf[9]}{cpf[10]}{cpf[0]}{cpf[1]}{cpf[2]}{cpf[3]}{cpf[4]}";
            administrador.ID = Index;
            administrador.Tipo = "Adm";
            funcionarios.Add(administrador.Cpf, administrador);
        }

        public Dictionary<String, Funcionario> ConsultarTodos()
        {
            return funcionarios;
        }

        public Funcionario ConsultarCPF(string cpf)
        {
            foreach (KeyValuePair<string, Funcionario> par in funcionarios)
            {
                if (par.Key == cpf)
                {
                    return par.Value;
                }
            }
            return null;
        }

        public void Editar(Funcionario funcionario)
        {
            foreach (KeyValuePair<string, Funcionario> par in funcionarios)
            {
                if (par.Key == funcionario.Cpf)
                {
                    funcionarios.Remove(par.Key);
                    funcionarios.Add(funcionario.Cpf, funcionario);
                }
            }
        }

        public void Excluir(string cpf)
        {
            foreach (KeyValuePair<string, Funcionario> par in funcionarios)
            {
                if (par.Key == cpf)
                {
                    funcionarios.Remove(par.Key);
                }
            }
        }
    }
}
