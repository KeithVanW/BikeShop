using BikeShop.Database;
using BikeShop.Domain.Cart;

namespace BikeShop.Service
{
    public class BagService : IBagService
    {
        private readonly IBagDatabase _bagDatabase;

        public BagService(IBagDatabase bagDatabase)
        {
            _bagDatabase = bagDatabase;
        }

        public void Delete(int id)
        {
            _bagDatabase.Delete(id);
        }

        public Bag GetBag(int id)
        {
            return _bagDatabase.GetBag(id);
        }

        public IEnumerable<Bag> GetBags()
        {
            return _bagDatabase.GetBags();
        }

        public void Insert(Bag bag)
        {
            _bagDatabase.Insert(bag);
        }

        public void Update(int id, Bag bag)
        {
            _bagDatabase.Update(id, bag);
        }
    }
}