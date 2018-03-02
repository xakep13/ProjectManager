using ProjectManager.DAL.Entitties;
using ProjectManager.DAL.Interfaces;
using ProjectManager.DAL.Context;

namespace ProjectManager.DAL.Repositories
{
    public class BoardRepository : EntityRepository<Board>, IBoardRepository
    {
        public BoardRepository(AplicationContext context) : base(context) { }
    }
}
