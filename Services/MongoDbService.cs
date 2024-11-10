using MongoDB.Driver;
using order_ms.Models;

namespace order_ms.Services
{
    public class MongoDbService
    {
        private IMongoDatabase _mongoDatabase;

        public MongoDbService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var client = new MongoClient(connectionString);
            _mongoDatabase = client.GetDatabase("orderms");
        }

        public IMongoCollection<Order> GetOrderCollection()
        {
            return _mongoDatabase.GetCollection<Order>("Orders");
        }

        public void CreateIndexOnCustomerId()
        {
            var indexKeysDefinition = Builders<Order>.IndexKeys.Ascending(o => o.CustumerId);
            var indexOptions = new CreateIndexOptions { Unique = false };

            var indexModel = new CreateIndexModel<Order>(indexKeysDefinition, indexOptions);

            var collection = GetOrderCollection();
            collection.Indexes.CreateOne(indexModel);
        }
    }
}
