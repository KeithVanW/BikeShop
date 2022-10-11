using AutoMapper;
using BikeShop.Database;
using BikeShop.Domain;
using BikeShop.Domain.Cart;
using BikeShop.Models;
using BikeShop.Models.Bag;
using BikeShop.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BikeShop.Controllers
{
    public class BagController : Controller
    {
        private readonly BikeDbContext _context;
        private readonly IBikeService _bikeService;
        private readonly ICustomerService _customerService;
        private readonly IItemService _itemService;
        private readonly IBagService _bagService;
        private readonly IMapper _mapper;

        public BagController(BikeDbContext context, IBikeService bikeService,
            ICustomerService customerService, IItemService itemService, 
            IBagService bagService, IMapper mapper)
        {
            _context = context;
            _bikeService = bikeService;
            _customerService = customerService;
            _itemService = itemService;
            _bagService = bagService; 
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IEnumerable<BagListViewModel> vm = _bagService.GetBags()
                .Select(x => _mapper.Map<BagListViewModel>(x));

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail([FromRoute] int id)
        {
            Bag bag = _bagService.GetBag(id);
            BagDetailViewModel vm = _mapper.Map<BagDetailViewModel>(bag);
            
            return View(vm);
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            Bag bag = _bagService.GetBag(id);
            BagDeleteViewModel vm = _mapper.Map<BagDeleteViewModel>(bag);

            return View(vm);
        }

        [HttpPost]
        public IActionResult ConfirmDelete([FromRoute] int id)
        {
            var items = _context.Items.Where(x => EF.Property<int>(x, "BagId") == id);
            foreach (var item in items)
            {
                _context.Items.Remove(item);
            }
            _context.SaveChanges();

            _bagService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddToCart([FromRoute] int id)
        {
            Item item = new Item
            {
                Quantity = 1,
                Bike = _bikeService.GetBike(id)
            };

            Collection<Item> items = new Collection<Item>();
            items.Add(item);

            _context.Items.Add(item);
            _context.SaveChanges();

            Bag bag = new Bag()
            {
                Date = DateTime.Now,
                Customer = _customerService.GetCustomer(4),
                Items = items
            };

            _context.Add(bag);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}