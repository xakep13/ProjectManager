using System.Web.Mvc;
using ProjectManager.BLL.Interfaces;
using ProjectManager.BLL.DTO;
using Microsoft.AspNet.Identity;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class BoardController : BaseController
    {
        public BoardController(IUserService user, IBoardService board, ITaskListService taskList, ICardService card) : base(user, board, taskList, card){        }

        
        public int Create(string name)
        {
            var map = mapper.CreateMapper();

            BoardDTO boardDTO = new BoardDTO { Name = name };

            int i = boardDTO.Id = BoardService.Create(boardDTO, User.Identity.GetUserId());

            return i;
        }

        public int Delete(string id, BoardViewModel data)
        {
            var map = mapper.CreateMapper();

            UserDTO user = UserService.GetById(id);
            BoardDTO board = map.Map<BoardDTO>(data);
            user.Boards.Remove(board);
            //int j = UserService.Update(user);
            int i = BoardService.Delete(board);
            return i;
        }

        public int Update(BoardViewModel data)
        {
            var map = mapper.CreateMapper();

            BoardDTO board = map.Map<BoardDTO>(data);
            int i = BoardService.Update(board);
            return i;
        }  
    }
}