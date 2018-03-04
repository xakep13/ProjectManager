using ProjectManager.DAL.Entitties;
using ProjectManager.DAL.Interfaces;
using ProjectManager.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class BoardRepository :  IBoardRepository
    {
        public AplicationContext Database { get; set; }
        public BoardRepository(AplicationContext db)
        {
            Database = db;
        }

        public virtual IEnumerable<object> Select(Func<Board, object> predicate) => Database.Board.Select(predicate).ToList();

        public virtual IQueryable<Board> Find(Func<Board, bool> predicate) => Database.Board.Where(predicate).AsQueryable<Board>();

        public virtual IQueryable<Board> GetAll() => Database.Board.ToList().AsQueryable<Board>();

        public virtual Board Get(int Id) => Database.Board.Find(Id);

        public virtual void Create(Board item)
        {
            if (item != null) Database.Board.Add(item);
        }

        public virtual void Delete(int Id)
        {
            Board item = Database.Board.Include(x => x.TaskLists.Select(y => y.Cards)).First(x=>x.Id==Id);

            if (item != null) Database.Board.Remove(item);
        }

        public virtual void Update(Board item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }

        public virtual bool IfExist(int Id)
        {
            if (Id < 1) return false;
            else
            {
                Board item = Database.Board.Find(Id);
                if (item != null) return true;
                else return false;
            }
        }
    }
}
