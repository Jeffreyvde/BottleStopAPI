﻿using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class Pin
    {
        public Pin()
        {
            PumpPin = new HashSet<PumpPin>();
        }

        public int PinId { get; set; }
        public string PinMode { get; set; }
        public string PinNumber { get; set; }
        public string PinName { get; set; }

        public virtual ICollection<PumpPin> PumpPin { get; set; }
    }
}
