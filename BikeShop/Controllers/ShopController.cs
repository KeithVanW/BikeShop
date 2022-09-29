using BikeShop.Database;
using BikeShop.Domain;
using BikeShop.Models;
using BikeShop.Models.Shop;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IBikeDatabase _bikeDatabase;

        public ShopController(IBikeDatabase bikeDatabase)
        {
            _bikeDatabase = bikeDatabase;
        }

        public IActionResult Index()
        {
            // TODO Use Automapper

            IEnumerable<Bike> bikes = _bikeDatabase.GetBikes();
            ShopListViewModel vm = new ShopListViewModel
            {
                Items = bikes.Select(
                    x => new ShopListItem
                    {
                        Id = x.Id,
                        Manufacturer = x.Manufacturer,
                        Model = x.Model,
                        PhotoUrl = x.PhotoUrl
                    }
                    ),
            };

            return View(vm);
        }

        public IActionResult Detail([FromRoute] int id)
        {
            var bike = _bikeDatabase.GetBike(id);

            // Todo look into automapper

            var vm = new ShopDetailViewModel
            {
                Manufacturer = bike.Manufacturer,
                Model = bike.Model,
                Type = bike.Type,
                Year = bike.Year,
                Price = bike.Price,
                PhotoUrl = bike.PhotoUrl
            };

            return View(vm);
        }
    }
}