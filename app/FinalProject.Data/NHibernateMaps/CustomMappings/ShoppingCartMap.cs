using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using FinalProject.Domain;

namespace Sample.Data.NHibernateMaps.CustomMappings
{
    public class ShoppingCartMap : IAutoMappingOverride<ShoppingCart>
    {
        #region IAutoMappingOverride<ShoppingCart> Members

        public void Override(FluentNHibernate.Automapping.AutoMapping<ShoppingCart> mapping)
        {
            mapping.HasMany(x => x.Items)
                .Cascade.AllDeleteOrphan();
        }

        #endregion
    }
}
