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

        public int Create(int id,CardViewModel data)
        {
            var map = mapper.CreateMapper();
            TaskListDTO taskList = TaskListService.Get(id);
            CardDTO card = map.Map<CardDTO>(data);
            taskList.Cards.Add(card);

            int j = TaskListService.Update(taskList);
            int i = card.Id = CardService.Create(card);

            if (i != -1 && j != -1) ; //to do something
            return i;

        }

        public int Update(CardViewModel data)
        {
            var map = mapper.CreateMapper();
            CardDTO card = map.Map<CardDTO>(data);
            int i = card.Id = CardService.Update(card);
            return i;

        }

        public int Delete(int id, CardViewModel data)
        {
            var map = mapper.CreateMapper();
            TaskListDTO taskList = TaskListService.Get(id);
            CardDTO card = map.Map<CardDTO>(data);
            taskList.Cards.Remove(card);
            int j = TaskListService.Update(taskList);
            int i = CardService.Delete(card);

            if (i != -1 && j != -1) ; //to do something
            return i;
        }
    }
}
