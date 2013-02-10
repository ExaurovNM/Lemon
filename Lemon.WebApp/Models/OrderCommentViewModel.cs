namespace Lemon.WebApp.Models
{
    using System;

    using Lemon.DataAccess.DomainModels;

    public class OrderCommentViewModel
    {
        public OrderCommentViewModel(OrderComment comment)
        {
            this.Comment = comment.Comment;
            this.CreationTime = comment.CreatedTime;
        }

        public string Comment { get; set; }

        public DateTime CreationTime { get; set; }
    }
}