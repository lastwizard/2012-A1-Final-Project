using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Validator.Constraints;

namespace FinalProject.Domain
{
    public class StoreOrder : CartBase<StoreOrderItem>
    {
        [NotNull]
        public virtual User Customer { get; set; }

        [NotNull]
        public virtual CreditCardType CreditCardType { get; set; }

        public virtual DateTime OrderDate { get; set; }

        [NotNull]
        public virtual Address BillingAddress { get; set; }

        [NotNull]
        public virtual Address ShippingAddress { get; set; }

        protected override StoreOrderItem CreateCartItem(Product product)
        {
            return new StoreOrderItem(this, product);
        }

        public override bool IsValid()
        {
            if (Items.Count == 0)
                return false;
            else if (IsTransient())
            {
                foreach (StoreOrderItem item in Items)
                {
                    if (item.Product.IsSoldOut || item.Product.CurrentQuantity < item.Quantity)
                        return false;
                }
            }

            return base.IsValid();
        }
    }
}
