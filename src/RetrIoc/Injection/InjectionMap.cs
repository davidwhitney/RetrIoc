using System;
using System.Collections.Generic;
using System.Reflection;

namespace RetrIoc.Injection
{
    public class InjectionMap : Dictionary<Type, List<PropertyInfo>>
    {
        public List<PropertyInfo> Lookup(Type type)
        {
            if (!ContainsKey(type))
            {
                PopulateMapForType(type);
            }

            return this[type];
        }

        private void PopulateMapForType(Type type)
        {
            var allInstanceProperties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var propsFound = new List<PropertyInfo>();

            foreach (var pi in allInstanceProperties)
            {
                var allAttributesOnProperty = pi.GetCustomAttributes(true);
                foreach (var attr in allAttributesOnProperty)
                {
                    if (attr.GetType() != typeof (InjectAttribute)) continue;
                    propsFound.Add(pi);
                    break;
                }
            }

            this[type] = propsFound;
        }
    }
}