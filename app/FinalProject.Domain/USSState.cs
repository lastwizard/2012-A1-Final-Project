using System;
using System.Collections.Generic;
using System.Text;
using FinalProject.Domain.BaseClasses;
using NHibernate.Validator.Constraints;

namespace FinalProject.Domain
{
    public class USState : Base
    {
        public const int AbbreviationLimit = 2;
        public const int FullNameLimit = 30;

        [NotNullNotEmpty]
        [Length(Max = AbbreviationLimit)]
        public virtual string Abbreviation { get; protected set; }

        [NotNullNotEmpty]
        [Length(Max = FullNameLimit)]
        public virtual string FullName { get; protected set; }

        protected USState()
        { }

        public USState(string abbreviation, string fullName)
        {
            Abbreviation = abbreviation;
            FullName = fullName;
        }
    }
}
