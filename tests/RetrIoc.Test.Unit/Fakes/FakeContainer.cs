using System;
using RetrIoc.Injection;

namespace RetrIoc.Test.Unit.Fakes
{
    public class FakeContainer : IResolveTypes
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