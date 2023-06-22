using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponto.Classes
{
    public class Empresa
    {
        public string Nome;
        public string CNPJ;
        public Endereco Endereco;
        public Empresa (string nome, string cnpj, Endereco endereco)
        {
            Nome = nome;
            CNPJ = cnpj;
            Endereco = endereco;
        }
    }
}