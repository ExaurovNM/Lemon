namespace Lemon.WebApp.Models
{
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;

    public class ProfileViewModel
    {
        public ProfileViewModel(Account user, bool isEditable,int userId, int positiveRaite, int negativeRaite, List<string> comments)
        {
            this.IsExist = user != null;
            this.IsEditable = isEditable;
            this.userId = userId;
            this.PositiveRaite = positiveRaite;
            this.NegativeRaite = negativeRaite;
            this.Comments = comments;
        }

        public bool IsEditable { get; set; }

        public bool IsExist { get; set; }

        public int userId { get; set; }

        public int PositiveRaite { get; set; }

        public int NegativeRaite { get; set; }

        public List<string> Comments { get; set; } 
    }
}