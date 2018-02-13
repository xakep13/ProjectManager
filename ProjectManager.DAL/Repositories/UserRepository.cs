using ProjectManager.DAL.Context;
using ProjectManager.DAL.Entitties;
using ProjectManager.DAL.Interfaces;

namespace ProjectManager.DAL.Repositories
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(AplicationContext context) : base(context) { }
    }
}
