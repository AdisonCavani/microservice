using Microsoft.EntityFrameworkCore;
using PlatformService.Database;
using PlatformService.Settings;

namespace PlatformService.Startup;

public static class DbContext
{
    public static void ConfigureDbContext(this IServiceCollection services, ConnectionSettings connectionSettings)
    {
        services.AddDbContextPool<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionSettings.SqlConnectionString,
                npgSettings => { npgSettings.EnableRetryOnFailure(); });
        });
    }
}