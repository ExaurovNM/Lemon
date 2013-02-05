namespace Lemon.WebApp.Services
{
    using System.Linq;
    using System.Web.Security;

    using Lemon.DataAccess.Repositories;

    class AuthService : IAuthService
    {
        private readonly IAccountRepository accountRepository;

        public AuthService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public void CreateAccount(string email, string password)
        {
            accountRepository.Create(email, password);
        }

        public void Logon(string email, bool remember = false)
        {
            FormsAuthentication.SetAuthCookie(email, remember);
        }

        public bool Validate(string email, string password)
        {
            var accounts = accountRepository.Items();
            return accounts.Any(account => account.Email == email && account.PasswordHash == password);
        }
    }
}