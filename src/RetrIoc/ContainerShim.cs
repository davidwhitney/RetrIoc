using System;
using System.Collections.Generic;
using RetrIoc.Injection;

namespace RetrIoc
{
    public class ContainerShim : IResolveTypes
    {
        private readonly Func<Type, object> _getType;
        private readonly Func<Type, IEnumerable<object>> _getAllTypes;
        private readonly Action<object> _releaseInstance;

        public ContainerShim(Func<Type, object> getType,
            Func<Type, IEnumerable<object>> getAllTypes,
            Action<object> releaseInstance)
        {
            _getType = getType;
            _getAllTypes = getAllTypes;
            _releaseInstance = releaseInstance;
        }

        public object Resolve(Type type)
        {
            return _getType(type);
        }

        public object ResolveAll(Type type)
        {
            return _getAllTypes(type);
        }

        public void Release(object instance)
        {
            _releaseInstance(instance);
        }
    }
}