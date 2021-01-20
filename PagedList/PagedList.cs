using PagedList.Interfaces;
using System.Linq;

namespace PagedList
{
    public class PagedList<TEntity> : BasePagedList<TEntity>, IPagedList<TEntity> where TEntity : class
    {
        public PagedList(IQueryable<TEntity> DBSetQuery) : this(DBSetQuery, new BasePagedListModel<TEntity>())
        {
        }

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
        /// Has previous page
        /// </summary>
        public bool HasPreviousPage => PageIndex > 0;

        /// <summary>
        /// Has next page
        /// </summary>
        public bool HasNextPage => PageIndex + 1 < TotalPages;

        public IPagedListReturn<TEntity> GetPagedReturn() => new PagedListReturn<TEntity>(this);
    }
}