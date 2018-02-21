using Microsoft.AspNet.Identity;
using ProjectManager.DAL.Entitties;

namespace ProjectManager.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store): base(store) { }      
    }
}
