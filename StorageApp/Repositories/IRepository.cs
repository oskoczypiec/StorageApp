using StorageApp.Entities;

namespace StorageApp.Repositories
{
    /// <summary>
    /// contraveriant type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWriteRepository<in T> 
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }
    /// <summary>
    /// covariant type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
    }
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : IEntity
    {
    }

    /// <summary>
    /// inheriting from non generic
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee> 
    {   
    }

    /// <summary>
    /// inheriting from generic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface ISuperRepository<T, TKey> : IRepository<T> where T : IEntity
    {
        TKey Key { get; }
    }
}