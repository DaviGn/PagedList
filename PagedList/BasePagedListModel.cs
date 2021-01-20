using PagedList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PagedList
{
    public class BasePagedListModel<TModel> : IPagedListModel<TModel>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 10;
        public string OrderBy { get; set; }
        public bool Ascending { get; set; }

        private IList<Expression<Func<TModel, bool>>> filtersDictionary = new List<Expression<Func<TModel, bool>>>();

        public IQueryable<TModel> GetQuery(IQueryable<TModel> query)
        {
            query = query.Where(GetFilters());
            query = GetOrdering(query);

            return query;
        }

        private Expression<Func<TModel, bool>> GetFilters()
        {
            var predicate = PredicateBuilder.True<TModel>();

            foreach (var filter in filtersDictionary)
                predicate = predicate.And(filter);

            return predicate;
        }

        private IQueryable<TModel> GetOrdering(IQueryable<TModel> source)
        {
            if (string.IsNullOrEmpty(OrderBy))
                return source;

            ParameterExpression parameter = Expression.Parameter(source.ElementType, "");

            MemberExpression property = Expression.Property(parameter, OrderBy);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methodName = Ascending ? "OrderBy" : "OrderByDescending";

            Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                  new Type[] { source.ElementType, property.Type },
                                  source.Expression, Expression.Quote(lambda));

            return source.Provider.CreateQuery<TModel>(methodCallExpression);
        }

        protected void AppendFilter(Expression<Func<TModel, bool>> expression)
        {
            filtersDictionary.Add(expression);
        }
    }
}