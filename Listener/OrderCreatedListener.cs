//using System.Text;
//using System.Text.Json;
//using Microsoft.Extensions.Logging;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
//using order_ms.DTOs;
//using order_ms.Services;
//using order_ms.RabbitMq;
//using static MongoDB.Driver.WriteConcern;

//namespace order_ms.Listener
//{
//    public class OrderCreatedListener
//    {
//        private readonly ILogger<OrderCreatedListener> _logger;
//        private readonly IServiceOrder _orderService;
//        private readonly IModel _channel;
//        private const string QueueName = RabbitMqConfig.ORDER_CREATED_QUEUE;

//        public OrderCreatedListener(ILogger<OrderCreatedListener> logger, IServiceOrder orderService, RabbitMqConfig rabbitMqConfig)
//        {
//            _logger = logger;
//            _orderService = orderService;

//            var connection = rabbitMqConfig.CreateConnection();
//            _channel = rabbitMqConfig.CreateChannel(connection);
//        }

//        public void Listen()
//        {
//            var consumer = new AsyncEventingBasicConsumer(_channel);
//            consumer.ReceivedAsync += async (model, ea) =>
//            {
//                var body = ea.Body.ToArray();
//                var messageJson = Encoding.UTF8.GetString(body);

//                var orderCreatedEvent = JsonSerializer.Deserialize<OrderCreatedEvent>(messageJson);

//                if (orderCreatedEvent != null)
//                {
//                    _logger.LogInformation("Mensagem consumida: {Message}", messageJson);

//                    _orderService.Save(orderCreatedEvent);
//                }

//                _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
//            };

//            _channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);
//            _logger.LogInformation("Esperando por mensagens...");
//        }
//    }
//}
