using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class CardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }

        public int TaskListId { get; set; }
        public TaskListViewModel TaskList { get; set; }
    }
}