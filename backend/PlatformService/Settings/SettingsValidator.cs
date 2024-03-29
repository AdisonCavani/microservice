﻿namespace PlatformService.Settings;

public static class SettingsValidator
{
    public static void Validate(this ConnectionSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings.SqlConnectionString);
        ArgumentNullException.ThrowIfNull(settings.RabbitMqHost);
        ArgumentNullException.ThrowIfNull(settings.RabbitMqPort);
    }
}