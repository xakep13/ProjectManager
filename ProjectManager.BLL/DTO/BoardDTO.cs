using System.Collections.Generic;

namespace ProjectManager.BLL.DTO
{
    public class BoardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TaskListDTO> TaskLists { get; set; }
        public List<UserDTO> Users { get; set; }

        public BoardDTO()
        {
            TaskLists = new List<TaskListDTO>();
            Users = new List<UserDTO>();
        }
    }
}
