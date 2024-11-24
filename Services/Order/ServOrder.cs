using domain;
using MongoDB.Driver;
using repository;

namespace services
{
    public class ServOrder : IServOrder
    {
        #region Ctor
        private readonly IRepOrder _repOrder;

        public ServOrder(IRepOrder repOrder)
        {
            _repOrder = repOrder;
        }
        #endregion

        #region EditOrder
        public Order EditOrder(Order order)
        {
            var result = _repOrder.EditOrder(order);

            return result;
        }
        #endregion

        #region GetOrderById
        public Order GetOrderById(int id)
        {
            var order = _repOrder.GetOrderById(id);

            return order;
        }
        #endregion

        #region InsertOrder
        public Order InsertOrder(Order order)
        {
            var result = _repOrder.InsertOrder(order);

            return result;
        }
        #endregion

        #region DeleteOrder
        public void DeleteOrder(int id)
        {
            _repOrder.DeleteOrder(id);
        }
        #endregion

        #region ListOrders
        public List<Order> ListOrders()
        {
            var orders = _repOrder.ListOrders();

            return orders;
        }
        #endregion

        #region GetOrderByCustomerId
        public List<Order> GetOrderByCustomerId(int customerId)
        {
            var orders = _repOrder.GetOrderByCustomerId(customerId);

            return orders;
        }
        #endregion

        #region GetPriceTotalOrder
        public PriceTotalOrderDTO GetPriceTotalOrder(int Id)
        {
            var dto = _repOrder.GetPriceTotalOrder(Id);

            return dto;
        }
        #endregion

        #region OrderByCustomer
        public OrderByCustomerDTO OrderByCustomer(int customerId)
        {
            var dto = _repOrder.OrderByCustomer(customerId);

            return dto;
        }
        #endregion
    }
}
