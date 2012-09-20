using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Data.NHibernate;
using FinalProject.Domain.BaseClasses;

namespace FinalProject.Data.Repositories
{
    public class BaseRepository<T> : Repository<T>
        where T : Base
    {
        public override T SaveOrUpdate(T entity)
        {
            if (entity != null)
                entity.Validate();

            return base.SaveOrUpdate(entity);
        }
    }
}
