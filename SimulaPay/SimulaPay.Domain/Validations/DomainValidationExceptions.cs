using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulaPay.Domain.Validations
{
    public class DomainValidationExceptions : Exception
    {
        public DomainValidationExceptions(string error) : base(error) { }
        public static void When(bool HasError, string error)
        {
            if (HasError)
            {
                throw new DomainValidationExceptions(error);
            }
        }
    }
}