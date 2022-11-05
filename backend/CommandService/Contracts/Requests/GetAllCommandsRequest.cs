namespace CommandService.Contracts.Requests;

public class GetAllCommandsRequest
{
    public int PlatformId { get; set; }
    
    public int Page { get; set; }
}