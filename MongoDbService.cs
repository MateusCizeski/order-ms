using MongoDB.Bson;
using MongoDB.Driver;

public class MongoDbService
{
    private readonly IMongoDatabase _database;

    public MongoDbService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("orderms");
    }

    public bool CheckConnection()
    {
        try
        {
            _database.RunCommand((Command<BsonDocument>)"{ping:1}");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao conectar ao MongoDB: {ex.Message}");
            return false;
        }
    }

}
