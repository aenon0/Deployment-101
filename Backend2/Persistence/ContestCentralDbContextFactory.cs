using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public class ContestCentralDbContextFactory: IDesignTimeDbContextFactory<ContestCentralDbContext>
{
    public ContestCentralDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "../../WebApi")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ContestCentralDbContext>();
        var connectionString = configuration.GetConnectionString("ContestCentralConnectionString");

        builder.UseNpgsql(connectionString);

        return new ContestCentralDbContext(builder.Options);
    }
}