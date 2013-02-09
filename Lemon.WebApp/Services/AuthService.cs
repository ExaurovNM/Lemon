namespace Lemon.WebApp.Services
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Security;

    using Lemon.Common;
    using Lemon.DataAccess.DomainModels;
    using Lemon.DataAccess.Repositories;

    public class AuthService : IAuthService
    {
        
        private readonly IAccountRepository accountRepository;
        private readonly ICriptoProvider criptoProvider;

        public AuthService(IAccountRepository accountRepository, ICriptoProvider criptoProvider)
        {
            this.accountRepository = accountRepository;
            this.criptoProvider = criptoProvider;
        }

        public void CreateAccount(string email, string password)
        {
            var existingAccount = accountRepository.GetByEmail(email);
            if (existingAccount != null)
            {
               throw new ArgumentException("Email is already used");
            }

            var salt = Guid.NewGuid().ToString();
            var account = new Account
                {
                    Email = email, 
                    PasswordHash = criptoProvider.ComputeHash(password, salt), 
                    Salt = salt
                };
            accountRepository.Create(account);
        }

        public void Logon(string email, bool remember = false)
        {
            FormsAuthentication.SetAuthCookie(email, remember);
        }

        public bool Validate(string email, string password)
        {
            var account = accountRepository.GetByEmail(email);
            if (account == null)
            {
                return false;
            }
            var hashedPassword = criptoProvider.ComputeHash(password, account.Salt);
            return hashedPassword == account.PasswordHash;
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