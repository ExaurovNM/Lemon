namespace Lemon.WebApp.Services
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Script.Serialization;
    using System.Web.Security;

    using Lemon.Common;
    using Lemon.DataAccess.DomainModels;
    using Lemon.DataAccess.Repositories;
    using Lemon.WebApp.WebHelpers;

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
            var account = accountRepository.GetByEmail(email);
            if (account != null)
            {
                Logon(account, remember);
            }
        }

        public void Logon(Account account, bool remember = false)
        {
            var serializeModel = new CustomPrincipalSerializeModel
                {
                    Email = account.Email, 
                    Id = account.Id
                };

            var serializer = new JavaScriptSerializer();

            var userData = serializer.Serialize(serializeModel);

            var authTicket = new FormsAuthenticationTicket(
                     1,
                     account.Email,
                     DateTime.Now,
                     DateTime.Now.AddMinutes(15),
                     remember,
                     userData);
            
            var encTicket = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
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
            var identity = (ICustomPrincipal)context.User;
            if (!identity.Identity.IsAuthenticated)
            {
                return null;
            }
            return accountRepository.GetById(identity.Id);
        }
    }
}