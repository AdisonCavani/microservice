using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using PlatformService.Contracts.Events;
using PlatformService.Settings;
using RabbitMQ.Client;

namespace PlatformService.Services;

public class MessageBusClient : IMessageBusClient, IDisposable
{
    private readonly IModel _channel;
    private readonly IConnection _connection;

    public MessageBusClient(ILogger<MessageBusClient> logger, IOptionsSnapshot<ConnectionSettings> settings)
    {
        var factory = new ConnectionFactory
        {
            HostName = settings.Value.RabbitMqHost,
            Port = settings.Value.RabbitMqPort
        };

        try
        {
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare("trigger", ExchangeType.Fanout);
        }
        catch (Exception ex)
        {
            logger.LogCritical(ex, "Couldn't connect to RabbitMQ");
            throw;
        }
    }

    public void PublishNewPlatform(PlatformPublished platformPublished)
    {
        var message = JsonSerializer.Serialize(platformPublished);

        if (_connection.IsOpen)
            SendMessage(message);
    }

    private void SendMessage(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish("trigger", "", null, body);
    }

    public void Dispose()
    {
        if (_connection.IsOpen)
        {
            _channel.Close();
            _connection.Close();
        }
    }
}