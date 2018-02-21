using ProjectManager.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DAL.UnitOfWork;
using ProjectManager.BLL.DTO;
using ProjectManager.DAL.Entitties;

namespace ProjectManager.BLL.Service
{
    public class CardService : BaseService, ICardService
    {
        public CardService(IUnitOfWork uow) : base(uow) { }

        public int Create(CardDTO data)
        {
            if (data != null)
            {
                var map = mapper.CreateMapper();
                Card card = map.Map<Card>(data);
                Database.Cards.Create(card);
                Database.Save();

                return card.Id;
            }
            else return -1; 
        }

        public int Delete(CardDTO data)
        {
            if (data != null)
            {
                var map = mapper.CreateMapper();
                Card card = map.Map<Card>(data);

                    Database.Cards.Delete(card.Id);

                Database.Save();
                return 0;
            }
            else return -1;
        }

        public CardDTO Get(int id)
        {
            var map = mapper.CreateMapper();
            return map.Map<CardDTO>(Database.Cards.Get(id));
        }

        public IEnumerable<CardDTO> GetAll(int id)
        {
            TaskList taskList = Database.TaskLists.Get(id);

            var mapping = mapper.CreateMapper();
            return mapping.Map<IEnumerable<CardDTO>>(taskList.Cards);
        }

        public int Update(CardDTO data)
        {
            if (data != null)
            {
                var map = mapper.CreateMapper();
                Card card = map.Map<Card>(data);
                Database.Cards.Update(card);
                Database.Save();
                return card.Id;
            }
            else return -1;
        }
    }
}
