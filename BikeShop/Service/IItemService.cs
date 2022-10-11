using BikeShop.Domain.Cart;

namespace BikeShop.Service
{
    public interface IItemService
    {
        Item GetItem(int id);

        public IEnumerable<Item> GetItems();

        void Insert(Item item);

        void Update(int id, Item item);

        void Delete(int id);
    }
}