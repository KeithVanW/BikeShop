using BikeShop.Domain.Cart;

namespace BikeShop.Database
{
    public class CustomerDatabase : ICustomerDatabase
    {
        private readonly BikeDbContext _bikeDbContext;

        public CustomerDatabase(BikeDbContext bikeDbContext)
        {
            _bikeDbContext = bikeDbContext;
        }

        public void Delete(int id)
        {
            var customer = GetCustomer(id);
            if (customer != null)
            {
                _bikeDbContext.Customer.Remove(customer);
                _bikeDbContext.SaveChanges();
            }
        }

        public Customer GetCustomer(int id)
        {
            return _bikeDbContext.Customer.FirstOrDefault(x => x.CustomerId == id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _bikeDbContext.Customer;
        }

        public Customer Insert(Customer customer)
        {
            _bikeDbContext.Customer.Add(customer);
            _bikeDbContext.SaveChanges();
            return customer;
        }

        public void Update(int id, Customer updatedCustomer)
        {
            var customer = GetCustomer(id);
            if (customer != null)
            {
                customer.FirstName = updatedCustomer.FirstName;
                customer.LastName = updatedCustomer.LastName;
                customer.Bags = updatedCustomer.Bags;
            }
            _bikeDbContext.SaveChanges();
        }
    }
}