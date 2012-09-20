using System;
using System.Collections.Generic;
using System.Text;
using FinalProject.Domain.BaseClasses;
using NHibernate.Validator.Constraints;
using SharpArch.Core;
using System.Linq;

namespace FinalProject.Domain
{
    public class Product : Base
    {
        public const int NameLimit = 50;
        public const int ImageUrlLimit = 100;

        public virtual int CurrentQuantity { get; protected set; }

        [NotNullNotEmpty]
        [Length(Max = NameLimit)]
        public virtual string Name { get; set; }

        [Length(Max = ImageUrlLimit)]
        public virtual string ImageUrl { get; set; }

        public virtual string Description { get; set; }

        [Min(Value = 0)]
        public virtual double Price { get; set; }

        public virtual bool IsSoldOut
        {
            get { return CurrentQuantity <= 0; }
        }

        protected Product()
        { }

        public Product(int currentQuantity, string name, string description, double price, string imageUrl)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            CurrentQuantity = currentQuantity;
        }

        public virtual void UpdateQuantity(StoreOrder order)
        {
            Check.Require(order != null, "Order is a required argument.");
            Check.Require(!order.IsTransient(), "Order must not be transient.");

            StoreOrderItem item = order.Items.FirstOrDefault(x => x.Product == this);
            Check.Require(item != null, "Order must be for this product.");

            CurrentQuantity -= item.Quantity;
        }
    }
}
