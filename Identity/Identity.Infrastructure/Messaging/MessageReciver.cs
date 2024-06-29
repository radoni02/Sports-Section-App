using Identity.Infrastructure.Keycloak;
using Identity.Infrastructure.Messaging.Messages;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Messaging;

internal sealed class MessageReciver : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IKeycloakService _keycloakService;

    public MessageReciver(IKeycloakService keycloakService)
    {
        _keycloakService = keycloakService;
        var factory = new ConnectionFactory() { HostName = "Localhost", UserName = "guest", Password = "guest" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        _channel.ExchangeDeclare(exchange: "ssa_AddSection", type: ExchangeType.Direct);

        var queueName = _channel.QueueDeclare().QueueName;
        _channel.QueueBind(queue: queueName,
            exchange: "ssa_AddSection",
            routingKey: "AddSection");

        Console.WriteLine("Waiting for logs");

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            byte[] body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var routingKey = ea.RoutingKey;
            HandleMessage(message);
        };
        _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        await Task.CompletedTask;
    }

    private void HandleMessage(string message)
    {
        var deserializedValue = JsonConvert.DeserializeObject<AddSection>(message);

        _keycloakService.AddGroupAsync(new GroupRepresentation($"kosz {deserializedValue.TeacherId}"));
    }

}
