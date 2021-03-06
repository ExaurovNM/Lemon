﻿namespace Lemon.WebApp.Services
{
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;

    public interface IUserEventsService
    {
        void AddEvent(Order order);

        void AddEvent(OrderComment orderComment, int accountId);

        IList<UserEvent> GetByUserId(int userId);
    }
}