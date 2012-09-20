using System;
using System.Collections.Generic;
using System.Text;
using FinalProject.Domain.BaseClasses;
using SharpArch.Core;

namespace FinalProject.Domain
{
    public class ShoppingCart : CartBase<ShoppingCartItem>
    {
        public virtual DateTime LastUpdated { get; set; }

        protected override ShoppingCartItem CreateCartItem(Product product)
        {
            return new ShoppingCartItem(this, product);
        }

        public ShoppingCart()
        {
            LastUpdated = DateTime.Now;
        }
    }
}
