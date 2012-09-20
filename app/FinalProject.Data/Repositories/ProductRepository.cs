using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinalProject.Domain;
using NHibernate;
using NHibernate.Criterion;
using FinalProject.Data.Search;
using FinalProject.Data.Interfaces;

namespace FinalProject.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public IList<Product> GetAvailableProducts()
        {
            ICriteria criteria = Session.CreateCriteria<Product>();
            criteria.Add(Expression.Gt("CurrentQuantity", 0));
            return criteria.List<Product>();
        }

        public IList<Product> GetSearchResults(ProductSearchParameters psp)
        {
            if (psp == null) return GetAvailableProducts();

            ICriteria criteria = Session.CreateCriteria<Product>();

            foreach (string word in psp.Criteria)
            {
                if (!String.IsNullOrWhiteSpace(word))
                {
                    criteria.Add(Restrictions.Disjunction()
                                    .Add(Expression.InsensitiveLike("Name", word, MatchMode.Anywhere))
                                    .Add(Expression.InsensitiveLike("Description", word, MatchMode.Anywhere))
                                    );
                }
            }

            string propSort = String.Empty;
            switch (psp.SortType)
            {
                case ProductSortType.Quantity:
                    propSort = "CurrentQuantity";
                    break;
                case ProductSortType.Price:
                case ProductSortType.Name:
                    propSort = psp.SortType.ToString();
                    break;
                case ProductSortType.Default:
                default:
                    propSort = "Name";
                    break;
            }
            criteria.AddOrder(new NHibernate.Criterion.Order(propSort, psp.SortDirection == SortDirection.Ascending));

            return criteria.List<Product>();
        }
    }
}
