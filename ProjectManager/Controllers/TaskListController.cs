using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.BLL.Interfaces;
using ProjectManager.BLL.DTO;
using System.Web.Script.Serialization;

namespace ProjectManager.Controllers
{
    public class TaskListController : BaseController
    {
        public TaskListController(IUserService user, IBoardService board, ITaskListService taskList, ICardService card) : base(user, board, taskList, card) { }
        private JavaScriptSerializer ser = new JavaScriptSerializer();

        public int Create(string name, int id)
        {
            var map = mapper.CreateMapper();
            BoardDTO board = BoardService.Get(id);
            TaskListDTO taskList = new TaskListDTO {Name = name , BoardId = board.Id};
            int i = taskList.Id = TaskListService.Create(taskList);
            return i;
        }

        public int Update(TaskListViewModel data)
        {
            var map = mapper.CreateMapper();
            TaskListDTO taskList = map.Map<TaskListDTO>(data);
            int i = taskList.Id = TaskListService.Update(taskList);
            return i;
        }

        public int Delete(int listId)
        {
            var map = mapper.CreateMapper();
            TaskListDTO taskList = TaskListService.Get(listId);
            int i = TaskListService.Delete(taskList);          
            return i;
        }
        [HttpPost]      
        public int ChangePosition(string json)
        {
            int update = 0;
            var msg =  ser.Deserialize<List<JsonObj>>(json);
            for(int i = 0; i < msg.Count; i++)
            {
                var item = TaskListService.Get(msg[i].list);
                for (int j = 0; j < msg[i].cards.Length; j++)
                {
                    var card = CardService.Get(msg[i].cards[j]);
                    if (item.Cards.Contains(card))
                    {
                        if (item.Cards[j].Position != j)
                        {
                            item.Cards[j].Position = j;
                            update = CardService.Update(item.Cards[j]);
                        }
                    }
                    else
                    {
                        card.TaskListId = item.Id;
                        card.Position = j;
                        update = CardService.Update(card);
                    }
                }
            }

            return update;
        }
    }
}
