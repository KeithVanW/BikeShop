using AutoMapper;
using BikeShop.Domain.Cart;
using BikeShop.Models.Customer;
using BikeShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<CustomerListViewModel> vm = _customerService.GetCustomers()
                .Select(x => _mapper.Map<CustomerListViewModel>(x));
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CustomerCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create([FromForm] CustomerCreateViewModel vm)
        {
            if (TryValidateModel(vm))
            {
                Customer customer = new Customer();
                customer = _mapper.Map<Customer>(vm);

                _customerService.Insert(customer);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail([FromRoute] int id)
        {
            Customer customer = _customerService.GetCustomer(id);
            CustomerDetailViewModel vm = _mapper.Map<CustomerDetailViewModel>(customer);

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            Customer customer = _customerService.GetCustomer(id);
            CustomerEditViewModel vm = _mapper.Map<CustomerEditViewModel>(customer);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, [FromForm] CustomerEditViewModel vm)
        {
            if (TryValidateModel(vm))
            {
                Customer customer = new Customer();
                customer = _mapper.Map<Customer>(vm);
                // Customer customerFromDb = _customerService.GetCustomer(id);
                _customerService.Update(id, customer);

                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            Customer customer = _customerService.GetCustomer(id);
            CustomerDeleteViewModel vm = _mapper.Map<CustomerDeleteViewModel>(customer);

            return View(vm);
        }

        [HttpPost]
        public IActionResult ConfirmDelete([FromRoute] int id)
        {
            _customerService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}