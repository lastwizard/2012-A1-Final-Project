using System;
using System.Collections.Generic;
using System.Text;
using FinalProject.Domain.BaseClasses;
using NHibernate.Validator.Constraints;

namespace FinalProject.Domain
{
    public class Address : Base
    {
        public const int NameLimit = 50;
        public const int LineLimit = 100;
        public const int CityLimit = 50;
        public const int ZipCodeLimit = 10;

        [Length(Max = NameLimit)]
        public virtual string Name { get; set; }

        [Length(Max = LineLimit)]
        public virtual string Line1 { get; set; }

        [Length(Max = LineLimit)]
        public virtual string Line2 { get; set; }

        [Length(Max = CityLimit)]
        public virtual string City { get; set; }

        [Length(Max = ZipCodeLimit)]
        public virtual string ZipCode { get; set; }

        [NotNull]
        public virtual USState State { get; set; }

        public virtual Address Clone()
        {
            Address address = new Address();
            address.Name = this.Name;
            address.Line1 = this.Line1;
            address.Line2 = this.Line2;
            address.City = this.City;
            address.State = this.State;
            address.ZipCode = this.ZipCode;
            return address;
        }

        public virtual string ToString(bool includeName, string delim)
        {
            StringBuilder builder = new StringBuilder();
            if (includeName && !String.IsNullOrEmpty(Name))
            {
                builder.Append(Name);
                builder.Append(delim);
            }
            builder.Append(Line1);
            builder.Append(delim);

            if (!String.IsNullOrEmpty(Line2))
            {
                builder.Append(Line2);
                builder.Append(delim);
            }

            builder.Append(City);
            builder.Append(", ");
            builder.Append(State.Abbreviation);
            builder.Append("  ");
            builder.Append(ZipCode);

            return builder.ToString();
        }
    }
}
