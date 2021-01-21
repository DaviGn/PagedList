using System.Linq;

namespace PagedList.Interfaces
{
    /// <summary>
    /// Represents an object of type IPagedListModel.
    /// Implement this interface to extend Paged List Model to encapsulate automated query generating
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedListModel<T>
    {
        /// <summary>
        /// Page index
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Ordering field
        /// </summary>
        string OrderBy { get; }

        /// <summary>
        /// Ordering direction
        /// </summary>
        bool Ascending { get; }

        /// <summary>
        /// Generates the query for Paged List creation. Includes filters and ordering.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>IQueryable of <typeparamref name="T"/> including filters and ordering clauses</returns>
        IQueryable<T> GetQuery(IQueryable<T> query);
    }
}