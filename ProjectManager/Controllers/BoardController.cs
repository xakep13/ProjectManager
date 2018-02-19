using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.BLL.Interfaces;
using ProjectManager.BLL.DTO;
using Microsoft.AspNet.Identity;

namespace ProjectManager.Controllers
{
    public class BoardController : BaseController
    {
        public BoardController(IUserService user, IBoardService board, ITaskListService taskList, ICardService card) : base(user, board, taskList, card){        }

        [HttpPost]
        public ActionResult Create(string name)
        {
            string id = User.Identity.GetUserId();
            UserDTO userDTO = UserService.GetById(id);

            BoardDTO boardDTO = new BoardDTO() { Name = name };
            boardDTO.Users.Add(userDTO);
            int i = BoardService.Create(boardDTO);

            if (i != -1) return null;
            else         return null;
        }
    }
}