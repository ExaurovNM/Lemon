namespace Lemon.DataAccess.Repositories
{
    using Lemon.DataAccess.DomainModels;

    public interface IUserEventsRepository
    {
        void Save(UserEvent userEvent);
    }
}
