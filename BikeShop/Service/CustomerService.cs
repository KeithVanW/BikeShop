using BikeShop.Domain.Cart;

namespace BikeShop.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDatabase _customerDatabase;
        public CustomerService(ICustomerDatabase customerDatabase)
        {
            _customerDatabase = customerDatabase;
        }
        public void Insert(Customer customer)
        {
            _customerDatabase.Insert(customer);
        }
        public Customer GetCustomer(int id)
        {
            return _customerDatabase.GetCustomer(id);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerDatabase.GetCustomers();
        }
        public void Update(int id, Customer customer)
        {
            _customerDatabase.Update(id, customer);
        }
        public void Delete(int id)
        {
            _customerDatabase.Delete(id);
        }
    }
}
