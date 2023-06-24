using System;

namespace Ponto.Classes
{
    public struct CPF
    {
        public string Value { get; set; }

        public void DoValidations()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Value.Substring(0, 3)
                   + "."
                   + Value.Substring(3, 3)
                   + "."
                   + Value.Substring(5, 3)
                   + "-"
                   + Value.Substring(9, 2);
        }
    }
}
