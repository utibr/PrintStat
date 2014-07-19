using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintStat
{
    public partial class Application: IBaseObject
    {
        public override string ToString()
        {
            if (Name.Length < 12) return Name.Trim();
            return Name.Substring(0, 11).Trim();
        }
    }
}