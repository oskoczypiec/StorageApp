using Microsoft.EntityFrameworkCore;
using StorageApp.Entities;

namespace StorageApp.Repositories
{
    // non generic delegate
    public delegate void ItemAdded(object item);

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly ItemAdded? _itemAddedCallback;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(DbContext dbContext, ItemAdded? itemAddedCallback = null)
        {
            _dbContext = dbContext;
            _itemAddedCallback = itemAddedCallback;
            _dbSet = _dbContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item=> item.Id).ToList();
        }
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
            //delegate will invoke method to which it points
            _itemAddedCallback?.Invoke(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }
    }
}
