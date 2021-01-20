using PagedList.Interfaces;
using System;
using System.Runtime.CompilerServices;

namespace PagedList.DataAnnotations
{
    public class GridItemAttribute : Attribute, IFieldProperties
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public string PropertyName { get; private set; }

        public GridItemAttribute(int order, [CallerMemberName] string propertyName = null) : base()
        {
            Order = order;
            PropertyName = ToCamelCase(propertyName);

            if (string.IsNullOrEmpty(Name))
                Name = propertyName;
        }

        private string ToCamelCase(string text)
        {
            var chars = text.ToCharArray();

            bool isSingleWord = false;
            int countToSingleWord = 3;
            int countUppers = 0;
            int lastUpperIndex = -1;
            int repetedUppers = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsUpper(chars[i]))
                {
                    countUppers++;

                    if (lastUpperIndex != -1)
                        repetedUppers++;

                    if (repetedUppers >= countToSingleWord)
                    {
                        isSingleWord = true;
                        break;
                    }

                    lastUpperIndex = i;
                }
                else
                    repetedUppers = -1;
            }

            if (isSingleWord)
                return text.ToLower();

            return text.Substring(0, 1).ToLower() + text.Substring(1);
        }
    }
}
