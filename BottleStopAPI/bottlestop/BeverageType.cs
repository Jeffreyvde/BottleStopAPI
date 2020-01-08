using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class BeverageType
    {
        public BeverageType()
        {
            Beverage = new HashSet<Beverage>();
        }

        public int BeverageTypeId { get; set; }
        public string BeverageType1 { get; set; }
        public string TypeImage { get; set; }

        public virtual ICollection<Beverage> Beverage { get; set; }
    }
}
