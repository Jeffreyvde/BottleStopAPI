using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class UserBottle
    {
        public int UserBottleId { get; set; }
        public int UserId { get; set; }
        public string BottleId { get; set; }

        public virtual Bottle Bottle { get; set; }
        public virtual User User { get; set; }
    }
}
