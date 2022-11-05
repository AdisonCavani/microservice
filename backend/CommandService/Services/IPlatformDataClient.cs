using CommandService.Database.Entities;

namespace CommandService.Services;

public interface IPlatformDataClient
{
    Task<IEnumerable<Platform>> ReturnAllPlatforms();
}