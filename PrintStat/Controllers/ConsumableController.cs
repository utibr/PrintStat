using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrintStat.Models.ViewModels;

namespace PrintStat.Controllers
{
    public class ConsumableController : BaseController
    {
        //
        // GET: /CartridgeColor/

        private void initViewBag()
        {
            ViewBag.TypeConsumable = Repository.TypeConsumables;
            ViewBag.CartridgeColor = Repository.CartridgeColors;
        }

        public int? checkCartridge(string TypeName)
        {
            return Repository.CheckCartridge(TypeName);
        }
        public ActionResult Index()
        {
            var _Component = Repository.Consumables.ToList();
            return View(_Component);
        }

        [HttpGet]
        public ActionResult CreateConsumable()
        {
            initViewBag();
            var newComponentView = new ConsumableView();
            return View(newComponentView);
        }

        [HttpPost]
        public ActionResult CreateConsumable(ConsumableView _ComponentView)
        {
            initViewBag();
            var anyComponent = Repository.Consumables.Any(p => string.Compare(p.Name, _ComponentView.Name) == 0);
            if (anyComponent)
            {
                ModelState.AddModelError("Name", "Component с" +
                                                 " таким наименованием уже существует");
            }

            if (ModelState.IsValid)
            {

                var _Component = (Consumable)ModelMapper.Map(_ComponentView, typeof(ConsumableView), typeof(Consumable));
                
                Repository.CreateConsumable(_Component);
                
                if (_ComponentView.ChosenModelIds!=null)
                {
                    Repository.CreateModelComsumable(_ComponentView.ChosenModelIds, _Component.ID);
                }
                return RedirectToAction("Index");
            }

            return View(_ComponentView);
        }

        [HttpGet]
        public ActionResult EditConsumable(int? id)
        {
            initViewBag();
            var _Component = Repository.Consumables.FirstOrDefault(p => p.ID == id);
            if (_Component != null)
            {
                var _ComponentView =(ConsumableView)ModelMapper.Map(_Component, typeof(Consumable), typeof(ConsumableView));

                var choosModelConsumable =  Repository.ModelConsumables.Where(m => m.ConsumableID == id);
                

                foreach (var item in choosModelConsumable)
                {
                    _ComponentView.Models.Add(Repository.Models.First(t => t.ID == item.ModelID));
                }
                
                return View(_ComponentView);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditConsumable(ConsumableView _ComponentView)
        {
            if (ModelState.IsValid)
            {
                var _Component = Repository.Consumables.FirstOrDefault(p => p.ID == _ComponentView.ID);
                ModelMapper.Map(_ComponentView, _Component, typeof(ConsumableView), typeof(Consumable));
                Repository.UpdateConsumable(_Component);

                return RedirectToAction("Index");
            }

            return View(_ComponentView);
        }


        [HttpGet]
        public ActionResult DeleteConsumable(int? id)
        {
            var _Component = Repository.Consumables.FirstOrDefault(p => p.ID == id);
            if (_Component != null && (Repository.CountUsesConsumble(id)==0))
            {
                Repository.RemoveConsumable(_Component);
            }
            else
            {
                
                ViewBag.Message = "Невозможно удалить комплектующий, т.к. он используется";
                return View("~/Views/Shared/ErrorView.cshtml");
            }
            return RedirectToAction("Index");
        }

    }
}
        
