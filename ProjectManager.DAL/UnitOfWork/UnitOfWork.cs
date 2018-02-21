using System;
using ProjectManager.DAL.Interfaces;
using ProjectManager.DAL.Context;
using ProjectManager.DAL.Repositories;
using ProjectManager.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManager.DAL.Entitties;

namespace ProjectManager.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AplicationContext       db;
        private ApplicationUserManager  userManager;
        private ApplicationRoleManager  roleManager;
        private TaskListRepository      taskListRepository;
        private ClientRepository        userRepository;
        private BoardRepository         boardRepository;
        private CardRepository          cardRepository;
        private bool                    disposed             = false;

        public UnitOfWork()
        {
            db                  = new AplicationContext();
            userManager         = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager         = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            taskListRepository  = new TaskListRepository(db);
            userRepository      = new ClientRepository(db);
            boardRepository     = new BoardRepository(db);
            cardRepository      = new CardRepository(db);
        }

        public ApplicationUserManager UserManager   => userManager;

        public ApplicationRoleManager RoleManager   => roleManager;

        public ITaskListRepository TaskLists        => taskListRepository;

        public IClientrRepository Users             => userRepository;
        
        public IBoardRepository Boards              => boardRepository;
        
        public ICardRepository Cards                => cardRepository;
             
        public void Save()                          => db.SaveChanges();

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                    userManager.Dispose();
                    roleManager.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
