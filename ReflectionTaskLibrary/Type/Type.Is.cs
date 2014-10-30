using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace PIHI.ReflectionTaskLibrary
{
    public static class TypeIs
    {
        public static bool Is<TType>(this Type ext)
        {
            return Is(ext, typeof (TType));
        }

        public static bool Is(this Type ext, Type check)
        {
            return (ext == check || // types are equal
                (ext.IsNullable() && ext.GetGenericArguments()[0] == check) || // Type is nullable and value types match
                (check.IsNullable() && check.GetGenericArguments()[0] == ext) || // Check is nullable and value type match
                (ext.IsSubclassOf(check)) || // Type extends subclass
                (ext.GetInterfaces().Any(i => i == check))); // Type implements interface 
        }
    }
}
