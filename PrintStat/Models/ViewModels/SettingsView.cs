using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintStat.Models.ViewModels
{
    public class SettingsView: BaseView
    {
        public string AccountName 
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }


        public string MailServer { get; set; }
        public string Pwd { get; set; }

        public string Protocol { get; set; }
        public string TabNumber { get; set; }
        public int Port { get; set; }
    }
}