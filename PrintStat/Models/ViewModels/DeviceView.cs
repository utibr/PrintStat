using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintStat.Models.ViewModels
{
    public class DeviceView: BaseView
    {
        public int DeviceTypeID { get; set; }
        public int PrintKindID { get; set; }

        public string SearchString { get; set; }

        public string InvNumber { get; set; }

        public bool StatisticsSupported { get; set; }
    }
}