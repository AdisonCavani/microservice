namespace PlatformService.Contracts.Events;

public class PlatformPublished
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string Event { get; set; } = default!;
}