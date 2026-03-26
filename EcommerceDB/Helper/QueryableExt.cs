using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EcommerceDB.Helper
{
    public static class QueryableExt
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string columName, bool isAscending = true)
        {
            if (string.IsNullOrEmpty(columName))
                return source;
            //(x)
            Console.WriteLine(typeof(T).Name);
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            //(x.price)
            MemberExpression property = Expression.Property(parameter, columName);
            //(x=>x.price)
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methedName = isAscending ? "OrderBy" : "OrderByDescending";

            Expression methodCallExpression = 
                Expression.Call(
                    typeof(Queryable), 
                    methedName, 
                    new Type[] { source.ElementType, property.Type },
                    source.Expression,
                    Expression.Quote(lambda));

            //Select * from Product order By Price
            return source.Provider.CreateQuery<T>(methodCallExpression);
        }
    }
}
