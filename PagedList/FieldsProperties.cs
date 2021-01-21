using PagedList.DataAnnotations;
using PagedList.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PagedList
{
    /// <summary>
    /// Provides fields information
    /// </summary>
    internal static class FieldsProperties
    {
        /// <summary>
        /// Generates an IEnumerable object of IFieldProperties of <typeparamref name="T"/> properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<IFieldProperties> GetFields<T>() where T : class
        {
            var properties = typeof(T).GetProperties();

            List<IFieldProperties> fields = new List<IFieldProperties>();

            foreach (var propertie in properties)
            {
                var attribute = propertie.GetCustomAttribute<GridItemAttribute>();

                if (attribute != null)
                    fields.Add(attribute as IFieldProperties);
            }

            fields = fields.OrderBy(x => x.Order).ToList();

            return fields;
        }
    }
}