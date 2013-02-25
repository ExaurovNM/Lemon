namespace Lemon.WebApp.Models
{
    using Lemon.DataAccess.DomainModels;

    public class ProfileViewModel
    {
        public ProfileViewModel(Account user, bool isEditable)
        {
            this.IsExist = user != null;
            this.IsEditable = isEditable;
        }

        public bool IsEditable { get; set; }

        public bool IsExist { get; set; }
    }
}