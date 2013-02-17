namespace Lemon.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;

    public interface IAccountRepository
    {
        IEnumerable<Account> Items();

        Account GetByEmail(string email);

        void Create(Account account);

        Account GetById(int id);
    }
}
