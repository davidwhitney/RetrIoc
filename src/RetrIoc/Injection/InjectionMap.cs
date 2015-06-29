using System;
using System.Collections.Generic;
using System.Reflection;

namespace RetrIoc.Injection
{
    public class InjectionMap : Dictionary<Type, List<ExtendedMemberInfo>>
    {
        public List<ExtendedMemberInfo> Lookup(Type type)
        {
            if (!ContainsKey(type))
            {
                PopulateMapForType(type);
            }

            return this[type];
        }

        private void PopulateMapForType(Type type)
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            
            var allInstanceFields = type.GetMembers(flags);
            var members = new List<ExtendedMemberInfo>();
            foreach (var pi in allInstanceFields)
            {
                var allAttributesOnProperty = pi.GetCustomAttributes(true);
                foreach (var attr in allAttributesOnProperty)
                {
                    if (attr.GetType() != typeof(InjectAttribute)) continue;
                    members.Add(new ExtendedMemberInfo(pi));
                    break;
                }
            }

            this[type] = members;
        }
    }

    public class ExtendedMemberInfo
    {
        public MemberInfo UnderlyingValue { get; set; }
        public Type Type { get; set; }

        public ExtendedMemberInfo(MemberInfo memberOrFieldInfo)
        {
            UnderlyingValue = memberOrFieldInfo;
            Type = GetUnderlyingType(memberOrFieldInfo);
        }

        public void SetValue(object instance, object value)
        {
            if (UnderlyingValue is PropertyInfo)
            {
                ((PropertyInfo)UnderlyingValue).SetValue(instance, value, null);
            }

            if (UnderlyingValue is FieldInfo)
            {
                ((FieldInfo)UnderlyingValue).SetValue(instance, value);
            }
        }
   
        public static Type GetUnderlyingType(MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;
                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;
                default:
                    throw new ArgumentException("Input MemberInfo must be if type FieldInfo or PropertyInfo");
            }
        }
    }
}