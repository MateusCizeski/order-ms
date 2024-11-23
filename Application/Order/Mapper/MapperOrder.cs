using domain;

namespace Application
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
