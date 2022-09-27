using BikeShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Database
{
    public class BikeDatabase : IBikeDatabase
    {
        // private readonly List<Bike> bikes;
        private readonly BikeDbContext _BikeDbContext;
        private DbSet<Bike> bikes;
        public BikeDatabase(BikeDbContext bikeDbContext)
        {
            // bikes = new List<Bike>();
            _BikeDbContext = bikeDbContext;
            bikes = bikeDbContext.Bikes;
        }

        public void Delete(int Id)
        {
            var bike = bikes.FirstOrDefault(x => x.Id == Id);
            if (bike != null)
            {
                bikes.Remove(bike);
                _BikeDbContext.SaveChanges();
            }
        }

        public Bike GetBike(int id)
        {
            return bikes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Bike> GetBikes()
        {
            return bikes;
        }

        public Bike Insert(Bike bike)
        {
            bikes.Add(bike);
            _BikeDbContext.SaveChanges();
            return bike;
        }

        public void Update(int Id, Bike updatedBike)
        {
            var bike = bikes.FirstOrDefault(x => x.Id == Id);

            if (bike != null)
            {
                bike.Manufacturer = updatedBike.Manufacturer;
                bike.Model = updatedBike.Model;
                bike.Type = updatedBike.Type;
                bike.Year = updatedBike.Year;
                bike.Price = updatedBike.Price;
                bike.PhotoUrl = updatedBike.PhotoUrl;
            }

            _BikeDbContext.SaveChanges();
        }
    }
}
