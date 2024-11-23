using domain;

namespace Application
{
    public interface IMapperOrder
    {
        void MapperEditOrder(Order order, EditOrderDTO dto);
    }
}
