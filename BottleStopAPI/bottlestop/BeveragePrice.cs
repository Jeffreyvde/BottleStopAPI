using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class BeveragePrice
    {
        public int BeveragePriceId { get; set; }
        public string MachineId { get; set; }
        public int BeverageId { get; set; }
        public float CostPerMl { get; set; }

        public virtual Beverage Beverage { get; set; }
        public virtual Machine Machine { get; set; }
    }
}
