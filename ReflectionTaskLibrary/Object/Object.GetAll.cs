using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PIHI.ReflectionTaskLibrary
{
    public static class ObjectGetAll
    {
        public static IEnumerable<TType> GetAll<TType>(this object ext, BindingFlags binding = BindingFlags.Public | BindingFlags.Instance)
        {
            var propertiesAndFields = ext.GetType().GetMembers(binding)
                .Where(p => (p.MemberType == MemberTypes.Field ||
                             p.MemberType == MemberTypes.Property))
                .ToList();

            foreach (var m in propertiesAndFields)
            {
                if (m is PropertyInfo)
                {
                    var pi = m as PropertyInfo;
                    if (pi.PropertyType.Is<TType>())
                    {
                        yield return ext.GetValue<TType>(pi);
                    }
                }
                else if (m is FieldInfo)
                {
                    var fi = m as FieldInfo;
                    if (fi.FieldType.Is<TType>())
                    {
                        yield return ext.GetValue<TType>(fi);
                    }
                }
            }
        }
    }
}
