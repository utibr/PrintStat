using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintStat
{
    public partial class Employee: IBaseObject
    {
        public int ID { get { return 0; } }
        public override string ToString()
        {
            return Name;
        }
    }
}