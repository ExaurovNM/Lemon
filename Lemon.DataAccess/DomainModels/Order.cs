namespace Lemon.DataAccess.DomainModels
{
    using System.Collections.Generic;

    public class Order : BaseEntity
    {
        public virtual Account Creater { get; set; }

        public int CreaterId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public decimal ProbableCost { get; set; }

        public virtual List<OrderComment> OrderComments { get; set; }

        public int Status { get; set; }

        public int? EmployeeId { get; set; }
    }
}