using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WTS_INFRASTRUCTURE.Data;

public class WtsDesignFactory : IDesignTimeDbContextFactory<WtsDbContext>
{
    public WtsDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../WTS_Api");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<WtsDbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("APRSDbConnection"));

        return new WtsDbContext(optionsBuilder.Options);
    }
}
