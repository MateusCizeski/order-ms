using order_ms.Models;

namespace order_ms.Service
{
    public interface IServOrder
    {
        Order InsertOrder(Order order);
        Order GetOrderById(int id);
        Order EditOrder(Order order);
        List<Order> ListOrders();
        void DeleteOrder(int id);
    }
}
