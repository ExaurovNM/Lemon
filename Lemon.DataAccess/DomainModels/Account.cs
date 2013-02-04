namespace Lemon.DataAccess.DomainModels
{
    public class Account
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}
