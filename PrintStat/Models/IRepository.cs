using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintStat.Models
{
    public interface IRepository
    {
        IQueryable<Printer> PrintersAndPlotters { get;  }
        IQueryable<Printer> Printers { get; }
        IQueryable<Printer> Plotters { get; }
        
        IQueryable<PaperType> PaperTypes { get;  }
        IQueryable<PaperType> PrinterPaperTypes { get;  }
        IQueryable<PaperType> PlotterPaperTypes { get; }
        
        IQueryable<DeviceType> DeviceTypes { get;  }

        IQueryable<PrintKind> PrintKinds { get;  }
        IQueryable<Job> Jobs { get;  }

        IQueryable<Application> Applications { get;  }
        IQueryable<Employee> AuthorEmployees { get;  }
        IQueryable<Employee> UserEmployees { get; }

        IQueryable<Setup> Setup { get; }

        IQueryable<Department> Departments { get; }


        bool CreatePrinter(Printer instance);
        bool UpdatePrinter(Printer instance);
        bool RemovePrinter(Printer instance);


        bool CreatePapertype(PaperType instance);
        bool UpdatePapertype(PaperType instance);

        bool RemovePapertype(PaperType instance);



        bool CreateDevicetype(DeviceType instance);
        bool UpdateDevicetype(DeviceType instance);

        bool RemoveDevicetype(DeviceType instance);

        bool CreateJob(Job instance);
        bool UpdateJob(Job instance);
        bool RemoveJob(Job instance);

        bool SaveSettings(Setup settings);
        


    }
}
