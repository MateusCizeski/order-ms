using Application;
using Consumer;
using domain;
using MongoDB.Driver;
using Producer;
using repository;
using services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<RabbitProducer>();
builder.Services.AddScoped<RabbitConsumer>();
builder.Services.AddScoped<IAplicOrder, AplicOrder>();
builder.Services.AddScoped<IRepOrder, RepOrder>();
builder.Services.AddScoped<IServOrder, ServOrder>();
builder.Services.AddScoped<IMapperOrder, MapperOrder>();

var mongoConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var databaseName = "orderms";
var collectionName = "Orders";

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(databaseName);
var mongoCollection = mongoDatabase.GetCollection<Order>(collectionName);

builder.Services.AddSingleton(mongoCollection);

builder.Services.AddHostedService<RabbitConsumerService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var producer = new RabbitProducer();
producer.SendMessage("Teste de mensagem para o RabbitMQ!");

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
