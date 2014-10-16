using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PrintStat.Models
{
    public partial class SQLRepository : IRepository 
    {
        
        [Display (Name = "Типоразмер бумаги")]
        public IQueryable<PaperType> PaperTypes
        {
            get
            {
                return Db.PaperType;
            }
        }

        public IQueryable<PaperType> PrinterPaperTypes 
        { 
            get
            {
                //       return Db.PaperType.Where(p => p.DeviceTypeID == 2);
                return null;
            }
        }
        public IQueryable<PaperType> PlotterPaperTypes 
        {
            get
            {
                //     return Db.PaperType.Where(p => p.DeviceTypeID == 1);
                return null;
            }
        }

        public IQueryable<Department> Departments
        {
            get
            {
                return Db.Department;
            }
        }


        public bool CreatePapertype(PaperType instance)
        {

            Db.PaperType.InsertOnSubmit(instance);
            Db.PaperType.Context.SubmitChanges();
            return true;
        }

        public bool UpdatePapertype(PaperType instance)
        {
            
            Db.PaperType.Context.SubmitChanges();
            return true;
        }

        public bool RemovePapertype(PaperType instance)
        {
            Db.PaperType.DeleteOnSubmit(instance);
            Db.PaperType.Context.SubmitChanges();
            return true;
        }


        [Display(Name = "Типы устройств")]
        public IQueryable<DeviceType> DeviceTypes
        {

            get
            {
                return Db.DeviceType;            
            }
        }



        public bool CreateDevicetype(DeviceType instance)
        {
            Db.DeviceType.InsertOnSubmit(instance);
            Db.DeviceType.Context.SubmitChanges();
            return true;
        }
        
        public bool UpdateDevicetype(DeviceType instance)
        {
            Db.DeviceType.Context.SubmitChanges();
            return true;
        }

        public bool RemoveDevicetype(DeviceType instance)
        {
            Db.DeviceType.DeleteOnSubmit(instance);
            Db.DeviceType.Context.SubmitChanges();
            return true;
        }

        [Display(Name = "Приложения")]
        public IQueryable<Application> Applications
        {

            get
            {
                return Db.Application;
            }
        }


        [Display(Name = "Сотрудники-авторы")]
        public IQueryable<Employee> AuthorEmployees
        {
            get
            {
                return Db.Employee.Where(p => p.DepartmentID != 2);
            }
        }

        [Display(Name = "Сотрудники-пользователи")]
        public IQueryable<Employee> UserEmployees
        {
            get
            {
                return Db.Employee.Where(p => p.DepartmentID == 2);
            }
        }


        public IQueryable<PrintKind> PrintKinds
        {
            get
            {
                return Db.PrintKind;
            }
        }


        //public IQueryable<Setup> Setup
        //{
        //    get
        //    {
        //        return Db.Setup;
        //    }
        //}

        //public bool SaveSettings(Setup settings)
        //{

        //    var s = Db.Setup.FirstOrDefault();
        //    if (s != null)
        //    {
        //        s.AccountName = settings.AccountName;
        //        s.MailServer = settings.MailServer;
        //        s.Pwd = settings.Pwd;
        //        s.Employee = Db.Employee.FirstOrDefault(p => p.TabNumber == "1190");
        //        s.Port = settings.Port;
        //    }
        //    else
        //    {
        //        settings.Employee = Db.Employee.FirstOrDefault(p => p.TabNumber == "1190");
        //        Db.Setup.InsertOnSubmit(settings);
        //    }

        //    Db.Setup.Context.SubmitChanges();
        //    return true;
        //}
    }
}