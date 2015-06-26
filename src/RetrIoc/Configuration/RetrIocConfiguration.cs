using System;
using RetrIoc.Injection;

namespace RetrIoc.Configuration
{
    public class RetrIocConfiguration
    {
        public IResolveTypes TypeResolver { get; set; }

        public RetrIocConfiguration(IResolveTypes typeResolver)
        {
            if (typeResolver == null) throw new ArgumentNullException("typeResolver");
            TypeResolver = typeResolver;
        }
    }
}