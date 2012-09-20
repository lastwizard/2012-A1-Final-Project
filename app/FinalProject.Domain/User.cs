using System;
using System.Data;
using System.Collections.Generic;
using FinalProject.Domain.BaseClasses;
using NHibernate.Validator.Constraints;

namespace FinalProject.Domain
{
	public class User : Base
	{
        public const int NameLimit = 50;
        public const int EmailLimit = 100;
        public const int PasswordLimit = 20;

        public virtual RoleType RoleType { get; set; }

        [NotNullNotEmpty]
        [Length(Max = NameLimit)]
        public virtual string LastName { get; set; }

        [NotNullNotEmpty]
        [Length(Max = NameLimit)]
        public virtual string FirstName { get; set; }

        [NotNullNotEmpty]
        [Length(Max = EmailLimit)]
        [Email]
        public virtual string Email { get; set; }

        [NotNullNotEmpty]
        [Length(Max = NameLimit)]
        public virtual string UserName { get; set; }

        [NotNullNotEmpty]
        [Length(Max = PasswordLimit)]
        public virtual string Password { get; set; }

        [NotNull]
        public virtual IList<Address> Addresses { get; protected set; }

		public User()
        {
            Addresses = new List<Address>();
            RoleType = RoleType.Customer;
        }

        public User(string firstName, string lastName, string email, string userName, string password)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}