using Microsoft.EntityFrameworkCore;

namespace SuperHero.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SuperHeroDb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Superhero> Superheroes { get; set; }
    }
}
