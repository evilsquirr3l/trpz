using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ZooDbContext : DbContext    
    {
        public DbSet<Animal> Animals { get; set; }

        public ZooDbContext(DbContextOptions<ZooDbContext> optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureCreated();
        }

        public ZooDbContext() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=localhost;Database=Zoo;Trusted_Connection=True;");
        }
    }
}