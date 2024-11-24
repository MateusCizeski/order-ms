using domain;

namespace services
{
    public interface IServOrder
    {
        Order InsertOrder(Order order);
        Order GetOrderById(int id);
        Order EditOrder(Order order);
        List<Order> ListOrders();
        void DeleteOrder(int id);
        List<Order> GetOrderByCustomerId(int customerId);
        PriceTotalOrderDTO GetPriceTotalOrder(int Id);
        OrderByCustomerDTO OrderByCustomer(int customerId);
    }
}
