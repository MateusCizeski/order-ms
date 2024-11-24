using domain;

namespace Application
{
    public interface IAplicOrder
    {
        Order InsertOrder(Order order);
        Order EditOrder(EditOrderDTO dto);
        Order GetOrderById(int id);
        List<Order> ListOrders();
        void DeleteOrder(int id);
        List<Order> GetOrderByCustomerId(int customerId);
        PriceTotalOrderDTO GetPriceTotalOrder(int Id);
        OrderByCustomerDTO OrderByCustomer(int customerId);
    }
}
