using BikeShop.Domain;

namespace BikeShop.Service
{
    public interface IBikeService
    {
        Bike GetBike(int id);
        public IEnumerable<Bike> GetBikes();
        void Insert(Bike bike);
        void Update(int id, Bike bike);
        void Delete(int id);
    }
}
