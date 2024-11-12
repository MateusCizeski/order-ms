using MongoDB.Driver;
using order_ms.Application;
using order_ms.Models;
using order_ms.Repository;
using order_ms.Service;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var databaseName = "orderms";
var collectionName = "Orders";

//builder.Services.AddScoped<RepBase<Order>>(sp =>
//    new RepBase<Order>(mongoConnectionString, databaseName, collectionName));

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(databaseName);
var mongoCollection = mongoDatabase.GetCollection<Order>(collectionName);

builder.Services.AddSingleton(mongoCollection);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepOrder, RepOrder>();
builder.Services.AddScoped<IServOrder, ServOrder>();
builder.Services.AddScoped<IAplicOrder, AplicOrder>();

//builder.Services.AddSingleton<MongoDbService>();

var app = builder.Build();

//var mongoDbService = app.Services.GetRequiredService<MongoDbService>();

//mongoDbService.CreateIndexOnCustomerId();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
