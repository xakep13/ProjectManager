using System;
using ProjectManager.DAL.Interfaces;

namespace ProjectManager.DAL.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }
        IBoardRepository Boards { get; }
        ICardRepository Cards { get; }
        ITaskListRepository TaskLists { get; }

        void Save();
    }
}
