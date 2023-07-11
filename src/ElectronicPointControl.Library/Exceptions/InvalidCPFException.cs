using System;

namespace ElectronicPointControl.Library.Exceptions
{
    public class InvalidCPFException : Exception
    {
        public InvalidCPFException(string message) : base(message)
        {
        }
    }
}
