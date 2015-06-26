using System;
using RetrIoc.Injection;

namespace WebFormsApp
{
    public class ActivatorContainer : IResolveTypes
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