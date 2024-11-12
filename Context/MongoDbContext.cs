using MongoDB.Driver;
using order_ms.Models;

namespace order_ms.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
    }
}
