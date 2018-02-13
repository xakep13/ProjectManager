using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DAL.Entitties
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int TaskListId { get; set; }
        public TaskList TaskList { get; set; }
    }
}
