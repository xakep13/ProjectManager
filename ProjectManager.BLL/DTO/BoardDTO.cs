using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL.DTO
{
    public class BoardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TaskListDTO> TaskLists { get; set; }
        public ICollection<UserDTO> Users { get; set; }

        public BoardDTO()
        {
            TaskLists = new List<TaskListDTO>();
            Users = new List<UserDTO>();
        }
    }
}
