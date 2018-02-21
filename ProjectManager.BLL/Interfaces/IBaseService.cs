using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Interfaces
{
    public interface IBaseService<T> where T:class
    {
        IEnumerable<T> GetAll(int id);
        int Create(T data);
        int Update(T data);
        int Delete(T data);
        T Get(int id);
    }
}
