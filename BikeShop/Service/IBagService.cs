using BikeShop.Domain.Cart;

namespace BikeShop.Service
{
    public interface IBagService
    {
        Bag GetBag(int id);

        public IEnumerable<Bag> GetBags();

        void Insert(Bag bag);

        void Update(int id, Bag bag);

        void Delete(int id);
    }
}