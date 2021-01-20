using System.Linq;

namespace PagedList.Interfaces
{
    public interface IPagedListModel<T>
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        string OrderBy { get; set; }
        bool Ascending { get; set; }

        IQueryable<T> GetQuery(IQueryable<T> query);
        //IQueryable<T> GetOrdering(IQueryable<T> source);
        //Expression<Func<T, bool>> GetFilters();
    }
}