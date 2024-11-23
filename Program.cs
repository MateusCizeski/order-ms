using Consumer;
using domain;
using MongoDB.Driver;
using Producer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<RabbitProducer>();
builder.Services.AddSingleton<RabbitConsumer>();

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

var producer = new RabbitProducer();
producer.SendMessage("Teste de mensagem para o RabbitMQ!");

var app = builder.Build();

var rabbitConsumer = app.Services.GetRequiredService<RabbitConsumer>();
_ = Task.Run(() => rabbitConsumer.ConsumerMessageAsync());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
