using System;

namespace RetrIoc.Injection
{
    public interface IResolveTypes
    {
        object Resolve(Type type);
        object ResolveAll(Type type);
        void Release(object instance);
    }
}