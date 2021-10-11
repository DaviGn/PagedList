using Microsoft.EntityFrameworkCore;
using PagedList.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PagedList
{
    /// <summary>
    /// Paged List of <typeparamref name="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class PagedList<TEntity> : BasePagedList<TEntity>, IPagedList<TEntity> where TEntity : class
    {
        private readonly IQueryable<TEntity> _dBSetQuery;
        private readonly IPagedListModel<TEntity> _pagedModel;

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
            _dBSetQuery = DBSetQuery;
            _pagedModel = pagedModel;
        }

        /// <summary>
        /// Performs query executing
        /// </summary>
        public void Fill()
        {
            var query = Process();
            Execute(query);
        }

        /// <summary>
        /// Performs query executing async
        /// </summary>
        /// <returns></returns>
        public async Task FillAsync(CancellationToken cancellationToken = default)
        {
            var query = Process();
            await ExecuteAsync(query, cancellationToken);
        }

        private IQueryable<TEntity> Process()
        {
            var query = _pagedModel.GetQuery(_dBSetQuery);

            if (_pagedModel is IIncludable<TEntity>)
                query = (_pagedModel as IIncludable<TEntity>).GetIncludes(query);

            if (_pagedModel.PageIndex > 0)
                _pagedModel.PageIndex--;

            PageSize = _pagedModel.PageSize;
            PageIndex = _pagedModel.PageIndex;

            OrderBy = _pagedModel.OrderBy;
            Ascending = _pagedModel.Ascending;

            return query;
        }

        private void Execute(IQueryable<TEntity> query)
        {
            var total = query.Count();
            TotalCount = total;
            TotalPages = total / _pagedModel.PageSize;

            if (total % _pagedModel.PageSize > 0)
                TotalPages++;

            AddRange(query.Skip(_pagedModel.PageIndex * _pagedModel.PageSize).Take(_pagedModel.PageSize).ToList());
        }


        private async Task ExecuteAsync(IQueryable<TEntity> query, CancellationToken token = default)
        {
            var total = await query.CountAsync(token);
            TotalCount = total;
            TotalPages = total / _pagedModel.PageSize;

            if (total % _pagedModel.PageSize > 0)
                TotalPages++;

            AddRange(await query.Skip(_pagedModel.PageIndex * _pagedModel.PageSize).Take(_pagedModel.PageSize).ToListAsync(token));
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