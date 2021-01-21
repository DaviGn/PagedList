using PagedList.Interfaces;
using System.Collections.Generic;

namespace PagedList
{
    /// <summary>
    /// Represents a complete information of a Paged List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedListReturn<T> : PagedProperties<T>, IPagedListReturn<T> where T : class
    {
        /// <summary>
        /// Represents a complete information of a Paged List
        /// </summary>
        /// <param name="pagedList"></param>
        public PagedListReturn(IPagedList<T> pagedList)
        {
            Items = pagedList.Items;

            TotalPages = pagedList.TotalPages;
            PageIndex = pagedList.PageIndex + 1;
            TotalCount = pagedList.TotalCount;
            OrderBy = pagedList.OrderBy;
            Ascending = pagedList.Ascending;
            HasNextPage = pagedList.HasNextPage;
            HasPreviousPage = pagedList.HasPreviousPage;
            PageSize = pagedList.PageSize;

            Pages = pagedList.CreatePagination();
            Fields = FieldsProperties.GetFields<T>();
        }

        /// <summary>
        /// List of page numbers. I.E: [1, 2, -1, 98, 99].
        /// Page number -1 represents a white space or ...
        /// </summary>
        public IEnumerable<int> Pages { get; set; }

        /// <summary>
        /// List of properties information of <typeparamref name="T"/>
        /// </summary>
        public IEnumerable<IFieldProperties> Fields { get; set; }
    }
}
