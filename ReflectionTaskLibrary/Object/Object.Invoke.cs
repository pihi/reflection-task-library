using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIHI.ReflectionTaskLibrary
{
    public static class ObjectInvoke
    {
        public static TResult Invoke<TResult>(this object ext, string name, params object[] arguments)
        {
            var types = new Type[arguments.Length];
            for (var i = 0; i < arguments.Length; i++)
            {
                types[i] = arguments[i].GetType();
            }

            var method = ext.GetType().GetMethod(name, types);
            return (TResult) method.Invoke(ext, arguments);
        }
    }
}
