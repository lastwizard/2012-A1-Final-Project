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
            mapping.HasMany(x => x.Items)
                .Cascade.AllDeleteOrphan();
        }

        #endregion
    }
}
