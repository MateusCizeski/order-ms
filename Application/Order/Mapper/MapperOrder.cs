using domain;

namespace Application
{
    public class MapperOrder : IMapperOrder
    {
        public void MapperEditOrder(Order order, EditOrderDTO dto)
        {
            order.CustomerId = dto.CustumerId;
        }
    }
}
