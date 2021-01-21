using PagedList.Interfaces;
using System.Collections.Generic;

namespace PagedList
{
    /// <summary>
    /// Represents Paged List Properties of <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PagedProperties<T> : IPagedProperties<T>
    {
        /// <summary>
        /// Paged list items
        /// </summary>
        public IList<T> Items { get; protected set; }

        /// <summary>
        /// Page index
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }
        
        /// <summary>
        /// Total count of items
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Indicates if there's previous page
        /// </summary>
        public bool HasPreviousPage { get; set; }

        /// <summary>
        /// Indicates if there's next page
        /// </summary>
        public bool HasNextPage { get; set; }
        
        /// <summary>
        /// Ordering field
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Ordering direction
        /// </summary>
        public bool Ascending { get; set; }
    }
}
