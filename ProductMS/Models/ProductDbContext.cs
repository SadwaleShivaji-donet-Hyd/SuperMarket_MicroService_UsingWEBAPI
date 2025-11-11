using Microsoft.EntityFrameworkCore;

namespace ProductMS.Models
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
