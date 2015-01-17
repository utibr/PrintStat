using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrintStat.Models.ViewModels;

namespace PrintStat.Controllers
{
        public class ModelController : BaseController
        {
            //
            // GET: /CartridgeColor/
            

            public ActionResult Index()
            {
                var _Model = Repository.Models.ToList();
                return View(_Model);
            }


            private void InitViewBag()
            {
                ViewBag.DeviceTypes = Repository.DeviceTypes;
                ViewBag.PrintKinds = Repository.PrintKinds;
                ViewBag.Manufacturers = Repository.Manufacturers;
                ViewBag.Tags = Repository.Tags;

            }
            [HttpGet]
            public ActionResult CreateModel()
            {
                InitViewBag();
                var newModelView = new ModelView();
                return View(newModelView);
            }

            [HttpPost]
            public ActionResult CreateModel(ModelView _ModelView)
            {
                var anyModel = Repository.Models.Any(p => string.Compare(p.Name, _ModelView.Name) == 0);
                if (anyModel)
                {
                    ModelState.AddModelError("Name", "Модель с таким наименованием уже существует");
                }

                if (ModelState.IsValid)
                {

                    var _Model = (Model)ModelMapper.Map(_ModelView, typeof(ModelView), typeof(Model));
                    Repository.CreateModel(_Model);
                    return RedirectToAction("Index");
                }

                return View(_ModelView);
            }

            [HttpGet]
            public ActionResult EditModel(int? id)
            {
                InitViewBag();
                var _Model = Repository.Models.FirstOrDefault(p => p.ID == id);
                if (_Model != null)
                {
                    var _ModelView = (ModelView)ModelMapper.Map(_Model, typeof(Model), typeof(ModelView));
                    return View(_ModelView);
                }
                return RedirectToAction("Index");
            }

            [HttpPost]
            public ActionResult EditModel(ModelView _ModelView)
            {
                if (ModelState.IsValid)
                {
                    var _Model = Repository.Models.FirstOrDefault(p => p.ID == _ModelView.ID);
                    ModelMapper.Map(_ModelView, _Model, typeof(ModelView), typeof(Model));
                    Repository.UpdateModel(_Model);

                    return RedirectToAction("Index");
                }

                return View(_ModelView);
            }


            [HttpGet]
            public ActionResult DeleteModel(int? id)
            {
                var _Model = Repository.Models.FirstOrDefault(p => p.ID == id);
                if (_Model != null)
                {
                    Repository.RemoveModel(_Model);
                }
                return RedirectToAction("Index");
            }

        }
        
    }

