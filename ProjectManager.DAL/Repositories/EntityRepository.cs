using ProjectManager.DAL.Context;
using ProjectManager.DAL.Interfaces;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.DAL.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public EntityRepository(AplicationContext context)
        {
            _entities = context; _dbset = context.Set<T>();
        }

        public virtual IEnumerable<object> Select(Func<T, object> predicate) => _dbset.Select(predicate).ToList();

        public virtual IQueryable<T> Find(Func<T, bool> predicate) => _dbset.Where(predicate).AsQueryable<T>();

        public virtual IQueryable<T> GetAll() => _dbset.ToList().AsQueryable<T>();

        public virtual T Get(int Id) => _dbset.Find(Id);

        public virtual void Create(T item)
        {
            if (item != null) _dbset.Add(item);
        }

        public virtual void Delete(int Id)
        {
            T item = _dbset.Find(Id);
            if (item != null) _dbset.Remove(item);
        }

        public virtual void Update(T item)
        {
            _entities.Entry(item).State = EntityState.Modified;
        }

        public virtual bool IfExist(int Id)
        {
            if (Id < 1) return false;
            else
            {
                T item = _dbset.Find(Id);
                if (item != null) return true;
                else return false;
            }
        } 
    }
}