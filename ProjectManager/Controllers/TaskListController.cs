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
        public TaskListController(IUserService user, IBoardService board, ITaskListService taskList, ICardService card) : base(user, board, taskList, card)
        {
        }

        // GET: TaskList
        public ActionResult Index()
        {
            return View();
        }

        // GET: TaskList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskList/Create
        [HttpPost]
        public ActionResult Create(TaskListViewModel data)
        {
            try
            {
                var map = mapper.CreateMapper();

                TaskListDTO taskList = map.Map<TaskListDTO>(data);

                taskList.Id = TaskListService.Create(taskList);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaskList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
