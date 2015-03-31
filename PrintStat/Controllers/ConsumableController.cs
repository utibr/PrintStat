using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrintStat.Models.ViewModels;

namespace PrintStat.Controllers
{
    public class СonsumableController : BaseController
    {
        //
        // GET: /CartridgeColor/

        private void initViewBag()
        {
            ViewBag.TypeConsumable = Repository.TypeConsumables;
            ViewBag.CartridgeColor = Repository.CartridgeColors;
        }
        public ActionResult Index()
        {
            var _Component = Repository.Сonsumables.ToList();
            return View(_Component);
        }

        [HttpGet]
        public ActionResult CreateСonsumable()
        {
            initViewBag();
            var newComponentView = new СonsumableView();
            return View(newComponentView);
        }

        [HttpPost]
        public ActionResult CreateСonsumable(СonsumableView _ComponentView)
        {
            var anyComponent = Repository.Сonsumables.Any(p => string.Compare(p.Name, _ComponentView.Name) == 0);
            if (anyComponent)
            {
                ModelState.AddModelError("Name", "Component с таким наименованием уже существует");
            }

            if (ModelState.IsValid)
            {

                var _Component = (Сonsumable)ModelMapper.Map(_ComponentView, typeof(СonsumableView), typeof(Сonsumable));
                Repository.CreateСonsumable(_Component);
                return RedirectToAction("Index");
            }

            return View(_ComponentView);
        }

        [HttpGet]
        public ActionResult EditСonsumable(int? id)
        {
            initViewBag();
            var _Component = Repository.Сonsumables.FirstOrDefault(p => p.ID == id);
            if (_Component != null)
            {
                var _ComponentView =
                    (СonsumableView)ModelMapper.Map(_Component, typeof(Сonsumable), typeof(СonsumableView));
                return View(_ComponentView);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditСonsumable(СonsumableView _ComponentView)
        {
            if (ModelState.IsValid)
            {
                var _Component = Repository.Сonsumables.FirstOrDefault(p => p.ID == _ComponentView.ID);
                ModelMapper.Map(_ComponentView, _Component, typeof(СonsumableView), typeof(Сonsumable));
                Repository.UpdateСonsumable(_Component);

                return RedirectToAction("Index");
            }

            return View(_ComponentView);
        }


        [HttpGet]
        public ActionResult DeleteСonsumable(int? id)
        {
            var _Component = Repository.Сonsumables.FirstOrDefault(p => p.ID == id);
            if (_Component != null)
            {
                Repository.RemoveСonsumable(_Component);
            }
            return RedirectToAction("Index");
        }

    }
}
        
