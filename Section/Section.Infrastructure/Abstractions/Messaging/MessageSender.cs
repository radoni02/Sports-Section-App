using Newtonsoft.Json;
using RabbitMQ.Client;
using Section.Application.Abstractions.Messaging;
using Section.Application.Abstractions.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Infrastructure.Abstractions.Messaging;

internal sealed class MessageSender : IMessageSender
{
    public void SendMessage(BaseMessage message)
    {
        var (serializedValue,type) = HandleMessage(message);
        var factory = new ConnectionFactory { HostName = "Localhost", UserName = "guest", Password = "guest" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.ExchangeDeclare($"ssa_{type}", ExchangeType.Direct);
        var body = Encoding.UTF8.GetBytes(serializedValue);
        channel.BasicPublish(exchange: $"ssa_{type}",
            routingKey: $"{type}",
            basicProperties: null,
            body: body);
        Console.WriteLine("Sent");
    }

    private (string,string) HandleMessage<T>(T value) where T : BaseMessage
    {
        var type = value.GetType().Name;
        var serializedvalue = JsonConvert.SerializeObject(value,
                  new JsonSerializerSettings
                  {
                      TypeNameHandling = TypeNameHandling.All
                  });
        return (serializedvalue, type);
    }
}
