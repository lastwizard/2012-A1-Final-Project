using System;
using FluentNHibernate;

namespace FinalProject.Data.NHibernateMaps.Conventions
{
    public class ForeignKeyConvention : FluentNHibernate.Conventions.ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            if (property == null)
                return type.Name + "_ID";

            return property.Name + "_ID";
        }
    }
}
