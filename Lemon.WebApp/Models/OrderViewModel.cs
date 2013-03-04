namespace Lemon.WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.Common;
    using Lemon.DataAccess.DomainModels;

    public class OrderViewModel
    {
        public OrderViewModel()
        {
        }

        public OrderViewModel(Order order)
        {
            if (order == null)
            {
                return;
            }
            this.OwnerId = order.AccountId;
            this.Title = order.Title;
            this.Content = order.Content;
            this.OwnerDisplayName = order.Account.Email;
            this.CreatedTime = order.CreatedTime;
            this.Id = order.Id;
            this.ProbableCost = order.ProbableCost;
            this.Comments = order.OrderComments == null
                                ? null
                                : order.OrderComments.Select(comment => new OrderCommentViewModel(comment)).ToList();
            this.OrderStatus = order.Status;
        }

        public IList<OrderCommentViewModel> Comments { get; set; }

        public int OwnerId { get; set; }

        public string OwnerDisplayName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public decimal ProbableCost { get; set; }

        public DateTime CreatedTime { get; set; }

        public string CreatedTimeOut
        {
            get
            {
                return DateTimeHelper.GetOutTime(this.CreatedTime);
            }
        }

        public int Id { get; set; }

        public bool IsOwnOrder { get; set; }

        public int OrderStatus { get; set; }
    }
}