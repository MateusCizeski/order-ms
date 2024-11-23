using Consumer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class RabbitConsumerService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public RabbitConsumerService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var rabbitConsumer = scope.ServiceProvider.GetRequiredService<RabbitConsumer>();
            await rabbitConsumer.ConsumerMessageAsync();
        }
    }
}
