using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Freelancer.Model.Common.Extensions
{
    public static class EnitityFrameworkExtensions
    {

        public static IOrderedEnumerable<TSource> OrderByWithDirection<TSource, TKey>
    (this IEnumerable<TSource> source,
     Func<TSource, TKey> keySelector,
     bool descending)
        {
            return descending ? source.OrderByDescending(keySelector)
                              : source.OrderBy(keySelector);
        }

        public static IQueryable<TSource> OrderByWithDirection<TSource, TKey>
            (this IQueryable<TSource> source,
             Expression<Func<TSource, TKey>> keySelector,
             bool descending)
        {
            return descending ? source.OrderByDescending(keySelector)
                              : source.OrderBy(keySelector);
        }



        public static IQueryable<TSource> ApplySortingAndPagging<TSource>
    (this IQueryable<TSource> source, string sortColumnName, bool sortOrderDescending, int pageSize, int pageStart)
        {


            // Apply Sort Order
            if (!string.IsNullOrEmpty(sortColumnName))
            {

                source = source.OrderBy(sortColumnName, sortOrderDescending);

                // Apply Pagging
                source = source.ApplyPagging(pageSize, pageStart);

            }

            return source;

        }


        public static IQueryable<TSource> ApplySortingAndPagging<TSource>
   (this IQueryable<TSource> source, List<SortInfo> sortOrders, int pageSize, int pageStart)
        {


            // Apply Sort Order
            if (sortOrders != null && sortOrders.Count > 0)
            {

                source = source.OrderBy(sortOrders[0].SortColumnName, sortOrders[0].SortOrderDescending);


                for(int i=1;i<sortOrders.Count;i++)
                {
                    source = source.ThenOrderBy(sortOrders[i].SortColumnName, sortOrders[i].SortOrderDescending);
                }

                // Apply Pagging
                source = source.ApplyPagging(pageSize, pageStart);

            }

            return source;

        }



        public static IQueryable<TSource> ApplyPagging<TSource>
    (this IQueryable<TSource> source, int pageSize, int start)
        {

            IQueryable<TSource> result = source;

            if (start > 0)
                result = result.Skip(start);


            if (pageSize > 0 && pageSize != int.MaxValue)
                result = result.Take(pageSize);

            return result;

        }


        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property, bool isDecending)
        {
            if (isDecending)                
                return ApplyOrder<T>(source, property, "OrderByDescending");
            else
                return ApplyOrder<T>(source, property, "OrderBy");

        }

        public static IOrderedQueryable<T> ThenOrderBy<T>(this IQueryable<T> source, string property, bool isDecending)
        {
            if (isDecending)

                return ApplyOrder<T>(source, property, "ThenByDescending");
            else
                return ApplyOrder<T>(source, property, "ThenBy");
        }

        public static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {

            if (string.IsNullOrEmpty(property))
                throw new NullReferenceException("Property Name cannot be null.");


            if (string.IsNullOrEmpty(methodName))
                throw new NullReferenceException("Method Name cannot be null.");


            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }




        public class SortInfo
        {
            public string SortColumnName { get; set; }


            public bool SortOrderDescending { get; set; }

        }
    }
}
