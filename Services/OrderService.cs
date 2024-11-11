using order_ms.DTOs;
using order_ms.Models;
using order_ms.Repository;

namespace order_ms.Services
{
    public class OrderService : IServiceOrder
    {
        private readonly IRepOrder _repOrder;

        public OrderService(IRepOrder repOrder)
        {
            _repOrder = repOrder;
        }

        public void Save(OrderCreatedEvent order)
        {
            var orderclass = new Order();
            //order.Id = message.codigoPedido;
            //order.CustumerId = message.codigoCliente;
            //order.Total = valoritem * qtde

            //order.Itens = message.itens

            //_repOrder.SaveChanges();
        }
    }
}
