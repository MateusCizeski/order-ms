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
    }
}
