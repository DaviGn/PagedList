using PagedList.Interfaces;
using System;
using System.Collections.Generic;

namespace PagedList
{
    internal static class Pagination
    {
        /// <summary>
        /// Creates a list of page numbers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pagedList">Paged List object</param>
        /// <param name="pagesToShow">Number of pages in the list</param>
        /// <returns></returns>
        public static IList<int> CreatePagination<T>(this IPagedList<T> pagedList, int pagesToShow = 8) where T : class
        {
            bool hasFirstLink = false;
            bool hasLastLink = false;
            int firstPage = 0;
            int lastPage = 0;
            int middle = (int)Math.Floor(pagesToShow / 2.0);

            if (pagedList.TotalPages <= pagesToShow)
            {
                firstPage = 1;
                lastPage = pagedList.TotalPages;
            }
            else if (pagedList.PageIndex <= middle)
            {
                firstPage = 1;
                lastPage = pagesToShow - 1;
                hasLastLink = true;
            }
            else if (pagedList.PageIndex >= (pagedList.TotalPages - middle))
            {
                lastPage = pagedList.TotalPages;
                firstPage = pagedList.TotalPages - pagesToShow + 1;
                hasFirstLink = true;
            }
            else
            {
                firstPage = pagedList.PageIndex + 1 - middle;
                lastPage = firstPage + pagesToShow - 2;
                hasFirstLink = true;
                hasLastLink = true;
            }

            var result = new List<int>();

            if (hasFirstLink)
            {
                result.Add(1);

                if (firstPage > 2)
                    result.Add(-1);
            }

            for (var i = firstPage; i <= lastPage; i++)
            {
                result.Add(i);
            }

            if (hasLastLink)
            {
                if (lastPage < pagedList.TotalPages - 1)
                    result.Add(-1);

                result.Add(pagedList.TotalPages);
            }

            return result;
        }
    }
}
