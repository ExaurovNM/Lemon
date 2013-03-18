namespace Lemon.DataAccess.Repositories
{
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;

    public interface IAccountRepository
    {
        IEnumerable<Account> Items();

        Account GetByUserName(string email);

        void Create(Account account);

        Account GetById(int id);

        Account GetByEmail(string email);
    }
}
