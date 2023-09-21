using Data;
using EcoPower_Logistics.Data;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SuperStoreContext context) : base(context)
        {
        }

        public void AddCustomer(Customer entity)
        {
            Add(entity);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return GetAll().ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return GetAll().FirstOrDefault(c => c.CustomerId == id);
        }

        public void RemoveCustomer(Customer entity)
        {
            Remove(entity);
        }

        public void UpdateCustomer(Customer entity)
        {
            Update(entity);
        }
    }
}
