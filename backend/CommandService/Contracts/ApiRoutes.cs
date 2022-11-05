namespace CommandService.Contracts;

public static class ApiRoutes
{
    private const string Base = "/api";

    public const string Health = $"{Base}/health";
    
    public static class Command
    {
        private const string Endpoint = $"{Base}/command";

        public const string Create = $"{Endpoint}/create";
        public const string Get = $"{Endpoint}/get";
        public const string GetAll = $"{Endpoint}/getAll";
    }
    
    public static class Platform
    {
        private const string Endpoint = $"{Base}/platform";

        public const string GetAll = $"{Endpoint}/getAll";
        public const string Test = $"{Endpoint}/test";
    }
}