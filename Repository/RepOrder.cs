using order_ms.Models;

namespace order_ms.Repository
{
    public class RepOrder : RepBase<Order>, IRepOrder
    {
        public RepOrder(string connectionString, string databaseName, string collectionName) : base(connectionString, databaseName, collectionName)
        {
        }
    }
}
