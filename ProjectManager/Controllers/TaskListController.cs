﻿using ProjectManager.Models;
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

        public int Create(int id, TaskListViewModel data)
        {
            var map = mapper.CreateMapper();

            BoardDTO board = BoardService.Get(id);
            TaskListDTO taskList = map.Map<TaskListDTO>(data);
            board.TaskLists.Add(taskList);

            int i = taskList.Id = TaskListService.Create(taskList);
            int j = BoardService.Update(board);

            if (i != -1 && j != -1) ; //to do something
                return i;

        }

        public int Update(TaskListViewModel data)
        {
            var map = mapper.CreateMapper();
            TaskListDTO taskList = map.Map<TaskListDTO>(data);
            int i = taskList.Id = TaskListService.Update(taskList);
            return i;
        }

        public int Delete(int id, TaskListViewModel data)
        {
            var map = mapper.CreateMapper();
            BoardDTO board = BoardService.Get(id);
            TaskListDTO taskList = map.Map<TaskListDTO>(data);
            board.TaskLists.Remove(taskList);

            int j = BoardService.Update(board);
            int i = TaskListService.Delete(taskList);

            if (i != -1 && j != -1) ; //to do something
            return i;
        }
    }
}
