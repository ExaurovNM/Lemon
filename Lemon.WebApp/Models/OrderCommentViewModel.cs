namespace Lemon.WebApp.Models
{
    using System;

    using Lemon.Common;
    using Lemon.DataAccess.DomainModels;

    public class OrderCommentViewModel
    {
        public OrderCommentViewModel(OrderComment comment)
        {
            this.Comment = comment.Comment;
            this.CreationTime = comment.CreatedTime;
            Cost = comment.ProposedCost;
        }

        public string Comment { get; set; }

        public DateTime CreationTime { get; set; }

        public decimal Cost { get; set; }

        public string CreationTimeOut
        {
            get
            {
                return DateTimeHelper.GetOutTime(CreationTime);
            }
        }
    }
}