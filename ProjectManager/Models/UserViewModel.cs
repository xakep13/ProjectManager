using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Login { get; set; }

        public List<BoardViewModel> Boards { get; set; }

        public UserViewModel()
        {
            Boards = new List<BoardViewModel>();
        }
    }
}