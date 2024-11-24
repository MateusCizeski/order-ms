using domain;
using MongoDB.Driver;

namespace repository
{
    public class RepOrder : IRepOrder
    {
        #region Ctor
        private readonly IMongoCollection<Order> _mongoCollection;

        public RepOrder(IMongoCollection<Order> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }
        #endregion

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

            if(order == null)
            {
                throw new Exception("Pedido não encontrado.");
            }

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
            var order = _mongoCollection.Find(p => p.Id == id).FirstOrDefault();

            if(order == null)
            {
                throw new Exception("Pedido informado não encontrado.");
            }

            _mongoCollection.DeleteOne(p => p.Id == id);
        }
        #endregion

        #region GetOrderByCustomerId
        public List<Order> GetOrderByCustomerId(int customerId)
        {
            var orders = _mongoCollection.Find(p => p.CustomerId == customerId).ToList();

            if(orders == null || orders.Count == 0)
            {
                throw new Exception("Cliente não possui pedidos.");
            }

            return orders;
        }
        #endregion

        #region GetPriceTotalOrder
        public PriceTotalOrderDTO GetPriceTotalOrder(int Id)
        {
            var order = _mongoCollection.Find(p => p.Id == Id).FirstOrDefault();

            if(order == null)
            {
                throw new Exception("Pedido não encontrado.");
            }

            decimal total = order.Itens.Sum(item => item.Price);

            return new PriceTotalOrderDTO
            {
                Id = order.Id,
                Price = total
            };
        }
        #endregion

        #region OrderByCustomer
        public OrderByCustomerDTO OrderByCustomer(int customerId)
        {
            var orders = _mongoCollection.Find(p => p.CustomerId == customerId).ToList();

            if (orders == null || orders.Count == 0)
            {
                throw new Exception("Cliente não possui pedidos.");
            }

            return new OrderByCustomerDTO
            {
                Id = orders.Select(order => order.Id).ToList(),
                QtdeOrders = orders.Count()
            };

        }
        #endregion
    }
}
