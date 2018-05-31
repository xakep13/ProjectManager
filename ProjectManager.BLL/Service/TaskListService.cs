using ProjectManager.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DAL.UnitOfWork;
using ProjectManager.BLL.DTO;
using ProjectManager.DAL.Entitties;

namespace ProjectManager.BLL.Service
{
    public class TaskListService : BaseService, ITaskListService
    {
        public TaskListService(IUnitOfWork uow) : base(uow) { }

        public int Create(TaskListDTO data)
        {
            if (data != null)
            {
                var map = mapper.CreateMapper();
                TaskList board = map.Map<TaskList>(data);
                Database.TaskLists.Create(board);
                Database.Save();

                return board.Id;
            }
            else return -1; 
        }

        public int Update(TaskListDTO data)
        {
            if (data != null)
            {
                var map = mapper.CreateMapper();
                TaskList board = map.Map<TaskList>(data);
                Database.TaskLists.Update(board);
                Database.Save();
                return board.Id;
            }
            else return -1;
        }

        public TaskListDTO Get(int id)
        {
            var map = mapper.CreateMapper();
            return map.Map<TaskListDTO>(Database.TaskLists.Get(id));
        }

        public IEnumerable<TaskListDTO> GetAll(int board_id)
        {
            Board board = Database.Boards.Get(board_id);

            var mapping = mapper.CreateMapper();
            return mapping.Map<IEnumerable<TaskListDTO>>(board.TaskLists);
        }

        public int Delete(TaskListDTO data)
        {
            if (data != null)
            {
                var map = mapper.CreateMapper();
                TaskList taskList = map.Map<TaskList>(data);

                //foreach (Card card in taskList.Cards)
                //    Database.Cards.Delete(card.Id);

                Database.TaskLists.Delete(taskList.Id);
                Database.Save();
                return 0;
            }
            else return -1;
        }
    }
}
