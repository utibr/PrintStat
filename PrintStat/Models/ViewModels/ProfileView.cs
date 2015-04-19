using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrintStat.Models.ViewModels
{
    public class ProfileView : BaseView
    {
        //
        // GET: /CartridgeColorView/

        public string NameParametr { get; set; }
        public string Value { get; set; }
    }
}