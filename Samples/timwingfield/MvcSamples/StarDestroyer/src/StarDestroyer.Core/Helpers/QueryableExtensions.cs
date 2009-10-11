using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Linq;

namespace StarDestroyer.Core.Helpers
{
    //public static class QueryableExtensions
    //{
    //    public static INHibernateQueryable<T> OrderBy<T>(this INHibernateQueryable<T> queryable, string propertyName, bool ascending)
    //    {
    //        var type = typeof(T);
    //        var property = type.GetProperty(propertyName);
    //        var parameter = Expression.Parameter(type, "p");
    //        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
    //        var orderByExp = Expression.Lambda(propertyAccess, parameter);
    //        MethodCallExpression resultExp = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { type, property.PropertyType }, queryable.Expression, Expression.Quote(orderByExp));

    //        return queryable.Provider.CreateQuery<T>(resultExp);
    //    }
    //}
}