using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrintStat.Models.ViewModels;

namespace PrintStat.Controllers
{

    public class TagController : BaseController
    {
        //
        // GET: /CartridgeColor/

        public ActionResult Index()
        {
            var _Tag = Repository.Tags.ToList();
            return View(_Tag);
        }

        [HttpGet]
        public ActionResult CreateTag()
        {
            var newTagView = new TagView();
            return View(newTagView);
        }

        [HttpPost]
        public ActionResult CreateTag(TagView _TagView)
        {
            var anyTag = Repository.Tags.Any(p => string.Compare(p.Name, _TagView.Name) == 0);
            if (anyTag)
            {
                ModelState.AddModelError("Name", "Tag с таким наименованием уже существует");
            }

            if (ModelState.IsValid)
            {

                var _Tag = (Tag)ModelMapper.Map(_TagView, typeof(TagView), typeof(Tag));
                Repository.CreateTag(_Tag);
                return RedirectToAction("Index");
            }

            return View(_TagView);
        }

        [HttpGet]
        public ActionResult EditTag(int? id)
        {
            var _Tag = Repository.Tags.FirstOrDefault(p => p.ID == id);
            if (_Tag != null)
            {
                var _TagView = (TagView)ModelMapper.Map(_Tag, typeof(Tag), typeof(TagView));
                return View(_TagView);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditTag(TagView _TagView)
        {
            if (ModelState.IsValid)
            {
                var _Tag = Repository.Tags.FirstOrDefault(p => p.ID == _TagView.ID);
                ModelMapper.Map(_TagView, _Tag, typeof(TagView), typeof(Tag));
                Repository.UpdateTag(_Tag);

                return RedirectToAction("Index");
            }

            return View(_TagView);
        }


        [HttpGet]
        public ActionResult DeleteTag(int? id)
        {
            var _Tag = Repository.Tags.FirstOrDefault(p => p.ID == id);
            if (_Tag != null)
            {
                Repository.RemoveTag(_Tag);
            }
            return RedirectToAction("Index");
        }

    }
        
}
