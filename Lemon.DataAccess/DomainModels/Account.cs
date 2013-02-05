namespace Lemon.DataAccess.DomainModels
{
    using System.Collections.Generic;

    public class Account : BaseEntity
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
