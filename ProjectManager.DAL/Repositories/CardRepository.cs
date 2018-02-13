using ProjectManager.DAL.Entitties;
using ProjectManager.DAL.Interfaces;
using ProjectManager.DAL.Context;

namespace ProjectManager.DAL.Repositories
{
    public class CardRepository : EntityRepository<Card>, ICardRepository
    {
        public CardRepository(AplicationContext context) : base(context) { }
    }
}
