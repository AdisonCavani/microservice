using CommandService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommandService.Database;

public class AppDbContext : DbContext
{
    public DbSet<Platform> Platforms { get; set; } = default!;

    public DbSet<Command> Commands { get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Platform>()
            .HasMany(x => x.Commands)
            .WithOne(x => x.Platform)
            .HasForeignKey(x => x.PlatformId);
        
        modelBuilder
            .Entity<Command>()
            .HasOne(x => x.Platform)
            .WithMany(x => x.Commands)
            .HasForeignKey(x => x.PlatformId);
    }
}