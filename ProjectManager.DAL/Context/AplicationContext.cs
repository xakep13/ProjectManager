using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManager.DAL.Entitties;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjectManager.DAL.Context
{
    public class AplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ClientProfile>     User        { get; set; }
        public DbSet<TaskList>          TaskList    { get; set; }
        public DbSet<Board>             Board       { get; set; }
        public DbSet<Card>              Card        { get; set; }



        public AplicationContext()
        {          
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.PasswordHash).HasMaxLength(500);
            modelBuilder.Entity<ApplicationUser>().Property(u => u.PhoneNumber).HasMaxLength(50);

            modelBuilder.Entity<ApplicationRole>().ToTable("Role");

        }
    }

    public class AplicationDbInitializer : DropCreateDatabaseAlways<AplicationContext>
    {
        protected override void Seed(AplicationContext context)
        {
            ClientProfile user = new ClientProfile();

            Board board = new Board() { Id = 1, Name = "Ласкаво просимо до дошки!"  };

            TaskList taskList1 = new TaskList() { Id = 1, Name = "Зробити",  Board = board };
            TaskList taskList2 = new TaskList() { Id = 2, Name = "РОбиться", Board = board };
            TaskList taskList3 = new TaskList() { Id = 3, Name = "Готово",   Board = board };
           
            Card card1 = new Card() { Id = 1, Name = "Tet_card", Description = "new test card 1", TaskList = taskList1 };
            Card card2 = new Card() { Id = 2, Name = "Tet_card", Description = "new test card 2", TaskList = taskList1 };
            Card card3 = new Card() { Id = 3, Name = "Tet_card", Description = "new test card 3", TaskList = taskList2 };
            Card card4 = new Card() { Id = 4, Name = "Tet_card", Description = "new test card 4", TaskList = taskList3 };

            user.Boards =       new List<Board>()           { board };
            board.Users =       new List<ClientProfile>()   { user };
            board.TaskLists =   new List<TaskList>()        { taskList1, taskList2, taskList3 };
            taskList1.Cards =   new List<Card>()            { card1, card2 };
            taskList2.Cards =   new List<Card>()            { card3 };
            taskList3.Cards =   new List<Card>()            { card4 };

            context.User.Add(user);
            context.Board.Add(board);
            context.TaskList.AddRange(new List<TaskList>() { taskList1, taskList2, taskList3 });
            context.Card.AddRange(new List<Card>() { card1, card2, card3, card4 });
            context.SaveChanges();
        }
    }
}
