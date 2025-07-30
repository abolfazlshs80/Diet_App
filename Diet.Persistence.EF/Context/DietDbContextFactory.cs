using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Diet.Persistence.EF.Context;

public class DietDbContextFactory : IDesignTimeDbContextFactory<DietDbContext>
{
    public DietDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory()) // Or adjust path
           .AddJsonFile("appsettings.json")
           .Build();

        var connectionString = configuration.GetConnectionString("DientConnection");

        var optionsBuilder = new DbContextOptionsBuilder<DietDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new DietDbContext(optionsBuilder.Options);
    }
}
