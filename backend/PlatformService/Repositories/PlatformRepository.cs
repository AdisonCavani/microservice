using Microsoft.EntityFrameworkCore;
using PlatformService.Database;
using PlatformService.Database.Entities;

namespace PlatformService.Repositories;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _context;

    public PlatformRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreatePlatformAsync(Platform platform, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(platform);

        // TODO: SaveChangesAsync() ???
        await _context.Platforms.AddAsync(platform, ct);
    }

    public async Task<IEnumerable<Platform>> GetAllPlatformsAsync(CancellationToken ct = default)
    {
        return await _context.Platforms.ToListAsync(ct);
    }

    public async Task<Platform?> GetPlatformByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Platforms.FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<bool> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct) >= 0;
    }
}