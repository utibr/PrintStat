using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Data.Linq;


namespace PrintStat.Models
{
    public partial class SQLRepository: IRepository 
    {
        [Inject]
        public PrintStatDataDataContext Db {get; set;}

        public IQueryable<Device> PrintersAndPlotters
        {
            get
            {
                return Db.Device;
            }
        }

        //public IQueryable<Device> Printers
        //{
        //    get 
        //    {
        //        return Db.Device.Where(p => p.DeviceTypeID == 2);
        //    }
        //}

        //public IQueryable<Device> Plotters
        //{
        //    get
        //    {
        //        return Db.Device.Where(p => p.DeviceTypeID == 1);
        //    }
        //}

        public bool CreatePrinter(Device instance)
        {
             Db.Device.InsertOnSubmit(instance);
             Db.Device.Context.SubmitChanges();
             return true;
         }

        public bool UpdatePrinter(Device instance)
        {
            Device updating = Db.Device.FirstOrDefault(p => p.ID == instance.ID);
            if (updating != null)
            {
                updating.Name = instance.Name;
                Db.Device.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemovePrinter(Device instance)
        {
            Device deleting = Db.Device.FirstOrDefault(p=>p.ID == instance.ID);
            if (deleting != null)
            {
                Db.Device.DeleteOnSubmit(deleting);
                Db.Device.Context.SubmitChanges();
                return true;
            }

            return false;
        }

    }
}