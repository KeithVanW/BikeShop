using BikeShop.Domain;
using BikeShop.Domain.Cart;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Database
{
    public class BikeDbContext : DbContext
    {
        public BikeDbContext(DbContextOptions<BikeDbContext> options) : base(options)
        {
        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Bag> Bag { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}