using PlatformService.Database.Entities;

namespace PlatformService.Domain;

public class GetAllPlatformsResult
{
    public IEnumerable<Platform> Platforms { get; set; } = Enumerable.Empty<Platform>();
    
    public int CurrentPage { get; set; }
    
    public int PagesCount { get; set; }
}