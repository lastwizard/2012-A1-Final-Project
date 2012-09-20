using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinalProject.Domain.BaseClasses;
using NHibernate.Validator.Constraints;
using SharpArch.Core;

namespace FinalProject.Domain
{
    public class ShoppingCartItem : CartItemBase
    {
        [NotNull]
        public virtual ShoppingCart ShoppingCart { get; protected set; }

        protected ShoppingCartItem() {}

        public ShoppingCartItem(ShoppingCart cart, Product product)
            : base(product)
        {
            ShoppingCart = cart;
            Check.Assert(IsValid());
        }
    }
}
