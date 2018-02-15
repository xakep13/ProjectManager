using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.BLL.Interfaces;
using ProjectManager.BLL.DTO;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    [Authorize]
    public class BoardController : BaseController
    {
        public BoardController(IUserService user,IBoardService board, ITaskListService taskList, ICardService card ) : base(user, board, taskList, card) { }
        

        public ActionResult Index()
        {
            var map = mapper.CreateMapper();
            string s = User.Identity.Name;
            IEnumerable<BoardDTO> boards = BoardService.GetAll();
            IEnumerable<BoardViewModel> boardsView = map.Map<IEnumerable<BoardViewModel>>(boards);

            return View((object)s);
        }
    }
}