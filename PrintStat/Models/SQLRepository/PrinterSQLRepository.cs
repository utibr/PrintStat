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


        #region ModelRelation
        public IQueryable<ModelTag> ModelTags
        {
            get
            {
                return Db.ModelTag;
            }
        }

        public IQueryable<SupportSize> ModelSizePapers
        {
            get
            {
                return Db.SupportSize;
            }
        }

        public IQueryable<ModelPaperType> ModelPaperTypes
        {
            get
            {
                return Db.ModelPaperType;
            }
        }


        public bool CreateModelTag(int[] ChosenTagIds, int idModel)
        {
            if (ChosenTagIds != null)
            {
                Db.ModelTag.InsertAllOnSubmit(
                    ChosenTagIds.Select(id =>
                        new ModelTag
                        {
                            TagID = id,
                            ModelID = idModel
                        })
                    );
                Db.ModelTag.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool CreateModelSizePaper(int[] ChosenSizePaperIds, int idModel)
        {
            if (ChosenSizePaperIds != null)
            {
                Db.SupportSize.InsertAllOnSubmit(
                    ChosenSizePaperIds.Select(id =>
                        new SupportSize
                        {
                            SizePaperID = id,
                            ModelID = idModel
                        })
                    );
                Db.SupportSize.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool CreateModelPaperType(int[] ChosenPaperTypeIds, int idModel)
        {
            if (ChosenPaperTypeIds != null)
            {
                Db.ModelPaperType.InsertAllOnSubmit(
                    ChosenPaperTypeIds.Select(id =>
                        new ModelPaperType
                        {
                            PaperTypeID = id,
                            ModelID = idModel
                        })
                    );
                Db.ModelPaperType.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveModelTag(IQueryable<ModelTag> instance)
        {

            if (instance != null)
            {
                Db.ModelTag.DeleteAllOnSubmit(instance);
                Db.ModelTag.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveModelSizePaper(IQueryable<SupportSize> instance)
        {

            if (instance != null)
            {
                Db.SupportSize.DeleteAllOnSubmit(instance);
                Db.ModelTag.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveModelPaperType(IQueryable<ModelPaperType> instance)
        {

            if (instance != null)
            {
                Db.ModelPaperType.DeleteAllOnSubmit(instance);
                Db.ModelTag.Context.SubmitChanges();
                return true;
            }
            return false;
        }
#endregion

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