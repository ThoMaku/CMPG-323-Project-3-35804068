using Models;

namespace EcoPower_Logistics.Repository
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetAllCustomers();
        void AddCustomer(Customer entity);
        void UpdateCustomer(Customer entity);
        void RemoveCustomer(Customer entity);
    }
}
