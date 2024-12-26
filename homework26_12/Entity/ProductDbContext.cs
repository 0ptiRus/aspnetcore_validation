using Microsoft.EntityFrameworkCore;

namespace homework26_12.Entity
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }

        public ProductDbContext() : base() 
        {
        }

    }
}
