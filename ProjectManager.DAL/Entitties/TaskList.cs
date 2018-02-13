using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DAL.Entitties
{
    public class TaskList
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int BoardId { get; set; }
        public Board Board { get; set; }

        public ICollection<Card> Cards { get; set; }

        public TaskList()
        {
            Cards = new List<Card>();
        }
    }
}