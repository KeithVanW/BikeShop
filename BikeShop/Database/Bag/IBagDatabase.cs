using BikeShop.Domain;
using BikeShop.Domain.Cart;

namespace BikeShop.Database
{
    public interface IBagDatabase
    {
        Bag Insert(Bag bag);

        IEnumerable<Bag> GetBags();

        Bag GetBag(int id);

        void Update(int Id, Bag bag);

        void Delete(int Id);
    }
}
