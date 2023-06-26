using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponto.Classes
{
    public struct Endereco
    {
        public string Uf {get;set;}
        public string Cidade {get;set;}
        public string Complemento {get;set;}
        public string Bairro {get;set;}
        public string Rua {get;set;}
        public int NumeroCasa {get;set;}
        public Endereco (string uf, string cidade, string complemento, string bairro, string rua, int numeroCasa)
        {
            Uf = uf;
            Cidade = cidade;
            Complemento = complemento;
            Bairro = bairro;
            Rua = rua;
            NumeroCasa = numeroCasa;
        }
    }
}