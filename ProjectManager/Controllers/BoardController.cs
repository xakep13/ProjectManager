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

        public int Delete(int boardId)
        {
            var map = mapper.CreateMapper();
            BoardDTO board = BoardService.Get(boardId);
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

        public ActionResult GetBoard(int id)
        {
            var map = mapper.CreateMapper();
            BoardDTO board = BoardService.GetByUserId(id, User.Identity.GetUserId());
            BoardViewModel myboard = map.Map<BoardViewModel>(board);

            return PartialView("GetBoard", map.Map<BoardViewModel>(myboard));
        }
    }
}