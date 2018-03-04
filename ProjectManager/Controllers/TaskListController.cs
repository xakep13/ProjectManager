using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.BLL.Interfaces;
using ProjectManager.BLL.DTO;

namespace ProjectManager.Controllers
{
    public class TaskListController : BaseController
    {
        public TaskListController(IUserService user, IBoardService board, ITaskListService taskList, ICardService card) : base(user, board, taskList, card) { }

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
    }
}
