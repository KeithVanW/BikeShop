using AutoMapper;
using BikeShop.Database;
using BikeShop.Domain;
using BikeShop.Models.Shop;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IBikeDatabase _bikeDatabase;
        private readonly IMapper _mapper;

        public ShopController(IBikeDatabase bikeDatabase, IMapper mapper)
        {
            _bikeDatabase = bikeDatabase;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IEnumerable<Bike> bikes = _bikeDatabase.GetBikes();
            var vm = new ShopListViewModel { Items = bikes.Select(x => _mapper.Map<ShopListItem>(x)) };

            return View(vm);
        }

        public IActionResult Detail([FromRoute] int id)
        {
            Bike bike = _bikeDatabase.GetBike(id);
            ShopDetailViewModel vm = _mapper.Map<ShopDetailViewModel>(bike);

            return View(vm);
        }
    }
}