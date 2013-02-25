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

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderComment> OrderComments { get; set; }

        public DbSet<Message> Messages { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasMany(account => account.Orders).WithRequired(order => order.Account).WillCascadeOnDelete();
            modelBuilder.Entity<Order>().HasMany(order => order.OrderComments).WithRequired(comment => comment.Order).WillCascadeOnDelete(false);
        }
    }
}
