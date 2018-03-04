using ProjectManager.DAL.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.DAL.Interfaces
{
    public interface ITaskListRepository 
    {
        IEnumerable<object> Select(Func<TaskList, object> predicate);
        IQueryable<TaskList> Find(Func<TaskList, bool> predicate);
        IQueryable<TaskList> GetAll();
        void Create(TaskList item);
        void Update(TaskList item);
        void Delete(int Id);
        bool IfExist(int Id);
        TaskList Get(int Id);
    }
}
