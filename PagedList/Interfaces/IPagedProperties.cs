using System.Collections.Generic;

namespace PagedList.Interfaces
{
    public interface IPagedProperties<T>
    {
        /// <summary>
        /// Paged list
        /// </summary>
        IList<T> Items { get; }

        /// <summary>
        /// Page index
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// Page size
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Total count
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Total pages
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Ordering
        /// </summary>
        string OrderBy { get; }

        /// <summary>
        /// Ordering direction
        /// </summary>
        bool Ascending { get; }
    }
}