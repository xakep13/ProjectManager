using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.BLL.Interfaces;
using Microsoft.AspNet.Identity;
using ProjectManager.Models;
using ProjectManager.BLL.DTO;

namespace ProjectManager.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUserService user, IBoardService board, ITaskListService taskList, ICardService card) : base(user, board, taskList, card) { }

        [Authorize]
        public ActionResult Index()
        {        
            var map = mapper.CreateMapper();
            IEnumerable<BoardDTO> board = BoardService.GetAll(User.Identity.GetUserId());
            IEnumerable<BoardViewModel> myboard = map.Map<IEnumerable<BoardViewModel>>(board);

            return View(myboard);
        }
  
        public ActionResult GetBoard(int id)
        {
            var map = mapper.CreateMapper();
            BoardDTO board = BoardService.GetByUserId(id,User.Identity.GetUserId());
            BoardViewModel myboard = map.Map<BoardViewModel>(board);

            return PartialView("GetBoard", map.Map<BoardViewModel>(myboard));
        }
    }
}