using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintStat.Models
{
    public interface IRepository
    {
        IQueryable<Device> PrintersAndPlotters { get;  }
        IQueryable<Device> Printers { get; }
        IQueryable<Device> Plotters { get; }

        //Добавление 
        IQueryable<SizePaper> SizePapers { get; }
        IQueryable<CartridgeColor> CartridgeColors { get;}

        IQueryable<PaperType> PaperTypes { get;  }
        IQueryable<PaperType> PrinterPaperTypes { get;  }
        IQueryable<PaperType> PlotterPaperTypes { get; }
        
        IQueryable<DeviceType> DeviceTypes { get;  }

        IQueryable<PrintKind> PrintKinds { get;  }
        IQueryable<Job> Jobs { get;  }


        IQueryable<Employee> AuthorEmployees { get;  }
        IQueryable<Employee> UserEmployees { get; }

       // IQueryable<Setup> Setup { get; }


        #region Employee

        IQueryable<Employee> Employees { get; }

        bool CreateEmployee(Employee instance);

        bool UpdateEmployee(Employee instance);

        bool RemoveEmployee(Employee instance);

        #endregion 
        

        #region Application

        IQueryable<Application> Applications { get; }

        bool CreateApplication(Application instance);

        bool UpdateApplication(Application instance);

        bool RemoveApplication(Application instance);

        #endregion 
        

        #region Department

        IQueryable<Department> Departments { get; }

        bool CreateDepartment(Department instance);

        bool UpdateDepartment(Department instance);

        bool RemoveDepartment(Department instance);

        #endregion 
        

        bool CreatePrinter(Device instance);
        bool UpdatePrinter(Device instance);
        bool RemovePrinter(Device instance);


        bool CreatePapertype(PaperType instance);
        bool UpdatePapertype(PaperType instance);

        bool RemovePapertype(PaperType instance);

        // SizePaper
        bool CreateSizePaper(SizePaper instance);
        bool UpdateSizePaper(SizePaper instance);
        bool RemoveSizePaper(SizePaper instance);
        //PrintKind
        bool CreatePrintKind(PrintKind instance);
        bool UpdatePrintKind(PrintKind instance);
        bool RemovePrintKind(PrintKind instance);

        //CartridgeColor
        bool CreateCartridgeColor(CartridgeColor instance);
        bool UpdateCartridgeColor(CartridgeColor instance);
        bool RemoveCartridgeColor(CartridgeColor instance);

        bool CreateDevicetype(DeviceType instance);
        bool UpdateDevicetype(DeviceType instance);

        bool RemoveDevicetype(DeviceType instance);

        bool CreateJob(Job instance);
        bool UpdateJob(Job instance);
        bool RemoveJob(Job instance);

       // bool SaveSettings(Setup settings);
        


    }
}
