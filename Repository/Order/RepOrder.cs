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

        public Order InsertOrder(Order order)
        {
            _mongoCollection.InsertOne(order);
            return order;
        }

        //public Order EditOrder(Order dto)
        //{
        //    var order = _mongoCollection.Find(p => p.Id == dto.Id).FirstOrDefault();

          
        //}

        public Order GetOrderById(int Id)
        {
            var order = _mongoCollection.Find(p => p.Id == Id).FirstOrDefault();

            return order;
        }
    }
}
