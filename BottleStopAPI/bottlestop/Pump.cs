using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class Pump
    {
        public Pump()
        {
            MachineAvailability = new HashSet<MachineAvailability>();
            PumpPin = new HashSet<PumpPin>();
        }

        public int PumpId { get; set; }
        public string PumpName { get; set; }
        public string PumpType { get; set; }

        public virtual ICollection<MachineAvailability> MachineAvailability { get; set; }
        public virtual ICollection<PumpPin> PumpPin { get; set; }
    }
}
