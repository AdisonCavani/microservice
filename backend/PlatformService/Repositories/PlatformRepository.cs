using Microsoft.EntityFrameworkCore;
using PlatformService.Database;
using PlatformService.Database.Entities;
using PlatformService.Domain;

namespace PlatformService.Repositories;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _context;

    public PlatformRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreatePlatformAsync(Platform platform, CancellationToken ct = default)
    {
        await _context.Platforms.AddAsync(platform, ct);
        return await _context.SaveChangesAsync(ct) > 0;
    }

    public async Task<GetAllPlatformsResult?> GetAllPlatformsAsync(int page, CancellationToken ct = default)
    {
        if (!await _context.Platforms.AnyAsync(ct))
            return new GetAllPlatformsResult();

        var pageResults = 5f;
        var urlsCount = await _context.Platforms
            .CountAsync(ct);
        var pageCount = Math.Ceiling(urlsCount / pageResults);

        if (page > pageCount)
            return null;

        var result = await _context.Platforms
            .Skip((page - 1) * (int) pageResults)
            .Take((int) pageResults)
            .OrderBy(x => x.Id)
            .ToListAsync(ct);

        return new GetAllPlatformsResult
        {
            Platforms = result,
            CurrentPage = page,
            PagesCount = (int) pageCount
        };
    }

    public async Task<Platform?> GetPlatformByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Platforms.FirstOrDefaultAsync(x => x.Id == id, ct);
    }
}