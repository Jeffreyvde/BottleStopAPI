using System;
using System.Collections.Generic;

namespace BottleStopAPI.bottlestop
{
    public partial class AvailableBeverage
    {
        public int AvailableBeverageId { get; set; }
        public int MachineId { get; set; }
        public int BeverageId { get; set; }

        public virtual Beverage Beverage { get; set; }
        public virtual Machine Machine { get; set; }
    }
}
