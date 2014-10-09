using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrintStat.Models.ViewModels;

namespace PrintStat.Controllers
{
    public class PrinterController : BaseController
    {
        //

        public ActionResult Index()
        {
            var printers = Repository.PrintersAndPlotters.ToList();
            return View(printers);
        }


        private void InitViewBag()
        {
            ViewBag.DeviceTypes = Repository.DeviceTypes;
            ViewBag.PrintKinds = Repository.PrintKinds;
        }
        [HttpGet]
        public ActionResult CreatePrinter()
        {
            InitViewBag();
            var newPaperView = new PrinterView ();
            return View(newPaperView);
        }


        [HttpPost]
        public ActionResult CreatePrinter(PrinterView  printerView)
        {
            var anyPrinter = Repository.PrintersAndPlotters.Any(p => string.Compare(p.Name, printerView.Name)==0);  
            if (anyPrinter)
            {
                ModelState.AddModelError("Name", "Принтер с таким наименованием уже существует");
            }

            if (ModelState.IsValid) 
            {
                var printer = (Device)ModelMapper.Map(printerView, typeof(PrinterView), typeof(Device));
                Repository.CreatePrinter(printer);
                return RedirectToAction("Index");
            }

            return View(printerView);
        }


        [HttpGet]
        public ActionResult EditPrinter(int? id)
        {
            InitViewBag();
            var printer = Repository.PrintersAndPlotters.FirstOrDefault(p => p.ID == id);
            if (printer != null)
            {
                var printerView = (PrinterView)ModelMapper.Map(printer, typeof(Device), typeof(PrinterView));
                return View(printerView);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditPrinter(PrinterView printerView)
        {
            if (ModelState.IsValid)
            {
                var printer = Repository.PrintersAndPlotters.FirstOrDefault(p => p.ID == printerView.ID);
                ModelMapper.Map(printerView, printer, typeof(PrinterView), typeof(Device));
                Repository.UpdatePrinter(printer);

                return RedirectToAction("Index");
            }

            return View(printerView);
        }


        [HttpGet]
        public ActionResult DeletePrinter(int? id)
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
