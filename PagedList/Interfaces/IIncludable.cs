using System.Linq;

namespace PagedList.Interfaces
{
    /// <summary>
    /// Provides method for include related entities to <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIncludable<T>
    {
        /// <summary>
        /// Includes related properties to <typeparamref name="T"/>.
        /// Implement this method as you want in your custom PagedListModel
        /// </summary>
        /// <param name="source"></param>
        /// <returns>IQueryable of <typeparamref name="T"/> with included properties</returns>
        IQueryable<T> GetIncludes(IQueryable<T> source);
    }
}