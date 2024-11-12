using order_ms.Models;

namespace order_ms.Application
{
    public interface IAplicOrder
    {
        Order InsertOrder(Order order);
    }
}
