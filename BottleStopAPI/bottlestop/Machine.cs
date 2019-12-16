using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class Machine
    {
        public Machine()
        {
            BeveragePrice = new HashSet<BeveragePrice>();
            MachineAvailability = new HashSet<MachineAvailability>();
        }

        public string MachineId { get; set; }
        public int? GpsCoordiantesId { get; set; }
        public int? FilledAmount { get; set; }
        public string ModelName { get; set; }

        public virtual GpsCoordinates GpsCoordiantes { get; set; }
        public virtual ICollection<BeveragePrice> BeveragePrice { get; set; }
        public virtual ICollection<MachineAvailability> MachineAvailability { get; set; }
    }
}
