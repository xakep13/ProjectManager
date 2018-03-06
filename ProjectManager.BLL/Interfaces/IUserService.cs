using ProjectManager.BLL.BusinessModels;
using ProjectManager.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails>      Create(UserDTO userDto);
        Task<ClaimsIdentity>        Authenticate(UserDTO userDto);
        Task                        SetInitialData(UserDTO adminDto, List<string> roles);
        UserDTO                     GetById(string id);
        List<UserDTO> GetAll();
    }
}
