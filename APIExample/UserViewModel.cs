using APIExample.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;
using PagedList.Interfaces;
using System.Linq;

namespace APIExample
{
    public class UserViewModel : BasePagedListModel<User>, IIncludable<User>
    {
        private string email;
        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;

                email = value;
                AppendFilter(x => x.Email == Email);
            }
        }

        public IQueryable<User> GetIncludes(IQueryable<User> source)
        => source.Include(x => x.Business);
    }
}
