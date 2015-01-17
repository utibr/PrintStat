using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintStat.Models.ViewModels
{
    public class DeviceView: BaseView
    {
        public int ModelID { get; set; }
        public string Sn { get; set; }
        public string Version { get; set; }
        public string SearchString { get; set; }
        public string InvNumber { get; set; }
        public bool StatisticsSupported { get; set; }
    }
}