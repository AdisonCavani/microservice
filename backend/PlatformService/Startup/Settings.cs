using PlatformService.Settings;

namespace PlatformService.Startup;

public static class Settings
{
    public static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionSettings>(configuration.GetSection(nameof(ConnectionSettings)));
    }
}