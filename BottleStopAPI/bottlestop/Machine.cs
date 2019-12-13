using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class Machine
    {
        public Machine()
        {
            AvailableBeverage = new HashSet<AvailableBeverage>();
            MachinePump = new HashSet<MachinePump>();
        }

        public int MachineId { get; set; }
        public int? GpsCoordiantesId { get; set; }
        public int? FilledAmount { get; set; }
        public string ModelName { get; set; }

        public virtual GpsCoordinates GpsCoordiantes { get; set; }
        public virtual ICollection<AvailableBeverage> AvailableBeverage { get; set; }
        public virtual ICollection<MachinePump> MachinePump { get; set; }
    }
}
