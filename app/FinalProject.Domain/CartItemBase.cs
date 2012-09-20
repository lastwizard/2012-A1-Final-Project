using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinalProject.Domain.BaseClasses;
using NHibernate.Validator.Constraints;
using SharpArch.Core;

namespace FinalProject.Domain
{
    public abstract class CartItemBase : Base
    {
        [NotNull]
        public virtual Product Product { get; protected set; }

        [Min(Value = 0)]
        public virtual int Quantity { get; set; }

        protected CartItemBase() {}

        public CartItemBase(Product product)
        {
            Product = product;
            Quantity = 1;
        }
    }
}
