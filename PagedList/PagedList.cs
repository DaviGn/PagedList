using PagedList.Interfaces;
using System.Linq;

namespace PagedList
{
    /// <summary>
    /// Paged List of <typeparamref name="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class PagedList<TEntity> : BasePagedList<TEntity>, IPagedList<TEntity> where TEntity : class
    {
        /// <summary>
        /// Creates a PagedList by an IQueryable of <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="DBSetQuery">DbSet of <typeparamref name="TEntity"/></param>
        public PagedList(IQueryable<TEntity> DBSetQuery) : this(DBSetQuery, new BasePagedListModel<TEntity>())
        {
        }

        /// <summary>
        /// Creates a PagedList by an IQueryable of <typeparamref name="TEntity"/> and an instance of an IPagedListModel of <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="DBSetQuery">DbSet of <typeparamref name="TEntity"/></param>
        /// <param name="pagedModel">IPagedListModel of <typeparamref name="TEntity"/></param>
        public PagedList(IQueryable<TEntity> DBSetQuery, IPagedListModel<TEntity> pagedModel)
        {
            var query = pagedModel.GetQuery(DBSetQuery);

            if (pagedModel is IIncludable<TEntity>)
                query = (pagedModel as IIncludable<TEntity>).GetIncludes(query);

            var total = query.Count();
            TotalCount = total;
            TotalPages = total / pagedModel.PageSize;

            if (total % pagedModel.PageSize > 0)
                TotalPages++;

            if (pagedModel.PageIndex > 0)
                pagedModel.PageIndex--;

            PageSize = pagedModel.PageSize;
            PageIndex = pagedModel.PageIndex;

            OrderBy = pagedModel.OrderBy;
            Ascending = !pagedModel.Ascending;

            AddRange(query.Skip(pagedModel.PageIndex * pagedModel.PageSize).Take(pagedModel.PageSize).ToList());
        }

        /// <summary>
        /// Indicates if there's previous page
        /// </summary>
        public bool HasPreviousPage => PageIndex > 0;

        /// <summary>
        /// Indicates if there's next page
        /// </summary>
        public bool HasNextPage => PageIndex + 1 < TotalPages;

        /// <summary>
        /// Creates an object of type IPagedListReturn of <typeparamref name="T"/>
        /// </summary>
        /// <returns>IPagedListReturn of <typeparamref name="T"/></returns>
        public IPagedListReturn<TEntity> ToPagedReturn() => new PagedListReturn<TEntity>(this);
    }
}