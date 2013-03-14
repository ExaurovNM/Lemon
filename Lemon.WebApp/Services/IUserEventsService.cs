namespace Lemon.WebApp.Services
{
    using Lemon.DataAccess.DomainModels;

    public interface IUserEventsService
    {
        void AddEvent(Order order);

        void AddEvent(OrderComment orderComment, int accountId);
    }
}