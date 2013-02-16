namespace Lemon.WebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Display(Name = "Емейл")]
        [Required(ErrorMessage = "Введите емейл")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля {1} символов")]
        public string Password { get; set; }
   
        [Display(Name = "Повторите пароль")]
        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }
    }
}