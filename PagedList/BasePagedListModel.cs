using PagedList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PagedList
{
    /// <summary>
    /// Represents an object of type IPagedListModel.
    /// Extends this class to implement a custom Paged List Model and encapsulate automated query generating
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BasePagedListModel<TModel> : IPagedListModel<TModel>
    {
        /// <summary>
        /// Page index
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Ordering field
        /// </summary>
        public string OrderBy { get; set; }


        /// <summary>
        /// Ordering expression
        /// </summary>
        protected Expression<Func<TModel, dynamic>> OrderByExpression { get; set; }

        /// <summary>
        /// Ordering direction
        /// </summary>
        public bool Ascending { get; set; }

        private IList<Expression<Func<TModel, bool>>> filtersDictionary = new List<Expression<Func<TModel, bool>>>();

        /// <summary>
        /// Generates the query for Paged List creation. Includes filters and ordering.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>IQueryable of <typeparamref name="TModel"/> including filters and ordering clauses</returns>
        public IQueryable<TModel> GetQuery(IQueryable<TModel> query)
        {
            if (filtersDictionary.Any())
                query = query.Where(GetFilters());

            query = GetOrdering(query);

            return query;
        }

        /// <summary>
        /// Includes filters compiling Lambda expression of included filters from the custom Paged List Model
        /// </summary>
        /// <returns>Filters lambda expression</returns>
        private Expression<Func<TModel, bool>> GetFilters()
        {
            var predicate = PredicateBuilder.True<TModel>();

            foreach (var filter in filtersDictionary)
                predicate = predicate.And(filter);

            return predicate;
        }

        /// <summary>
        /// Includes ordening
        /// </summary>
        /// <returns>IQueryable of <typeparamref name="TModel"/> with ordering clause</returns>
        private IQueryable<TModel> GetOrdering(IQueryable<TModel> source)
        {
            if (OrderByExpression != null)
            {
                return Ascending ? source.OrderBy(OrderByExpression) : source.OrderByDescending(OrderByExpression);
            }

            if (string.IsNullOrEmpty(OrderBy))
                return source;

            if (OrderBy.IndexOf(".") != -1)
            {
                var lambdaProperty = ToLambda<TModel>(OrderBy);

                return Ascending ? source.OrderBy(lambdaProperty) : source.OrderByDescending(lambdaProperty);
            }

            ParameterExpression parameter = Expression.Parameter(source.ElementType, "");

            MemberExpression property = Expression.Property(parameter, OrderBy);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methodName = Ascending ? "OrderBy" : "OrderByDescending";

            Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                  new Type[] { source.ElementType, property.Type },
                                  source.Expression, Expression.Quote(lambda));

            return source.Provider.CreateQuery<TModel>(methodCallExpression);
        }

        private Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var propertyNames = propertyName.Split('.');
            var parameter = Expression.Parameter(typeof(T));
            Expression body = parameter;
            foreach (var propName in propertyNames)
                body = Expression.Property(body, propName);
            return Expression.Lambda<Func<T, object>>(body, parameter);
        }

        /// <summary>
        /// Adds Lambda expression for query filtering
        /// </summary>
        /// <param name="expression">Filtering lambda expression</param>
        protected void AppendFilter(Expression<Func<TModel, bool>> expression)
        {
            filtersDictionary.Add(expression);
        }
    }
}