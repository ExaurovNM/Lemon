namespace Lemon.WebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LogonViewModel
    {
        [Display(Name = "Емейл")]
        [Required(ErrorMessage = "Введите емейл")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        [Display(Name = "Оставаться в системе")]
        public bool Remember { get; set; }
    }
}