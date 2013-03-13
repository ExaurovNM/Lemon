﻿namespace Lemon.DataAccess.Repositories
{
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;

    public interface IOrderRepository
    {
        void Create(Order order);

        List<Order> Items();

        Order GetById(int id);

        List<Order> GetByUserId(int id);

        void ChangeOrderStatus(int orderId, int newStatus);

        List<Order> GetByStatusId(int statusId);

        void ChangeOrderEmployee(int orderId, int? employeeId);
    }
}
