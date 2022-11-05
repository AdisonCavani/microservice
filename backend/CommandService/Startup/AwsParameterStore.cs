namespace CommandService.Startup;

public static class AwsParameterStore
{
    public static void AddAwsParameterStore(this ConfigureWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(confBuilder =>
        {
            confBuilder.AddSystemsManager(config =>
            {
                // FIX: this will not work in test env
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower();

                // Parameter Store prefix to pull configuration data from.
                config.Path = $"/command-service/{environment ?? "development"}";

                // Reload configuration data every 15 minutes.
                config.ReloadAfter = TimeSpan.FromMinutes(15);

                // AWSOptions credentials are configured using AWS CLI
            });
        });
    }
}