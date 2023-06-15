global using Microsoft.EntityFrameworkCore;

namespace SuperHeroes_Project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=superherodb;Trusted_Connection=true;");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<SuperHeroInfos> SuperHeroInfos { get; set; }

        //public DbSet<TestModel> Test { get; set; }
    }
}
