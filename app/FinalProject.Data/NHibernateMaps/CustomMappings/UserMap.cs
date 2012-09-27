using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using FinalProject.Domain;

namespace Sample.Data.NHibernateMaps.CustomMappings
{
    public class UserMap : IAutoMappingOverride<User>
    {
        #region IAutoMappingOverride<StoreOrder> Members

        public void Override(FluentNHibernate.Automapping.AutoMapping<User> mapping)
        {
            mapping.HasManyToMany(x => x.Addresses)
                .Table("UserAddresses");
        }

        #endregion
    }
}
