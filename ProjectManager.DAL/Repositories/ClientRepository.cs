using ProjectManager.DAL.Context;
using ProjectManager.DAL.Entitties;
using ProjectManager.DAL.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.DAL.Repositories
{
    public class ClientRepository : IClientrRepository
    {
        public AplicationContext Database { get; set; }
        public ClientRepository(AplicationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.User.Add(item);
            Database.SaveChanges();
        }
        public  ClientProfile GetById(string id)
        {
            return Database.User.Include(x => x.Boards.Select(w => w.TaskLists.Select(q => q.Cards))).First(x => x.Id == id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
