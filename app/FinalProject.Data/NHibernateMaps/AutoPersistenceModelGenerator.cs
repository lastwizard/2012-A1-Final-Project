using System;
using System.Linq;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using FinalProject.Data.NHibernateMaps.Conventions;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate.FluentNHibernate;
using FinalProject.Domain.BaseClasses;
using FinalProject.Domain;

namespace FinalProject.Data.NHibernateMaps
{

    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {

        #region IAutoPersistenceModelGenerator Members

        public AutoPersistenceModel Generate()
        {
            return AutoMap.AssemblyOf<Base>(new AutomappingConfiguration())
                .Conventions.Setup(GetConventions())
                .IgnoreBase<Entity>()
                .IgnoreBase(typeof(EntityWithTypedId<>))
                .IgnoreBase<Base>()
                .IgnoreBase<CartItemBase>()
                .IgnoreBase(typeof(CartBase<>))
                .UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
        }

        #endregion

        private Action<IConventionFinder> GetConventions()
        {
            return c =>
            {
                c.Add<FinalProject.Data.NHibernateMaps.Conventions.ForeignKeyConvention>();
                c.Add<FinalProject.Data.NHibernateMaps.Conventions.HasManyConvention>();
                c.Add<FinalProject.Data.NHibernateMaps.Conventions.HasManyToManyConvention>();
                c.Add<FinalProject.Data.NHibernateMaps.Conventions.ManyToManyTableNameConvention>();
                c.Add<FinalProject.Data.NHibernateMaps.Conventions.ReferenceConvention>();
                c.Add<FinalProject.Data.NHibernateMaps.Conventions.TableNameConvention>();
            };
        }
    }
}
