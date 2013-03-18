namespace Lemon.WebApp.Services
{
    using Lemon.DataAccess.DomainModels;

    public interface IAuthService
    {
        void CreateAccount(string userName, string email, string password);

        void Logon(string email, bool remember = false);

        bool Validate(string email, string password);

        void Logout();

        Account GetCurrentUser();

        int? GetCurrentUserId();
    }
}