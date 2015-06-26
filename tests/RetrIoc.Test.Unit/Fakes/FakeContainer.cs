using System;

namespace RetrIoc.Test.Unit.Fakes
{
    public class FakeContainer : IContainerBinding
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