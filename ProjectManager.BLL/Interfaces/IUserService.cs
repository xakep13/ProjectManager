using ProjectManager.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Interfaces
{
    public interface IUserService
    {
        bool Create(UserDTO item);
        UserDTO Login(string email, string password);
        UserDTO GetByName(string Name);
        UserDTO GetById(int Id);
    }
}
