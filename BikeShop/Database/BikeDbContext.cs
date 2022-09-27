using BikeShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Database
{
    public class BikeDbContext : DbContext
    {
        public BikeDbContext(DbContextOptions<BikeDbContext> options) : base(options)
        {

        }
        public DbSet<Bike> Bikes { get; set; }
    }
}
