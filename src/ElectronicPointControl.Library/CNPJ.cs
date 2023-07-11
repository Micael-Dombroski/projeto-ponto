using System;
using ElectronicPointControl.Library.Exceptions;

namespace ElectronicPointControl.Library
{
    public class CNPJ
    {
        public string cnpj { get; set; }

        public CNPJ(string cNPJValue)
        {
            cnpj = cNPJValue;
            CleanCNPJ();
            DoValidations();
        }

        private void CleanCNPJ()
        {
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
        }

        public void DoValidations()
        {
            AllDigitsAreEquals();
            CheckLength();
        }

        private void CheckLength()
        {
            if (cnpj.Length != 14)
                throw new InvalidCNPJException("CNPJ inválido: quantidade de caracteres incorreta");
        }

        private void AllDigitsAreEquals()
        {
            bool allAreEqual = true;

            foreach (char digit in cnpj)
                if (digit != cnpj[0])
                {
                    allAreEqual = false;
                    break;
                }

            if (allAreEqual)
                throw new InvalidCNPJException("CNPJ inválido: todos os dígitos iguais");
        }

        public override string ToString()
        {
            return cnpj.Substring(0, 2)
                   + "."
                   + cnpj.Substring(2, 3)
                   + "."
                   + cnpj.Substring(5, 3)
                   + "/"
                   + cnpj.Substring(8, 4)
                   + "-"
                   + cnpj.Substring(12, 2);
        }
    }
}
