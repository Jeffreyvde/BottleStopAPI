using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class MachinePump
    {
        public int MachinePumpId { get; set; }
        public int MachineId { get; set; }
        public int PumpId { get; set; }

        public virtual Machine Machine { get; set; }
        public virtual Pump Pump { get; set; }
    }
}
