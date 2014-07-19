using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintStat.Models.ViewModels
{
    public class ReportSettingsView 
    {
        public string EmployeeTabNumber { get; set; }
        public int ApplicationID { get; set; }
        public string AuthorTabNumber { get; set; }
        public int DepartmentID { get; set; }

        public int PrinterID { get; set; }
    }
}