using BikeShop.Database;
using BikeShop.Domain;

namespace BikeShop.Service
{
    public class BikeService : IBikeService
    {
        private readonly IBikeDatabase _bikeDatabase;
        public BikeService(IBikeDatabase bikeDatabase)
        {
            _bikeDatabase = bikeDatabase;
        }

        public void Delete(int id)
        {
            _bikeDatabase.Delete(id);
        }

        public Bike GetBike(int id)
        {
            return _bikeDatabase.GetBike(id);
        }

        public IEnumerable<Bike> GetBikes()
        {
            return _bikeDatabase.GetBikes();
        }

        public void Insert(Bike bike)
        {
            _bikeDatabase.Insert(bike);
        }

        public void Update(int id, Bike bike)
        {
            _bikeDatabase.Update(id, bike);
        }
    }
}
