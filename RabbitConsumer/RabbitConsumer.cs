using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Consumer
{
    public class RabbitConsumer
    {
        private readonly string _hostName = "localhost";
        private readonly string _queueName = "hello";

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
                await Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(queue: _queueName, autoAck: true, consumer: consumer);

            await Task.Delay(Timeout.Infinite);
        }
    }
}