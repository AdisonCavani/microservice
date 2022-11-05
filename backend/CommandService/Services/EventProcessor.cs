using System.Text.Json;
using AutoMapper;
using CommandService.Contracts.Events;
using CommandService.Database.Entities;
using CommandService.Repositories;

namespace CommandService.Services;

enum EventType
{
    PlatformPublished,
    Unknown
}

public class EventProcessor : IEventProcessor
{
    private readonly IMapper _mapper;
    private readonly IServiceScopeFactory _scopeFactory;

    public EventProcessor(IMapper mapper, IServiceScopeFactory scopeFactory)
    {
        _mapper = mapper;
        _scopeFactory = scopeFactory;
    }

    public void ProcessEvent(string message)
    {
        var eventType = DetermineEvent(message);
        switch (eventType)
        {
            case EventType.PlatformPublished:
                // TODO: add functionality
                break;
        }
    }

    private EventType DetermineEvent(string notificationMessage)
    {
        // TODO: Generic event dto
        var eventType = JsonSerializer.Deserialize<object>(notificationMessage);

        // switch (eventType.Event)
        switch (eventType)
        {
            case "Platform_Published":
                return EventType.PlatformPublished;
            
            default:
                return EventType.Unknown;
        }
    }

    private void AddPlatform(string platformPublishedMessage)
    {
        // TODO: add async scope
        using var scope = _scopeFactory.CreateScope();

        var repo = scope.ServiceProvider.GetRequiredService<ICommandRepository>();
        var platformPublished = JsonSerializer.Deserialize<PlatformPublished>(platformPublishedMessage);

        try
        {
            var plat = _mapper.Map<Platform>(platformPublished);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}