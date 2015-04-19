using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrintStat.Models.ViewModels;

namespace PrintStat.Controllers
{
    public class ProfileController : BaseController
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            var profiles = Repository.Profiles.ToList();
            return View(profiles);
        }

        [HttpGet]
        public ActionResult CreateProfile()
        {
            var newProfileView = new ProfileView();
            return View(newProfileView);
        }

        [HttpGet]
        public ActionResult DeleteProfile(Profile instance)
        {
            
            if (instance != null)
            {
                Repository.RemoveProfile(instance);
            }
            return RedirectToAction("Index");
        }
    }
}
