using BikeShop.Domain.Cart;

public interface ICustomerDatabase
{
    Customer Insert(Customer customer);

    IEnumerable<Customer> GetCustomers();

    Customer GetCustomer(int id);

    void Update(int id, Customer customer);

    void Delete(int id);
}