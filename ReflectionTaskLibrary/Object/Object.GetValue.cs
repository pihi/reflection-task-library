using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PIHI.ReflectionTaskLibrary
{
    public static class ObjectGetValue
    {
        public static object GetValue(this object ext, string propertyOrField)
        {
            if (String.IsNullOrWhiteSpace(propertyOrField))
                throw new ArgumentNullException("propertyOrField", "Null or Empty string was passed");

            object value;
            var pi = ext.GetType().GetProperty(propertyOrField);

            if (pi != null)
            {
                value = pi.GetValue(ext);
            }
            // Not a property, check fields
            else
            {
                var fi = ext.GetType().GetField(propertyOrField);

                // Not a field, return default
                if (fi == null) return null;

                value = fi.GetValue(ext);
            }

            return value;
        }

        public static TType GetValue<TType>(this object ext, string propertyOrField)
        {
            var value = GetValue(ext, propertyOrField);
            if (value == null) return default(TType);
            return (TType) value;
        }

        public static object GetValue(this object ext, FieldInfo fi)
        {
            return fi.GetValue(ext);
        }

        public static TType GetValue<TType>(this object ext, FieldInfo fi)
        {
            var value = GetValue(ext, fi);
            if (value == null) return default(TType);
            return (TType) fi.GetValue(ext);
        }

        public static object GetValue(this object ext, PropertyInfo pi)
        {
            return pi.GetValue(ext);
        }

        public static TType GetValue<TType>(this object ext, PropertyInfo pi)
        {
            var value = GetValue(ext, pi);
            if (value == null) return default(TType);
            return (TType) pi.GetValue(ext);
        }
    }
}
