using System.Linq;

namespace PagedList.Interfaces
{
    public interface IIncludable<T>
    {
        IQueryable<T> GetIncludes(IQueryable<T> source);
    }
}