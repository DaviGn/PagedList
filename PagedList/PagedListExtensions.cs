using PagedList.Interfaces;
using System.Linq;

namespace PagedList
{
    public static class PagedListExtensions
    {
        /// <summary>
        /// Creates a PagedList by an IQueryable of <typeparamref name="T"/>
        /// </summary>
        /// <param name="DBSetQuery">DbSet of <typeparamref name="T"/></param>
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> DBSetQuery) where T : class
        => new PagedList<T>(DBSetQuery);

        /// <summary>
        /// Creates a PagedList by an IQueryable of <typeparamref name="T"/> and an instance of an IPagedListModel of <typeparamref name="T"/>
        /// </summary>
        /// <param name="DBSetQuery">DbSet of <typeparamref name="T"/></param>
        /// <param name="pagedModel">IPagedListModel of <typeparamref name="T"/></param>
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> DBSetQuery, IPagedListModel<T> pagedModel) where T : class
        => new PagedList<T>(DBSetQuery, pagedModel);
    }
}