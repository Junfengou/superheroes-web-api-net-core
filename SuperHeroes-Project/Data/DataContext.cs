global using Microsoft.EntityFrameworkCore;


namespace SuperHeroes_Project.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //"Server=(localdb)\\MSSQLLocalDB;Database=superherodb;Trusted_Connection=true;"
            var connectionString = _configuration.GetConnectionString("MyConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=superherodb;Trusted_Connection=true;");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<SuperHeroInfos> SuperHeroInfos { get; set; }

    }
}
