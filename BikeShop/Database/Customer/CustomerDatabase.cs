using BikeShop.Domain;
using BikeShop.Domain.Cart;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Database
{
    public class CustomerDatabase : ICustomerDatabase
    {
        private readonly BikeDbContext _BikeDbContext;
        private DbSet<Customer> customers;
        public CustomerDatabase(BikeDbContext bikeDbContext)
        {
            _BikeDbContext = bikeDbContext;
            customers = bikeDbContext.Customer;
        }

        public void Delete(int Id)
        {
            var customer = customers.FirstOrDefault(x => x.CustomerId == Id);
            if (customer != null)
            {
                customers.Remove(customer);
                _BikeDbContext.SaveChanges();
            }
        }

        public Customer GetCustomer(int id)
        {
            return customers.FirstOrDefault(x => x.CustomerId == id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
          return customers;
        }

        public Customer Insert(Customer customer)
        {
            customers.Add(customer);
            _BikeDbContext.SaveChanges();
            return customer;
        }

        public void Update(int Id, Customer updatedCustomer)
        {
            var customer = customers.FirstOrDefault(x => x.CustomerId == Id);

            if (customer != null)
            {
                customer.FirstName = updatedCustomer.FirstName;
                customer.LastName = updatedCustomer.LastName;
                customer.Bags = updatedCustomer.Bags;
            }
        }
    }
}
