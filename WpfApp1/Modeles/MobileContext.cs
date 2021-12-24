using System.Data.Entity;
using MyLibrary;
namespace WpfApp1.Modeles
{
    class MobileContext : DbContext
    {
        public MobileContext() : base("DefaultConnection")
        {

        }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
