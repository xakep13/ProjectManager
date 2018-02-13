using ProjectManager.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BLL.DTO;
using ProjectManager.DAL.UnitOfWork;
using ProjectManager.DAL.Entitties;
using ProjectManager.BLL.BusinessModels;

namespace ProjectManager.BLL.Service
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork uow) : base(uow) { }

        public bool Create(UserDTO item)
        {
            User user = Database.Users.Find(u => u.Email == item.Email || u.Login == item.Login).FirstOrDefault();

            if (user == null)
            {
                string hashPassword = Hashing.GetHashString(item.Password);
                User newUser = new User()
                {
                    Email = item.Email,
                    Login = item.Login,
                    Password = hashPassword
                };
                Database.Users.Create(newUser);
                Database.Save();
                return true;
            }
            else  return false; 
        }

        public UserDTO Login(string login, string password)
        {
            var map = mapper.CreateMapper();
            User user = Database.Users.Find(u => u.Login == login && u.Password == Hashing.GetHashString(password)).FirstOrDefault();
            if (user != null)
            {
                return map.Map<UserDTO>(user);
            }
            else  return null; 
        }

        public UserDTO GetByName(string Name)
        {
            var map = mapper.CreateMapper();
            return map.Map<UserDTO>(Database.Users.Find(u => u.Login == Name).FirstOrDefault());
        }

        public UserDTO GetById(int Id)
        {
            var map = mapper.CreateMapper();
            return map.Map<UserDTO>(Database.Users.Get(Id));
        }
    }
}
