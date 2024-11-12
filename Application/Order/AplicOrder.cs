using order_ms.Models;
using order_ms.Service;
namespace order_ms.Application
{
    public class AplicOrder : IAplicOrder
    {
        private readonly IServOrder _servOrder;

        public AplicOrder(IServOrder servOrder)
        {
            _servOrder = servOrder;
        }

        public Order InsertOrder(Order order)
        {
           var result = _servOrder.InsertOrder(order);

            return result;
        }
    }
}
