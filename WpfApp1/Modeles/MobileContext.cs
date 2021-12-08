using System.Data.Entity;
using MyLibrary;
namespace WpfApp1.Modeles
{
    class MobileContext : DbContext
    {
        public MobileContext() : base("DefaultConnection")
        {

        }
        public DbSet<Vopros> Vopros { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
