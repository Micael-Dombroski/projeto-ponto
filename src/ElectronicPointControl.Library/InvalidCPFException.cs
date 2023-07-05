using System;

namespace ElectronicPointControl.Library
{
    public class InvalidCPFException : Exception
    {
        public InvalidCPFException(string message) : base(message)
        {
        }
    }
}
