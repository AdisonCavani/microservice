using CommandService.Database.Entities;

namespace CommandService.Domain;

public class GetAllCommandsForPlatformResult
{
    public IEnumerable<Command> Commands { get; set; } = Enumerable.Empty<Command>();

    public int CurrentPage { get; set; }
    
    public int PagesCount { get; set; }
}