using System;
using System.Collections.Generic;
using System.Linq;
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
                var model = Repository.Models.ToList();
                return View(model);
            }


            private void InitViewBag()
            {
                ViewBag.Tags = Repository.Tags;
                ViewBag.DeviceTypes = Repository.DeviceTypes;
                ViewBag.PrintKinds = Repository.PrintKinds;
                ViewBag.Manufacturers = Repository.Manufacturers;
                
                ViewBag.PaperTypes = Repository.PaperTypes;
                ViewBag.SizePapers = Repository.SizePapers;

                //ViewBag.AsignTags = Repository.ModelTags;
            }
            [HttpGet]
            public ActionResult CreateModel()
            {
                InitViewBag();
                var newModelView = new ModelView();
                int t = 5;
                return View(newModelView);
            }

            [HttpPost]
            public ActionResult CreateModel(ModelView modelView)
            {
                var anyModel = Repository.Models.Any(p => String.Compare(p.Name, modelView.Name) == 0);
                if (anyModel)
                {
                    ModelState.AddModelError("Name", "Модель с таким наименованием уже существует");
                }

                if (ModelState.IsValid)
                {

                    var model = (Model)ModelMapper.Map(modelView, typeof(ModelView), typeof(Model));
                    Repository.CreateModel(model);
                    var modelId = model.ID;
                    Repository.CreateModelTag(modelView.ChosenTagIds, modelId);
                    Repository.CreateModelPaperType(modelView.ChosenPaperTypeIds, modelId);
                    Repository.CreateModelSizePaper(modelView.ChosenSizePaperIds, modelId);
                    return RedirectToAction("Index");
                }

                return View(modelView);
            }

            [HttpGet]
            public ActionResult EditModel(int? id)
            {
                InitViewBag();
                var model = Repository.Models.FirstOrDefault(p => p.ID == id);
                if (model != null)
                {
                    var modelView = (ModelView)ModelMapper.Map(model, typeof(Model), typeof(ModelView));
                    var choosModelTag = Repository.ModelTags.Where(p => p.ModelID == id);
                    foreach (var item in choosModelTag)
                    {
                        modelView.Tags.Add(Repository.Tags.First(t=>t.ID==item.TagID));
                    }

                    var choosModelSizePaper = Repository.ModelSizePapers.Where(p => p.ModelID == id);
                    foreach (var item in choosModelSizePaper)
                    {
                        modelView.SizePapers.Add(Repository.SizePapers.First(t => t.ID == item.SizePaperID));
                    }

                    var choosModelPaperType = Repository.ModelPaperTypes.Where(p => p.ModelID == id);
                    foreach (var item in choosModelPaperType)
                    {
                        modelView.PaperTypes.Add(Repository.PaperTypes.First(t => t.ID == item.PaperTypeID));
                    }

                    return View(modelView);
                }
                return RedirectToAction("Index");
            }

            [HttpPost]
            public ActionResult EditModel(ModelView modelView)
            {
                if (ModelState.IsValid)
                {
                    var model = Repository.Models.FirstOrDefault(p => p.ID == modelView.ID);
                    ModelMapper.Map(modelView, model, typeof(ModelView), typeof(Model));
                    Repository.UpdateModel(model);
                    var modelId = modelView.ID;
                   
                    var modelTag = Repository.ModelTags.Where(mt => mt.ModelID == modelId);
                    Repository.RemoveModelTag(modelTag);
                    Repository.CreateModelTag(modelView.ChosenTagIds, modelId);

                    var modelSizePaper = Repository.ModelSizePapers.Where(mt => mt.ModelID == modelId);
                    Repository.RemoveModelSizePaper(modelSizePaper);
                    Repository.CreateModelSizePaper(modelView.ChosenSizePaperIds, modelId);

                    var modelPaperType = Repository.ModelPaperTypes.Where(mt => mt.ModelID == modelId);
                    Repository.RemoveModelPaperType(modelPaperType);
                    Repository.CreateModelPaperType(modelView.ChosenPaperTypeIds, modelId);

                    return RedirectToAction("Index");
                }

                return View(modelView);
            }


            [HttpGet]
            public ActionResult DeleteModel(int? id)
            {
                var model = Repository.Models.FirstOrDefault(p => p.ID == id);
                if (model != null)
                {
                    Repository.RemoveModel(model);
                }
                return RedirectToAction("Index");
            }

        }
        
    }

