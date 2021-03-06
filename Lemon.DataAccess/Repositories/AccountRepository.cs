namespace Lemon.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.DataAccess.Context;
    using Lemon.DataAccess.DomainModels;

    public class AccountRepository : IAccountRepository
    {
        public IEnumerable<Account> Items()
        {
            using (var context = new DataBaseContext())
            {
                return context.Accounts.ToList();
            }
        }

        public Account GetByUserName(string email)
        {
            using (var context = new DataBaseContext())
            {
                return context.Accounts.FirstOrDefault(account => account.UserName == email);
            }
        }

        public void Create(Account account)
        {
            using (var context = new DataBaseContext())
            {
                account.CreatedTime = DateTime.UtcNow;
                context.Accounts.Add(account);
                context.SaveChanges();
            }
        }

        public Account GetById(int id)
        {
            using (var context = new DataBaseContext())
            {
                return context.Accounts.FirstOrDefault(account => account.Id == id);
            }
        }

        public Account GetByEmail(string email)
        {
            using (var context = new DataBaseContext())
            {
                return context.Accounts.FirstOrDefault(account => account.Email.ToLower() == email.ToLower());
            }
        }
    }
}