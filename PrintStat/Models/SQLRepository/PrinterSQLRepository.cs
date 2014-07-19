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
        public PrinterStatDataContext Db {get; set;}

        public IQueryable<Printer> PrintersAndPlotters
        {
            get
            {
                return Db.Printer;
            }
        }

        public IQueryable<Printer> Printers
        {
            get 
            {
                return Db.Printer.Where(p => p.DeviceTypeID == 2);
            }
        }

        public IQueryable<Printer> Plotters
        {
            get
            {
                return Db.Printer.Where(p => p.DeviceTypeID == 1);
            }
        }

        public bool CreatePrinter(Printer instance)
        {
             Db.Printer.InsertOnSubmit(instance);
             Db.Printer.Context.SubmitChanges();
             return true;
         }

        public bool UpdatePrinter(Printer instance)
        {
            Printer updating = Db.Printer.FirstOrDefault(p => p.ID == instance.ID);
            if (updating != null)
            {
                updating.Name = instance.Name;
                Db.Printer.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemovePrinter(Printer instance)
        {
            Printer deleting = Db.Printer.FirstOrDefault(p=>p.ID == instance.ID);
            if (deleting != null)
            {
                Db.Printer.DeleteOnSubmit(deleting);
                Db.Printer.Context.SubmitChanges();
                return true;
            }

            return false;
        }

    }
}