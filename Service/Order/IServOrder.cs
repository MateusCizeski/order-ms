using order_ms.Models;

namespace order_ms.Service
{
    public interface IServOrder
    {
        Order InsertOrder(Order order);
    }
}
