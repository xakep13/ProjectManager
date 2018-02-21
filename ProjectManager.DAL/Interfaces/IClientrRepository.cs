using System;
using ProjectManager.DAL.Entitties;
using System.Threading.Tasks;

namespace ProjectManager.DAL.Interfaces
{
    public interface IClientrRepository : IDisposable
    {
        void Create(ClientProfile item);
        ClientProfile GetById(string id);
    }
}
