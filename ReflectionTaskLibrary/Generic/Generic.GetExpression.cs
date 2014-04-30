using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PIHI.ReflectionTaskLibrary
{
    public static class GenericGetExpression
    {
        public static Expression<Func<T,object>> GetExpression<T>(this T ext, String memberName)
        {
            var type = typeof (T);
            var method = type.GetMethod(memberName, new Type[] {});

            Expression expr;

            if (method != null)
            {
                expr = Expression.Call(Expression.Constant(ext), method);
                
            }
            else
            {
                expr = Expression.PropertyOrField(Expression.Constant(ext), memberName);
            }

            var extParam = Expression.Parameter(typeof (T), "ext");
            return Expression.Lambda<Func<T, object>>(expr, extParam);
        }
    }
}
