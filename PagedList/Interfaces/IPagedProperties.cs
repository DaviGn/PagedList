using System.Collections.Generic;

namespace PagedList.Interfaces
{
    /// <summary>
    /// Represents Paged List Properties of <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedProperties<T>
    {
        /// <summary>
        /// Paged list items
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
        /// Total count of items
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Total pages
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Ordering field
        /// </summary>
        string OrderBy { get; }

        /// <summary>
        /// Ordering direction
        /// </summary>
        bool Ascending { get; }
    }
}