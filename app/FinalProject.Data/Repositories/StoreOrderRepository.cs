using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinalProject.Domain;
using NHibernate;
using FinalProject.Data.Interfaces;

namespace FinalProject.Data.Repositories
{
  public class StoreOrderRepository : BaseRepository<StoreOrder>, IStoreOrderRepository
  {
    private static readonly DateTime SqlServerMinDate = new DateTime(1753, 1, 1);

    public IList<StoreOrder> GetByCustomer(User customer)
    {
      if (customer == null) return new List<StoreOrder>();

      ICriteria criteria = Session.CreateCriteria<StoreOrder>();
      criteria.Add(NHibernate.Criterion.Expression.Eq("Customer", customer));
      return criteria.List<StoreOrder>();
    }

    public IList<StoreOrder> FindOrdersBetween(DateTime? startDate, DateTime? endDate)
    {
      var query = Session.QueryOver<StoreOrder>();
      if (startDate != null)
      {
        if (startDate < SqlServerMinDate) startDate = SqlServerMinDate;
        query.Where(so => so.OrderDate >= startDate.Value);
      }

      if (endDate != null)
      {
        if (endDate < SqlServerMinDate) endDate = SqlServerMinDate;
        query.Where(so => so.OrderDate <= endDate.Value);
      }

      return query.List();
    }
  }
}
