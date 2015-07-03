using System;
using System.Collections.Generic;
using System.Web.UI;
using RetrIoc.Configuration;

namespace RetrIoc.Injection
{
    public class AspxPageInjector
    {
        private readonly RetrIocConfiguration _cfg;
        private readonly InjectionMap _injectionMap;

        public AspxPageInjector(RetrIocConfiguration cfg)
        {
            if (cfg == null) throw new ArgumentNullException("cfg");

            _cfg = cfg;
            _injectionMap = new InjectionMap();
        }

        public void InjectInto(Control control)
        {
            if (_cfg.TypeResolver == null)
            {
                throw new InvalidOperationException("Please configure your container bindings.");
            }

            var injectTheseProperties = _injectionMap.Lookup(control.GetType());
            foreach (var property in injectTheseProperties)
            {
                var instance = _cfg.TypeResolver.Resolve(property.Type);

                if (instance == null)
                {
                    System.Diagnostics.Debug.WriteLine("Attempt to inject value into member " + property.UnderlyingValue.Name + " resulted in a NULL.");
                }

                property.SetValue(control, instance);
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
    }
}