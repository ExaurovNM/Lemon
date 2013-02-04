namespace Lemon.DataAccess.Context
{
    using System.Data.Entity;

    using Lemon.DataAccess.DomainModels;

    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("LemonDB")
        {
        }

        public DbSet<Account> Accounts { get; set; }  
    }
}
