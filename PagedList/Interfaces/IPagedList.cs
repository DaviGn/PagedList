using System.Collections.Generic;

namespace PagedList.Interfaces
{
    /// <summary>
    /// Represents a Paged List of <typeparamref name="T"/>
    /// </summary>
    public interface IPagedList<T> : IPagedProperties<T>, IList<T>
    {
        /// <summary>
        /// Indicates if there's previous page
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Indicates if there's next page
        /// </summary>
        bool HasNextPage { get; }

        /// <summary>
        /// Creates an object of type IPagedListReturn of <typeparamref name="T"/>
        /// </summary>
        /// <returns>IPagedListReturn of <typeparamref name="T"/></returns>
        IPagedListReturn<T> ToPagedReturn();
    }
}