namespace Lemon.WebApp.Services
{
    using System.Linq;
    using System.Web;
    using System.Web.Security;

    using Lemon.DataAccess.DomainModels;
    using Lemon.DataAccess.Repositories;

    public class AuthService : IAuthService
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

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public Account GetCurrentUser()
        {
            var context = HttpContext.Current;
            var identity = context.User.Identity;
            if (!identity.IsAuthenticated)
            {
                return null;
            }
            var email = identity.Name;
            return accountRepository.GetByEmail(email);
        }
    }
}