using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new Configuration());
        }

        //public DbSet<Hotel>? Hotels { get; set; }
    }
}
