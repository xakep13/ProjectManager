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

        [HttpPost]
        public ActionResult Create(BoardViewModel data)
        {
            var map = mapper.CreateMapper();

            UserDTO userDTO = UserService.GetById(User.Identity.GetUserId());
            BoardDTO boardDTO = map.Map<BoardDTO>(data);
            boardDTO.Users.Add(userDTO);
            boardDTO.Id = BoardService.Create(boardDTO);

            return null;
        }

        
    }
}