using Microsoft.EntityFrameworkCore;

namespace OrderMS.Models
{
    public class OrderDbContext: DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options): base(options) { }
       

        public DbSet<Order> orders { get; set; }

       
    }
}
