using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PIHI.ReflectionTaskLibrary
{
    public static class TypeGetProperties
    {
        public static PropertyInfo[] GetProperties(this Type ext, 
            BindingFlags binding = BindingFlags.Instance | BindingFlags.Public, 
            params string[] props)
        {
            var properties = new PropertyInfo[props.Length];
            for (int i=0; i<props.Length; i++)
            {
                properties[i] = ext.GetProperty(props[i], binding);
            }
            return properties;
        }

        public static PropertyInfo[] GetProperties<TType>(this Type ext,
            BindingFlags binding = BindingFlags.Instance | BindingFlags.Public,
            params Expression<Func<TType, object>>[] props)
        {
            var properties = new PropertyInfo[props.Length];
            for (int i = 0; i < props.Length; i++)
            {
                var memExp = props[i].Body as MemberExpression;
                if (memExp == null) continue;
                properties[i] = ext.GetProperty(memExp.Member.Name);
            }
            return properties;
        }
    }
}
