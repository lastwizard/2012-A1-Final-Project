using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FinalProject.Web.Persistence
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PersistFieldAttribute : Attribute
    {
        public string Key { get; set; }
        public PersistLocation Location { get; set; }

        public PersistFieldAttribute()
            : this(PersistLocation.Nowhere, null)
        {}

        public PersistFieldAttribute(PersistLocation location)
            : this(location, null)
        {}

        public PersistFieldAttribute(PersistLocation location, string key)
        {
            Location = location;
            Key = key;
        }

        public string GetKeyFor(MemberInfo mi)
        {
            return (Key != null ? Key + "_" + mi.Name : mi.Name);
        }

        public static PersistFieldAttribute GetAttribute(MemberInfo mi)
        {
            return (PersistFieldAttribute)Attribute.GetCustomAttribute(mi,
                                typeof(PersistFieldAttribute));
        }

        public static PersistFieldAttribute GetAttribute(MemberInfo mi,
                                PersistLocation forLocation)
        {
            PersistFieldAttribute attr = GetAttribute(mi);
            return (attr != null && attr.Location == forLocation ? attr : null);
        }
    }
}
