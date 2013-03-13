using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lemon.WebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CompleteOrderViewModel
    {
        public int OrderId { get; set; }

        [Display(Name = "Оставьте отзыв о качестве выполнения работы")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Поставьте оценку")]
        [Display(Name = "Общая оценка")]
        public bool? Raiting { get; set; }
    }
}