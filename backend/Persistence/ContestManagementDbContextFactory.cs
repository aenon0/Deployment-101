using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public class ContestManagementDbContextFactory : IDesignTimeDbContextFactory<ContestManagementDbContext>
{
    public ContestManagementDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/../WebApi/")
                .AddJsonFile("appsettings.json")
                .Build();

        var builder = new DbContextOptionsBuilder<ContestManagementDbContext>();
        var connectionString = configuration.GetConnectionString("ContestManagementConnectionString");

        builder.UseNpgsql(connectionString);

        return new ContestManagementDbContext(builder.Options);
    }
}




