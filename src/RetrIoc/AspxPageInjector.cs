using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;

namespace RetrIoc
{
    public class AspxPageInjector
    {
        private readonly RetrIocConfiguration _cfg;

        public AspxPageInjector(RetrIocConfiguration cfg)
        {
            if (cfg == null) throw new ArgumentNullException("cfg");

            _cfg = cfg;
        }

        public void InjectInto(Control control)
        {
            if (_cfg.ContainerBindings == null)
            {
                throw new InvalidOperationException("Please configure your container bindings.");
            }

            var injectTheseProperties = GetProperties(control.GetType());
            foreach (var property in injectTheseProperties)
            {
                var instance = _cfg.ContainerBindings.Resolve(property.PropertyType);
                property.SetValue(control, instance, null);
            }

            foreach (var child in GetControlTree(control))
            {
                InjectInto(child);
            }
        }

        private static IEnumerable<Control> GetControlTree(Control root)
        {
            foreach (Control child in root.Controls)
            {
                yield return child;
                foreach (var c in GetControlTree(child))
                {
                    yield return c;
                }
            }
        }

        private static IEnumerable<PropertyInfo> GetProperties(IReflect type)
        {
            var allInstanceProperties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var propsFound = new List<PropertyInfo>();

            foreach (var pi in allInstanceProperties)
            {
                var allAttributesOnProperty = pi.GetCustomAttributes(true);
                foreach (var attr in allAttributesOnProperty)
                {
                    if (attr.GetType() != typeof(InjectAttribute)) continue;
                    propsFound.Add(pi);
                    break;
                }
            }

            return propsFound;
        }

    }
}