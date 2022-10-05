using BikeShop.Domain;
using BikeShop.Domain.Cart;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Database
{
    public class BagDatabase : IBagDatabase
    {
        private readonly BikeDbContext _BikeDbContext;
        private DbSet<Bag> bags;
        public BagDatabase(BikeDbContext bikeDbContext)
        {
            _BikeDbContext = bikeDbContext;
            bags = bikeDbContext.Bag;
        }

        public void Delete(int Id)
        {
            var bag = bags.FirstOrDefault(x => x.BagId == Id);
            if (bag != null)
            {
                bags.Remove(bag);
                _BikeDbContext.SaveChanges();
            }
        }

        public Bag GetBag(int id)
        {
            return bags.FirstOrDefault(x => x.BagId == id);
        }

        public IEnumerable<Bag> GetBags()
        {
            return bags;
        }

        public Bag Insert(Bag bag)
        {
            bags.Add(bag);
            _BikeDbContext.SaveChanges();
            return bag;
        }

        public void Update(int Id, Bag updatedBag)
        {
            var bag = bags.FirstOrDefault(x => x.BagId == Id);

            if (bag != null)
            {
                bag.Date = updatedBag.Date;
                bag.Customer = updatedBag.Customer;
                bag.Items = updatedBag.Items;
            }

            _BikeDbContext.SaveChanges();
        }
    }
}
