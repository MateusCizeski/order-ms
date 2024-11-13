using order_ms.DTOs;
using order_ms.Models;
using order_ms.Service;

namespace order_ms.Application
{
    public class AplicOrder : IAplicOrder
    {
        private readonly IServOrder _servOrder;
        private readonly IMapperOrder _mapperOrder;

        public AplicOrder(IServOrder servOrder, IMapperOrder mapperOrder)
        {
            _servOrder = servOrder;
            _mapperOrder = mapperOrder;
        }

        public Order EditOrder(EditOrderDTO dto)
        {
            var order = _servOrder.GetOrderById(dto.Id);

            _mapperOrder.MapperEditOrder(order, dto);

            _servOrder.EditOrder(order);

            return order;

        }

        public Order InsertOrder(Order order)
        {
           var result = _servOrder.InsertOrder(order);

            return result;
        }
    }
}
