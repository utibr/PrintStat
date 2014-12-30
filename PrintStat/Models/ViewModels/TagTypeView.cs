using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrintStat.Models.ViewModels
{
    public class TagTypeView
    {
        public int ID { get; set; }
        [Display(Name = "Тег")]
        [Required(ErrorMessage = "Введите тип тега")]
        public string Type { get; set; }
    }
}