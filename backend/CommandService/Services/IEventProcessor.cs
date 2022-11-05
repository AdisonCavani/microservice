namespace CommandService.Services;

public interface IEventProcessor
{
    void ProcessEvent(string message);
}