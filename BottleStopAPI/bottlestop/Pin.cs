using System;
using System.Collections.Generic;

namespace BottleStopAPI.bottlestop
{
    public partial class Pin
    {
        public Pin()
        {
            PumpPin = new HashSet<PumpPin>();
        }

        public int PinId { get; set; }
        public int PinModeId { get; set; }
        public int PinNumber { get; set; }
        public string PinName { get; set; }

        public virtual PinMode PinMode { get; set; }
        public virtual ICollection<PumpPin> PumpPin { get; set; }
    }
}
