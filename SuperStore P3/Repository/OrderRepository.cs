using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(SuperStoreContext context) : base(context)
        {
        }

        public void AddOrder(Order entity)
        {
            Add(entity);
        }

        public IEnumerable<Order> GetAllOrderrs()
        {
            return GetAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            return GetAll().FirstOrDefault(o => o.OrderId == id);
        }

        public void RemoveOrder(Order entity)
        {
            Remove(entity);
        }

        public void UpdateOrder(Order entity)
        {
            Update(entity);
        }
    }
}
