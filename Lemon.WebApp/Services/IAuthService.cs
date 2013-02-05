namespace Lemon.WebApp.Services
{
    public interface IAuthService
    {
        void CreateAccount(string email, string password);

        void Logon(string email, bool remember = false);

        bool Validate(string email, string password);
    }
}