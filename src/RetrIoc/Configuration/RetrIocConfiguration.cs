using RetrIoc.Injection;

namespace RetrIoc.Configuration
{
    public class RetrIocConfiguration
    {
        public IResolveTypes TypeResolver { get; set; }

        public RetrIocConfiguration(IResolveTypes typeResolver)
        {
            TypeResolver = typeResolver;
        }
    }
}