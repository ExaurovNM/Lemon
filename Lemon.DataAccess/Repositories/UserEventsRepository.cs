namespace Lemon.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.DataAccess.Context;
    using Lemon.DataAccess.DomainModels;

    public class UserEventsRepository : IUserEventsRepository
    {
        public void Save(UserEvent userEvent)
        {
            using (var context = new DataBaseContext())
            {
                userEvent.CreatedTime = DateTime.UtcNow;
                context.UserEvents.Add(userEvent);
                context.SaveChanges();
            }
        }

        public IList<UserEvent> GetByUserId(int userId)
        {
            using (var context = new DataBaseContext())
            {
                return context.UserEvents
                    .Where(evend => evend.EventSunscriberId == userId)
                    .OrderByDescending(evend => evend.CreatedTime).ToList();
            }
        }
    }
}