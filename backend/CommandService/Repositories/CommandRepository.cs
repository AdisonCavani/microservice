using CommandService.Database;
using CommandService.Database.Entities;
using CommandService.Domain;
using Microsoft.EntityFrameworkCore;

namespace CommandService.Repositories;

public class CommandRepository : ICommandRepository
{
    private readonly AppDbContext _context;

    public CommandRepository(AppDbContext context)
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
            .ToListAsync(ct);

        return new GetAllPlatformsResult
        {
            Platforms = result,
            CurrentPage = page,
            PagesCount = (int) pageCount
        };
    }

    public async Task<bool?> CreateCommandForPlatformAsync(int platformId, Command command,
        CancellationToken ct = default)
    {
        var platformExist = await _context.Platforms.AnyAsync(x => x.Id == platformId, ct);

        if (!platformExist)
            return null;

        command.PlatformId = platformId;
        await _context.Commands.AddAsync(command, ct);
        return await _context.SaveChangesAsync(ct) > 0;
    }

    public async Task<Command?> GetCommandAsync(int platformId, int commandId, CancellationToken ct = default)
    {
        return await _context.Commands
            .Where(x => x.PlatformId == platformId && x.Id == commandId)
            .FirstOrDefaultAsync(ct);
    }

    public async Task<GetAllCommandsForPlatformResult?> GetCommandsForPlatform(
        int platformId,
        int page,
        CancellationToken ct = default)
    {
        if (!await _context.Platforms.AnyAsync(x => x.Id == platformId, ct))
            return new GetAllCommandsForPlatformResult();

        var pageResults = 5f;
        var urlsCount = await _context.Commands
            .Where(x => x.PlatformId == platformId)
            .CountAsync(ct);
        var pageCount = Math.Ceiling(urlsCount / pageResults);

        if (page > pageCount)
            return null;

        var result = await _context.Commands
            .Where(x => x.PlatformId == platformId)
            .Skip((page - 1) * (int) pageResults)
            .Take((int) pageResults)
            .ToListAsync(ct);

        return new GetAllCommandsForPlatformResult
        {
            Commands = result,
            CurrentPage = page,
            PagesCount = (int) pageCount
        };
    }
}