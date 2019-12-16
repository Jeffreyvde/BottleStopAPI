using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class MachineAvailability
    {
        public int AvailableBeverageId { get; set; }
        public string MachineId { get; set; }
        public int BeverageId { get; set; }
        public int PumpId { get; set; }
        public int ContainerSize { get; set; }

        public virtual Beverage Beverage { get; set; }
        public virtual Machine Machine { get; set; }
        public virtual Pump Pump { get; set; }
    }
}
