using PlatformService.Database.Entities;

namespace PlatformService.Database;

public static class Seeder
{
    public static void SeedData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (context.Platforms.Any())
            return;

        context.Platforms.AddRange(
            new Platform
            {
                Name = "Dotnet",
                Publisher = "Microsoft",
                Cost = "Free"
            },
            new Platform
            {
                Name = "SQL Server Express",
                Publisher = "Microsoft",
                Cost = "Free",
            },
            new Platform
            {
                Name = "Kubernetes",
                Publisher = "Cloud Native Computing Foundation",
                Cost = "Free"
            }
        );

        context.SaveChanges();
    }
}