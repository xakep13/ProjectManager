using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.DAL.Interfaces
{
    public interface IEntityRepository<T> where T : class
    {
        IEnumerable<object>     Select(Func<T, object> predicate);
        IQueryable<T>           Find(Func<T, bool> predicate);
        IQueryable<T>           GetAll();
        void                    Create(T item);
        void                    Update(T item);
        void                    Delete(int Id);
        bool                    IfExist(int Id);
        T                       Get(int Id);
    }
}