using order_ms.Models;
using order_ms.Repository;

namespace order_ms.Service
{
    public class ServOrder : IServOrder
    {
        private readonly IRepOrder _repOrder;

        public ServOrder(IRepOrder repOrder)
        {
            _repOrder = repOrder;
        }

        public Order InsertOrder(Order order)
        {
            var result = _repOrder.InsertOrder(order);

            return result;
        }
    }
}
