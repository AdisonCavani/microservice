using PlatformService.Database.Entities;
using PlatformService.Domain;

namespace PlatformService.Repositories;

public interface IPlatformRepository
{
    Task<bool> CreatePlatformAsync(Platform platform, CancellationToken ct = default);
    Task<GetAllPlatformsResult?> GetAllPlatformsAsync(int page, CancellationToken ct = default);
    Task<Platform?> GetPlatformByIdAsync(int id, CancellationToken ct = default);
}