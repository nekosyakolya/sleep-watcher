using System.Collections.Generic;

namespace SleepWatcher.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> All { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(string id);
        T FindById(int id);
    }
}