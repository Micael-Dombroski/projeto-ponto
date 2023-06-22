using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponto.Classes
{
    public class FuncionarioComum:Funcionario
    {
        public FuncionarioComum (string cpf, string nome, string sobrenome, Endereco endereco):base(cpf,nome,sobrenome,endereco)
        {
            Cpf = cpf;
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            Usuario = $"{Nome.ToLower()}.{Sobrenome.ToLower()}";
            Senha = cpf;
        }
    }
}