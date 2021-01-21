using PagedList.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PagedList
{
    public static class PagedListExtensions
    {
        /// <summary>
        /// Creates a PagedList by an IQueryable of <typeparamref name="T"/>
        /// </summary>
        /// <param name="DBSetQuery">DbSet of <typeparamref name="T"/></param>
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> DBSetQuery) where T : class
        {
            var pagedList = new PagedList<T>(DBSetQuery);
            pagedList.Fill();

            return pagedList;
        }

        /// <summary>
        /// Creates a PagedList by an IQueryable of <typeparamref name="T"/> async
        /// </summary>
        /// <param name="DBSetQuery">DbSet of <typeparamref name="T"/></param>
        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> DBSetQuery) where T : class
        {
            var pagedList = new PagedList<T>(DBSetQuery);
            await pagedList.FillAsync();

            return pagedList;
        }

        /// <summary>
        /// Creates a PagedList by an IQueryable of <typeparamref name="T"/> and an instance of an IPagedListModel of <typeparamref name="T"/>
        /// </summary>
        /// <param name="DBSetQuery">DbSet of <typeparamref name="T"/></param>
        /// <param name="pagedModel">IPagedListModel of <typeparamref name="T"/></param>
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> DBSetQuery, IPagedListModel<T> pagedModel) where T : class
        {
            var pagedList = new PagedList<T>(DBSetQuery, pagedModel);
            pagedList.Fill();

            return pagedList;
        }

        /// <summary>
        /// Creates a PagedList by an IQueryable of <typeparamref name="T"/> and an instance of an IPagedListModel of <typeparamref name="T"/> async
        /// </summary>
        /// <param name="DBSetQuery">DbSet of <typeparamref name="T"/></param>
        /// <param name="pagedModel">IPagedListModel of <typeparamref name="T"/></param>
        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> DBSetQuery, IPagedListModel<T> pagedModel) where T : class
        {
            var pagedList = new PagedList<T>(DBSetQuery, pagedModel);
            await pagedList.FillAsync();

            return pagedList;
        }
    }
}