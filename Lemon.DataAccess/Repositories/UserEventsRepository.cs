namespace Lemon.DataAccess.Repositories
{
    using System;

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
    }
}