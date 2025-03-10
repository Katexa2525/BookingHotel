using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookingHotel.Server.ContextFactory
{
  public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
  {
    public RepositoryContext CreateDbContext(string[] args)
    {
      var configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json")
       .Build();

      var builder = new DbContextOptionsBuilder<RepositoryContext>().UseSqlServer(configuration.GetConnectionString("sqlConnection"));
      return new RepositoryContext(builder.Options);
    }
  }
}
