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
            this.Cost = comment.ProposedCost;
            this.AuthorId = comment.AuthorId;
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

        public int AuthorId { get; set; }
        
        public string AuthorEmail { get; set; }
    }
}