using PagedList.Interfaces;
using System.Collections.Generic;

namespace PagedList
{
    public class PagedListReturn<T> : PagedProperties<T>, IPagedListReturn<T> where T : class
    {
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

        public IEnumerable<int> Pages { get; set; }
        public IEnumerable<IFieldProperties> Fields { get; set; }
    }
}
