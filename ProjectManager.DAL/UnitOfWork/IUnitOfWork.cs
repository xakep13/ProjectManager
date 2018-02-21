using System;
using ProjectManager.DAL.Interfaces;
using ProjectManager.DAL.Identity;

namespace ProjectManager.DAL.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        ApplicationUserManager  UserManager     { get; }
        ApplicationRoleManager  RoleManager     { get; }
        ITaskListRepository     TaskLists       { get; }
        IClientrRepository      Users           { get; }
        IBoardRepository        Boards          { get; }
        ICardRepository         Cards           { get; }

        void Save();
    }
}
