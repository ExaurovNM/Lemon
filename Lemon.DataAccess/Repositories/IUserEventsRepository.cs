namespace Lemon.DataAccess.Repositories
{
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;

    public interface IUserEventsRepository
    {
        void Save(UserEvent userEvent);

        IList<UserEvent> GetByUserId(int userId);
    }
}
