using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Data
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> opt) :base(opt)
        {

        }
    }
}
