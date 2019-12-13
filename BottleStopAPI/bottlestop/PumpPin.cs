using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class PumpPin
    {
        public int PumpPinId { get; set; }
        public int PumpId { get; set; }
        public int PinId { get; set; }

        public virtual Pin Pin { get; set; }
        public virtual Pump Pump { get; set; }
    }
}
