using System.Linq;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using SharpArch.Core.DomainModel;
using FinalProject.Domain.BaseClasses;
using FinalProject.Domain;

namespace FinalProject.Data.NHibernateMaps
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(System.Type type)
        {
            return type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEntityWithTypedId<>));
        }

        public override bool ShouldMap(Member member)
        {
            return base.ShouldMap(member) && member.CanWrite;
        }

        public override bool AbstractClassIsLayerSupertype(System.Type type)
        {
            System.Console.Out.WriteLine(type.FullName);
            bool result = type == typeof(EntityWithTypedId<>)
                || type == typeof(Entity)
                || type == typeof(Base)
                || type == typeof(CartBase<>);

            System.Console.Out.WriteLine(result);
            return result;
        }

        public override bool IsId(Member member)
        {
            return member.Name == "Id";
        }
    }
}
