using RabbitMQ.Client;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using static MongoDB.Driver.WriteConcern;

namespace order_ms.RabbitMq
{
    public class RabbitMqConfig
    {
        public const string ORDER_CREATED_QUEUE = "order-ms-created";
        private readonly IConfiguration _configuration;

        public RabbitMqConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Método para criar a conexão de forma assíncrona (a partir da versão 7.x)
        public async Task<IConnection> CreateConnectionAsync()
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration["RabbitMq:HostName"] ?? "localhost",
                UserName = _configuration["RabbitMq:UserName"] ?? "guest",
                Password = _configuration["RabbitMq:Password"] ?? "guest"
            };

            return await factory.CreateConnectionAsync(); // Criação assíncrona da conexão
        }

        // Método para criar o canal (IModel) de comunicação com RabbitMQ
        public IModel CreateChannel(IConnection connection)
        {
            var channel = connection.CreateModel(); // Criação do canal (IModel)
            channel.QueueDeclare(queue: ORDER_CREATED_QUEUE, durable: true, exclusive: false, autoDelete: false, arguments: null);
            return channel; // Retorna o canal
        }
    }
}
