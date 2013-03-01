using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lemon.WebApp.Models
{
    public class CreateMessageModel
    {
        public int recieverId { get; set; }

        [Required(ErrorMessage = " Введите сообщение.")]
        [Display(Name = "Сообщение")]
        public string Text { get; set; }

    }
}