using BikeShop.Domain.Cart;

namespace BikeShop.Database
{
    public interface IItemDatabase
    {
        Item Insert(Item item);

        IEnumerable<Item> GetItems();

        Item GetItem(int id);

        void Update(int Id, Item item);

        void Delete(int Id);
    }
}
