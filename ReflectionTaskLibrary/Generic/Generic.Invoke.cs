using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIHI.ReflectionTaskLibrary
{
    public static class GenericInvoke
    {
        public static TResult Invoke<T, TResult>(this T ext, string name, params object[] arguments)
        {
            return ObjectInvoke.Invoke<TResult>(ext, name, arguments);
        }
    }
}
