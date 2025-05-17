using IEEEProject.Entity;
using Microsoft.EntityFrameworkCore;
namespace IEEEProject.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
      public  DbSet<Product> Product { get; set; }
    }
}
