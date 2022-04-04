using StorageApp.Entities;

namespace StorageApp.Repositories
{
    public class ListRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> _items = new();

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }
        public void Add(T item)
        {
            item.Id = _items.Any() ? _items.Max(item => item.Id) + 1 : 1;
            _items.Add(item);
        }

        public void Save()
        {
            //already saved 
        }
        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }
    }
}
