using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrintStat.Models.ViewModels
{
    public class СonsumableView : BaseView
    {
        [Display(Name = "Рабочий ресурс")]
        public int Endurance { get; set; }

        [Display(Name = "Короткое название")]
        public string ShortName { get; set; }
    }
}
