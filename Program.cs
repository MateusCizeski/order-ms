using MongoDB.Driver;
using order_ms.Application;
using order_ms.Consumer;
using order_ms.Models;
using order_ms.Producer;
using order_ms.Repository;
using order_ms.Service;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var databaseName = "orderms";
var collectionName = "Orders";

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(databaseName);
var mongoCollection = mongoDatabase.GetCollection<Order>(collectionName);

builder.Services.AddSingleton(mongoCollection);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var consumer = new Consumer();
await consumer.ConsumerMessageAsync();

var producer = new Producer();
await producer.ProduceMessageAsync();

builder.Services.AddScoped<IRepOrder, RepOrder>();
builder.Services.AddScoped<IServOrder, ServOrder>();
builder.Services.AddScoped<IAplicOrder, AplicOrder>();
builder.Services.AddScoped<IMapperOrder, MapperOrder>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
