using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.CommonValidator;
using SharpArch.Core;

namespace FinalProject.Domain.Exceptions
{
    public class ValidationResultException : Exception
    {
        public ICollection<IValidationResult> Results { get; protected set; }

        private ValidationResultException()
        { }

        public ValidationResultException(ICollection<IValidationResult> errors)
        {
            Check.Require(errors != null, "Collection required.");
            Results = errors;
        }
    }
}
