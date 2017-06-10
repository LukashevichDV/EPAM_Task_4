using System.Collections.Generic;

namespace DAL.Repository
{
    public interface IModelRepository<T, K>
    {
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        K GetEntity(T source);
        K GetEntityNameById(int id);
        IEnumerable<T> Items { get; }
        void SaveChanges();
    }
}