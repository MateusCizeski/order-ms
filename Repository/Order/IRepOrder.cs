using domain;

namespace repository
{
    public interface IRepOrder
    {
        Order InsertOrder(Order order);
        Order GetOrderById(int Id);
        Order EditOrder(Order order);
        List<Order> ListOrders();
        void DeleteOrder(int id);
        List<Order> GetOrderByCustomerId(int customerId);
        PriceTotalOrderDTO GetPriceTotalOrder(int Id);
        OrderByCustomerDTO OrderByCustomer(int customerId);
    }
}
