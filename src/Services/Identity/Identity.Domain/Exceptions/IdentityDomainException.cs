using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Exceptions
{
    public class IdentityDomainException : Exception
    {
        public IdentityDomainException() { }

        public IdentityDomainException(string message)
            : base(message) { }

        public IdentityDomainException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
