using order_ms.DTOs;
using order_ms.Models;

namespace order_ms.Application
{
    public interface IAplicOrder
    {
        Order InsertOrder(Order order);
        Order EditOrder(EditOrderDTO dto);
        Order GetOrderById(int id);
        List<Order> ListOrders();
        void DeleteOrder(int id);
    }
}
