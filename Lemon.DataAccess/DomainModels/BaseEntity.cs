namespace Lemon.DataAccess.DomainModels
{
    using System;

    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}