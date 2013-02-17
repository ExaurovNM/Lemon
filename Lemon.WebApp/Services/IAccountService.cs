namespace Lemon.WebApp.Services
{
    using Lemon.DataAccess.DomainModels;
    using Lemon.DataAccess.Repositories;

    public interface IAccountService
    {
        Account GetById(int id);
    }

    class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Account GetById(int id)
        {
            return accountRepository.GetById(id);
        }
    }
}