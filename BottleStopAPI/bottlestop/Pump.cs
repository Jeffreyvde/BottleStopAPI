using System;
using System.Collections.Generic;

namespace BottleStopAPI.bottlestop
{
    public partial class Pump
    {
        public Pump()
        {
            MachinePump = new HashSet<MachinePump>();
            PumpPin = new HashSet<PumpPin>();
        }

        public int PumpId { get; set; }
        public string PumpName { get; set; }
        public string PumpType { get; set; }

        public virtual ICollection<MachinePump> MachinePump { get; set; }
        public virtual ICollection<PumpPin> PumpPin { get; set; }
    }
}
