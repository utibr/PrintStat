using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrintStat.Models.ViewModels
{
    public class ModelView : BaseView
    {
        public int ManufacturerID { get; set; }
        public int DeviceTypeID { get; set; }
        public int PrintKindID { get; set; }
        
        private List<Consumable>_Consumables = new List<Consumable>();

        public List<Consumable> Consumables
        {
            get { return _Consumables;}
            set { _Consumables = value; }
        }
        public int[] ChosenConsIds { get; set; }


        private List<Tag> _Tags = new List<Tag>();
        public List<Tag> Tags
        {
            get { return _Tags; }
            set { _Tags = value; }
        }
        
        public int[] ChosenTagIds { get; set; }



        public int[] ChosenSizePaperIds { get; set; }

        private List<SizePaper> _SizePapers = new List<SizePaper>();
        public List<SizePaper> SizePapers
        {
            get { return _SizePapers; }
            set { _SizePapers = value; }
        }

        public int[] ChosenPaperTypeIds { get; set; }

        private List<PaperType> _PaperTypes = new List<PaperType>();// Ique
        public List<PaperType> PaperTypes
        {
            get { return _PaperTypes; }
            set { _PaperTypes = value; }
        }
    }
}
