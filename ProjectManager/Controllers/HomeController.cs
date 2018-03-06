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

        public object Search(string name)
        {
            if (name.Length > 2)
            {
                var map = mapper.CreateMapper();
                List<UserDTO> users = UserService.GetAll().Where(a => a.Login.Contains(name)).ToList();
                if (users.Count <= 0)
                {
                    return null;
                }
                return PartialView("Search", users);
            }
            return null;
        }
    }
}