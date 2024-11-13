using order_ms.DTOs;
using order_ms.Models;

namespace order_ms.Application
{
    public class MapperOrder : IMapperOrder
    {
        public void MapperEditOrder(Order order, EditOrderDTO dto)
        {
            order.CustumerId = dto.CustumerId;
            order.Total = dto.Total;
        }
    }
}
