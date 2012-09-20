using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinalProject.Domain;
using SharpArch.Core.PersistenceSupport;
using FinalProject.Data.Search;

namespace FinalProject.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IList<Product> GetAvailableProducts();
        IList<Product> GetSearchResults(ProductSearchParameters psp);
    }
}
