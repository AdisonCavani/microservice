namespace PlatformService.Contracts.Requests;

public class CreatePlatformRequest
{
    public string Name { get; set; } = default!;

    public string Publisher { get; set; } = default!;

    public string Cost { get; set; } = default!;
}