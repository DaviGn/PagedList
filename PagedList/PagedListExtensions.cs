using PagedList.Interfaces;
using System.Linq;

namespace PagedList
{
    public static class PagedListExtensions
    {
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> DBSetQuery, IPagedListModel<T> pagedModel) where T : class
        => new PagedList<T>(DBSetQuery, pagedModel);
    }
}