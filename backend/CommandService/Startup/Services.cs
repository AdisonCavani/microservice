using CommandService.Repositories;
using CommandService.Services;

namespace CommandService.Startup;

public static class Services
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICommandRepository, CommandRepository>();
        services.AddScoped<IPlatformDataClient, PlatformDataClient>();
    }
}