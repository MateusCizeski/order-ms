﻿using order_ms.Models;

namespace order_ms.Repository
{
    public interface IRepOrder
    {
        Order InsertOrder(Order order);
        Order GetOrderById(int Id);
        Order EditOrder(Order order);
        List<Order> ListOrders();
        void DeleteOrder(int id);
    }
}
