using BikeShop.Domain.Cart;

namespace BikeShop.Database
{
    public class ItemDatabase : IItemDatabase
    {
        private readonly BikeDbContext _BikeDbContext;

        public ItemDatabase(BikeDbContext bikeDbContext)
        {
            _BikeDbContext = bikeDbContext;
        }

        public void Delete(int id)
        {
            var item = GetItem(id);
            if (item != null)
            {
                _BikeDbContext.Items.Remove(item);
                _BikeDbContext.SaveChanges();
            }
        }

        public Item GetItem(int id)
        {
            return _BikeDbContext.Items.FirstOrDefault(x => x.ItemId == id);
        }

        public IEnumerable<Item> GetItems()
        {
            return _BikeDbContext.Items;
        }

        public Item Insert(Item item)
        {
            _BikeDbContext.Items.Add(item);
            _BikeDbContext.SaveChanges();
            return item;
        }

        public void Update(int id, Item updatedItem)
        {
            var item = GetItem(id);

            if (item != null)
            {
                item.Quantity = updatedItem.Quantity;
                item.Bike = updatedItem.Bike;
                item.Bag = updatedItem.Bag;
            }
        }
    }
}