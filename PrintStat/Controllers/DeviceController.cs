using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrintStat.Models.ViewModels;

namespace PrintStat.Controllers
{
    public class DeviceController : BaseController
    {
        //



        public ActionResult Index()
        {
                var printers = Repository.PrintersAndPlotters.ToList();
                return View(printers);
        }


        private void InitViewBag()
        {
            ViewBag.Models = Repository.Models;

        }
        [HttpGet]
        public ActionResult CreateDevice()
        {
            InitViewBag();
            var newPrintView = new DeviceView ();
            return View(newPrintView);
        }

        public int? AddManufacturer(string name)
        {
            if (name == null) return null;
            int? id = Repository.CheckManufacturer(name);
            if (id == 0)
            {
                Manufacturer insence = new Manufacturer()
                {
                    Name = name
                };
                Repository.CreateManufacturer(insence);
                id = insence.ID;
            }
            return id;
        }

        [HttpPost]
        public ActionResult CreateDevice(DeviceView  printerView)
        {
            InitViewBag();
            var anyPrinter = Repository.PrintersAndPlotters.Any(p => string.Compare(p.Name, printerView.Name)==0);  
            if (anyPrinter)
            {
                ModelState.AddModelError("Name", "Принтер с таким наименованием уже существует");
            }

            if (ModelState.IsValid)
            {
                AddManufacturer(printerView.Manufacturer);

                var printer = (Device)ModelMapper.Map(printerView, typeof(DeviceView), typeof(Device));
                Repository.CreatePrinter(printer);
                return RedirectToAction("Index");
            }

            return View(printerView);
        }


        [HttpGet]
        public ActionResult EditDevice(int? id)
        {
            InitViewBag();
            var printer = Repository.PrintersAndPlotters.FirstOrDefault(p => p.ID == id);
            if (printer != null)
            {
                var printerView = (DeviceView)ModelMapper.Map(printer, typeof(Device), typeof(DeviceView));
                return View(printerView);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditDevice(DeviceView printerView)
        {
            if (ModelState.IsValid)
            {
                var printer = Repository.PrintersAndPlotters.FirstOrDefault(p => p.ID == printerView.ID);
                ModelMapper.Map(printerView, printer, typeof(DeviceView), typeof(Device));
                Repository.UpdatePrinter(printer);

                return RedirectToAction("Index");
            }

            return View(printerView);
        }


        [HttpGet]
        public ActionResult DeleteDevice(int? id)
        {
            var printer = Repository.PrintersAndPlotters.FirstOrDefault(p => p.ID == id);
            if (printer != null)
            {
                Repository.RemovePrinter(printer);
            }
            return RedirectToAction("Index");
        }
    }

}
