using System;
using System.Collections.Generic;

namespace BottleStopAPI.bottlestop
{
    public partial class Bottle
    {
        public Bottle()
        {
            BottleModel = new HashSet<BottleModel>();
            UserBottle = new HashSet<UserBottle>();
        }

        public int BottleId { get; set; }
        public string SerialCode { get; set; }
        public string RfidCode { get; set; }

        public virtual ICollection<BottleModel> BottleModel { get; set; }
        public virtual ICollection<UserBottle> UserBottle { get; set; }
    }
}
