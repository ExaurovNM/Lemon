namespace Lemon.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;

    public interface IAccountRepository
    {
        void Create(string email, string password);

        IEnumerable<Account> Items();
    }
}
