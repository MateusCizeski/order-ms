using RabbitMQ.Client;
using System.Text;

namespace Producer
{
    public class RabbitProducer
    {
        private readonly string _hostName;
        private readonly string _queueName;

        public RabbitProducer(string hostName = "localhost", string queueName = "hello")
        {
            _hostName = hostName;
            _queueName = queueName;
        }

        public async Task SendMessage(string message)
        {
            var factory = new ConnectionFactory { HostName = _hostName };

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: _queueName, body: body);
            Console.WriteLine($" [x] Sent {message}");
        }
    }
}