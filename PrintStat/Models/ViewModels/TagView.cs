using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrintStat.Models.ViewModels
{
    public class TagView :BaseView
    {
        [Display(Name = "Тег")]
        [Required(ErrorMessage = "Введите тег")]
        public string Tag1 { get; set; }

        public int TagTypeID { get; set; }

    }
}