using PagedList.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PagedList
{
    /// <summary>
    /// Represents Paged List Properties of <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BasePagedList<TEntity> : List<TEntity>, IPagedProperties<TEntity> where TEntity : class
    {
        /// <summary>
        /// Paged list items
        /// </summary>
        public IList<TEntity> Items { get => this.ToList(); }

        /// <summary>
        /// Page index
        /// </summary>
        public int PageIndex { get; protected set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; protected set; }

        /// <summary>
        /// Total count of items
        /// </summary>
        public int TotalCount { get; protected set; }

        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; protected set; }

        /// <summary>
        /// Ordering field
        /// </summary>
        public string OrderBy { get; protected set; }

        /// <summary>
        /// Ordering direction
        /// </summary>
        public bool Ascending { get; protected set; }
    }
}
