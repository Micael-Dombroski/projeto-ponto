using System;

namespace ElectronicPointControl.Library
{
    public class CPF
    {
        private int cpfLengthWithOnlyNumbers = 11;

        public string cpf { get; private set; }

        public CPF(string value)
        {
            cpf = value;
            RemoveDotsAndHyphens();
            DoValidations();
        }

        private void RemoveDotsAndHyphens()
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
        }

        public void DoValidations()
        {
            LengthIsCorrect();
            AllDigitsAreEqual();
            ValidateCheckDigits();
        }

        private void LengthIsCorrect()
        {
            if (cpf.Length != cpfLengthWithOnlyNumbers)
                throw new InvalidCPFException("Número de caracteres é insuficiente.");
        }

        private void AllDigitsAreEqual()
        {
            char firstDigit = cpf[0];
            foreach (char digit in cpf)
                if (firstDigit != digit)
                    throw new Exception("CPF inválido");
        }

        private void ValidateCheckDigits()
        {
            CheckFirstVerifyingDigit();
            CheckSecondVerifyingDigit();
        }

        private void CheckFirstVerifyingDigit()
        {
            string tempCpf = cpf.Substring(0, 9);
            int[] multipliers = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (int)tempCpf[i] * multipliers[i];

            string secondVerifyingDigit = cpf.Substring(9, 1);

            int modulus = sum % 11;
            string trueCheckDigit = (modulus < 2 ? 0 : 11 - modulus).ToString();

            bool itIsNotValid = !secondVerifyingDigit.Equals(trueCheckDigit);

            if (itIsNotValid)
                throw new Exception("CPF inválido");
        }

        private void CheckSecondVerifyingDigit()
        {
            string tempCpf = cpf.Substring(0, 10);
            int[] multipliers = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            int sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (int)tempCpf[i] * multipliers[i];

            string firstVerifyingDigit = cpf.Substring(10, 1);

            int modulus = sum % 11;
            string trueCheckDigit = (modulus < 2 ? 0 : 11 - modulus).ToString();

            bool itIsNotValid = !firstVerifyingDigit.Equals(trueCheckDigit);

            if (itIsNotValid)
                throw new Exception("CPF inválido");
        }

        public override string ToString()
        {
            return cpf.Substring(0, 3)
                   + "."
                   + cpf.Substring(3, 3)
                   + "."
                   + cpf.Substring(6, 3)
                   + "-"
                   + cpf.Substring(9, 2);
        }
    }
}
