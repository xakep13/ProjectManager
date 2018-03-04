using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.BLL.Interfaces;
using ProjectManager.Models;
using ProjectManager.BLL.DTO;

namespace ProjectManager.Controllers
{
    public class CardController : BaseController
    {
        public CardController(IUserService user, IBoardService board, ITaskListService taskList, ICardService card) : base(user, board, taskList, card) { }

        public int Create(string name,int id, string description)
        {
            var map = mapper.CreateMapper();
            TaskListDTO taskList = TaskListService.Get(id);
            CardDTO card = new CardDTO { Name = name, TaskListId = taskList.Id,Description=description };
            
            int i = card.Id = CardService.Create(card);

            return i;
        }

        public int Update(CardViewModel data)
        {
            var map = mapper.CreateMapper();
            CardDTO card = map.Map<CardDTO>(data);
            int i = card.Id = CardService.Update(card);
            return i;

        }

        public int Delete(int cardId)
        {
            var map = mapper.CreateMapper();
            CardDTO card = CardService.Get(cardId);
            int i = CardService.Delete(card);

            return i;
        }
    }
}
