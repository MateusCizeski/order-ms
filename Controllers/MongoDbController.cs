// MongoDbController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/order")]
public class MongoDbController : ControllerBase
{
    private readonly MongoDbService _mongoDbService;

    public MongoDbController(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    [HttpGet("check-connection")]
    public IActionResult CheckConnection()
    {
        bool isConnected = _mongoDbService.CheckConnection();
        if (isConnected)
        {
            return Ok("Conectado ao MongoDB com sucesso!");
        }
        else
        {
            return StatusCode(500, "Falha na conexão com o MongoDB.");
        }
    }
}
