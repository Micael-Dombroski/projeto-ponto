using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponto.Classes
{
    public class Pessoa
    {
        public string Cpf {get;set;}
        public string Nome {get;set;}
        public string Sobrenome {get;set;}
        public Endereco Endereco {get;set;}
        public Pessoa(string cpf, string nome, string sobrenome, Endereco endereco)
        {
            Cpf = cpf;
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
        }
    }
}