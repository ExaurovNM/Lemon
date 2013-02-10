namespace Lemon.DataAccess.DomainModels
{
    using System;

    public class OrderComment : BaseEntity
    {
        public Account Author { get; set; }

        public int AuthorId { get; set; }

        public string Comment { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
