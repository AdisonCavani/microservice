using CommandService.Repositories;
using CommandService.Services;
using Microsoft.EntityFrameworkCore;

namespace CommandService.Database;

public static class Seeder
{
    public static async Task SeedDataAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var grpcClient = scope.ServiceProvider.GetRequiredService<IPlatformDataClient>();
        var repository = scope.ServiceProvider.GetRequiredService<ICommandRepository>();

        if (context.Database.IsRelational())
            await context.Database.MigrateAsync();

        var platforms = await grpcClient.ReturnAllPlatforms();

        foreach (var platform in platforms)
            await repository.CreatePlatformAsync(platform);

        await context.SaveChangesAsync();
    }
}