using domain;
using MongoDB.Driver;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using repository;
using System.Text;
using System.Text.Json;

namespace Consumer
{
    public class RabbitConsumer
    {
        private readonly string _hostName = "localhost";
        private readonly string _queueName = "orders";
        private readonly IMongoCollection<Order> _mongoCollection;
        private readonly IRepOrder _repOrder;

        public RabbitConsumer(IMongoCollection<Order> mongoCollection, IRepOrder repOrder)
        {
            _mongoCollection = mongoCollection;
            _repOrder = repOrder;
        }

        public async Task ConsumerMessageAsync()
        {
            var factory = new ConnectionFactory { HostName = _hostName };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received: {message}");

                try
                {
                    var order = JsonSerializer.Deserialize<Order>(message);

                    if(order != null)
                    {
                        Console.WriteLine($"Processing Order {order.Id} for Customer {order.CustomerId}");

                        _repOrder.InsertOrder(order);
                    }
                    else
                    {
                        Console.WriteLine("Invalid order format received.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing message: {ex.Message}");
                }

                await Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(queue: _queueName, autoAck: true, consumer: consumer);

            await Task.Delay(Timeout.Infinite);
        }
    }
}