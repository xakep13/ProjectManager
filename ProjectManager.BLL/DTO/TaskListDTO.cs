using System.Collections.Generic;

namespace ProjectManager.BLL.DTO
{
    public class TaskListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BoardId { get; set; }
        public BoardDTO Board { get; set; }

        public ICollection<CardDTO> Cards { get; set; }

        public TaskListDTO()
        {
            Cards = new List<CardDTO>();
        }
    }
}