using System;

namespace RetrIoc
{
    public interface IContainerBinding
    {
        object Resolve(Type type);
        object ResolveAll(Type type);
        void Release(object instance);
    }
}