using PagedList.Interfaces;
using System.Collections.Generic;

namespace PagedList
{
    public abstract class PagedProperties<T> : IPagedProperties<T>
    {
        public IList<T> Items { get; protected set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public string OrderBy { get; set; }

        public bool Ascending { get; set; }
    }
}
