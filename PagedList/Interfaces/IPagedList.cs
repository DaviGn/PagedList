using System.Collections.Generic;

namespace PagedList.Interfaces
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    public interface IPagedList<T> : IPagedProperties<T>, IList<T>
    {
        /// <summary>
        /// Has previous page
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Has next age
        /// </summary>
        bool HasNextPage { get; }

        IPagedListReturn<T> GetPagedReturn();
    }
}