using Microsoft.EntityFrameworkCore;
using PlatformService.Database.Entities;

namespace PlatformService.Database;

public static class Seeder
{
    public static async Task SeedDataAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (context.Database.IsRelational())
            await context.Database.MigrateAsync();

        if (await context.Platforms.AnyAsync())
            return;

        await context.Platforms.AddRangeAsync(
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

        await context.SaveChangesAsync();
    }
}