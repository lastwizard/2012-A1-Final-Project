using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core;
using FinalProject.Domain.BaseClasses;

namespace FinalProject.Domain
{
    public abstract class CartBase<T> : Base
        where T : CartItemBase
    {
        public virtual IList<T> Items { get; protected set; }

        public virtual double TotalCost
        {
            get
            {
                double result = 0;
                foreach (T item in Items)
                    result += (item.Product.Price * item.Quantity);
                return result;
            }
        }

        public virtual bool IsEmpty
        {
            get { return (Items.Count == 0); }
        }

        protected abstract T CreateCartItem(Product product);

        public virtual void AddItem(Product product, int count)
        {
            Check.Require(product != null, "Product is a required argument.");
            T item = Items.FirstOrDefault(x => x.Product == product);
            if (item != null)
            {
                item.Quantity += count;
            }
            else
            {
                item = CreateCartItem(product);
                item.Quantity = count;
                Items.Add(item);
            }

            if (item.Quantity <= 0)
                RemoveItem(product);
        }

        public virtual void RemoveItem(Product product)
        {
            if (Items.Any(x => x.Product == product))
                Items.Remove(Items.First(x => x.Product == product));
        }

        public virtual void RemoveItemById(int productId)
        {
            Product product = null;
            foreach (Product checkProduct in Items.Select(x => x.Product))
            {
                if (checkProduct.Id.Equals(productId))
                {
                    product = checkProduct;
                    break;
                }
            }
            if (product != null)
                RemoveItem(product);
        }

        public CartBase()
        {
            Items = new List<T>();
        }
    }
}
