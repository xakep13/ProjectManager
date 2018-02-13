using ProjectManager.DAL.Entitties;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjectManager.DAL.Context
{
    public class AplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Board> Board { get; set; }
        public DbSet<TaskList> TaskList { get; set; }
        public DbSet<Card> Card { get; set; }

        public AplicationContext()
        {
           // Database.SetInitializer<AplicationContext>(new AplicationDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
