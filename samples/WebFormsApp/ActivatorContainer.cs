using System;
using RetrIoc;

namespace WebFormsApp
{
    public class ActivatorContainer : IContainerBinding
    {
        public object Resolve(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public object ResolveAll(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public void Release(object instance)
        {
            //noop;
        }
    }
}