using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DAL.Entitties
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Board> Boards { get; set; }
        public User() => Boards = new List<Board>();
        
    }
}
