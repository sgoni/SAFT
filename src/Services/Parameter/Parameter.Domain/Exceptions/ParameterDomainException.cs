using System;

namespace Parameter.Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class ParameterDomainException : Exception
    {
        public ParameterDomainException() { }

        public ParameterDomainException(string message) : base(message) { }

        public ParameterDomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}
