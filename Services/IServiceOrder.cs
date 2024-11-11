using order_ms.DTOs;

namespace order_ms.Services
{
    public interface IServiceOrder
    {
        void Save(OrderCreatedEvent order);
    }
}
