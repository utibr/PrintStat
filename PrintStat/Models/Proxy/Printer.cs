using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintStat
{

    public partial class Printer: IBaseObject
    {

        public override string ToString()
        {
            return Name;
        }
    }
}