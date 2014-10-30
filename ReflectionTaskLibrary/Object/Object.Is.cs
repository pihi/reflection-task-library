using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIHI.ReflectionTaskLibrary
{
    public static class ObjectIs
    {
        public static bool Is<TType>(this object ext)
        {
            return Is(ext, typeof(TType));
        }

        public static bool Is(this object ext, Type type)
        {
            return ext.GetType().Is(type);
        }
    }
}
