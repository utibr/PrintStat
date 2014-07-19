using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrintStat.Models.ViewModels;

namespace PrintStat.Controllers
{
    public class DeviceTypeController: BaseController
    {
        public ActionResult Index()
        {
            var devicetypes = Repository.DeviceTypes.ToList();
            return View(devicetypes);
        }


        [HttpGet]
        public ActionResult CreateDeviceType()
        {
            var newDeviceType = new DeviceTypeView();
            return View(newDeviceType);
        }


        [HttpPost]
        public ActionResult CreateDeviceType(DeviceTypeView  devicetypeView)
        {
            var anyDeviceType = Repository.DeviceTypes.Any(p => string.Compare(p.Name, devicetypeView.Name)==0);  
            if (anyDeviceType)
            {
                ModelState.AddModelError("Name", "Тип устройства с таким наименованием уже существует");
            }

            if (ModelState.IsValid) 
            {
                var deviceType = (DeviceType)ModelMapper.Map(devicetypeView, typeof(DeviceTypeView), typeof(DeviceType));
                Repository.CreateDevicetype(deviceType);
                return RedirectToAction("Index");
            }

            return View(devicetypeView);
        }


        [HttpGet]
        public ActionResult EditDeviceType(int? id)
        {
            var devicetype = Repository.DeviceTypes.FirstOrDefault(p => p.ID == id);
            if (devicetype != null)
            {
                var devicetypeView = (DeviceTypeView)ModelMapper.Map(devicetype, typeof(DeviceType), typeof(DeviceTypeView));
                return View(devicetypeView);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditDeviceType(DeviceTypeView devicetypeView)
        {
            if (ModelState.IsValid)
            {
                var deviceType = Repository.DeviceTypes.FirstOrDefault(p => p.ID == devicetypeView.ID);
                ModelMapper.Map(devicetypeView, deviceType, typeof(DeviceTypeView), typeof(DeviceType));
                Repository.UpdateDevicetype(deviceType);

                return RedirectToAction("Index");
            }

            return View(devicetypeView);
        }


        [HttpGet]
        public ActionResult DeleteDeviceType(int? id)
        {
            var devicetype = Repository.DeviceTypes.FirstOrDefault(p => p.ID == id);
            if (devicetype != null)
            {
                Repository.RemoveDevicetype(devicetype);
            }
            return RedirectToAction("Index");
        }
    }

}