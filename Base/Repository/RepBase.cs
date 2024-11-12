using MongoDB.Driver;

namespace order_ms
{
    public class RepBase<T> : IRepBase<T>
    {
        private readonly IMongoCollection<T> _collection;

        public RepBase(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            _collection = database.GetCollection<T>(collectionName);
        }
    }
}
