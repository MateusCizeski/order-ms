using Microsoft.AspNetCore.Mvc;
using order_ms.Services;

[ApiController]
[Route("api/order")]
public class MongoDbController : ControllerBase
{
    private readonly MongoDbService _mongoDbService;

    public MongoDbController(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }
}
