using System.Collections.Generic;

namespace PagedList.Interfaces
{
    public interface IPagedListReturn<T> : IPagedProperties<T>
    {
        IEnumerable<int> Pages { get; }
        IEnumerable<IFieldProperties> Fields { get; }
    }
}