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

        public IQueryable<Device> Printers
        {
            get
            {
                return Db.Model.Join(Db.DeviceType.Where(dt => (dt.Name == "Принтер" || dt.Name == "принтер")),
                                    m => m.DeviceTypeID,
                                    dt => dt.ID,
                                    (m, dt) => m).Join(Db.Device,
                                                        d => d.ID,
                                                        dt => dt.ModelID,
                                                        (d, dt) => dt);

            }
        }

        public IQueryable<Device> Plotters
        {
            get
            {

                return Db.Model.Join(Db.DeviceType.Where(dt => (dt.Name=="Плоттер" || dt.Name=="плоттер")),
                                    m => m.DeviceTypeID,
                                    dt => dt.ID,
                                    (m, dt) => m).Join(Db.Device,
                                                        m => m.ID,
                                                        d => d.ModelID,
                                                        (m, d) => d);
            }
        }

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


        #region Model

        public IQueryable<Model> Models
        {
            get
            {
                return Db.Model;
            }
        }

        public bool CreateModel(Model instance)
        {
            if (instance.ID == 0)
            {
                Db.Model.InsertOnSubmit(instance);
                Db.Model.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateModel(Model instance)
        {
            Model cache = Db.Model.Where(p => p.ID == instance.ID).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for Model
                Db.Model.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveModel(Model instance)
        {
            
            if (instance != null)
            {
                Db.Model.DeleteOnSubmit(instance);
                Db.Model.Context.SubmitChanges();
                return true;
            }

            return false;
        }
        
        #endregion
    }
}