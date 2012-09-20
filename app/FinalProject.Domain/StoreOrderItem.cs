using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinalProject.Domain.BaseClasses;
using NHibernate.Validator.Constraints;
using SharpArch.Core;

namespace FinalProject.Domain
{
    public class StoreOrderItem : CartItemBase
    {
        [NotNull]
        public virtual StoreOrder StoreOrder { get; protected set; }

        protected StoreOrderItem() {}

        public StoreOrderItem(StoreOrder order, Product product)
            : base(product)
        {
            StoreOrder = order;
            Check.Assert(IsValid());
        }
    }
}
