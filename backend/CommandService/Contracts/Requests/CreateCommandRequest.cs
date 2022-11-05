namespace CommandService.Contracts.Requests;

public class CreateCommandRequest
{
    public int PlatformId { get; set; }
    
    public string HowTo { get; set; } = default!;

    public string CommandLine { get; set; } = default!;
}