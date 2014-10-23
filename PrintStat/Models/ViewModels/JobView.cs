using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PrintStat.Models.Validation;
using DataAnnotationsExtensions;


namespace PrintStat.Models.ViewModels
{
    public class JobView: BaseView
    {

        public int DeviceID { get; set; } //PrinterID
        public int ApplicationID { get; set; }
        public int? Duration { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public string UserTabNumber { get; set; }
        public int Pages { get; set; }
        public int Copies { get; set; }
        public decimal Width_cm { get; set; }
        public decimal Height_cm { get; set; }
        public int? Width_px { get; set; }
        public int? Height_px { get; set; }
        public int? SizePaperID { get; set; }
        public string AuthorTabNumber { get; set; }
        public int? Size_kb { get; set; }
        public string IP { get; set; }
        public string ComputerName { get; set; }

        public bool IsManual { get; set; }
    }
}