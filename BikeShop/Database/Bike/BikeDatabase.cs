using BikeShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Database
{
    public class BikeDatabase : IBikeDatabase
    {
        private readonly BikeDbContext _bikeDbContext;

        public BikeDatabase(BikeDbContext bikeDbContext)
        {
            _bikeDbContext = bikeDbContext;
        }

        public void Delete(int id)
        {
            var bike = GetBike(id);
            if (bike != null)
            {
                _bikeDbContext.Bikes.Remove(bike);
                _bikeDbContext.SaveChanges();
            }
        }

        public Bike GetBike(int id)
        {
            return _bikeDbContext.Bikes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Bike> GetBikes()
        {
            return _bikeDbContext.Bikes;
        }

        public Bike Insert(Bike bike)
        {
            _bikeDbContext.Bikes.Add(bike);
            _bikeDbContext.SaveChanges();
            return bike;
        }

        public void Update(int id, Bike updatedBike)
        {
            var bike = GetBike(id);

            if (bike != null)
            {
                bike.Manufacturer = updatedBike.Manufacturer;
                bike.Model = updatedBike.Model;
                bike.Type = updatedBike.Type;
                bike.Year = updatedBike.Year;
                bike.Price = updatedBike.Price;
                bike.PhotoUrl = updatedBike.PhotoUrl;
            }

            _bikeDbContext.SaveChanges();
        }
    }
}