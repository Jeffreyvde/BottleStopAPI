using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class PinMode
    {
        public PinMode()
        {
            Pin = new HashSet<Pin>();
        }

        public int PinModeId { get; set; }
        public string PinMode1 { get; set; }

        public virtual ICollection<Pin> Pin { get; set; }
    }
}
