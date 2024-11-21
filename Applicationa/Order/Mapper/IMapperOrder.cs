using order_ms.DTOs;
using order_ms.Models;

namespace order_ms.Application
{
    public interface IMapperOrder
    {
        void MapperEditOrder(Order order, EditOrderDTO dto);
    }
}
