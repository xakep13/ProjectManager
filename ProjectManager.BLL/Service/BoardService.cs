using System;
using System.Collections.Generic;
using ProjectManager.DAL.UnitOfWork;
using ProjectManager.BLL.DTO;
using ProjectManager.BLL.Interfaces;

namespace ProjectManager.BLL.Service
{
    public class BoardService : BaseService, IBoardService
    {
        public BoardService(IUnitOfWork uow) : base(uow) { }

        public IEnumerable<BoardDTO> GetAll()
        {
            var mapping = mapper.CreateMapper();
            return mapping.Map<IEnumerable<BoardDTO>>(Database.Boards.GetAll());
        }


    }
}
