using PlatformService.Database.Entities;

namespace PlatformService.Repositories;

public interface IPlatformRepository
{
    Task CreatePlatformAsync(Platform platform, CancellationToken ct = default);
    Task<IEnumerable<Platform>> GetAllPlatformsAsync(CancellationToken ct = default);
    Task<Platform?> GetPlatformByIdAsync(int id, CancellationToken ct = default);
    Task<bool> SaveChangesAsync(CancellationToken ct = default);
}