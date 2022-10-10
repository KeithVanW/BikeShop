using BikeShop.Domain.Cart;

namespace BikeShop.Service
{
    public interface ICustomerService
    {
        Customer GetCustomer(int id);
        public IEnumerable<Customer> GetCustomers();
        void Insert(Customer customer);
        void Update(int id, Customer customer);
        void Delete(int id);
    }
}
