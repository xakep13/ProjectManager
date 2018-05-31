using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.BLL.Interfaces;
using Microsoft.AspNet.Identity;
using ProjectManager.Models;
using ProjectManager.BLL.DTO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace ProjectManager.Controllers
{

    public class HomeController : BaseController
    {
        public HomeController(IUserService user, IBoardService board, ITaskListService taskList, ICardService card) : base(user, board, taskList, card) { }
        
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public object GetBoard(int id)
        {
            var map = mapper.CreateMapper();
            if (id != 0)
            {
                
                BoardDTO board = BoardService.Get(id);
                BoardViewModel myboard = map.Map<BoardViewModel>(board);

                return JsonConvert.SerializeObject(myboard, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            else
            {
                IEnumerable<BoardDTO> board = BoardService.GetAll(User.Identity.GetUserId());
                IEnumerable<BoardViewModel> myboard = map.Map<IEnumerable<BoardViewModel>>(board);

                return JsonConvert.SerializeObject(myboard.FirstOrDefault(), Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
        }

        public object GetListOfBoards()
        {
            var user = UserService.GetById(User.Identity.GetUserId());
            Dictionary<int, string> links = new Dictionary<int, string>();
            for (int i = 0; i< user.Boards.Count; i++)
            {
                links.Add(user.Boards[i].Id, user.Boards[i].Name);
            }
            return JsonConvert.SerializeObject(links, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
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