using Ninject.Modules;
using ProjectManager.DAL.UnitOfWork;

namespace ProjectManager.BLL
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
