using System;
using ProjectManager.DAL.Interfaces;
using ProjectManager.DAL.Context;
using ProjectManager.DAL.Repositories;

namespace ProjectManager.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AplicationContext db;
        private UserRepository userRepository;
        private BoardRepository boardRepository;
        private CardRepository cardRepository;
        private TaskListRepository taskListRepository;
        private bool disposed = false;

        public UnitOfWork()
        {
            db  = new AplicationContext();
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null) userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IBoardRepository Boards
        {
            get
            {
                if (boardRepository == null) boardRepository = new BoardRepository(db);
                return boardRepository;
            }
        }

        public ICardRepository Cards
        {
            get
            {
                if (cardRepository == null) cardRepository = new CardRepository(db);
                return cardRepository;
            }
        }

        public ITaskListRepository TaskLists
        {
            get
            {
                if (taskListRepository == null) taskListRepository = new TaskListRepository(db);
                return taskListRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing) db.Dispose();
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save() => db.SaveChanges();
    }
}
