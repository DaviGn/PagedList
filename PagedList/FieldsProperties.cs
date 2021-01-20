using PagedList.DataAnnotations;
using PagedList.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PagedList
{
    internal static class FieldsProperties
    {
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