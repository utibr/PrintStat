using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using PrintStat.Models;
using System.Web.Mvc;
using PrintStat.Mappers;

namespace PrintStat.Controllers
{
    public class BaseController: Controller
    {
        [Inject]
        public IRepository Repository { get; set; }

        [Inject]
        public IMapper ModelMapper { get; set; }
    }
}