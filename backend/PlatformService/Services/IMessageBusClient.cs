using PlatformService.Contracts.Events;

namespace PlatformService.Services;

public interface IMessageBusClient
{
    void PublishNewPlatform(PlatformPublished platformPublished);
}