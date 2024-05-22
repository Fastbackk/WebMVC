using Microsoft.EntityFrameworkCore;

namespace MVCproject.Models {
    public class AppDbContext : DbContext {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBName;Integrated Security=True");
            optionsBuilder.UseSqlite("Data Source = arabalar.db");

        }

        public DbSet<ArabaModel> arabalar { get; set; }
    }
}