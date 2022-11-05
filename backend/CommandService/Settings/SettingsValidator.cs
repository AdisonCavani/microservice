namespace CommandService.Settings;

public static class SettingsValidator
{
    public static void Validate(this ConnectionSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings.GrpcPlatformService);
        ArgumentNullException.ThrowIfNull(settings.RabbitMqHost);
        ArgumentNullException.ThrowIfNull(settings.RabbitMqPort);
        ArgumentNullException.ThrowIfNull(settings.SqlConnectionString);
    }
}