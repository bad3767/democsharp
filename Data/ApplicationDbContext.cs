using Microsoft.EntityFrameworkCore;
using CrudWithMySQL.Models;

namespace CrudWithMySQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
