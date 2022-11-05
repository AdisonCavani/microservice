using PlatformService.Repositories;
using PlatformService.Services;

namespace PlatformService.Startup;

public static class Services
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPlatformRepository, PlatformRepository>();
        services.AddScoped<IMessageBusClient, MessageBusClient>();
    }
}