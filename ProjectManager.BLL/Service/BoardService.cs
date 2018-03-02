using System;
using System.Collections.Generic;
using ProjectManager.DAL.UnitOfWork;
using ProjectManager.BLL.DTO;
using ProjectManager.BLL.Interfaces;
using Microsoft.AspNet.Identity;
using ProjectManager.DAL.Entitties;

namespace ProjectManager.BLL.Service
{
    public class BoardService : BaseService, IBoardService
    {
        public BoardService(IUnitOfWork uow) : base(uow) { }

        public int Create(BoardDTO data)
        {
            if (data != null)
            {
                var map = mapper.CreateMapper();
                Board board = map.Map<Board>(data);
                Database.Boards.Create(board);
                Database.Save();

                return board.Id;
            }
            else return -1;
        }

        public int Update(BoardDTO data)
        {
            if (data != null)
            {
                var map = mapper.CreateMapper();
                Board board = map.Map<Board>(data);
                Database.Boards.Update(board);
                Database.Save();
                return board.Id;
            }
            else  return -1; 
        }

        public BoardDTO Get(int id)
        {
            var map = mapper.CreateMapper();
            return map.Map<BoardDTO>(Database.Boards.Get(id));
        }

        public IEnumerable<BoardDTO> GetAll(string id)
        {
            ClientProfile user = Database.Users.GetById(id);


            var mapping = mapper.CreateMapper();
            return mapping.Map<IEnumerable<BoardDTO>>(user.Boards);
        }

        public int Delete(BoardDTO data)
        {
            if (data != null)
            {
                var map = mapper.CreateMapper();
                Board board = map.Map<Board>(data);

                foreach (ClientProfile user in board.Users)
                    user.Boards.Remove(board);

                foreach (TaskList taskList in board.TaskLists)
                {
                    foreach (Card card in taskList.Cards)
                        Database.Cards.Delete(card.Id);
                    Database.TaskLists.Delete(taskList.Id);
                }

                Database.Boards.Delete(board.Id);
                Database.Save();
                return 0;
            }
            else return -1;
        }


        public int Create(BoardDTO data, string v)
        {
            if (data != null && !String.IsNullOrEmpty(v))
            {
                var map = mapper.CreateMapper();
                Board board = map.Map<Board>(data);
                ClientProfile client = Database.Users.GetById(v);
                board.Users.Add(client);
                Database.Boards.Create(board);
                Database.Save();

                return board.Id;
            }
            else return -1;
        }

        public BoardDTO GetByUserId(int id, string v)
        {
            var map = mapper.CreateMapper();
            ClientProfile client = Database.Users.GetById(v);

            return map.Map<BoardDTO>(client.Boards.Find(x => x.Id == id));
        }

        public IEnumerable<BoardDTO> GetAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}
