namespace Lemon.WebApp.Models
{
    using Lemon.DataAccess.DomainModels;

    public class ProfileViewModel
    {
        public ProfileViewModel(Account user, bool isEditable,int userId)
        {
            this.IsExist = user != null;
            this.IsEditable = isEditable;
            this.userId = userId;
        }

        public bool IsEditable { get; set; }

        public bool IsExist { get; set; }

        public int userId { get; set; }
    }
}