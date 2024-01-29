using System;

namespace VechileManagement.Domain.Exceptions
{
    public class UnsupportedAddressException : Exception
    {
        public UnsupportedAddressException()
            : base("Address is unsupported.")
        {
        }
    }
}
