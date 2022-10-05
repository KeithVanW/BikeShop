using AutoMapper;
using BikeShop.Database;
using BikeShop.Domain;
using BikeShop.Domain.Cart;
using BikeShop.Models;
using BikeShop.Models.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class ItemController : Controller
    {
        private IItemDatabase _itemDatabase;
        private IBikeDatabase _bikeDatabase;
        private IMapper _mapper;
        public ItemController(IItemDatabase itemDatabase, IBikeDatabase bikeDatabase, IMapper mapper)
        {
            _itemDatabase = itemDatabase;
            _bikeDatabase = bikeDatabase;
            _mapper = mapper;

            CopyBikesToItems();
        }

        public IActionResult Index()
        {
            IEnumerable<ItemListViewModel> vm = _bikeDatabase.GetBikes().
                Select(x => _mapper.Map<ItemListViewModel>(x));

            return View(vm);
        }

        public void CopyBikesToItems()
        {
            IEnumerable<Bike> bikesToCopy = _bikeDatabase.GetBikes();

            foreach (Bike bike in bikesToCopy)
            {
                Item item = new Item();
                item.ItemId = bike.Id;
                item.Bike = bike;

                _itemDatabase.Insert(item);
            }
        }
    }
}
