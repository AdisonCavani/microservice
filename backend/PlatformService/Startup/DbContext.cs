using Microsoft.EntityFrameworkCore;
using PlatformService.Database;
using PlatformService.Settings;

namespace PlatformService.Startup;

public static class DbContext
{
    public static void ConfigureDbContext(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment env)
    {
        if (env.IsProduction())
        {
            var connectionSettings = new ConnectionSettings();
            configuration.GetSection(nameof(ConnectionSettings)).Bind(connectionSettings);
            connectionSettings.Validate();
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseNpgsql("User ID=admin; Password=admin123!; Host=localhost; Port=5432; Database=PlatformServiceDb; Pooling=true;",
                    npgSettings => { npgSettings.EnableRetryOnFailure(); });
            });
        }
        else
        {
            services.AddDbContextPool<AppDbContext>(options => { options.UseInMemoryDatabase("platform-service"); });
        }
    }
}