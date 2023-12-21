using Application.Contracts.Infrastructure;
using Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastrucureServiceRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        // email settings setup will be added here
        services.AddScoped<IUserAccessor, UserAccessor>();
        services.AddHttpClient<ICodeforcesService, CodeforcesService>();
        return services;
    }
}
