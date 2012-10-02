using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using FinalProject.Domain;

namespace Sample.Data.NHibernateMaps.CustomMappings
{
    public class StoreOrderMap : IAutoMappingOverride<StoreOrder>
    {
        #region IAutoMappingOverride<StoreOrder> Members

        public void Override(FluentNHibernate.Automapping.AutoMapping<StoreOrder> mapping)
        {
            mapping.References(x => x.BillingAddress).Cascade.All();
            mapping.References(x => x.ShippingAddress).Cascade.All();
            mapping.HasMany(x => x.Items)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }

        #endregion
    }
}
