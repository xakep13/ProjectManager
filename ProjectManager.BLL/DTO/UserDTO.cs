using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<BoardDTO> Boards { get; set; }
        public UserDTO()
        {
            Boards = new List<BoardDTO>();
        }
    }
}
