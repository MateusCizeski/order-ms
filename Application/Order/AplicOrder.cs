﻿using domain;
using services;

namespace Application
{
    public class AplicOrder : IAplicOrder
    {
        #region Ctor
        private readonly IServOrder _servOrder;
        private readonly IMapperOrder _mapperOrder;

        public AplicOrder(IServOrder servOrder, IMapperOrder mapperOrder)
        {
            _servOrder = servOrder;
            _mapperOrder = mapperOrder;
        }
        #endregion

        #region EditOrder
        public Order EditOrder(EditOrderDTO dto)
        {
            var order = _servOrder.GetOrderById(dto.Id);

            _mapperOrder.MapperEditOrder(order, dto);

            _servOrder.EditOrder(order);

            return order;

        }
        #endregion

        #region InsertOrder
        public Order InsertOrder(Order order)
        {
            var result = _servOrder.InsertOrder(order);

            return result;
        }
        #endregion

        #region GetOrderById
        public Order GetOrderById(int id)
        {
            var order = _servOrder.GetOrderById(id);

            return order;
        }
        #endregion

        #region ListOrders
        public List<Order> ListOrders()
        {
            var orders = _servOrder.ListOrders();

            return orders;
        }
        #endregion

        #region DeleteOrder
        public void DeleteOrder(int id)
        {
            _servOrder.DeleteOrder(id);
        }
        #endregion

        #region GetOrderByCustomerId
        public List<Order> GetOrderByCustomerId(int customerId)
        {
            var orders = _servOrder.GetOrderByCustomerId(customerId);

            return orders;
        }
        #endregion

        #region GetPriceTotalOrder
        public PriceTotalOrderDTO GetPriceTotalOrder(int Id)
        {
            var dto = _servOrder.GetPriceTotalOrder(Id);

            return dto;
        }
        #endregion

        #region OrderByCustomer
        public OrderByCustomerDTO OrderByCustomer(int customerId)
        {
            var dto = _servOrder.OrderByCustomer(customerId);

            return dto;
        }
        #endregion
    }
}
