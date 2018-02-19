using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class TaskListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BoardId { get; set; }
        public BoardViewModel Board { get; set; }

        public ICollection<CardViewModel> Cards { get; set; }

        public TaskListViewModel()
        {
            Cards = new List<CardViewModel>();
        }
    }
}