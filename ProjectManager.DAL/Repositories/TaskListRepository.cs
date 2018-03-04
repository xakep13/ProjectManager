using ProjectManager.DAL.Entitties;
using ProjectManager.DAL.Interfaces;
using ProjectManager.DAL.Context;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Data.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class TaskListRepository :  ITaskListRepository
    {
        public AplicationContext Database { get; set; }
        public TaskListRepository(AplicationContext db)
        {
            Database = db;
        }

        public virtual IEnumerable<object> Select(Func<TaskList, object> predicate) => Database.TaskList.Select(predicate).ToList();

        public virtual IQueryable<TaskList> Find(Func<TaskList, bool> predicate) => Database.TaskList.Where(predicate).AsQueryable<TaskList>();

        public virtual IQueryable<TaskList> GetAll() => Database.TaskList.ToList().AsQueryable<TaskList>();

        public virtual TaskList Get(int Id) => Database.TaskList.Find(Id);

        public virtual void Create(TaskList item)
        {
            if (item != null) Database.TaskList.Add(item);
        }

        public virtual void Delete(int Id)
        {
            TaskList item = Database.TaskList.Include(b=>b.Board)
                                             .Include(b => b.Cards)
                                             .FirstOrDefault(b => b.Id == Id);
            foreach (Card card in item.Cards.ToList())
                Database.Card.Remove(card);

            if (item != null) Database.TaskList.Remove(item);
        }

        public virtual void Update(TaskList item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }

        public virtual bool IfExist(int Id)
        {
            if (Id < 1) return false;
            else
            {
                TaskList item = Database.TaskList.Find(Id);
                if (item != null) return true;
                else return false;
            }
        }
    }
}

