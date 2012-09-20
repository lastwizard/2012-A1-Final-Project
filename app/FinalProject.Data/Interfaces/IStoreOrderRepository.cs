using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.PersistenceSupport;
using FinalProject.Domain;

namespace FinalProject.Data.Interfaces
{
  public interface IStoreOrderRepository : IRepository<StoreOrder>
  {
    IList<StoreOrder> GetByCustomer(User customer);
    IList<StoreOrder> FindOrdersBetween(DateTime? startDate, DateTime? endDate);
  }
}
