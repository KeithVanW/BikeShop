using BikeShop.Domain;

namespace BikeShop.Database
{
    public class BikeDatabase : IBikeDatabase
    {
        private int counter;
        private readonly List<Bike> bikes;
        public BikeDatabase()
        {
            bikes = new List<Bike>();

            Insert(new Bike
            {
                Manufacturer = "Juliana",
                Model = "Wilder X01 AXS TR Carbon CC",
                Year = 2022,
                Type = "Mountainbike",
                Price = 9450
            });

            Insert(new Bike
            {
                Manufacturer = "Rocky Mountain",
                Model = "Element Carbon 90",
                Year = 2022,
                Type = "Mountainbike",
                Price = 9590
            });

            Insert(new Bike
            {
                Manufacturer = "Yeti",
                Model = "160E T1",
                Year = 2022,
                Type = "Mountainbike",
                Price = 13000
            });
        }
        public void Delete(int Id)
        {
            var bike = bikes.FirstOrDefault(x => x.Id == Id);
            if (bike != null)
            {
                bikes.Remove(bike);
            }
        }

        public Bike GetBike(int id)
        {
            return bikes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Bike> GetBikes()
        {
            return bikes;
        }

        public Bike Insert(Bike bike)
        {
            bike.Id = counter++;
            bikes.Add(bike);
            return bike;
        }

        public void Update(int Id, Bike updatedBike)
        {
            var bike = bikes.FirstOrDefault(x => x.Id == Id);
            if (bike != null)
            {
                bike.Manufacturer = updatedBike.Manufacturer;
                bike.Model = updatedBike.Model;
                bike.Type = updatedBike.Type;
                bike.Year = updatedBike.Year;
                bike.Price = updatedBike.Price;
                bike.PhotoUrl = updatedBike.PhotoUrl;
            }
        }
    }
}
