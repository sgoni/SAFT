using System;

namespace Workshop.Damain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class WorkshopDomainException : Exception
    {
        public WorkshopDomainException() { }

        public WorkshopDomainException(string message) : base(message) { }

        public WorkshopDomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}
