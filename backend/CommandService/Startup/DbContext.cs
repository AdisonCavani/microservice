using CommandService.Database;
using CommandService.Settings;
using Microsoft.EntityFrameworkCore;

namespace CommandService.Startup;

public static class DbContext
{
    public static void ConfigureDbContext(this IServiceCollection services, ConnectionSettings connectionSettings)
    {
        services.AddDbContextPool<AppDbContext>(options =>
            options.UseNpgsql(connectionSettings.SqlConnectionString, options => { options.EnableRetryOnFailure(); }));
    }
}