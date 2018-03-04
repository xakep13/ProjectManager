using ProjectManager.DAL.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.DAL.Interfaces
{
    public interface IBoardRepository 
    {
        IEnumerable<object> Select(Func<Board, object> predicate);
        IQueryable<Board> Find(Func<Board, bool> predicate);
        IQueryable<Board> GetAll();
        void Create(Board item);
        void Update(Board item);
        void Delete(int Id);
        bool IfExist(int Id);
        Board Get(int Id);
    }
}
