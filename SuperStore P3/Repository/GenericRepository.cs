using Data;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SuperStoreContext _context;
        public GenericRepository(SuperStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public void Add(T entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be added: {ex.Message}");
            }
        }
        public void Update(T entity)
        {
            try
            {
                _context.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't remove entity: {ex.Message}");
            }
        }
        public void Remove(T entity)
            {
                try
                {
                    _context.Remove(entity);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception($"{nameof(entity)} couldn't be updated: {ex.Message}");
                }
            }

        IEnumerable<T> IGenericRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<T>.Remove(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
