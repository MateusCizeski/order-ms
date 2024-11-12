using order_ms;
using order_ms.Models;
using order_ms.Services;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var databaseName = "orderms";
var collectionName = "Orders";

builder.Services.AddScoped<RepBase<Order>>(sp =>
    new RepBase<Order>(mongoConnectionString, databaseName, collectionName));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MongoDbService>();

var app = builder.Build();

var mongoDbService = app.Services.GetRequiredService<MongoDbService>();

mongoDbService.CreateIndexOnCustomerId();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
