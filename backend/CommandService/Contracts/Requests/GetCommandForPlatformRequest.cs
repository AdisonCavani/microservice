namespace CommandService.Contracts.Requests;

public class GetCommandForPlatformRequest
{
    public int PlatformId { get; set; }
    
    public int CommandId { get; set; }
}