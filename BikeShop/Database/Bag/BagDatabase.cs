using BikeShop.Domain.Cart;

namespace BikeShop.Database
{
    public class BagDatabase : IBagDatabase
    {
        private readonly BikeDbContext _BikeDbContext;

        public BagDatabase(BikeDbContext bikeDbContext)
        {
            _BikeDbContext = bikeDbContext;
        }

        public Bag Insert(Bag bag)
        {
            _BikeDbContext.Bag.Add(bag);
            _BikeDbContext.SaveChanges();
            return bag;
        }

        public Bag GetBag(int id)
        {
            return _BikeDbContext.Bag.FirstOrDefault(x => x.BagId == id);
        }

        public IEnumerable<Bag> GetBags()
        {
            return _BikeDbContext.Bag;
        }

        public void Update(int Id, Bag updatedBag)
        {
            var bag = GetBag(Id);

            if (bag != null)
            {
                bag.Date = updatedBag.Date;
                bag.Customer = updatedBag.Customer;
                bag.Items = updatedBag.Items;
            }

            _BikeDbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var bag = GetBag(Id);
            if (bag != null)
            {
                _BikeDbContext.Bag.Remove(bag);
                _BikeDbContext.SaveChanges();
            }
        }
    }
}