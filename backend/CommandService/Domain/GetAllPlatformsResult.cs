using CommandService.Database.Entities;

namespace CommandService.Domain;

public class GetAllPlatformsResult
{
    public IEnumerable<Platform> Platforms { get; set; } = Enumerable.Empty<Platform>();
    
    public int CurrentPage { get; set; }
    
    public int PagesCount { get; set; }
}