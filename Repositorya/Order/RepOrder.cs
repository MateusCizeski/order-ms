using MongoDB.Driver;
using order_ms.Models;

namespace order_ms.Repository
{
    public class RepOrder : IRepOrder
    {
        private readonly IMongoCollection<Order> _mongoCollection;

        public RepOrder(IMongoCollection<Order> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        #region InsertOrder
        public Order InsertOrder(Order order)
        {
            _mongoCollection.InsertOne(order);
            return order;
        }
        #endregion

        #region EditOrder
        public Order EditOrder(Order order)
        {
            _mongoCollection.ReplaceOne(filter: p => p.Id == order.Id, replacement: order);

            return order;
        }
        #endregion

        #region GetOrderById
        public Order GetOrderById(int Id)
        {
            var order = _mongoCollection.Find(p => p.Id == Id).FirstOrDefault();

            return order;
        }
        #endregion

        #region ListOrders
        public List<Order> ListOrders()
        {
            var orders = _mongoCollection.Find(_ => true).ToList();

            return orders;
        }
        #endregion

        #region DeleteOrder
        public void DeleteOrder(int id)
        {
            _mongoCollection.DeleteOne(p => p.Id == id);
        }
        #endregion
    }
}
