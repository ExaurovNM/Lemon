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

        public DbSet<UserRating> UserRatings { get; set; }

        public DbSet<UserEvent> UserEvents { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasMany(account => account.Orders).WithRequired(order => order.Creater).WillCascadeOnDelete();
            modelBuilder.Entity<Order>().HasMany(order => order.OrderComments).WithRequired(comment => comment.Order).WillCascadeOnDelete(false);
            modelBuilder.Entity<Account>().HasMany(account => account.Messages).WithRequired(message => message.Receiver).WillCascadeOnDelete(false);
            modelBuilder.Entity<Account>().HasMany(account => account.Messages).WithRequired(message => message.Sender).WillCascadeOnDelete(false);
        }
    }
}
