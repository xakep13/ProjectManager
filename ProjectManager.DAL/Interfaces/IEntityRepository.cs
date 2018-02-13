using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.DAL.Interfaces
{
    public interface IEntityRepository<T> where T : class
    {
        T Get(int Id);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Func<T, bool> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int Id);
        bool IfExist(int Id);
        IEnumerable<object> Select(Func<T, object> predicate);
    }
}