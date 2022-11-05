using CommandService.Database.Entities;
using CommandService.Domain;

namespace CommandService.Repositories;

public interface ICommandRepository
{
    Task<bool> CreatePlatformAsync(Platform platform, CancellationToken ct = default);
    Task<GetAllPlatformsResult?> GetAllPlatformsAsync(int page, CancellationToken ct = default);
    Task<bool?> CreateCommandForPlatformAsync(int platformId, Command command, CancellationToken ct = default);
    Task<Command?> GetCommandAsync(int platformId, int commandId, CancellationToken ct = default);
    Task<GetAllCommandsForPlatformResult?> GetCommandsForPlatform(int platformId, int page, CancellationToken ct = default);
}