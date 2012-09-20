using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using SharpArch.Core;
using SharpArch.Core.CommonValidator;
using FinalProject.Domain.Exceptions;

namespace FinalProject.Domain.BaseClasses
{
    public abstract class Base : Entity
    {
        public new virtual bool IsTransient()
        {
            return Id == 0;
        }

        public virtual void Validate()
        {
            ICollection<IValidationResult> results = ValidationResults();
            if (results != null && results.Count > 0)
                throw new ValidationResultException(results);
        }
    }
}
