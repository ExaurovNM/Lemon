namespace Lemon.DataAccess.Repositories
{
    using Lemon.DataAccess.Context;
    using Lemon.DataAccess.DomainModels;

    public interface IAccountRepository
    {
        void Create(string email, string password);
    }

    public class AccountRepository : IAccountRepository
    {
        public void Create(string email, string password)
        {
            using (var context = new DataBaseContext())
            {
                var account = new Account { Email = email, PasswordHash = password };
                context.Accounts.Add(account);
                context.SaveChanges();
            }
        }
    }
}
