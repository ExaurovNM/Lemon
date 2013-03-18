namespace Lemon.DataAccess.DomainModels
{
    using System.Collections.Generic;

    public class Account : BaseEntity
    {
        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public virtual List<Order> Orders { get; set; }

        public string Salt { get; set; }

        public virtual IList<Message> Messages { get; set; }

        public string Email { get; set; }
    }
}
