using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SuperStoreContext context) : base(context)
        {
        }

        public void AddProduct(Product entity)
        {
            Add(entity);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return GetAll().ToList();
        }

        public Product GetProductById(int id)
        {
            return GetAll().FirstOrDefault(p => p.ProductId == id);
        }

        public void RemoveProduct(Product entity)
        {
            Remove(entity);
        }

        public void UpdateProduct(Product entity)
        {
            Update(entity);
        }
    }
}
