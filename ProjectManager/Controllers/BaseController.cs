using AutoMapper;
using ProjectManager.BLL.DTO;
using ProjectManager.BLL.Interfaces;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Controllers
{
    public class BaseController : Controller
    {
        protected MapperConfiguration mapper;    
        protected IBoardService BoardService;
        protected ITaskListService TaskListService;
        protected ICardService CardService;
        protected IUserService UserService;

        public BaseController(IUserService user, IBoardService board, ITaskListService taskList, ICardService card)
        {
            TaskListService = taskList;
            BoardService = board;
            CardService = card;
            UserService = user;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskListDTO, TaskListViewModel>();
                cfg.CreateMap<TaskListViewModel, TaskListDTO>();

                cfg.CreateMap<BoardDTO, BoardViewModel>();
                cfg.CreateMap<BoardViewModel, BoardDTO>();

                cfg.CreateMap<CardDTO, CardViewModel>();
                cfg.CreateMap<CardViewModel, CardDTO>();

                cfg.CreateMap<UserDTO, UserViewModel>();
               
            });
        }
    }
}