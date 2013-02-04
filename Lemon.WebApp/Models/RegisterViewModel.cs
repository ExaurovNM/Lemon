namespace Lemon.WebApp.Models
{
    using Lemon.DataAccess.DomainModels;

    public class RegisterViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}