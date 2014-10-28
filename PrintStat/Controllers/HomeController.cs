using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Ninject;
using PrintStat.Models;
using PrintStat.Models.ViewModels;


namespace PrintStat.Controllers
{
    public class HomeController : BaseController
    {
        // GET: /Paper/


        public ActionResult Index()
        {
            var Jobs = Repository.Jobs.OrderByDescending(s => s.EndTime).ToList();
            return View(Jobs);
        }

        private void InitViewBag()
        {
            ViewBag.Printers = Repository.Printers;
            ViewBag.Plotters = Repository.Plotters;
            ViewBag.Applications = Repository.Applications;
            ViewBag.PrinterPaper = Repository.PrinterPaperTypes;
            ViewBag.PlotterPapertypes = Repository.PlotterPaperTypes;
            ViewBag.AuthorEmployees = Repository.AuthorEmployees;
            ViewBag.UserEmployees = Repository.UserEmployees;
        }

        [HttpGet]
        public ActionResult CreatePrinterJob()
        {

            InitViewBag();
            var newJobView = new JobView();
            newJobView.StartTime = DateTime.Now;
            newJobView.EndTime = DateTime.Now;
            newJobView.Duration = 0;
            newJobView.Pages = 1;
            newJobView.Copies = 1;
            newJobView.SizePaperID = 0;
            newJobView.IsManual = true;

            return View(newJobView);
        }

        public ActionResult CreatePlotterJob()
        {

            InitViewBag();
            var newJobView = new JobView();
            newJobView.StartTime = DateTime.Now;
            newJobView.EndTime = DateTime.Now;
            newJobView.Duration = 0;
            newJobView.Pages = 1;
            newJobView.Copies = 1;
            newJobView.SizePaperID = 0;
            newJobView.IsManual = true;

            return View(newJobView);
        }

        [HttpPost]
        public ActionResult CreateJob(JobView JobView)
        {
            var anyJob = Repository.Jobs.Any(p => string.Compare(p.Name, JobView.Name) == 0);
            if (anyJob)
            {
                ModelState.AddModelError("Name", "Тип бумаги с таким наименованием уже существует");
            }

            if (ModelState.IsValid)
            {
                var Job = (Job)ModelMapper.Map(JobView, typeof(JobView), typeof(Job));
                Repository.CreateJob(Job);
                return RedirectToAction("Index");
            }

            return View(JobView);
        }


        [HttpGet]
        public ActionResult EditPrinterJob(int? id)
        {


            var Job = Repository.Jobs.FirstOrDefault(p => p.ID == id);
            if (Job != null)
            {
                InitViewBag();
                var JobView = (JobView)ModelMapper.Map(Job, typeof(Job), typeof(JobView));
                return View(JobView);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditPlotterJob(int? id)
        {


            var Job = Repository.Jobs.FirstOrDefault(p => p.ID == id);
            if (Job != null)
            {
                InitViewBag();
                var JobView = (JobView)ModelMapper.Map(Job, typeof(Job), typeof(JobView));
                return View(JobView);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditJob(JobView JobView)
        {
            if (ModelState.IsValid)
            {
                var Job = Repository.Jobs.FirstOrDefault(p => p.ID == JobView.ID);
                ModelMapper.Map(JobView, Job, typeof(JobView), typeof(Job));
                Repository.UpdateJob(Job);

                return RedirectToAction("Index");
            }

            return View(JobView);
        }


        [HttpGet]
        public ActionResult DeleteJob(int? id)
        {
            var Job = Repository.Jobs.FirstOrDefault(p => p.ID == id);
            if (Job != null)
            {
                Repository.RemoveJob(Job);
            }
            return RedirectToAction("Index");
        }
    

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

     
    }
}
