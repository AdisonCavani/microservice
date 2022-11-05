namespace PlatformService.Contracts.Responses;

public class GetAllPlatformsResponse
{
    public IEnumerable<GetPlatformResponse> Platforms { get; set; } = Enumerable.Empty<GetPlatformResponse>();
    
    public int CurrentPage { get; set; }
    
    public int PagesCount { get; set; }
}