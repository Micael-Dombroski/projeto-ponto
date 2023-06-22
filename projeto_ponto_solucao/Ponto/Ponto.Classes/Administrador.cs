using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponto.Classes
{
    public class Administrador:Funcionario
    {
        public string ChaveAdministrador {get;set;}//Uma chave de acesso diferenciada
        public Administrador (string cpf, string nome, string sobrenome, Endereco endereco):base(cpf,nome,sobrenome,endereco)
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