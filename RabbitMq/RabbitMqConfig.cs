//using RabbitMQ.Client;
//using Microsoft.Extensions.Configuration;
//using System.Threading.Tasks;
//using static MongoDB.Driver.WriteConcern;

//namespace order_ms.RabbitMq
//{
//    public class RabbitMqConfig
//    {
//        public const string ORDER_CREATED_QUEUE = "order-ms-created";
//        private readonly IConfiguration _configuration;

//        public RabbitMqConfig(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }
//        public async Task<IConnection> CreateConnectionAsync()
//        {
//            var factory = new ConnectionFactory
//            {
//                HostName = _configuration["RabbitMq:HostName"] ?? "localhost",
//                UserName = _configuration["RabbitMq:UserName"] ?? "guest",
//                Password = _configuration["RabbitMq:Password"] ?? "guest"
//            };

//            return await factory.CreateConnectionAsync();
//        }

//        public IModel CreateChannel(IConnection connection)
//        {
//            var channel = connection.CreateModel();
//            channel.QueueDeclare(queue: ORDER_CREATED_QUEUE, durable: true, exclusive: false, autoDelete: false, arguments: null);
//            return channel;
//        }
//    }
//}
