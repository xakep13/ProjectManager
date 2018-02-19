using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class BoardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TaskListViewModel> TaskLists { get; set; }
        public ICollection<UserViewModel> Users { get; set; }

        public BoardViewModel()
        {
            TaskLists = new List<TaskListViewModel>();
            Users = new List<UserViewModel>();
        }
    }
}