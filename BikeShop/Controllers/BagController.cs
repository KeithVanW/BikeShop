using BikeShop.Database;
using BikeShop.Domain.Cart;
using BikeShop.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace BikeShop.Controllers
{
    public class BagController : Controller
    {
        private readonly BikeDbContext _context;
        private readonly IBikeService _bikeService;
        private readonly ICustomerService _customerService;
        private readonly IItemDatabase _itemDatabase;

        public BagController(BikeDbContext context, IBikeService bikeService,
            ICustomerService customerService, IItemDatabase itemDatabase)
        {
            _context = context;
            _bikeService = bikeService;
            _customerService = customerService;
            _itemDatabase = itemDatabase;
        }

        // GET: Bag
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bag.ToListAsync());
        }

        // GET: Bag/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bag == null)
            {
                return NotFound();
            }

            var bag = await _context.Bag
                .FirstOrDefaultAsync(m => m.BagId == id);
            if (bag == null)
            {
                return NotFound();
            }

            return View(bag);
        }

        // GET: Bag/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BagId,Date")] Bag bag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bag);
        }

        // GET: Bag/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bag == null)
            {
                return NotFound();
            }

            var bag = await _context.Bag.FindAsync(id);
            if (bag == null)
            {
                return NotFound();
            }
            return View(bag);
        }

        // POST: Bag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BagId,Date")] Bag bag)
        {
            if (id != bag.BagId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BagExists(bag.BagId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bag);
        }

        // GET: Bag/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bag == null)
            {
                return NotFound();
            }

            var bag = await _context.Bag
                .FirstOrDefaultAsync(m => m.BagId == id);
            if (bag == null)
            {
                return NotFound();
            }

            return View(bag);
        }

        // POST: Bag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bag == null)
            {
                return Problem("Entity set 'BikeDbContext.Bag'  is null.");
            }
            var bag = await _context.Bag.FindAsync(id);
            if (bag != null)
            {
                _context.Bag.Remove(bag);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BagExists(int id)
        {
            return _context.Bag.Any(e => e.BagId == id);
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
                Customer = _customerService.GetCustomer(1),
                Items = items
            };

            _context.Add(bag);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}