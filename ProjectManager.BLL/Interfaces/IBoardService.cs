using System.Collections.Generic;
using ProjectManager.BLL.DTO;

namespace ProjectManager.BLL.Interfaces
{
    public interface IBoardService : IBaseService<BoardDTO>
    {
        IEnumerable<BoardDTO> GetAll(string id);
    }
}