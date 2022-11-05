namespace PlatformService.Settings;

public class ConnectionSettings
{
    public string SqlConnectionString { get; set; } = default!;
    
    public string RabbitMqHost { get; set; } = default!;
    
    public int RabbitMqPort { get; set; }
}