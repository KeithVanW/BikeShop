using BikeShop.Domain;

namespace BikeShop.Database
{
    public interface IBikeDatabase
    {
        Bike Insert(Bike bike);
        IEnumerable<Bike> GetBikes();
        Bike GetBike(int id);
        void Update(int Id, Bike bike);
        void Delete(int Id);
    }
}
