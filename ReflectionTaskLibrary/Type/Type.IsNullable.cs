using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIHI.ReflectionTaskLibrary
{
    public static class TypeIsNullable
    {
        public static bool IsNullable(this Type ext)
        {
            return (ext.IsGenericType &&
                ext.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}
