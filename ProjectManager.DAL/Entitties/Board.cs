using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DAL.Entitties
{
    public class Board
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TaskList> TaskLists { get; set; }
        public List<ClientProfile> Users { get; set; }

        public Board()
        {
            TaskLists = new List<TaskList>();
            Users = new List<ClientProfile>();
        }
    }
}
