using System;
using System.Collections.Generic;
using System.Text;
using FinalProject.Domain.BaseClasses;
using NHibernate.Validator.Constraints;

namespace FinalProject.Domain
{
    public class CreditCardType : Base
    {
        public const int NameLimit = 20;
        protected CreditCardType()
        { }

        public CreditCardType(string name)
        {
            Name = name;
        }

        [NotNullNotEmpty]
        [Length(Max = NameLimit)]
        public virtual string Name { get; set; }
    }
}
