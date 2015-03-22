using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrintStat.Models.ViewModels
{
    public class DeviceView: BaseView
    {
        private  List<Model> _model =new List<Model>();

        public List<Model> models
        {
            get { return _model; }
        }

    [Required(ErrorMessage = "Пожалуйста введите производителя")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "Пожалуйста выберите модель")]
        public int ModelID { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите серийный номер")]
        public string Sn { get; set; }
        
        public string SearchString { get; set; }
        public string InvNumber { get; set; }
        public bool StatisticsSupported { get; set; }
    }
}