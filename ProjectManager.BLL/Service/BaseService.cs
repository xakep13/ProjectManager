using AutoMapper;
using ProjectManager.BLL.DTO;
using ProjectManager.DAL.Entitties;
using ProjectManager.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Service
{
    public class BaseService
    {
        protected MapperConfiguration mapper;
        protected IUnitOfWork Database { get; set; }

        public BaseService(IUnitOfWork uow)
        {
            Database = uow;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Board, BoardDTO>();
                cfg.CreateMap<BoardDTO, Board>();
                cfg.CreateMap<Card, CardDTO>();
                cfg.CreateMap<CardDTO, Card>();
                cfg.CreateMap<TaskList, TaskListDTO>();
                cfg.CreateMap<TaskListDTO, TaskList>();
            });
        }
    }
}
