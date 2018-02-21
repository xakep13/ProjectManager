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
                cfg.CreateMap<ClientProfile, UserDTO>()
                    .ForMember(x => x.Email, y => y.MapFrom(z => z.ApplicationUser.Email))
                    .ForMember(x => x.Login, y => y.MapFrom(z => z.ApplicationUser.UserName))
                    .ForMember(x => x.Role, y => y.MapFrom(z => z.ApplicationUser.Roles.FirstOrDefault()))
                    .ForMember(x => x.Boards, y => y.MapFrom(z => z.Boards));
                
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
