using Microsoft.EntityFrameworkCore;
using PlatformService.Database.Entities;

namespace PlatformService.Database;

public class AppDbContext : DbContext
{
    public DbSet<Platform> Platforms { get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}