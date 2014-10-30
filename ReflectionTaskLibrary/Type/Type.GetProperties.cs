using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace PIHI.ReflectionTaskLibrary
{
    public static class TypeGetProperties
    {
        public static ICollection<PropertyInfo> GetProperties(this Type ext,
            params Type[] types)
        {
            var properties = new List<PropertyInfo>();
            for (int i = 0; i < types.Length; i++)
            {
                properties.AddRange(ext.GetProperties()
                    .Where(p => p.PropertyType == types[i]).ToList());
            }

            return properties;
        }

        public static ICollection<PropertyInfo> GetProperties(this Type ext, 
            params string[] props)
        {
            var properties = new PropertyInfo[props.Length];
            for (int i=0; i<props.Length; i++)
            {
                properties[i] = ext.GetProperty(props[i]);
            }
            return properties.ToList();
        }
    }
}
