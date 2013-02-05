namespace Lemon.DataAccess.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.DataAccess.Context;
    using Lemon.DataAccess.DomainModels;

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

        public IEnumerable<Account> Items()
        {
            using (var context = new DataBaseContext())
            {
                return context.Accounts.ToList();
            }
        }
    }
}