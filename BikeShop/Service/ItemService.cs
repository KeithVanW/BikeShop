using BikeShop.Database;
using BikeShop.Domain.Cart;

namespace BikeShop.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemDatabase _itemDatabase;

        public ItemService(IItemDatabase itemDatabase)
        {
            _itemDatabase = itemDatabase;
        }

        public void Delete(int id)
        {
            _itemDatabase.Delete(id);
        }

        public Item GetItem(int id)
        {
            return _itemDatabase.GetItem(id);
        }

        public IEnumerable<Item> GetItems()
        {
            return _itemDatabase.GetItems();
        }

        public void Insert(Item item)
        {
            _itemDatabase.Insert(item);
        }

        public void Update(int id, Item item)
        {
            _itemDatabase.Update(id, item);
        }
    }
}