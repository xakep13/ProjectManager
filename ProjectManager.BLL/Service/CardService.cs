using ProjectManager.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DAL.UnitOfWork;

namespace ProjectManager.BLL.Service
{
    class CardService : BaseService, ICardService
    {
        public CardService(IUnitOfWork uow) : base(uow) { }    
    }
}
