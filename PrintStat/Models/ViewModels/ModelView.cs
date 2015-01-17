using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrintStat.Models.ViewModels
{
    public class ModelView : BaseView
    {
        public int ManufacturerID { get; set; }
        public int DeviceTypeID { get; set; }
        public int PrintKindID { get; set; }
    }
}
