using System.Collections.Generic;

namespace PagedList.Interfaces
{
    /// <summary>
    /// Represents a complete information of a Paged List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedListReturn<T> : IPagedProperties<T>
    {
        /// <summary>
        /// List of page numbers. I.E: [1, 2, -1, 98, 99].
        /// Page number -1 represents a white space or ...
        /// </summary>
        IEnumerable<int> Pages { get; }

        /// <summary>
        /// List of properties information of <typeparamref name="T"/>
        /// </summary>
        IEnumerable<IFieldProperties> Fields { get; }
    }
}