using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PIHI.ReflectionTaskLibrary
{
    public static class ObjectSetValue
    {
        public static void SetValue<TValue>(this object ext, string propertyOrField, TValue value)
        {
            if (String.IsNullOrWhiteSpace(propertyOrField))
                throw new ArgumentNullException("propertyOrField", "Null or Empty string was passed");

            var pi = ext.GetType().GetProperty(propertyOrField);
            if (pi != null)
            {
                SetValue(ext, pi, value);
            }
            else
            {
                var fi = ext.GetType().GetField(propertyOrField);
                if (fi != null) SetValue(ext, fi, value);
            }
        }

        public static void SetValue<TValue>(this object ext, PropertyInfo property, TValue value)
        {
            property.SetValue(ext, value);
        }

        public static void SetValue<TValue>(this object ext, FieldInfo field, TValue value)
        {
            field.SetValue(ext, value);
        }
    }
}
