using BikeShop.Controllers;
using BikeShop.Domain;
using BikeShop.Domain.Cart;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Database
{
    public class ItemDatabase : IItemDatabase
    {
        private readonly BikeDbContext _BikeDbContext;
        private DbSet<Item> items;
        private IItemDatabase _itemDatabase;

        public ItemDatabase(BikeDbContext bikeDbContext, IItemDatabase itemDatabase)
        {
            _BikeDbContext = bikeDbContext;
            items = bikeDbContext.Items;
            _itemDatabase = itemDatabase;
        }
        public void Delete(int Id)
        {
            var item = items.FirstOrDefault(x => x.ItemId == Id);
            if (item != null)
            {
                items.Remove(item);
                _BikeDbContext.SaveChanges();
            }
        }

        public Item GetItem(int id)
        {
            return items.FirstOrDefault(x => x.ItemId == id);
        }

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item Insert(Item item)
        {
            items.Add(item);
            _BikeDbContext.SaveChanges();
            return item;
        }

        public void Update(int Id, Item updatedItem)
        {
            var item = items.FirstOrDefault(x => x.ItemId == Id);

            if (item != null)
            {
                item.Quantity = updatedItem.Quantity;
                item.Bike = updatedItem.Bike;
                item.Bag = updatedItem.Bag;
            }
        }
    }
}
