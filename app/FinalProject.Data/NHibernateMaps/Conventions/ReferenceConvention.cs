using FluentNHibernate.Conventions;
using FluentNHibernate.Mapping;

namespace FinalProject.Data.NHibernateMaps.Conventions
{
    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IManyToOneInstance instance)
        {
            instance.Column(instance.Property.Name + "_ID");
        }
    }
}
