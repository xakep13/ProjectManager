using ProjectManager.BLL.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BLL.DTO;
using ProjectManager.DAL.UnitOfWork;
using ProjectManager.DAL.Entitties;
using ProjectManager.BLL.BusinessModels;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System;

namespace ProjectManager.BLL.Service
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork uow) : base(uow) { }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
           
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Login };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0) return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
               
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);

                Board board = new Board { Name = "Welcome" };
                ClientProfile clientProfile = new ClientProfile { Id = user.Id  };

                board.Users.Add(clientProfile);

                TaskList taskList1 = new TaskList() {  Name = "To Do", Board = board };
                TaskList taskList2 = new TaskList() {  Name = "Doing", Board = board };
                TaskList taskList3 = new TaskList() {  Name = "Done", Board = board };

                board.TaskLists.AddRange(new List<TaskList> { taskList1, taskList2, taskList3 });

                Card card1 = new Card() {  Name = "Tet_card", Description = "new test card 1", TaskList = taskList1, Position = 1 };
                Card card2 = new Card() {  Name = "Tet_card", Description = "new test card 2", TaskList = taskList1, Position = 2 };
                Card card3 = new Card() {  Name = "Tet_card", Description = "new test card 3", TaskList = taskList2, Position = 3 };
                Card card4 = new Card() {  Name = "Tet_card", Description = "new test card 4", TaskList = taskList3, Position = 4 };

                taskList1.Cards.AddRange(new List<Card> { card1, card2 });
                taskList2.Cards.Add(card3);
                taskList3.Cards.Add(card4);

                Database.Users.Create(clientProfile);
                Database.Boards.Create(board);
                Database.TaskLists.Create(taskList1);
                Database.TaskLists.Create(taskList2);
                Database.TaskLists.Create(taskList3);
                Database.Cards.Create(card1);
                Database.Cards.Create(card2);
                Database.Cards.Create(card3);
                Database.Cards.Create(card4);
                Database.Save();

                return new OperationDetails(true, "Registration successful", "");
            }
            else  return new OperationDetails(false, "User with such login already exists", "Login");
            
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
           
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Login, userDto.Password);

            if (user != null) claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            await AddRoleAsync(roles);
            await Create(adminDto);
        }

        public async Task AddRoleAsync(List<string> roles)
        {
            foreach (string roleName in roles)  await AddRoleAsync(roleName);         
        }

        public async Task AddRoleAsync( string roleName)
        {
            var role = await Database.RoleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                role = new ApplicationRole { Name = roleName };
                await Database.RoleManager.CreateAsync(role);
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public UserDTO GetById(string id)
        {
            var map = mapper.CreateMapper();

            return map.Map<UserDTO>(Database.Users.GetById(id));
        }

        public List<UserDTO> GetAll()
        {
            var map = mapper.CreateMapper();
            return map.Map<List<UserDTO>>(Database.Users.GetAll());
        }
    }
}
