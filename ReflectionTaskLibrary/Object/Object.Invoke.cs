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
            var argTypes = arguments.Select(a => a.GetType()).ToArray();
            return Invoke<TResult>(ext, name, argTypes, arguments);
        }

        public static TResult Invoke<TResult>(this object ext, string name, Type[] argTypes, params object[] arguments)
        {
            var method = ext.GetType().GetMethod(name, argTypes);
            if (method == null) throw new NotImplementedException();
            return (TResult)method.Invoke(ext, arguments);
        }
    }
}
