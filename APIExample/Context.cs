using APIExample.Models;
using Microsoft.EntityFrameworkCore;

namespace APIExample
{
    public class Context : DbContext
    {
        public DbSet<Business> Business { get; set; }

        public DbSet<User> Users { get; set; }

        public Context() : base()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
