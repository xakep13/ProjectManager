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

        public JsonResult Index()
        {
            
            var map = mapper.CreateMapper();
            IEnumerable<BoardDTO> board = BoardService.GetAll(User.Identity.GetUserId());
            IEnumerable<BoardViewModel> myboard = map.Map<IEnumerable<BoardViewModel>>(board);

            return Json(myboard, JsonRequestBehavior.AllowGet);
        }
    }
}